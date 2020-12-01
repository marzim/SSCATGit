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
	public class NcrServerInfoTests
	{
		NcrServerInfo i;
		
		[SetUp]
		public void Setup()
		{
			i = new NcrServerInfo("localhost", 30000);
		}
		
		[Test]
		public void TestDispose()
		{
			i.Dispose();
		}
		
		[Test]
		public void TestValues()
		{
			Assert.IsTrue(i.Legal);
		}
	}
}
