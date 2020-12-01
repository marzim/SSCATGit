//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Models;
using NUnit.Framework;

namespace Ncr.Core.Tests.Models
{
	[TestFixture]
	public class PsxWrapperEventArgsTests
	{
		PsxWrapperEventArgs e;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			e = new PsxWrapperEventArgs("localhost", "FastLaneRemoteServer", "AUTOMATION", 5000);
        }

        [Test]
        public void TestHostNameValue()
        {
            Assert.AreEqual("localhost", e.HostName);
        }

        [Test]
        public void TestServiceNameValue()
        {
            Assert.AreEqual("FastLaneRemoteServer", e.ServiceName);
        }
		
		[Test]
		public void TestConnectionNameValue()
		{
			Assert.AreEqual("AUTOMATION", e.ConnectionName);
		}

        [Test]
        public void TestTimeoutValue()
        {
            Assert.AreEqual(5000, e.Timeout);
        }
	}
}
