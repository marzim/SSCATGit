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
using Sscat.Core.Emulators;
using Sscat.Core.Net;
using Sscat.Core.Services;
using Sscat.Tests.Commands.Gui;
using Sscat.Tests.Config;
using Sscat.Tests.Emulators;
using Sscat.Tests.Models;

namespace Sscat.Tests.Net
{
	[TestFixture]
	public class SscatServerWokerTests
	{
		SscatServerWorker worker;
		SscatServer server;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
//			MessageService.Attach(new ConsoleMessageProvider());
			MessageService.Attach(new NoMessageProvider());
			
			server = new SscatServerStub(new XmlRequestParser(), new SscatLane(), new EasyServerEngine(30000, "SSCAT Server", new XmlRequestParser()));
			server.AddDispatcher(new G());
			
			worker = new SscatServerWorker(server);
		}
		
		[Test]
//		[Ignore()]
		public void TestDispatchRequest()
		{
//			Request r = Request.Deserialize(new StringReader(@"<Request Type='G'/>"));
			Request r = new Request("G", new MessageContent(""));
			worker.Request = r;
			worker.DispatchRequest();
		}
		
		[Test]
//		[Ignore()]
		public void TestDispatchRequestOnException()
		{
			server.AddDispatcher(new D());
//			Request r = Request.Deserialize(new StringReader(@"<Request Type='D'/>"));
			Request r = new Request("D", new MessageContent(""));
			worker.Request = r;
			worker.DispatchRequest();
		}
		
		[Test]
//		[Ignore()]
		public void TestDispatchRequestOnConnectionTimeoutException()
		{
			server.AddDispatcher(new C());
//			Request r = Request.Deserialize(new StringReader(@"<Request Type='C'/>"));
			Request r = new Request("C", new MessageContent(""));
			worker.Request = r;
			worker.DispatchRequest();
		}
		
		[Test]
//		[Ignore()]
		public void TestDispatchUnsupportedRequest()
		{
//			Request r = Request.Deserialize(new StringReader(@"<Request Type='QWERTY'/>"));
			Request r = new Request("QWERTY", new MessageContent(""));
			worker.Request = r;
			worker.DispatchRequest();
		}
		
		[Test]
		public void TestStop()
		{
			worker.Stop();
		}
		
		class G : SscatRequestDispatcher
		{
			public G() : base("G")
			{
			}
			
			public override void Dispatch(Request request)
			{
				OnLoggerStart(null);
				OnParserInitialize(null);
				OnLogHookInitialize(null);
				OnClientInitialize(null);
				OnConnectionAdding(new PsxWrapperEventArgs("localhost", "FastLaneRemoteServer", "AUTOMATION", 100));
				OnDispatching("...");
//				OnDispatched(new Response("HELLO", ""));
				OnDispatched(new Response("HELLO", new MessageContent("")));
				OnLoggerStop(null);
			}
		}
		
		class C : SscatRequestDispatcher
		{
			public C() : base("C")
			{
			}
			
			public override void Dispatch(Request request)
			{
				throw new ClientDisconnectedException("...");
			}
		}
		
		class D : SscatRequestDispatcher
		{
			public D() : base("D")
			{
			}
			
			public override void Dispatch(Request request)
			{
				throw new NotImplementedException();
			}
		}
	}
}
