//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using JadBenAutho.EasySocket;
using Ncr.Core.Net;
using NUnit.Framework;

namespace Ncr.Core.Tests.Net
{
	[TestFixture]
	public class EasyClientEngineTests
	{
		EasyClientEngine e;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			e = new EasyClientEngine();
			e.Server = "localhost";
			
			e.DataSent += new EventHandler<NetworkEventArgs>(EngineDataSent);
			e.DataArrived += new EventHandler<NetworkEventArgs>(EngineDataArrived);
			e.Connected += new EventHandler<NetworkEventArgs>(EngineConnected);
			e.ConnectionRejected += new EventHandler(EngineConnectionRejected);
			e.ConnectionRejecting += new EventHandler(EngineConnectionRejecting);
			e.ConnectionTimeOut += new EventHandler<NetworkEventArgs>(EngineConnectionTimeOut);
			e.Disconnected += new EventHandler<NetworkEventArgs>(EngineDisconnected);
		}
		
		[TearDown]
		public void Teardown()
		{
			e.DataSent -= new EventHandler<NetworkEventArgs>(EngineDataSent);
			e.DataArrived -= new EventHandler<NetworkEventArgs>(EngineDataArrived);
			e.Connected -= new EventHandler<NetworkEventArgs>(EngineConnected);
			e.ConnectionRejected -= new EventHandler(EngineConnectionRejected);
			e.ConnectionRejecting -= new EventHandler(EngineConnectionRejecting);
			e.ConnectionTimeOut -= new EventHandler<NetworkEventArgs>(EngineConnectionTimeOut);
			e.Disconnected -= new EventHandler<NetworkEventArgs>(EngineDisconnected);
		}
		
		[Test]
		public void TestValues()
		{
			Assert.IsNotEmpty(e.Server);
		}
		
		[Test]
		public void TestSendRequest()
		{
//			e.SendRequest(new Request("MESSAGE", "").Serialize());
//			e.SendRequest(new Request("MESSAGE", ""));
            Assert.That(() => e.SendRequest(new Request("MESSAGE", new MessageContent(""))),
                Throws.TypeOf<EasySocketException>());
		}
		
		[Test]
		public void TestConnect()
		{
            Assert.That(() => e.Connect(),
                Throws.TypeOf<EasySocketException>());
		}
		
		[Test]
		public void TestDisconnect()
		{
			e.Disconnect();
		}

		void EngineDisconnected(object sender, NetworkEventArgs e)
		{
		}

		void EngineConnectionTimeOut(object sender, NetworkEventArgs e)
		{
		}

		void EngineConnectionRejecting(object sender, EventArgs e)
		{
		}

		void EngineConnectionRejected(object sender, EventArgs e)
		{
		}

		void EngineConnected(object sender, NetworkEventArgs e)
		{
		}

		void EngineDataArrived(object sender, NetworkEventArgs e)
		{
		}

		void EngineDataSent(object sender, NetworkEventArgs e)
		{
		}
	}
}
