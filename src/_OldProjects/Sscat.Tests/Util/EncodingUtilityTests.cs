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
	public class EncodingUtilityTests
	{
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			FileHelper.Attach(new FileManager());
			FileHelper.Create(@"C:\Projects\finger\trunk\tests\lalala.txt");
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			FileHelper.Delete(@"C:\Projects\finger\trunk\tests\lalala.txt");
		}
		
		[Test]
		public void TestGetFileEncoding()
		{
			EncodingUtility.GetFileEncoding(@"C:\Projects\finger\trunk\tests\lalala.txt");
		}
	}
}
