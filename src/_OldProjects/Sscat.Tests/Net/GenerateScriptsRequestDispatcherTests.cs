//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core;
using Ncr.Core.Net;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Rhino.Mocks;
using Sscat.Core.Config;
using Sscat.Core.Emulators;
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
	public class GenerateScriptsRequestDispatcherTests
	{
		GenerateScriptsRequestDispatcher dispatcher;
		SscatClient client;
		SscatServer server;
		LaneService service;
		SscatLane lane;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			RegistryHelper.Attach(new RegistryManagerStub());
			ApplicationUtility.Attach(new ApplicationManagerStub());
			DnsHelper.Attach(new DnsManagerStub());
			MessageService.Attach(new NoMessageProvider());
			ThreadHelper.Attach(new ThreadManagerStub());
			
			client = new SscatClientStub(new XmlResponseParser(), new EasyClientEngine());
			client.AddDispatcher(new MessageResponseDispatcher());
			client.AddDispatcher(new ConfigResponseDispatcher());
			
			lane = new SscatLane();

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
			
			lane.Configuration = service.ReadLaneConfiguration("");

			server = new SscatServerStub(new XmlRequestParser(), lane, new EasyServerEngine(30000, "SSCAT Server", new XmlRequestParser()));
			server.AddDispatcher(new GetConfigRequestDispatcher(new ConfigFileRepositoryStub()));

			dispatcher = new GenerateScriptsRequestDispatcher(client, new ConfigFilesRepositoryStub());
			dispatcher.Server = server;
			
			client.DataSent += new EventHandler<NetworkEventArgs>(ClientDataSent);
			server.DataSent += new EventHandler<NetworkEventArgs>(ServerDataSent);
			dispatcher.Dispatching += new EventHandler<NcrEventArgs>(DispatcherDispatching);
			dispatcher.ParserInitialize += new EventHandler(DispatcherParserInitialize);
		}
		
		[OneTimeTearDown]
		public void Teardown()
		{
			client.DataSent -= new EventHandler<NetworkEventArgs>(ClientDataSent);
			server.DataSent -= new EventHandler<NetworkEventArgs>(ServerDataSent);
			dispatcher.Dispatching -= new EventHandler<NcrEventArgs>(DispatcherDispatching);
			dispatcher.ParserInitialize -= new EventHandler(DispatcherParserInitialize);
		}
		
		[Test]
		public void TestValues()
		{
			Assert.AreEqual("GENERATE_SCRIPTS", dispatcher.Name);
		}
		
		[Test]
		public void TestDispatch()
		{
            //			Request r = Request.Deserialize(new StringReader(@"<Request>
            //	<Content>
			            //<![CDATA[
			            //<Configuration ScriptName='test' ScriptOutputDirectory='C:\SSCAT\Scripts'>
            //	<Files Destination='C:\scot\config' Source='C:\SSCAT\ScotConfig'>
            //		<File Name='test.xml'/>
            //		<File Name='test2.xml' Host='g2lane-ian'/>
            //	</Files>
			            //</Configuration>
			            //]]>
            //	</Content>
			            //</Request>"));
			GeneratorConfiguration c = new GeneratorConfiguration();
			c.ScriptName = "test";
			c.ScriptOutputDirectory = @"C:\sscat\scripts";
			c.ScriptOutputDirectory = @"C:\sscat\scripts";
			c.Files.DestinationDirectory = @"C:\scot\config";
			c.Files.AddFile(new ConfigFile("test.xml"));
			c.Files.AddFile(new ConfigFile("test2.xml", "g2lane-ian"));
			Request r = new Request("", c);
			dispatcher.Dispatch(r);
		}
		
		[Test]
		public void TestDispatchOnLaneStop()
		{
            //			Request r = Request.Deserialize(new StringReader(@"<Request>
            //	<Content>
			            //<![CDATA[
			            //<Configuration ScriptName='test' ScriptOutputDirectory='C:\SSCAT\Scripts'>
            //	<Files Destination='C:\scot\config' Source='C:\SSCAT\ScotConfig'>
            //		<File Name='test.xml'/>
            //		<File Name='test2.xml' Host='g2lane-ian'/>
            //	</Files>
			            //</Configuration>
			            //]]>
            //	</Content>
			            //</Request>"));
			GeneratorConfiguration c = new GeneratorConfiguration();
			c.ScriptName = "test";
			c.ScriptOutputDirectory = @"C:\sscat\scripts";
			c.Files.DestinationDirectory = @"C:\scot\config";
			c.Files.SourceDirectory = @"C:\sscat\scotconfig";
			c.Files.AddFile(new ConfigFile("test.xml"));
			c.Files.AddFile(new ConfigFile("test2.xml", "g2lane-ian"));
			Request r = new Request("", c);
			server.Lane = new S();
			dispatcher.Dispatch(r);
		}
		
		[Test]
		public void TestDispatchWithLaneErrors()
		{
            //			Request r = Request.Deserialize(new StringReader(@"<Request>
            //	<Content>
			            //<![CDATA[
			            //<Configuration ScriptName='test' ScriptOutputDirectory='C:\SSCAT\Scripts'>
            //	<Files Destination='C:\scot\config' Source='C:\SSCAT\ScotConfig'>
            //		<File Name='test.xml'/>
            //		<File Name='test2.xml' Host='g2lane-ian'/>
            //	</Files>
			            //</Configuration>
			            //]]>
            //	</Content>
			            //</Request>"));
			GeneratorConfiguration c = new GeneratorConfiguration();
			c.ScriptName = "test";
			c.ScriptOutputDirectory = @"C:\sscat\scripts";
			c.Files.DestinationDirectory = @"C:\scot\config";
			c.Files.SourceDirectory = @"C:\sscat\scotconfig";
			c.Files.AddFile(new ConfigFile("test.xml"));
			c.Files.AddFile(new ConfigFile("test2.xml", "g2lane-ian"));
			Request r = new Request("", c);
			lane = new SscatLane();
			dispatcher.Dispatch(r);
		}
		
		[Test]
		public void TestDispatchWithException()
		{
            //			Request r = Request.Deserialize(new StringReader(@"<Request>
            //	<Content>
			            //<![CDATA[
			            //<Configuration ScriptName='test' ScriptOutputDirectory='C:\SSCAT\Scripts'>
            //	<Files Destination='C:\scot\config' Source='C:\SSCAT\ScotConfig'>
            //		<File Name='test.xml'/>
            //		<File Name='test2.xml' Host='g2lane-ian'/>
            //	</Files>
			            //</Configuration>
			            //]]>
            //	</Content>
			            //</Request>"));
			GeneratorConfiguration c = new GeneratorConfiguration();
			c.ScriptName = "test";
			c.ScriptOutputDirectory = @"C:\sscat\scripts";
			c.Files.DestinationDirectory = @"C:\scot\config";
			c.Files.SourceDirectory = @"C:\sscat\scotconfig";
			c.Files.AddFile(new ConfigFile("test.xml"));
			c.Files.AddFile(new ConfigFile("test2.xml", "g2lane-ian"));
			Request r = new Request("", c);
			server.Lane = new L();
			dispatcher.Dispatch(r);
		}
		
		[Test]
		public void TestDispatchWithFileNotFoundException()
		{
            //			Request r = Request.Deserialize(new StringReader(@"<Request>
            //	<Content>
			            //<![CDATA[
			            //<Configuration ScriptName='test' ScriptOutputDirectory='C:\SSCAT\Scripts'>
            //	<Files Destination='C:\scot\config' Source='C:\SSCAT\ScotConfig'>
            //		<File Name='test.xml'/>
            //		<File Name='test2.xml' Host='g2lane-ian'/>
            //	</Files>
			            //</Configuration>
			            //]]>
            //	</Content>
			            //</Request>"));
			GeneratorConfiguration c = new GeneratorConfiguration();
			c.ScriptName = "test";
			c.ScriptOutputDirectory = @"C:\sscat\scripts";
			c.Files.DestinationDirectory = @"C:\scot\config";
			c.Files.SourceDirectory = @"C:\sscat\scotconfig";
			c.Files.AddFile(new ConfigFile("test.xml"));
			c.Files.AddFile(new ConfigFile("test2.xml", "g2lane-ian"));
			Request r = new Request("", c);
			server.Lane = new E();
			dispatcher.Dispatch(r);
		}
		
		void DispatcherParserInitialize(object sender, EventArgs e)
		{
			lane.Parsers = service.CreateParsers();
		}

		void ClientDataSent(object sender, NetworkEventArgs e)
		{
            //ReceiveRequest(e.Message);
			server.ReceiveRequest(e.Request);
		}

		void ServerDataSent(object sender, NetworkEventArgs e)
		{
            //client.ReceiveResponse(e.Message);
			client.ReceiveResponse(e.Response);
		}
		
		void DispatcherDispatching(object sender, NcrEventArgs e)
		{
			LoggingService.Info(e.Message);
		}
		
		class S : SscatLaneStub
		{
			protected override void OnParserInitialize(EventArgs e)
			{
				base.OnParserInitialize(e);
				Stop();
			}

            //public override void ValidateForGenerate()
            //{
            //	Stop();
            //}
		}
		
		class E : SscatLaneStub
		{
			protected override void OnParserInitialize(EventArgs e)
			{
				base.OnParserInitialize(e);
				throw new FileNotFoundException();
			}
			
            //public override void ValidateForGenerate()
            //{
            //	throw new FileNotFoundException();
            //}
		}
		
		class L : SscatLaneStub
		{
			protected override void OnParserInitialize(EventArgs e)
			{
				base.OnParserInitialize(e);
				throw new Exception();
			}
			
            //public override void ValidateForGenerate()
            //{
            //	throw new Exception();
            //}
		}
	}
}
