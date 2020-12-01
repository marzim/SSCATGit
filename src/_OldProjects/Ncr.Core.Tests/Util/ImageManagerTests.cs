//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class ImageManagerTests
	{
		ImageManager m;
        string dir;
        string filename;
        string filename1;
        //string dir = @"C:\Projects\finger\trunk\tests";
        //string filename = @"C:\Projects\finger\trunk\tests\test.jpg";
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
            // Get the working directory so that it will work running in local machine or in build machine
            string debugDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] trunkDir = debugDir.Split(new[] { "src" }, StringSplitOptions.None);

            dir = System.IO.Path.Combine(trunkDir[0], "tests");
            filename = System.IO.Path.Combine(trunkDir[0], @"tests\test.jpg");
            filename1 = System.IO.Path.Combine(trunkDir[0], @"tests\test2.jpg");

			FileHelper.Attach(new FileManager());
			DirectoryHelper.Attach(new DirectoryManager());
			DirectoryHelper.CreateDirectory(dir);
			
			m = new ImageManager();
			m.Save(new Bitmap(5, 5), filename, ImageFormat.Jpeg);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			DirectoryHelper.DeleteDirectory(dir);
		}
		
		[Test]
		public void TestFileNameValue()
		{
			using (Image i = m.FromFile(filename)) {
				Assert.IsNotNull(i);
			}
		}
		
		[Test]
		public void TestSaveWithQuality()
		{
			using (Image i = m.FromFile(filename)) {
                Assert.That(() => m.Save(i, filename, -42),
                    Throws.TypeOf<ArgumentOutOfRangeException>());
			}
		}
		
		[Test]
		public void TestSave()
		{
			using (Image i = m.FromFile(filename)) {
                m.Save(i, filename1, 30);
			}
		}
	}
}
