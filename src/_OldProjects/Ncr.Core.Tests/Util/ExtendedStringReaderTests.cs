//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class ExtendedStringReaderTests
	{
		ExtendedStringReader r;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			r = new ExtendedStringReader("hello world");
		}
		
		[Test]
		public void TestLengthValue()
		{
			Assert.AreEqual(11, r.Length);
		}

        [Test]
        public void TestPositionValue()
        {
            r.Read();
            Assert.AreEqual(1, r.Position);
        }
	}
}
