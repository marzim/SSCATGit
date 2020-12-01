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
	public class LogFormatterTests
	{
		ILogFormatter simple;
		ILogFormatter date;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			simple = new SimpleLogFormatter();
			date = new DateLogFormatter();
		}
		
		[Test]
		public void TestMethod()
		{
			Assert.AreEqual(@"    create C:\Finger\scripts\test.finger", simple.Format(@"C:\Finger\scripts\test.finger", LogLevel.Create));
			Assert.AreEqual(@"      info Parsing PSX Log...", simple.Format(@"Parsing PSX Log...", LogLevel.Info));
			Assert.AreEqual(@"           Another simple log", simple.Format("Another simple log"));
			Assert.Greater(date.Format("Test formatting...", LogLevel.Info).IndexOf("[Info]: Test formatting..."), -1);
			Assert.Greater(date.Format("Another test...").IndexOf("Another test..."), -1);
		}
	}
}
