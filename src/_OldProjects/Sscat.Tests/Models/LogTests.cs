//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class LogTests
	{
		Sscat.Core.Models.Log l;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			l = new Sscat.Core.Models.Log();
			l.Changed += new EventHandler(LogChanged);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			l.Changed -= new EventHandler(LogChanged);
		}
		
		[Test]
		public void TestAppendLog()
		{
			l.AppendLog("");
		}
		
		[Test]
		public void TestClear()
		{
			l.Clear();
		}
		
		[Test]
		public void TestToString()
		{
			Assert.IsNotNull(l.ToString());
		}

		void LogChanged(object sender, EventArgs e)
		{
		}
	}
}
