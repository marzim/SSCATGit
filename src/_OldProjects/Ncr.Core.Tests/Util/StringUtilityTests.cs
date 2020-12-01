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
	public class StringUtilityTests
	{
		[Test]
		public void TestTruncate()
		{
			Assert.AreEqual("hello...", StringUtility.Truncate("hello world", 5));
		}
		
		[Test]
		public void TestStringNotFound()
		{
			Assert.IsFalse(StringUtility.Contains("life", "amazing"));
		}
		
		[Test]
		public void TestValues()
		{
			Assert.AreEqual("hello world".Contains("hello"), StringUtility.Contains("hello world", "hello"));
			Assert.AreEqual("".Contains("hello"), StringUtility.Contains("", "hello"));
			Assert.AreEqual("world hello".Contains("hello"), StringUtility.Contains("world hello", "hello"));
		}
		
		[Test]
		public void TestContainRapString()
		{
			Assert.AreEqual("RAP.".IndexOf("RAP") >= 0 && !"RAP.".Equals(string.Empty), true);
		}
		
		[Test]
		public void TestScannerSplit()
		{
			string s = "A074806001417~074806001417~101";
			Assert.AreEqual(s.Split(new char[] { '~' }).Length, 3);
			s = "234";
			Assert.AreEqual(s.Split(new char[] { '~' }).Length, 1);
		}
		
		[Test]
		public void TestReplace()
		{
			Assert.AreEqual("world", StringUtility.Replace("hello world", "hello ", ""));
		}
		
		[Test]
		public void TestTrimLast()
		{
			string s = "034481074601";
			string x = s.Substring(0, s.Length - 1);
			Assert.AreEqual("03448107460", x);
		}
		
		[Test]
		public void TestCasing()
		{
			Assert.AreEqual("hELLO", StringUtility.ToCamelCase("HELLO"));
			Assert.AreEqual("HELLO", StringUtility.ToPascalCase("HELLO"));
			Assert.AreEqual("HELLO_world", StringUtility.ToPascalCase("HELLO_world"));
		}
	}
}
