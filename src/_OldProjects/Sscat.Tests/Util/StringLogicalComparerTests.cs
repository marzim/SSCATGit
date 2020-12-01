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
	public class StringLogicalComparerTests
	{
		[Test]
		public void TestNull()
		{
			Assert.AreEqual(0, StringLogicalComparer.Compare(null, null));
			Assert.AreEqual(-1, StringLogicalComparer.Compare(null, ""));
			Assert.AreEqual(1, StringLogicalComparer.Compare("", null));
		}
		
		[Test]
		public void TestEmpty()
		{
			Assert.AreEqual(0, StringLogicalComparer.Compare("", ""));
			Assert.AreEqual(-1, StringLogicalComparer.Compare("", "test"));
			Assert.AreEqual(-1, StringLogicalComparer.Compare("test", ""));
		}
		
		[Test]
		public void TestDigits()
		{
			Assert.AreEqual(1, StringLogicalComparer.Compare("1a", "!a"));
			Assert.AreEqual(-1, StringLogicalComparer.Compare("!a", "1a"));
		}
		
		[Test]
		public void Test()
		{
			Assert.AreEqual(0, StringLogicalComparer.Compare("file1", "file1"));
			Assert.AreEqual(-1, StringLogicalComparer.Compare("file1", "file2"));
		}
	}
}
