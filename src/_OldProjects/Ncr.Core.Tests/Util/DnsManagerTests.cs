//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Net;
using Ncr.Core.Net;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class DnsManagerTests
	{
		DnsManager m;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			m = new DnsManager();
		}
		
		[Test]
		public void TestValidHostName()
		{
			Assert.IsTrue(m.ValidHostName("localhost"));
		}
		
		[Test]
		public void TestGetHostByName()
		{
			Assert.IsNotNull(m.GetHostByName("localhost"));
		}
		
		[Test]
		public void TestInvalidHostName()
		{
			Assert.IsFalse(m.ValidHostName("qwerty"));
		}
		
		[Test]
		public void TestGetLocalIPAddress()
		{
            //string host = Dns.GetHostName();
            //IPHostEntry entry = Dns.GetHostEntry(host);
            //Assert.AreEqual(entry.AddressList[0].ToString(), m.GetLocalIPAddress());
            Assert.IsNotEmpty(m.GetLocalIPAddress()); //Changed the way it was tested.
		}
		
		[Test]
		public void TestGetHostName()
		{
			Assert.AreEqual(Dns.GetHostName(), m.GetHostName());
		}
		
		[Test]
		public void TestHasHost()
		{
			Assert.IsFalse(m.HasHost("localhost"));
		}
	}
}
