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
	public class ConvertUtilityTests
	{

        [Test]
        public void TestStringConversionEqualTo0()
        {
            Assert.AreEqual(0, ConvertUtility.ToInt32("life"));
        }

        [Test]
        public void TestIntegerEquality()
        {
            Assert.AreEqual(23, ConvertUtility.ToInt32("23"));
        }

        [Test]
        public void TestIntValidIntegerIsTrue()
        {
            Assert.IsTrue(ConvertUtility.ValidInteger(56));

        }

        [Test]
        public void TestStringValidIntegerIsFalse()
        {
            Assert.IsFalse(ConvertUtility.ValidInteger("hello"));
        }

        [Test]
        public void TestStringValidIntegerIsTrue()
        {
            Assert.IsTrue(ConvertUtility.ValidInteger("33"));
        }
		
		[Test]
		public void TestInvalidInt()
		{
            Assert.That(() => ConvertUtility.ToInt32("lalala", true),
                Throws.TypeOf<FormatException>());
		}
		
		[Test]
		public void TestInvalidIntWithDefaultValue()
		{
			Assert.AreEqual(0, ConvertUtility.ToInt32("lalala", 0));
		}
		
		[Test]
		public void TestMin()
		{
			Assert.AreEqual(0, ConvertUtility.Min(5, 0));
			Assert.AreEqual(5, ConvertUtility.Min(5, 10));
		}
	}
}
