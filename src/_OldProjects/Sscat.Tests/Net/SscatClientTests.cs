//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Ncr.Core;
using Ncr.Core.Emulators;
using Ncr.Core.Models;
using Ncr.Core.Net;
using Ncr.Core.Tests.Models;
using Ncr.Core.Tests.Net;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Rhino.Mocks;
using Sscat.Core.Config;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Core.Net;
using Sscat.Core.Parsers;
using Sscat.Core.Repositories.IO;
using Sscat.Core.Repositories.Xml;
using Sscat.Core.Services;
using Sscat.Tests.Commands.Gui;
using Sscat.Tests.Commands.Psx;
using Sscat.Tests.Config;
using Sscat.Tests.Models;
using Sscat.Tests.Repositories;
using Sscat.Tests.Services;

namespace Sscat.Tests.Net
{
	[TestFixture]
	public class SscatClientTests
	{
		SscatClientStub client;
		SscatServerStub server;
		SscatLane lane;
		LaneService laneService;
		ClientService clientService;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			DnsHelper.Attach(new DnsManagerStub());
//			MessageService.Attach(new NoMessageProvider());
			MessageService.Attach(new ConsoleMessageProvider());
			RegistryHelper.Attach(new RegistryManagerStub());
			ProcessUtility.Attach(new ProcessManagerStub(true, false, "SMAttract"));
			ApiHelper.Attach(new ApiManagerStub());
//			ThreadHelper.Attach(new ThreadManagerStub());
			ThreadHelper.Attach(new T());
			ApplicationUtility.Attach(new ApplicationManagerStub());
			
			client = new SscatClientStub(new XmlResponseParser(), new ClientEngineStub());
			client.Configuration = new ClientConfigurationRepositoryStub().Read("");

			client.AddDispatcher(new ErrorResponseDispatcher());
			client.AddDispatcher(new MessageResponseDispatcher());
			client.AddDispatcher(new ScriptsResponseDispatcher(new ConfigFileRepositoryStub(), new ScriptRepositoryStub(), "localhost"));
			client.AddDispatcher(new ScriptEventResponseDispatcher());
			client.AddDispatcher(new ScriptResultResponseDispatcher());
			client.AddDispatcher(new ReportResponseDispatcher(new ReportRepositoryStub()));
			
			clientService = new ClientService(
				new ClientConfigurationRepositoryStub(), 
				new ConfigFilesRepositoryStub(), 
				new ConfigFileRepositoryStub(), 
				new ScriptRepositoryStub(), 
				null
			);
			
			SscatClient serverClient = new SscatClientStub(new XmlResponseParser(), new ClientEngineStub());
			lane = new SscatLane();
			lane.AddEmulator(new BagScale());
			lane.AddEmulator(new Scale());
			
			laneService = new LaneServiceStub(
				lane, 
				new ScriptRepositoryStub(), 
				new ConfigFileRepositoryStub(), 
				new ConfigFilesRepositoryStub(), 
				new PlayerConfigurationRepositoryStub(), 
				new GeneratorConfigurationRepositoryStub(), 
				new LaneConfigurationRepositoryStub(), 
				new ReportRepositoryStub(), 
				new PsxDisplayRepositoryStub(),
				null, 
				null
			);
			lane.Configuration = laneService.ReadLaneConfiguration("");
			
			server = new SscatServerStub(
				new XmlRequestParser(), 
				lane, 
				new ServerEngineStub(new XmlRequestParser())
			);
			server.AddDispatcher(new GenerateScriptsRequestDispatcher(serverClient, new ConfigFilesRepositoryStub()));
			server.AddDispatcher(new PlayScriptRequestDispatcher(laneService));
			server.AddDispatcher(new StopPlayerRequestDispatcher());
			
			server.Serving += new EventHandler<NcrEventArgs>(ServerServing);
			server.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(ServerConnectionAdding);
			server.LogHookInitialize += new EventHandler(ServerLogHookInitialize);
			server.ParserInitialize += new EventHandler(ServerParserInitialize);

			client.DataSent += new EventHandler<NetworkEventArgs>(ClientDataSent);
			client.PlayerConfigurationPrepare += new EventHandler<PlayerConfigurationEventArgs>(ClientPlayerConfigurationPrepare);

