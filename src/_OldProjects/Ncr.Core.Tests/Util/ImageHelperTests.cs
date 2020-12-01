//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class ImageHelperTests
	{
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ImageHelper.Attach(new ImageManagerStub());
		}

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ImageHelper.Attach(null);
        }
		
		[Test]
		public void TestFromFile()
		{
			Assert.IsNull(ImageHelper.FromFile(@"C:\Projects\finger\trunk\logs"));
		}
		
		[Test]
		public void TestSave()
		{
			ImageHelper.Save(new PictureBox().Image, @"C:\Projects\finger\trunk\tests\test.png", 30);
		}
		
		[Test]
		public void TestSaveOnNullManager()
		{
			ImageHelper.Attach(null);
            Assert.That(() => ImageHelper.Save(new PictureBox().Image, @"C:\Projects\finger\trunk\tests\test.png", 30),
               Throws.TypeOf<ArgumentNullException>());
			   
            ImageHelper.Attach(new ImageManagerStub());
		}
		
		[Test]
		public void TestFromFileOnNullManager()
		{
			ImageHelper.Attach(null);
            Assert.That(() => Assert.IsNotNull(ImageHelper.FromFile(@"C:\Projects\finger\trunk\logs")),
               Throws.TypeOf<ArgumentNullException>());
			   
            ImageHelper.Attach(new ImageManagerStub());
		}
	}
}
