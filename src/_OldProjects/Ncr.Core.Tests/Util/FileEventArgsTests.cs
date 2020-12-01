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
	public class FileEventArgsTests
	{
		FileEventArgs e;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			e = new FileEventArgs(@"C:\Projects\finger\trunk\tests\test.xml");
		}
		
		[Test]
		public void TestFileValue()
		{
			Assert.IsNotEmpty(e.File);
		}
	}
}
