//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Util;

namespace Sscat.Tests.Util
{
	[TestFixture]
	public class FileNameComparerTests
	{
		FileNameComparer c;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			c = new FileNameComparer();
		}
		
		[Test]
		public void TestCompare()
		{
			Assert.AreEqual(0, c.Compare("", ""));
		}
	}
}
