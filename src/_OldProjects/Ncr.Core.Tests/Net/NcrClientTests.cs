//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using Ncr.Core.Net;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Net
{
	[TestFixture]
	public class NcrClientTests
	{
		NcrClient c;
		
		[SetUp]
		public void Setup()
		{
			DnsHelper.Attach(new DnsManagerStub());
			
			c = new NcrClient("localhost", 30000, new XmlResponseParser());
			c.Connected += new NetworkEventHandler(ClientConnected);
			c.ConnectionTimeOut += new NetworkEventHandler(ClientConnectionTimeOut);
			c.DataArrived += new NetworkEventHandler(ClientDataArrived);
			c.DataSent += new NetworkEventHandler(ClientDataSent);
			c.Disconnected += new NetworkEventHandler(ClientDisconnected);
		}
		
		[Test]
		public void TestDisconnect()
		{
			c.Disconnect();
		}
		
		[TearDown]
		public void Teardown()
		{
			c.Connected -= new NetworkEventHandler(ClientConnected);
			c.ConnectionTimeOut -= new NetworkEventHandler(ClientConnectionTimeOut);
			c.DataArrived -= new NetworkEventHandler(ClientDataArrived);
			c.DataSent -= new NetworkEventHandler(ClientDataSent);
			c.Disconnected -= new NetworkEventHandler(ClientDisconnected);
		}
		
		[Test]
		public void TestMethod()
		{
		}

		void ClientDisconnected(object sender, NetworkEventArgs e)
		{
		}

		void ClientDataSent(object sender, NetworkEventArgs e)
		{
		}

		void ClientDataArrived(object sender, NetworkEventArgs e)
		{
		}

		void ClientConnectionTimeOut(object sender, NetworkEventArgs e)
		{
		}

		void ClientConnected(object sender, NetworkEventArgs e)
		{
		}
	}
}
