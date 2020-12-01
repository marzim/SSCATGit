//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using System.Text;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class ExtendedStreamReaderTests
	{
		ExtendedStreamReader r;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			FileHelper.Attach(new FileManager());
			FileHelper.Create(@"C:\Projects\finger\trunk\tests\test.log");
		}

		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			FileHelper.Delete(@"C:\Projects\finger\trunk\tests\test.log");
		}


        [TearDown]
        public void TearDown()
        {
            r.Dispose();
        }
		
		
		[Test]
		public void TestConstructorWithStreamParameter()
		{
			r = new ExtendedStreamReader(new FileStream(@"C:\Projects\finger\trunk\tests\test.log", FileMode.Open));
			Assert.AreEqual(0, r.Position);
			Assert.AreEqual(0, r.Length);
		}
		
		[Test]
		public void TestConstructorWithStreamEncodingParameter()
		{
			r = new ExtendedStreamReader(new FileStream(@"C:\Projects\finger\trunk\tests\test.log", FileMode.Open), Encoding.Default);
			Assert.AreEqual(0, r.Position);
			Assert.AreEqual(0, r.Length);
		}
		
		[Test]
		public void TestConstructorWithFileNameEncodingParameter()
		{
			r = new ExtendedStreamReader(@"C:\Projects\finger\trunk\tests\test.log", Encoding.Default);
			Assert.AreEqual(0, r.Position);
			Assert.AreEqual(0, r.Length);
		}
		
		[Test]
		public void TestConstructorWithFileNameParameter()
		{
			r = new ExtendedStreamReader(@"C:\Projects\finger\trunk\tests\test.log");
			Assert.AreEqual(0, r.Position);
			Assert.AreEqual(0, r.Length);
		}
	}
}
