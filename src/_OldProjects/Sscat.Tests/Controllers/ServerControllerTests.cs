//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using System.Windows.Forms;
using Ncr.Core;
using Ncr.Core.Models;
using Ncr.Core.Net;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Rhino.Mocks;
using Sscat.Core.Controllers;
using Sscat.Core.Emulators;
using Sscat.Core.Models;
using Sscat.Core.Net;
using Sscat.Core.Parsers;
using Sscat.Core.Services;
using Sscat.Server.Gui;
using Sscat.Tests.Commands.Gui;
using Sscat.Tests.Commands.Psx;
using Sscat.Tests.Config;
using Sscat.Tests.Models;
using Sscat.Tests.Net;
using Sscat.Tests.Repositories;
using Sscat.Tests.Services;

namespace Sscat.Tests.Controllers
{
	[TestFixture]
	public class ServerControllerTests
	{
		ServerController controller;
		SscatServer server;
		SscatLane lane;
		LaneService service;

		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApplicationUtility.Attach(new ApplicationManagerStub());
			DnsHelper.Attach(new DnsManagerStub());
			MessageService.Attach(new NoMessageProvider());

			lane = new SscatLane();
			
			server = new SscatServerStub(new XmlRequestParser(), lane, new EasyServerEngine(30000, "SSCAT Server", new XmlRequestParser()));
			server.Serving += new EventHandler<NcrEventArgs>(ServerServing);

			server.AddDispatcher(new GodRequestDispatcher());
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
			controller = new ServerController(server, service, new ServerForm());
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			server.Serving -= new EventHandler<NcrEventArgs>(ServerServing);
		}
		
		[Test]
		public void TestStop()
		{
			server.Stop();
		}
		
		[Test]
//		[Ignore()]
		public void TestReceiveRequestWithConnectionAddingButConnectionExists()
		{
			server.Lane.PsxConnections.Add(service.CreatePsx("localhost", "FastLaneRemoteServer", "AUTOMATION", 100));
//			server.ReceiveRequest(Request.Deserialize(new StringReader(@"<Request Type='CHUCK_NORRIS'/>")));
		}
		
		[Test]
//		[Ignore()]
		public void TestReceiveRequestWithConnectionAddingOnException()
		{
			lane = MockRepository.GenerateMock<SscatLane>();
//			server.ReceiveRequest(Request.Deserialize(new StringReader(@"<Request Type='CHUCK_NORRIS'/>")));
			server.ReceiveRequest(new Request("CHUCK_NORRIS", new MessageContent("")));
		}
		
		[Test]
//		[Ignore("Not sure about the error caught. No Debug, nothing. Nada!")]
		public void TestReceiveRequestWithConnectionAdding()
		{
//			server.ReceiveRequest(Request.Deserialize(new StringReader(@"<Request Type='CHUCK_NORRIS'/>")));
			server.ReceiveRequest(new Request("CHUCK_NORRIS", new MessageContent("")));
		}
		
		[Test]
//		[Ignore()]
		public void TestReceiveRequest()
		{
//			server.ReceiveRequest(Request.Deserialize(new StringReader(@"<Request Type='GOD'/>")));
			server.ReceiveRequest(new Request("GOD", new MessageContent("")));
		}
		
		[Test]
		public void TestValues()
		{
			Assert.IsNotNull(controller.Index());
		}
		
		//[Test]
        //TODO: Either remove or fix empty test
		public void TestDispatcherNotFound()
		{
//			server.ReceiveRequest(@"<Request Type='QWERTY'><Content></Content></Request>");
		}

		void ServerServing(object sender, NcrEventArgs e)
		{
//			Console.WriteLine(e.Message);
		}
	}
}
