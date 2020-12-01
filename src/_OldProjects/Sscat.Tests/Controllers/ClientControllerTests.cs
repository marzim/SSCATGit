//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.IO;
using Ncr.Core.Net;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Rhino.Mocks;
using Sscat.Core.Config;
using Sscat.Core.Controllers;
using Sscat.Core.Finger;
using Sscat.Core.Models;
using Sscat.Core.Net;
using Sscat.Core.Repositories;
using Sscat.Core.Services;
using Sscat.Core.Views;
using Sscat.Gui;
using Sscat.Tests.Config;
using Sscat.Tests.Models;
using Sscat.Tests.Net;
using Sscat.Tests.Repositories;
using Sscat.Views;

namespace Sscat.Tests.Controllers
{
	public class ClientServiceStub : ClientService
	{
		public ClientServiceStub(IClientConfigurationRepository clientConfigRepository, IConfigFilesRepository configFilesRepository, IConfigFileRepository configFileRepository, IScriptRepository scriptRepository, CpuAndMemoryLogger logger)
			: base(clientConfigRepository, configFilesRepository, configFileRepository, scriptRepository, logger)
		{
		}
		
		public override void StartLogger()
		{
		}
		
		public override void StopLogger()
		{
		}
	}
	
	[TestFixture]
	public class ClientControllerTests
	{
		SscatClientStub client;
		ClientController controller;
		IClientView clientView;
		IPlayerView playerView;
		IClientConfigurationView clientConfigView;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApplicationUtility.Attach(new ApplicationManagerStub());
//			MessageService.Attach(new ConsoleMessageProvider());
			MessageService.Attach(new NoMessageProvider());
			DnsHelper.Attach(new DnsManagerStub());
			ThreadHelper.Attach(new ThreadManagerStub());
			
			client = new SscatClientStub(new XmlResponseParser(), new EasyClientEngine());
			
			client.AddDispatcher(new ErrorResponseDispatcher());
			
			client.AddDispatcher(new ScriptsResponseDispatcher(new ConfigFileRepositoryStub(), new ScriptRepositoryStub(), "localhost"));

			client.AddDispatcher(new ScriptEventResponseDispatcher());
			client.AddDispatcher(new ScriptResultResponseDispatcher());
			client.AddDispatcher(new ReportResponseDispatcher(new ReportRepositoryStub()));
			
			playerView = new ConsolePlayerView();
			clientConfigView = new ClientConfigurationPane();
			clientView = new ClientPane(new GeneratorPane(), playerView, clientConfigView);
			
			ClientServiceStub service = new ClientServiceStub(
				new ClientConfigurationRepositoryStub(), 
				new ConfigFilesRepositoryStub(), 
				new ConfigFileRepositoryStub(), 
				new ScriptRepositoryStub(), 
				new CpuAndMemoryLogger(200, new Log4NetLogger(), "Sscat.WinForms")
			);
			controller = new ClientController(client, service, clientView);
			controller.ClientConnected += new EventHandler<NetworkEventArgs>(ControllerClientConnected);
			controller.ClientDisconnected += new EventHandler<NetworkEventArgs>(ControllerClientDisconnected);
			controller.ClientTimeout += new EventHandler<NetworkEventArgs>(ControllerClientTimeout);
			controller.ScriptFileNameCheck += new EventHandler<GeneratorConfigurationEventArgs>(ControllerScriptFileNameCheck);
			controller.ClientRejecting += new EventHandler(ControllerClientRejecting);
			
			client.Connect();
		}
		
		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			client.Disconnect();
			controller.ClientConnected -= new EventHandler<NetworkEventArgs>(ControllerClientConnected);
			controller.ClientDisconnected -= new EventHandler<NetworkEventArgs>(ControllerClientDisconnected);
			controller.ClientTimeout -= new EventHandler<NetworkEventArgs>(ControllerClientTimeout);
			controller.ScriptFileNameCheck -= new EventHandler<GeneratorConfigurationEventArgs>(ControllerScriptFileNameCheck);
			controller.ClientRejecting -= new EventHandler(ControllerClientRejecting);
		}
		
		[Test]
		public void TestIndex()
		{
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(IClientView), controller.Index());
		}
		
		[Test]
		public void TestStop()
		{
//			client.ReceiveResponse(new Response(SscatResponse.Error, ""));
			client.ReceiveResponse(new Response(SscatResponse.ERROR, new MessageContent("")));
		}
		
		[Test]
		public void TestScriptResultDispatched()
		{
//			client.ReceiveResponse(new Response(SscatResponse.ScriptResult, new FingerScript().Serialize()));
			client.ReceiveResponse(new Response(SscatResponse.SCRIPT_RESULT, new FingerScript()));
		}
		
		[Test]
		public void TestEventResultDispatched()
		{
//			client.ReceiveResponse(new Response(SscatResponse.EventResult, new ScriptEvent().Serialize()));
			client.ReceiveResponse(new Response(SscatResponse.EVENT_RESULT, new ScriptEvent()));
		}
		
		[Test]
		public void TestGenerate()
		{
			IClientView view = controller.Index() as IClientView;
			client.Configuration.GeneratorConfiguration.ScriptName = "test";
			
			client.DataSent += delegate(object sender, NetworkEventArgs e) { 
				GeneratorConfiguration config = new GeneratorConfigurationRepositoryStub().Read("");
				foreach (ConfigFile file in config.Files.Files) {
					file.Destination = config.Files.DestinationDirectory;
				}
//				client.ReceiveResponse(new Response(SscatResponse.Scripts, config.Serialize()));
				client.ReceiveResponse(new Response(SscatResponse.SCRIPTS, config));
			};
			
			clientView.PerformGenerate();
		}
		
		[Test]
		public void TestPlayerViewStop()
		{
			playerView.PerformStop();
		}
		
		[Test]
		public void TestConfigurationSave()
		{
			clientConfigView.Save();
		}
		
		[Test]
		public void TestConfigurationRestore()
		{
			clientConfigView.Restore();
		}
		
		[Test]
		public void TestPlay()
		{
			DnsHelper.Attach(new DA());
			client.DataSent += delegate(object sender, NetworkEventArgs e) { 
//				client.ReceiveResponse(new Response(SscatResponse.Report, new Report().Serialize()));
				client.ReceiveResponse(new Response(SscatResponse.PLAYBACK, new Report()));
			};
			playerView.AddScript(new List<string>(new string[] { @"C:\Projects\finger\trunk\tests\test.xml" }));
//			playerView.AddScript(new List<string>(new string[] { @"C:\Projects\Finger\trunk\scripts\test_0.xml" }));
			playerView.PerformPlay();
		}
		
		[Test]
		public void TestConnectionTimeout()
		{
			client.PerformConnectionTimeOut();
		}
		
		[Test]
		public void TestConnectionRejected()
		{
			client.PerformRejected();
		}
		
		void ControllerClientRejecting(object sender, EventArgs e)
		{
		}

		void ControllerScriptFileNameCheck(object sender, GeneratorConfigurationEventArgs e)
		{
		}

		void ControllerClientTimeout(object sender, NetworkEventArgs e)
		{
		}

		void ControllerClientDisconnected(object sender, NetworkEventArgs e)
		{
		}

		void ControllerClientConnected(object sender, NetworkEventArgs e)
		{
		}
		
		class DA : DnsManagerStub
		{
			public override bool ValidHostName(string host)
			{
				return true;
			}
		}
	}
}
