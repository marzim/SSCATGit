//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class CsvLogFormatterTests
	{
		CsvLogFormatter f;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			f = new CsvLogFormatter();
		}
		
		[Test]
		public void TestFormat()
		{
			DateTime d = DateTime.Now;
			Assert.IsTrue(f.Format("test", LogLevel.Debug).Contains("test"));
			Assert.IsTrue(f.Format("test").Contains("test"));
		}
	}
}
