//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Commands;
using Ncr.Core.Emulators;
using Ncr.Core.Models;
using Ncr.Core.Net;
using Ncr.Core.Plugins;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using Ncr.Core.Views;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Emulators;
using Sscat.Core.Models;
using Sscat.Core.Net;
using Sscat.Core.Services;
using Sscat.Server;
using Sscat.Tests.Commands.Psx;
using Sscat.Tests.Config;
using Sscat.Tests.Models;
using Sscat.Tests.Net;
using Sscat.Tests.Repositories;
using Sscat.Tests.Services;

namespace Sscat.Tests
{
	[TestFixture]
	public class SscatServerStartUpTests
	{
		SscatServerStartUp startup;
		SscatServer server;
		LaneService service;
		SscatLane lane;
		
		[SetUp]
		public void Setup()
		{
			ApplicationUtility.Attach(new ApplicationManagerStub());
			ProcessUtility.Attach(new ProcessManager());
			FileHelper.Attach(new FileManagerStub());
			DirectoryHelper.Attach(new DirectoryManagerStub());
			ProcessUtility.Attach(new ProcessManagerStub(true, false, "SMAttract"));
			RegistryHelper.Attach(new RegistryManagerStub());
			ThreadHelper.Attach(new ThreadManagerStub());
			
			lane = new SscatLane();
			SscatContext.Lane = lane;
			
			server = new SscatServerStub(
				new XmlRequestParser(),
				lane,
				new EasyServerEngine(30000, "SSCAT Server", new XmlRequestParser())
			);
			server.AddDispatcher(new ChuckNorrisRequestDispatcher());
			
			service = new LaneServiceStub(
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
			
			startup = new SscatServerStartUp(
				new ApplicationManagerStub(),
				new DnsManagerStub(),
				new Log4NetLogger(), // TODO: Create a logger that displays nothing!
				new NoMessageProvider(),
				server,
				service,
				new PluginRepositoryStub()
			);
			
			FileHelper.Create(@"C:\scot\logs\psx_ScotAppU.log");
			FileHelper.Create(@"C:\scot\logs\psx_LaunchPadNet.log");
			FileHelper.Create(@"C:\scot\logs\traces.log");
			FileHelper.Create(@"C:\scot\logs\SM.log");
		}
		
		[Test]
		public void TestStart()
		{
			FileHelper.Attach(new FileManagerStub());
			ImageHelper.Attach(new ImageManagerStub());
			ProcessUtility.Attach(new ProcessManagerStub(false, false, "SMAttract"));
			startup.Start();
		}
		
		[Test]
		public void TestStartWithException()
		{
			server = new SscatServerStub(new XmlRequestParser(), new X(), new EasyServerEngine(30000, "SSCAT Server", new XmlRequestParser()));
			server.AddDispatcher(new ChuckNorrisRequestDispatcher());
			
			startup = new SscatServerStartUp(
				new ApplicationManagerStub(),
				new DnsManagerStub(),
				new Log4NetLogger(),
				new ConsoleMessageProvider(),
				server,
				service,
				new PluginRepositoryStub()
			);
			
			ProcessUtility.Attach(new ProcessManagerStub());
			LoggingService.DetachAll();
			startup.Start();
		}
		
		[Test]
		public void TestWithClientInitialize()
		{
			server = new Y(
				new SscatLane(), 
				new EasyServerEngine(30000, "SSCAT Server", new XmlRequestParser())
			);
			server.AddDispatcher(new Z());
			
			startup = new SscatServerStartUp(
				new ApplicationManagerStub(),
				new DnsManagerStub(),
				new Log4NetLogger(),
				new ConsoleMessageProvider(),
				server,
				service,
				new PluginRepositoryStub()
			);
			
			ProcessUtility.Attach(new ProcessManagerStub(true, false, "SMAttract"));
			startup.Start();
		}
		
		[Test]
		public void TestStartOnServerStarted()
		{
			ProcessUtility.Attach(new ProcessManagerStub(true));
			startup.Start();
		}
		
		class X : SscatLane
		{
			public override void AddEmulator(params IEmulator[] emulators)
			{
				throw new Exception();
			}
		}
		
		class Y : SscatServerStub
		{
			public Y(SscatLane lane, IServerEngine serverEngine) : base(new XmlRequestParser(), lane, serverEngine)
			{
			}
			
			public override void Listen()
			{
//				ReceiveRequest(new Request("Z", ""));
				ReceiveRequest(new Request("Z", new MessageContent("")));
			}
		}
		
		class Z : SscatRequestDispatcher
		{
			public Z() : base("Z")
			{
			}
			
			public override void Dispatch(Request request)
			{
				OnClientInitialize(null);
			}
		}
	}
}
