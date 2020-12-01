//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Net;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Net
{
	[TestFixture]
	public class ClientTests
	{
		BaseClient client;
		BaseServer server;
		ClientEngineStub clientEngine;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			MessageService.Attach(new ConsoleMessageProvider());
			DnsHelper.Attach(new DnsManagerStub());
			
			clientEngine = new ClientEngineStub();
			
			client = new BaseClient("localhost", 30000, new XmlResponseParser(), clientEngine);
			client.AddDispatcher(new HelloResponseDispatcher());
			client.AddDispatcher(new ErrorResponseDispatcher());
			client.AddDispatcher(new ExceptionResponseDispatcher());

			server = new BaseServer(3000, "Dummy Server", new XmlRequestParser(), new ServerEngineStub(new XmlRequestParser()));
			server.AddDispatcher(new HelloRequestDispatcher());
			
			client.Connected += new EventHandler<NetworkEventArgs>(ClientConnected);
			client.ConnectionTimeOut += new EventHandler<NetworkEventArgs>(ClientConnectionTimeOut);
			client.Disconnected += new EventHandler<NetworkEventArgs>(ClientDisconnected);
			client.ResponseDispatching += new EventHandler<NcrEventArgs>(ClientResponseDispatching);
			client.ConnectionRejecting += new EventHandler(ClientConnectionRejecting);
			client.ConnectionRejected += new EventHandler(ClientConnectionRejected);
			client.DataSent += new EventHandler<NetworkEventArgs>(ClientDataSent);
			client.ErrorDispatched += new EventHandler(ClientErrorDispatched);
			client.DataArrived += new EventHandler<NetworkEventArgs>(ClientDataArrived);
			
			server.Serving += new EventHandler<NcrEventArgs>(ServerServing);
			server.DataSent += new EventHandler<NetworkEventArgs>(ServerDataSent);
		}
		
		[TearDown]
		public void Teardown()
		{
			client.Disconnect();
			
			client.Connected -= new EventHandler<NetworkEventArgs>(ClientConnected);
			client.ConnectionTimeOut -= new EventHandler<NetworkEventArgs>(ClientConnectionTimeOut);
			client.Disconnected -= new EventHandler<NetworkEventArgs>(ClientDisconnected);
			client.ResponseDispatching -= new EventHandler<NcrEventArgs>(ClientResponseDispatching);
			client.ConnectionRejecting -= new EventHandler(ClientConnectionRejecting);
			client.ConnectionRejected -= new EventHandler(ClientConnectionRejected);
			client.DataSent -= new EventHandler<NetworkEventArgs>(ClientDataSent);
			client.ErrorDispatched -= new EventHandler(ClientErrorDispatched);
			client.DataArrived -= new EventHandler<NetworkEventArgs>(ClientDataArrived);
			
			server.Serving -= new EventHandler<NcrEventArgs>(ServerServing);
			server.DataSent -= new EventHandler<NetworkEventArgs>(ServerDataSent);
		}
		
		[Test]
		public void TestDataArrived()
		{
			E e = new E();
			BaseClient c = new BaseClient(0, new XmlResponseParser(), e);
			c.AddDispatcher(new HelloResponseDispatcher());
			e.X();
		}
		
		[Test]
		public void TestConnectionTimeout()
		{
			clientEngine.PerformConnectionTimeout();
		}
		
		[Test]
		public void TestConnectionRejected()
		{
			clientEngine.PerformConnectionRejected();
		}
		
		[Test]
		public void TestEmptyServerConstructor()
		{
			BaseClient c = new BaseClient(30000, new XmlResponseParser(), new ClientEngineStub());
			Assert.IsEmpty(c.Server);
		}
		
		[Test]
		public void TestValidate()
		{
			client.Validate();
			Assert.IsFalse(client.HasErrors);
		}
		
		[Test]
		public void TestConnect()
		{
			client.Connect();
			Assert.IsFalse(client.Rejected);
		}
		
		[Test]
		public void TestReceiveStringResponse()
		{
//			client.ReceiveResponse(@"<Response Type='HELLO'/>");
		}
		
		[Test]
		public void TestReceiveErrorResponse()
		{
//			client.ReceiveResponse(new Response("ERROR", ""));
			client.ReceiveResponse(new Response("ERROR", new MessageContent("")));
		}
		
		[Test]
		public void TestReceiveUnsupportedResponse()
		{
//			client.ReceiveResponse(new Response("QWERTY", ""));
            Assert.That(() => client.ReceiveResponse(new Response("QWERTY", new MessageContent(""))),
                Throws.TypeOf<NotSupportedException>());
		}
		
		[Test]
		public void TestReceiveExceptionResponse()
		{
//			client.ReceiveResponse(new Response("EXCEPTION", ""));
			client.ReceiveResponse(new Response("EXCEPTION", new MessageContent("")));
		}
		
		[Test]
		public void TestPerformConnectionTimeout()
		{
			client.PerformConnectionTimeOut();
		}
		
		[Test]
		public void TestSendHelloRequest()
		{
			client.Connect();
//			client.SendRequest(new Request("HELLO", "World"));
			client.SendRequest(new Request("HELLO", new MessageContent("World")));
		}
		
		[Test]
		public void TestDispatchersCountValue()
		{
			Assert.AreEqual(3, client.Dispatchers.Count);
		}

        [Test]
        public void TestServerValue()
        {
            Assert.AreEqual("localhost", client.Server);
        }

        [Test]
        public void TestHostNameValue()
        {
            Assert.AreEqual("127.0.0.1", client.HostName);
        }

        [Test]
        public void TestTimeoutValue()
        {
            Assert.Greater(client.Timeout, 42);
            //Assert.IsTrue(client.HasTimedOut);
        }

		void ClientDataArrived(object sender, NetworkEventArgs e)
		{
		}

		void ClientErrorDispatched(object sender, EventArgs e)
		{
		}

		void ClientResponseDispatching(object sender, NcrEventArgs e)
		{
			Console.WriteLine(e.Message);
		}

		void ClientDisconnected(object sender, NetworkEventArgs e)
		{
		}

		void ClientConnectionTimeOut(object sender, NetworkEventArgs e)
		{
		}

		void ClientConnected(object sender, NetworkEventArgs e)
		{
		}

		void ClientConnectionRejecting(object sender, EventArgs e)
		{
		}

		void ServerServing(object sender, NcrEventArgs e)
		{
		}

		void ClientConnectionRejected(object sender, EventArgs e)
		{
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
		
		class E : ClientEngineStub
		{
			public void X()
			{
//				OnDataArrived(new NetworkEventArgs(new Response("HELLO", "")));
				OnDataArrived(new NetworkEventArgs(new Response("HELLO", new MessageContent(""))));
			}
		}
		
		class HelloResponseDispatcher : ResponseDispatcher
		{
			public HelloResponseDispatcher() : base("HELLO")
			{
			}
			
			public override void Dispatch(Response response)
			{
//				OnDispatching(response.Content);
				OnDispatching((response.Content as MessageContent).Message);
			}
		}
		
		class ErrorResponseDispatcher : ResponseDispatcher
		{
			public ErrorResponseDispatcher() : base("ERROR")
			{
			}
			
			public override void Dispatch(Response response)
			{
				OnErrorDispatched(null);
			}
		}
		
		class ExceptionResponseDispatcher : ResponseDispatcher
		{
			public ExceptionResponseDispatcher() : base("EXCEPTION")
			{
			}
			
			public override void Dispatch(Response response)
			{
				throw new Exception();
			}
		}
	}
}
