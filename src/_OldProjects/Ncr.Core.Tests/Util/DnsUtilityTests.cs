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
	public class DnsHelperTests
	{
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			DnsHelper.Attach(new DnsManagerStub());
		}
		
		[Test]
		public void TestGetHostName()
		{
			Assert.AreEqual("holy-cow", DnsHelper.GetHostName());
		}
		
		[Test]
		public void TestGetHostNameOnNullManager()
		{
			DnsHelper.Attach(null);
            Assert.That(() => DnsHelper.GetHostName(),
                Throws.TypeOf<ArgumentNullException>());
				
            DnsHelper.Attach(new DnsManagerStub());
		}
		
		[Test]
		public void TestGetHostByName()
		{
			Assert.IsNotNull(DnsHelper.GetHostByName("localhost"));
		}
		
		[Test]
		public void TestGetHostByNameOnNullManager()
		{
			DnsHelper.Attach(null);
            Assert.That(() => Assert.IsNotNull(DnsHelper.GetHostByName("localhost")),
                Throws.TypeOf<ArgumentNullException>());
				
            DnsHelper.Attach(new DnsManagerStub());
		}
		
		[Test]
		public void TestGetIPAddressOnNullManager()
		{
			DnsHelper.Attach(null);
            Assert.That(() => Assert.AreEqual("127.0.0.1", DnsHelper.GetIPAddress("localhost")),
                Throws.TypeOf<ArgumentNullException>());
				
            DnsHelper.Attach(new DnsManagerStub());
		}
		
		[Test]
		public void TestGetIPAddress()
		{
			Assert.AreEqual("127.0.0.1", DnsHelper.GetIPAddress("localhost"));
		}
		
		[Test]
		public void TestHasHostOnNullManager()
		{
			DnsHelper.Attach(null);
            Assert.That(() => Assert.IsTrue(DnsHelper.HasHost("g2lane-ian")),
                Throws.TypeOf<ArgumentNullException>());
				
            DnsHelper.Attach(new DnsManagerStub());
		}
		
		[Test]
		public void TestHasHost()
		{
			Assert.IsTrue(DnsHelper.HasHost("g2lane-ian"));
		}
		
		[Test]
		public void TestGetLocalIPAddressOnNullManager()
		{
			DnsHelper.Attach(null);
            Assert.That(() => Assert.AreEqual("127.0.0.1", DnsHelper.GetLocalIPAddress()),
                Throws.TypeOf<ArgumentNullException>());
				
            DnsHelper.Attach(new DnsManagerStub());
		}
		
		[Test]
		public void TestGetLocalIPAddress()
		{
			Assert.AreEqual("127.0.0.1", DnsHelper.GetLocalIPAddress());
		}
		
		[Test]
		public void TestValidHostNameOnNullManager()
		{
			DnsHelper.Attach(null);
            Assert.That(() => Assert.IsTrue(DnsHelper.ValidHostName("localhost")),
                Throws.TypeOf<ArgumentNullException>());
				
            DnsHelper.Attach(new DnsManagerStub());
		}
		
		[Test]
		public void TestValidHostName()
		{
			Assert.IsTrue(DnsHelper.ValidHostName("localhost"));
		}
	}
}
