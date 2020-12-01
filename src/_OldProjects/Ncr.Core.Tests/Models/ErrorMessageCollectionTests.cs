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
	public class ErrorMessageCollectionTests
	{
		ErrorMessageCollection c;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			c = new ErrorMessageCollection();
			c.Add("hello");
			c.Add("world");
		}
		
		[Test]
		public void TestCountValue()
		{
			Assert.AreEqual(2, c.Count);
		}

        [Test]
        public void TestMessageValue()
        {
            Assert.AreEqual("hello" + Environment.NewLine + "world", c.ToString());
        }
	}
}
