//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Util;

namespace Sscat.Tests.Util
{
	[TestFixture]
	public class ArrayHelperTests
	{
		[Test]
		public void TestIntAndStringValue()
		{
			Assert.AreEqual("3a", ArrayHelper.GetValue(new string[] { "1", "2", "3a" }, 2));
		}

        [Test]
        public void TestIntValue()
        {
            Assert.AreEqual("2", ArrayHelper.GetValue(new string[] { "1", "2", "3a" }, 1));
        }

        [Test]
        public void TestEmptyValue()
        {
            Assert.AreEqual("", ArrayHelper.GetValue(new string[] { "1", "2", "3a" }, 4));
        }
	}
}
