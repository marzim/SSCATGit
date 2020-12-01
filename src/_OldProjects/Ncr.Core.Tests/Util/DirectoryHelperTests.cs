//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Util;
using NUnit.Framework;
using Rhino.Mocks;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class DirectoryHelperTests
	{
        string debugDir;
        string[] trunkDir;

		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
            // Get the working directory so that it will work running in local machine or in build machine
            debugDir = AppDomain.CurrentDomain.BaseDirectory;
            trunkDir = debugDir.Split(new[] { "src" }, StringSplitOptions.None);

			DirectoryHelper.Attach(new DirectoryManager());
		}

		[Test]
		public void TestGetDirectoriesOnNullManager()
		{
			DirectoryHelper.Attach(null);
            Assert.That(() => DirectoryHelper.GetDirectories(@"C:\Projects\finger\trunk\tests"),
                Throws.TypeOf<ArgumentNullException>());

            DirectoryHelper.Attach(new DirectoryManager());
		}
		
		[Test]
		public void TestGetDirectories()
		{
			DirectoryHelper.GetDirectories(@"C:\Projects\finger\trunk\tests");
		}
		
		[Test]
		public void TestDirectoryHelperExistsValue()
		{
			//DirectoryHelper.CreateDirectory(@"C:\Projects\finger\trunk\tests");
            //Assert.IsTrue(DirectoryHelper.Exists(@"C:\Projects\finger\trunk\tests"));
            //DirectoryHelper.DeleteDirectory(@"C:\Projects\finger\trunk\tests");
            string testDir = Path.Combine(trunkDir[0], "tests1");
            DirectoryHelper.CreateDirectory(testDir);
            Assert.IsTrue(DirectoryHelper.Exists(testDir));
            DirectoryHelper.DeleteDirectory(testDir);
		}
		
		[Test]
		public void TestGetCurrentDirectoryOnNullManager()
		{
			DirectoryHelper.Attach(null);
            Assert.That(() => Assert.AreEqual(@"C:\Projects\finger\trunk\tests", DirectoryHelper.GetCurrentDirectory()),
                Throws.TypeOf<ArgumentNullException>());

			DirectoryHelper.Attach(new DirectoryManager());
		}
		
		[Test]
		public void TestCurrentDirectoryOnNullManager()
		{
			DirectoryHelper.Attach(null);
            Assert.That(() => DirectoryHelper.SetCurrentDirectory(@"C:\Projects\finger\trunk\tests"),
                Throws.TypeOf<ArgumentNullException>());

			DirectoryHelper.Attach(new DirectoryManager());
		}
		
		[Test]
		public void TestCurrentDirectory()
		{
			DirectoryHelper.CreateDirectory(@"C:\Projects\finger\trunk\tests");
			DirectoryHelper.SetCurrentDirectory(@"C:\Projects\finger\trunk\tests");
			Assert.AreEqual(@"C:\Projects\finger\trunk\tests", DirectoryHelper.GetCurrentDirectory());
		}
		
		[Test]
		public void TestGetFiles()
		{
			FileHelper.Attach(new FileManager());
			FileHelper.Create(@"C:\Projects\finger\trunk\tests\test.txt");
			Assert.AreEqual(1, DirectoryHelper.GetFiles(@"C:\Projects\finger\trunk\tests", "test.txt").Length);
		}
		
		[Test]
		public void TestGetFilesWithoutDirectories()
		{
            //DirectoryHelper.DeleteDirectory(@"C:\Projects\finger\trunk\tests");
            //FileHelper.Attach(new FileManager());
            //Assert.AreEqual(0, DirectoryHelper.GetFiles(@"C:\Projects\finger\trunk\tests", "test.txt").Length);
            //DirectoryHelper.DeleteDirectory(@"C:\Projects\finger\trunk\tests");
            string testDir = Path.Combine(trunkDir[0], "tests2");
            DirectoryHelper.DeleteDirectory(testDir);
			FileHelper.Attach(new FileManager());
            Assert.AreEqual(0, DirectoryHelper.GetFiles(testDir, "test.txt").Length);
            DirectoryHelper.DeleteDirectory(testDir);
		}
		
		[Test]
		public void TestGetFilesOnNullManager()
		{
			DirectoryHelper.Attach(null);
            Assert.That(() => Assert.AreEqual(2, DirectoryHelper.GetFiles(@"C:\Projects\finger\trunk\tests", "*.txt").Length),
                Throws.TypeOf<ArgumentNullException>());

            DirectoryHelper.Attach(new DirectoryManager());
		}
		
		[Test]
		public void TestExistsOnNullManager()
		{
			DirectoryHelper.Attach(null);
            Assert.That(() => Assert.IsTrue(DirectoryHelper.Exists(@"C:\Projects\finger\trunk\tests")),
                Throws.TypeOf<ArgumentNullException>());

            DirectoryHelper.Attach(new DirectoryManager());
		}
		
		[Test]
		public void TestCreateOnNullManager()
		{
			DirectoryHelper.Attach(null);
            Assert.That(() => DirectoryHelper.CreateDirectory(@"C:\Projects\finger\trunk\tests"),
                Throws.TypeOf<ArgumentNullException>());

            DirectoryHelper.Attach(new DirectoryManager());
		}
		
		[Test]
		public void TestDeleteOnNullManager()
		{
			DirectoryHelper.Attach(null);
            Assert.That(() => DirectoryHelper.DeleteDirectory(@"C:\Projects\finger\trunk\tests"),
                Throws.TypeOf<ArgumentNullException>());

            DirectoryHelper.Attach(new DirectoryManager());
		}
		
		[Test]
		public void TestIOHelperReadAllLine()
		{
            string testFile = Path.Combine(trunkDir[0], @"scripts\2013-03-05 08.37.58.274 - TestPickListPopularSameItemCode\psx_LaunchPadNet.log");
			//Assert.IsNotNull(IOHelper.ReadAllLines(@"C:\Projects\Finger\trunk\scripts\2013-03-05 08.37.58.274 - TestPickListPopularSameItemCode\psx_LaunchPadNet.log"));
            Assert.IsNotNull(IOHelper.ReadAllLines(testFile));
		}
		
		[Test]
		public void TestIOHelperCtor()
		{
			IOHelper h = new IOHelper();
		}
		
		[Test]
		public void TestIOHelper2()
		{
            Assert.That(() => IOHelper.ReadAllLines("FileNotFound.log"),
                Throws.TypeOf<FileNotFoundException>());
		}
	}
}
