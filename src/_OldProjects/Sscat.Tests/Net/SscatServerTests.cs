//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core;
using Ncr.Core.Models;
using Ncr.Core.Net;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Emulators;
using Sscat.Core.Finger;
using Sscat.Core.Models;
using Sscat.Core.Net;
using Sscat.Core.Parsers;
using Sscat.Core.Services;
using Sscat.Tests.Commands.Gui;
using Sscat.Tests.Commands.Psx;
using Sscat.Tests.Config;
using Sscat.Tests.Emulators;
using Sscat.Tests.Models;
using Sscat.Tests.Repositories;
using Sscat.Tests.Services;

namespace Sscat.Tests.Net
{
	[TestFixture]
	public class SscatServerTests
	{
		SscatServer server;
		SscatLane lane;
		LaneService service;
		
		[SetUp]
		public void Setup()
		{
			MessageService.Attach(new NoMessageProvider());
			DnsHelper.Attach(new DnsManagerStub());
			ThreadHelper.Attach(new ThreadManagerStub());
			ProcessUtility.Attach(new ProcessManagerStub(true, false, "SMAttract"));
			ApiHelper.Attach(new ApiManagerStub());
			
			lane = new SscatLaneStub();
			
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
			
			server = new SscatServerStub(new XmlRequestParser(), lane, new EasyServerEngine(30000, "SSCAT Server", new XmlRequestParser()));
			server.Serving += new EventHandler<NcrEventArgs>(ServerServing);
			server.LogHookInitialize += new EventHandler(ServerLogHookInitialize);
			server.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(ServerConnectionAdding);
			
			server.AddDispatcher(new PlayScriptRequestDispatcher(service));
		}
		
		[Test]
//		[Ignore()]
		public void TestPlay()
		{
//			Request r = Request.Deserialize(new StringReader(@"<Request Type='PLAY_SCRIPT'>
//	<Content>
//<![CDATA[
//<Configuration LogHookTimeout='100' LoadConfiguration='true' SaveReportInServer='true'>
//	<ScriptConfigs>
//		<ScriptConfig>
//			<Config Destination='C:\scot\config'>
//				<File Name='test.xml'>holy sh*t</File>
//			</Config>
//			<Script>
//				<FingerEventData>
//					<enable>true</enable>
//					<eventTimeMS>942962708</eventTimeMS>
//					<eventType>PsxEventData</eventType>
//					<PsxEventData>
//						<contextName>Attract</contextName>
//						<controlName>Display</controlName>
//						<eventName>ChangeContext</eventName>
//						<param />
//						<psxId>1</psxId>
//						<remoteConnectionName />
//						<seqId>1</seqId>
//					</PsxEventData>
//				</FingerEventData>
//			</Script>
//		</ScriptConfig>
//	</ScriptConfigs>
//</Configuration>
//]]>
//	</Content>
//</Request>"));
PlayerConfiguration pc = new PlayerConfiguration();
pc.LogHookTimeout = 100;
FingerScript s = new FingerScript("test", "", "", "", new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));
ConfigFiles cf = new ConfigFiles(@"C:\scot\config");
ConfigFile f = new ConfigFile("test.xml", "");
f.Content = "hello world";
cf.AddFile(f);
pc.ScriptConfigs.AddConfig(new ScriptConfig(s, cf));
Request r = new Request("PLAY_SCRIPT", pc);
			server.ReceiveRequest(r);
		}
		
		[Test]
//		[Ignore()]
		public void TestUnsupportedDispatcher()
		{
            //Request r = Request.Deserialize(new StringReader(@"<Request Type='Hello'>
            //<Content>Hello, World!</Content>
            //</Request>"));
            Request r = new Request("Hello", new MessageContent("Hello, world!"));
			server.ReceiveRequest(r);
		}

		void ServerConnectionAdding(object sender, PsxWrapperEventArgs e)
		{
			lane.PsxConnections.Add(service.CreatePsx(e.HostName, e.ServiceName, e.ConnectionName, e.Timeout));
		}

		void ServerLogHookInitialize(object sender, EventArgs e)
		{
			lane.Hooks = service.CreateHooks();
		}

		void ServerServing(object sender, NcrEventArgs e)
		{
			LoggingService.Info(e.Message);
		}
	}
	
	public class SscatServerStub : SscatServer
	{
		public SscatServerStub(IRequestParser requestParser, SscatLane lane, IServerEngine engine) : this(1337, requestParser, lane, engine)
		{
		}
		
		public SscatServerStub(int port, IRequestParser requestParser, SscatLane lane, IServerEngine engine) : base(port, requestParser, lane, engine)
		{
		}
		
		public override void Listen()
		{
			OnStarting(null);
			OnServing("SSCAT server is starting");
			OnServing(string.Format("Listening connections on port {0}", Port));
		}
		
		public override void Stop()
		{
			OnStopping(null);
			OnServing("SSCAT server is stopping");
		}
		
		public override void SendResponse(Response response)
		{
			OnDataSent(new NetworkEventArgs(response.Serialize()));
		}
	}
}
