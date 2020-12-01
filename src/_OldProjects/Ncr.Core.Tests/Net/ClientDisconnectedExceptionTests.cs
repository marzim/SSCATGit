//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Net;
using NUnit.Framework;

namespace Ncr.Core.Tests.Net
{
	[TestFixture]
	public class ClientDisconnectedExceptionTests
	{
		ClientDisconnectedException e;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			e = new ClientDisconnectedException("test...");
		}
		
		[Test]
		public void TestValues()
		{
			Assert.AreEqual("test...", e.Message);
		}
	}
}
