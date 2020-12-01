//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections;
using System.IO;
using Ncr.Core;
using Ncr.Core.Emulators;
using Ncr.Core.Net;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
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
	public class PlayScriptRequestDispatcherTests
	{
		PlayScriptRequestDispatcher dispatcher;
		SscatLane lane;
		LaneService service;
		SscatServer server;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			RegistryHelper.Attach(new RegistryManagerStub());
			DnsHelper.Attach(new DnsManagerStub());
			ProcessUtility.Attach(new ProcessManagerStub(true, false, "SMAttract"));
			ApiHelper.Attach(new ApiManagerStub());
			
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
			
			lane = new SscatLaneStub();
			lane.AddEmulator(new BagScale());
			lane.Configuration = service.ReadLaneConfiguration("");
			
			server = new SscatServerStub(new XmlRequestParser(), lane, new EasyServerEngine(30000, "SSCAT Server", new XmlRequestParser()));

			dispatcher = new PlayScriptRequestDispatcher(service);
			dispatcher.Dispatching += new EventHandler<NcrEventArgs>(DispatcherDispatching);
			dispatcher.LogHookInitialize += new EventHandler(DispatcherLogHookInitialize);
			dispatcher.ClientInitialize += new EventHandler(DispatcherClientInitialize);
			
			dispatcher.Server = server;
		}

		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			dispatcher.Dispatching -= new EventHandler<NcrEventArgs>(DispatcherDispatching);
			dispatcher.LogHookInitialize -= new EventHandler(DispatcherLogHookInitialize);
			dispatcher.ClientInitialize -= new EventHandler(DispatcherClientInitialize);
		}

		[Test]
		public void TestDispatch()
		{
			Request r = new Request(
				"",
				PlayerConfiguration.Deserialize(new StringReader(@"<Configuration SaveReportInServer='true' LoadConfiguration='true' LogHookTimeout='500'>
	<ScriptConfigs>
		<ScriptConfig>
			<Script>
				<scriptName>test</scriptName>
				<FileName>C:\SSCAT\Scripts\test.xml</FileName>
				<FingerEventData>
					<enable>true</enable>
					<eventTimeMS>942985140</eventTimeMS>
					<eventType>DeviceEventData</eventType>
					<DeviceEventData>
						<deviceId>BagScale</deviceId>
						<deviceValue>0</deviceValue>
						<seqId>17</seqId>
					</DeviceEventData>
				</FingerEventData>
			</Script>
			<Config Destination='C:\Projects\finger\trunk\ScotConfig\' Source='C:\scot\config'>
				<File Name='test.xml' Exists='true'>hello world</File>
				<File Name='test2.xml' Exists='true' Host='g2lane-ian'/>
			</Config>
		</ScriptConfig>
	</ScriptConfigs>
</Configuration>")));
			dispatcher.Dispatch(r);
		}

		void DispatcherClientInitialize(object sender, EventArgs e)
		{
			SscatClient client = new SscatClientStub(new XmlResponseParser(), new EasyClientEngine());
			client.AddDispatcher(new ConfigResponseDispatcher());
			client.AddDispatcher(new ConfigCheckedResponseDispatcher());
			client.AddDispatcher(new ConfigLoadedResponseDispatcher());
			client.DataSent += new EventHandler<NetworkEventArgs>(ClientDataSent);
			dispatcher.Client = client;
		}

		void ClientDataSent(object sender, NetworkEventArgs e)
		{
			Request request = Request.Deserialize(new StringReader(e.Message));
			if (request.Type == SscatRequest.CHECK_CONFIG) {
				ConfigFile f = new ConfigFile();
				f.DifferentFromScotConfig = true;
//				dispatcher.Client.ReceiveResponse(new Response(SscatResponse.ConfigChecked, f.Serialize()));
				dispatcher.Client.ReceiveResponse(new Response(SscatResponse.CONFIG_CHECKED, f));
			} else if (request.Type == SscatRequest.LOAD_CONFIG) {
//				dispatcher.Client.ReceiveResponse(new Response(SscatResponse.ConfigLoaded, ""));
				dispatcher.Client.ReceiveResponse(new Response(SscatResponse.CONFIG_LOADED, new MessageContent("")));
			}
		}

		void DispatcherLogHookInitialize(object sender, EventArgs e)
		{
			lane.Hooks = service.CreateHooks();
		}

		void DispatcherDispatching(object sender, NcrEventArgs e)
		{
			LoggingService.Info(e.Message);
		}
		
//		[Test]
//		public void TestDispatchWithSecurityServerError()
//		{
//			Request r = Request.Deserialize(new StringReader(@"<Request>
//	<Content>
		//<![CDATA[
		//<Configuration OverrideSecurityServer='true' SecurityServer='' LogHookTimeout='500'>
		//</Configuration>
		//]]>
//	</Content>
		//</Request>"));
//			dispatcher.Dispatch(r);
//			Assert.IsTrue(player.HasErrors);
//		}
//
//		[Test]
//		public void TestDispatchWithRapError()
//		{
//			Request r = Request.Deserialize(new StringReader(@"<Request>
//	<Content>
		//<![CDATA[
		//<Configuration OverrideRapName='true' RapName='' LogHookTimeout='500'>
		//</Configuration>
		//]]>
//	</Content>
		//</Request>"));
//			dispatcher.Dispatch(r);
//			Assert.IsTrue(player.HasErrors);
//		}
	}
}
