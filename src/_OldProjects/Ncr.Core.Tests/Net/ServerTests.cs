//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Net;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Net
{
	[TestFixture]
	public class ServerTests
	{
		BaseServer server;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			MessageService.Attach(new ConsoleMessageProvider());
		}

        [SetUp]
        public void SetUp()
        {
            server = new BaseServer(30000, "Dummy Server", new XmlRequestParser(), new ServerEngineStub(new XmlRequestParser()));
            server.AddDispatcher(new GodRequestDispatcher());
            server.AddDispatcher(new ErroryRequestDispatcher());

            server.MultipleClients = true;

            server.Serving += new EventHandler<NcrEventArgs>(ServerServing);
            server.Starting += new EventHandler(ServerStarting);
            server.Stopping += new EventHandler(ServerStopping);
            server.DataSent += new EventHandler<NetworkEventArgs>(ServerDataSent);
            server.DataArrived += new EventHandler<NetworkEventArgs>(ServerDataArrived);
        }
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			server.Serving -= new EventHandler<NcrEventArgs>(ServerServing);
			server.Starting -= new EventHandler(ServerStarting);
			server.Stopping -= new EventHandler(ServerStopping);
			server.DataSent -= new EventHandler<NetworkEventArgs>(ServerDataSent);
			server.DataArrived -= new EventHandler<NetworkEventArgs>(ServerDataArrived);
		}
		
		[Test]
		public void TestClientAdding()
		{
			E e = new E();
			BaseServer s = new BaseServer(30000, "Dummy Server", new XmlRequestParser(), e);
			s.MultipleClients = false;
			e.X();
		}
		
		[Test]
		public void TestDataArrived()
		{
			E e = new E();
			BaseServer s = new BaseServer(30000, "Dummy Server", new XmlRequestParser(), e);
			s.MultipleClients = false;
			e.Y();
		}
		
		[Test]
		public void TestDispose()
		{
			server.Dispose();
		}
		
		//[Test]
        //TODO: Either remove or fix empty test
		public void TestReceiveRequest()
		{
//			server.ReceiveRequest(new Request("GOD", ""));
		}

        //[Test]
        //TODO: Either remove or fix empty test
		public void TestReceiveStringRequest()
		{
//			server.ReceiveRequest(@"<Request Type='GOD'/>");
		}
		
		[Test]
//		[Ignore()]
		//Deprecated in NUnit 3 
		//[ExpectedException(typeof(Exception))]
		public void TestReceiveStringRequestOnNullParser()
		{
			server.RequestParser = null;
//			server.ReceiveRequest(@"<Request Type='GOD'/>");
		}
		
		[Test]
		public void TestSendResponse()
		{
			server.SendResponse(new Response());
		}
		
		[Test]
		public void TestStop()
		{
			server.Stop();
		}
		
		[Test]
		public void TestListen()
		{
			server.Listen();
		}
		
		[Test]
		public void TestServerNameValue()
		{
			Assert.AreEqual("Dummy Server", server.Name);
		}

        [Test]
        public void TestServerDispatchersCountValue()
        {
            Assert.AreEqual(2, server.Dispatchers.Count);
        }

        [Test]
        public void TestRequestParserValue()
        {
            Assert.IsNotNull(server.RequestParser);
        }

        [Test]
        public void TestServerPortValue()
        {
            Assert.AreEqual(30000, server.Port);
        }

        [Test]
        public void TestServerMultipleClientsValue()
        {
            Assert.IsTrue(server.MultipleClients);
        }

        //[Test]
        //TODO: Either remove or fix empty test
		public void TestReceiveRequestOnNotSupported()
		{
//			server.ReceiveRequest(new Request("QWERTY", ""));
		}

        //[Test]
        //TODO: Either remove or fix empty test
		public void TestReceiveRequestWithException()
		{
//			server.ReceiveRequest(new Request("ERRORY", ""));
		}

		void ServerDataArrived(object sender, NetworkEventArgs e)
		{
		}

		void ServerDataSent(object sender, NetworkEventArgs e)
		{
		}

		void ServerStopping(object sender, EventArgs e)
		{
		}

		void ServerStarting(object sender, EventArgs e)
		{
		}

		void ServerServing(object sender, NcrEventArgs e)
		{
		}
		
		class E : ServerEngineStub
		{
			public E() : base(new XmlRequestParser())
			{
			}
			
			public void X()
			{
				OnClientAdding(new NetworkEventArgs(""));
			}
			
			public void Y()
			{
				OnDataArrived(new NetworkEventArgs(new Request("GOD", new RC())));
			}
		}
		
		class RC : IContent
		{
			public virtual void Dispose()
			{
			}
		}
		
		class ErroryRequestDispatcher : RequestDispatcher
		{
			public ErroryRequestDispatcher() : base("ERRORY")
			{
			}
			
			public override void Dispatch(Request request)
			{
				throw new Exception();
			}
		}
		
		class GodRequestDispatcher : RequestDispatcher
		{
			public GodRequestDispatcher() : base("GOD")
			{
			}
			
			public override void Dispatch(Request request)
			{
				OnDispatching("Dispatching...");
//				OnDispatched(new Response("MESSAGE", ""));
				OnDispatched(new Response("MESSAGE", new MessageContent("")));
			}
		}
	}
}
