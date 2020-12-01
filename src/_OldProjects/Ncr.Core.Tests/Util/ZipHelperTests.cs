//	<file>
//		<license></license>
//		<owner name="Apple Leo Chiong" email="Apple_Leo_Derilo.Chiong@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class ZipHelperTests
	{
		[SetUp]
		public void Setup()
		{
			ZipHelper.Attach(new ZipManagerStub());
		}
		
		[Test]
		public void TestExtract()
		{
			ZipHelper.Extract("", "", "", "");
		}
		
		[Test]
		public void TestStringExtract()
		{
			Assert.AreEqual("", ZipHelper.Extract("", "", "", "", ""));
		}
		
		[Test]
		public void TestCompressFolder()
		{
			ZipHelper.CompressFolder("", "");
		}
		
		[Test]
		public void TestExtractWithError()
		{
			ZipHelper.Attach(new ZipManagerStub(true));
            Assert.That(() => ZipHelper.Extract("", "", "", ""),
               Throws.TypeOf<Exception>());
		}
		
		[Test]
		public void TestStringExtractWithError()
		{
			ZipHelper.Attach(new ZipManagerStub(true));
            Assert.That(() => Assert.AreEqual("", ZipHelper.Extract("", "", "", "", "")),
               Throws.TypeOf<Exception>());
		}
		
		[Test]
		public void TestCompressFolderWithError()
		{
			ZipHelper.Attach(new ZipManagerStub(true));
            Assert.That(() => ZipHelper.CompressFolder("", ""),
               Throws.TypeOf<Exception>());
		}
		
		[Test]
		public void TestExtractOnNullManager()
		{
			ZipHelper.Attach(null);
            Assert.That(() => Assert.AreEqual("", ZipHelper.Extract("", "", "", "", "")),
               Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestExtractOnNullManager2()
		{
			ZipHelper.Attach(null);
            Assert.That(() => ZipHelper.Extract("", "", "", ""),
               Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestCompressFolderOnNullManager()
		{
			ZipHelper.Attach(null);
            Assert.That(() => ZipHelper.CompressFolder("", ""),
               Throws.TypeOf<ArgumentNullException>());
		}
	}
}
