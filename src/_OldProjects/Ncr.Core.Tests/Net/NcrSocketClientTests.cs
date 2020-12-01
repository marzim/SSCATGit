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
	public class NcrSocketClientTests
	{
		NcrSocketClient c;
		
		[SetUp]
		public void Setup()
		{
			c = new NcrSocketClient(new NcrServerInfo("localhost", 30000));
		}
		
		[TearDown]
		public void Teardown()
		{
			c.Dispose();
		}
		
		[Test]
		public void TestMethod()
		{
		}
	}
}
