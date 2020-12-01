//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class FileManagerTests
	{
		FileManager m;
		string dir;
        string testDir;
		string iniTestFileDir;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
            // Get the working directory so that it will work running in local machine or in build machine
            string debugDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] trunkDir = debugDir.Split(new[] { "src" }, StringSplitOptions.None);

			m = new FileManager();
			//dir = @"C:\Projects\finger\trunk\logs";
			//iniTestFileDir = @"C:\Projects\Finger\trunk\scripts\Artifacts";
            dir = Path.Combine(trunkDir[0], "logs");
            testDir = Path.Combine(trunkDir[0], @"scripts\Artifacts\testDir");
            iniTestFileDir = Path.Combine(trunkDir[0], @"scripts\Artifacts");
			
			FileHelper.Attach(m);
			DirectoryHelper.Attach(new DirectoryManager());
			m.Create(Path.Combine(dir, "test.log"));
		}

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            m.Delete(Path.Combine(dir, "test.log"));
        }
		
		[Test]
		public void TestGetFileVersion()
		{
			Assert.AreEqual("0.0.0.0", m.GetFileVersion(Path.Combine(dir, "test.log")).ToString());
		}
		
		[Test]
		public void TestValidFileName()
		{
			Assert.IsTrue(m.ValidFileName("test"));
			Assert.IsFalse(m.ValidFileName("test:"));
		}
		
		[Test]
		public void TestDelete()
		{
			m.Delete(Path.Combine(dir, "test.log"));
            Assert.IsFalse(m.Exists(Path.Combine(dir, "test.log")));
            m.Create(Path.Combine(dir, "test.log"));
		}
		
		[Test]
		public void TestDeleteAll()
		{
			//string testDir = @"C:\Projects\Finger\trunk\scripts\Artifacts\testDir";
			m.Create(Path.Combine(testDir, "testDeleteAll.log"));
			m.Create(Path.Combine(testDir, "testDeleteAll1.log"));
			m.DeleteAll(testDir);
			
			Assert.IsFalse(m.Exists(Path.Combine(testDir, "testDeleteAll.log")));
			Assert.IsFalse(m.Exists(Path.Combine(testDir, "testDeleteAll1.log")));
			DirectoryHelper.DeleteDirectory(testDir);
		}
		
		[Test]
		public void TestCreate()
		{
			Assert.IsTrue(m.Exists(Path.Combine(dir, "test.log")));
		}
		
		[Test]
		public void TestCopy()
		{
			m.Copy(Path.Combine(dir, "test.log"), Path.Combine(dir, "test2.log"));
			Assert.IsTrue(m.Exists(Path.Combine(dir, "test2.log")));
		}
		
		[Test]
		public void TestCopyOnNotFound()
		{
			FileHelper.Delete(Path.Combine(dir, "test.log"));
            Assert.That(() => m.Copy(Path.Combine(dir, "test.log"), Path.Combine(dir, "test2.log")),
               Throws.TypeOf<Exception>());
            m.Create(Path.Combine(dir, "test.log"));
        }
		
		[Test]
		public void TestCopyOnDirectoryNotFound()
		{
			DirectoryHelper.DeleteDirectory(dir);
            Assert.That(() => m.Copy(Path.Combine(dir, "test.log"), Path.Combine(dir, "test2.log")),
               Throws.TypeOf<Exception>());
		}
		
		[Test]
		public void TestReadToEnd()
		{
			Assert.AreEqual("", m.ReadToEnd(Path.Combine(dir, "test.log")));
		}
		
		[Test]
		public void TestGetExtension()
		{
			Assert.AreEqual("", FileHelper.GetExtension(m.ReadToEnd(Path.Combine(dir, "test.log"))));
		}
		
		[Test]
		public void TestGetIniValue()
		{
			Assert.AreEqual("-1,-5,-10,-25,100,500,1000,2000", m.GetIniValue("Locale", "CashValueList", Path.Combine(iniTestFileDir, "Test.ini")));
			Assert.AreEqual("", m.GetIniValue("InvalidSection", "CashValueList", Path.Combine(iniTestFileDir, "Test.ini")));
			Assert.AreEqual("", m.GetIniValue("Locale", "InvalidKeyName", Path.Combine(iniTestFileDir, "Test.ini")));
			Assert.AreEqual("Y", m.GetIniValue("Locale", "CashManagementScreen", Path.Combine(iniTestFileDir, "Test.ini")));
		}
		
		[Test]
		public void TestWriteIniValue()
		{
			m.WriteIniValue("TestSection", "TestKey", "TestKeyName", Path.Combine(iniTestFileDir, "Test.ini"));
			Assert.AreEqual("TestKeyName", m.GetIniValue("TestSection", "TestKey", Path.Combine(iniTestFileDir, "Test.ini")));
		}
	}
}
