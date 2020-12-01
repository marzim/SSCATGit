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
	public class NcrEasyServerTests
	{
		NcrEasyServer s;
		
		[SetUp]
		public void Setup()
		{
			MessageService.Attach(new ConsoleMessageProvider());
			
			s = new NcrEasyServer(30000, "Server", new XmlRequestParser());
			s.AddDispatcher(new GodRequestDispatcher());
			
			s.ClientRejected += new EventHandler(ServerClientRejected);
		}
		
		[TearDown]
		public void Teardown()
		{
			s.ClientRejected -= new EventHandler(ServerClientRejected);
		}
		
		[Test]
		public void TestClientRejected()
		{
			new NcrEasyServerStub().PerformClientRejected();
		}
		
		[Test]
		public void TestListen()
		{
			s.Listen();
		}
		
		[Test]
		[ExpectedException(typeof(ClientDisconnectedException))]
		public void TestResponse()
		{
			s.Listen();
			s.SendResponse(new Response());
		}
		
		[Test]
		public void TestStop()
		{
			s.Stop();
		}
		
		[Test]
		public void TestDispose()
		{
			s.Dispose();
		}
		
		[Test]
		public void TestReceiveRequest()
		{
			s.ReceiveRequest(new Request("GOD", "").Serialize());
		}

		void ServerClientRejected(object sender, EventArgs e)
		{
		}
		
		class GodRequestDispatcher : RequestDispatcher
		{
			public GodRequestDispatcher() : base("GOD")
			{
			}
			
			public override void Dispatch(Request request)
			{
			}
		}
		
		class NcrEasyServerStub : NcrEasyServer
		{
			public NcrEasyServerStub() : base(3000, "localhost", new XmlRequestParser())
			{
			}
			
			public void PerformClientRejected()
			{
				OnClientRejected(null);
			}
		}
	}
}
