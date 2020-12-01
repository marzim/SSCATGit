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
	public class ArgumentParserTests
	{
		ArgumentParser p;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			p = new ArgumentParser();
			p.Description = "test";
		}
		
		[Test]
		public void TestDescriptionValue()
		{
			Assert.AreEqual("test", p.Description);
		}
		
		[Test]
		public void TestParseArguments()
		{
			p.AddArgument("-c", "");
			p.ParseArguments(new string[] { "-c", "192.168.0.1", "-p", "0..5" });
		}
	}
}
