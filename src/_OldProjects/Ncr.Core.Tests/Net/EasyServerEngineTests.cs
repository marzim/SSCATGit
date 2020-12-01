//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using Ncr.Core.Net;
using NUnit.Framework;

namespace Ncr.Core.Tests.Net
{
	[TestFixture]
	public class EasyServerEngineTests
	{
		EasyServerEngine e;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			e = new EasyServerEngine(30000, "Server", new XmlRequestParser());
			
			e.ClientAdding += new EventHandler<NetworkEventArgs>(EngineClientAdding);
			e.ClientRejected += new EventHandler(EngineClientRejected);
			e.DataArrived += new EventHandler<NetworkEventArgs>(EngineDataArrived);
			e.DataSent += new EventHandler<NetworkEventArgs>(EngineDataSent);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			e.ClientAdding -= new EventHandler<NetworkEventArgs>(EngineClientAdding);
			e.ClientRejected -= new EventHandler(EngineClientRejected);
			e.DataArrived -= new EventHandler<NetworkEventArgs>(EngineDataArrived);
			e.DataSent -= new EventHandler<NetworkEventArgs>(EngineDataSent);
		}
		
		[Test]
		public void TestDispose()
		{
			e.Dispose();
		}
		
		[Test]
		public void TestSendResponse()
		{
            try
            {
                e.SendResponse(new Response("HELLO", new MessageContent("")));
            }
            catch (Exception ex)
            {
                Assert.That(() => e.SendResponse(new Response("HELLO", new MessageContent(""))),
                    Throws.TypeOf<ClientDisconnectedException>());
            }
		}
		
		[Test]
		public void TestStop()
        {
            e = new EasyServerEngine(10000, "Server", new XmlRequestParser());
			e.Stop();
		}
		
		[Test]
		public void TestListen()
		{
			e.Listen();
		}

		void EngineDataSent(object sender, NetworkEventArgs e)
		{
		}

		void EngineDataArrived(object sender, NetworkEventArgs e)
		{
		}

		void EngineClientRejected(object sender, EventArgs e)
		{
		}

		void EngineClientAdding(object sender, NetworkEventArgs e)
		{
		}
	}
}
