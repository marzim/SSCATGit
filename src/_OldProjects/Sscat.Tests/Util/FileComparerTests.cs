//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Util;

namespace Sscat.Tests.Util
{
	[TestFixture]
	public class FileComparerTests
	{
		string file1 = @"C:\Projects\finger\trunk\tests\test1.txt";
		string file2 = @"C:\Projects\finger\trunk\tests\test2.txt";
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			FileHelper.Attach(new FileManager());
			FileHelper.Create(file1);
			FileHelper.Create(file2);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			FileHelper.Delete(file1);
			FileHelper.Delete(file2);
		}
		
		[Test]
		public void TestCompare()
		{
			Assert.IsTrue(FileComparer.Compare(file1, file2));
		}
	}
}
