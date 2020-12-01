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
	public class PsxCollectionTests
	{
		PsxCollection c;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
            c = new PsxCollection();
            c.Add(new PsxStub("localhost", "FastLaneRemoteServer", "AUTOMATION", 5000));
		}
		
		[Test]
		public void TestSingleCountValue()
        {
			Assert.AreEqual(1, c.Count);
		}

        [Test]
        public void TestZeroCountValue()
        {
            c.Clear();
            Assert.AreEqual(0, c.Count);
        }
	}
}
