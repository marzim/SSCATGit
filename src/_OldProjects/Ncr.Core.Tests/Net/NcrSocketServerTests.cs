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
	public class NcrSocketServerTests
	{
		NcrSocketServer s;
		
		[SetUp]
		public void Setup()
		{
			DnsHelper.Attach(new DnsManagerStub());
			
			s = new NcrSocketServer(30000, "Server");
		}
		
		[Test]
		[ExpectedException(typeof(NcrSocketException))]
		public void TestInvalidPortNumber()
		{
			s = new NcrSocketServer(-45, "Server");
		}
		
		[Test]
		public void TestMethod()
		{
		}
	}
}
