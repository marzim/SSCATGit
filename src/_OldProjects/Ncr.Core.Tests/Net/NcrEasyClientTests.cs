//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using JadBenAutho.EasySocket;
using Ncr.Core.Net;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Net
{
	[TestFixture]
	public class NcrEasyClientTests
	{
		NcrEasyClient c;
		
		[SetUp]
		public void Setup()
		{
			DnsHelper.Attach(new DnsManagerStub());
			
			c = new NcrEasyClient("localhost", 30000, new XmlResponseParser());
		}
		
		[TearDown]
		public void Teardown()
		{
		}
		
		[Test]
		public void TestDisconnect()
		{
			c.Disconnect();
		}
		
		[Test]
		[ExpectedException(typeof(EasySocketException))]
		public void TestSendRequest()
		{
			c.SendRequest(new Request().Serialize());
		}
		
		[Test]
		public void TestConnect()
		{
			c.Connect();
		}
		
		[Test]
		public void TestValues()
		{
			Assert.AreEqual(0, c.Dispatchers.Count);
			Assert.AreEqual("127.0.0.1", c.Server);
		}
	}
}