			server.DataSent += new EventHandler<NetworkEventArgs>(ServerDataSent);
		}
		
		[OneTimeTearDown]
		public void TearDown()
		{
			client.Disconnect();
			
			server.Serving -= new EventHandler<NcrEventArgs>(ServerServing);
			server.ConnectionAdding -= new EventHandler<PsxWrapperEventArgs>(ServerConnectionAdding);
			server.LogHookInitialize -= new EventHandler(ServerLogHookInitialize);
			server.ParserInitialize -= new EventHandler(ServerParserInitialize);
			client.DataSent -= new EventHandler<NetworkEventArgs>(ClientDataSent);
			client.PlayerConfigurationPrepare -= new EventHandler<PlayerConfigurationEventArgs>(ClientPlayerConfigurationPrepare);
			server.DataSent -= new EventHandler<NetworkEventArgs>(ServerDataSent);
		}
		
		[Test]
//		[Ignore()]
		public void TestGenerateWithNullConfiguration()
		{
//			client.Configuration = null;
			GeneratorConfiguration c = GeneratorConfiguration.Deserialize(new StringReader(@"<Configuration/>"));
			client.Generate(c);
//			Assert.AreEqual(1, client.Errors.Count);
			Assert.AreEqual(2, c.Errors.Count);
		}
		
		[Test]
//		[Ignore()]
		public void TestGenerate()
		{
//			client.Generate(new GeneratorConfiguration("test", "", "", true, @"C:\sscat\scripts", @"C:\sscat\scotconfig"));
			GeneratorConfiguration c = GeneratorConfiguration.Deserialize(new StringReader(@"<Configuration ScriptName='test' ScriptOutputDirectory='C:\sscat\scripts'/>"));
			client.Generate(c);
		}
		
		[Test]
//		[Ignore("Script configuration is still not in the instance, make it so that the passed config is the client's generator configuration.")]
		public void TestGenerateWithNoFileName()
		{
			GeneratorConfiguration c = GeneratorConfiguration.Deserialize(new StringReader(@"<Configuration/>"));
			client.Generate(c);
//			Assert.AreEqual(1, client.Configuration.GeneratorConfiguration.Errors.Count);
			Assert.AreEqual(2, c.Errors.Count);
		}
		
		[Test]
		public void TestInvalidServerName()
		{
			client.Validate();
			Assert.IsTrue(client.HasErrors);
		}
		
		[Test]
		public void TestStop()
		{
			client.Stop();
		}
		
		[Test]
//		[Ignore()]
		public void TestPlay()
		{
			DnsHelper.Attach(new DA());
			ScriptFile[] scripts = new ScriptFile[] { new ScriptFile(@"C:\sscat\scripts\test_0.xml"), new ScriptFile(@"C:\sscat\scripts\test_1.xml") };
			client.Play(new List<ScriptFile>(scripts));
		}

		void ClientPlayerConfigurationPrepare(object sender, PlayerConfigurationEventArgs e)
		{
			clientService.PreparePlayerConfiguration(e.Config, e.Script);
		}

		void ServerParserInitialize(object sender, EventArgs e)
		{
			lane.Parsers = laneService.CreateParsers();
		}
		
		void ServerDataSent(object sender, NetworkEventArgs e)
		{
//			client.ReceiveResponse(e.Message);
			client.ReceiveResponse(e.Response);
		}

		void ClientDataSent(object sender, NetworkEventArgs e)
		{
//			server.ReceiveRequest(e.Message);
			server.ReceiveRequest(e.Request);
		}

		void ServerLogHookInitialize(object sender, EventArgs e)
		{
			lane.Hooks = laneService.CreateHooks();
		}

		void ServerConnectionAdding(object sender, PsxWrapperEventArgs e)
		{
			lane.PsxConnections.Add(new PsxStub(e.HostName, e.ServiceName, e.ConnectionName, e.Timeout));
		}

		void ServerServing(object sender, NcrEventArgs e)
		{
//			Console.WriteLine("{0}: {1}",  DateTimeUtility.Now(), e.Message);
		}
		
		class DA : DnsManagerStub
		{
			public override bool ValidHostName(string host)
			{
				return true;
			}
		}
		
		class T : ThreadManagerStub
		{
			public override void Start(System.Threading.ThreadStart d)
			{
			}
		}
	}
}
