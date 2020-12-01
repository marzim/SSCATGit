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
	public class NcrServerTests
	{
		NcrServer s;
		
		[SetUp]
		public void Setup()
		{
			DnsHelper.Attach(new DnsManagerStub());
			
			s = new NcrServer(30000, "Server", new XmlRequestParser());
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
	}
}
