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
	public class FileHelperTests
	{
		string iniTestFileDir;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
            // Get the working directory so that it will work running in local machine or in build machine
            string debugDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] trunkDir = debugDir.Split(new[] { "src" }, StringSplitOptions.None);

			//iniTestFileDir = @"C:\Projects\Finger\trunk\scripts\Artifacts";
            iniTestFileDir = Path.Combine(trunkDir[0], @"scripts\Artifacts");
			
			FileHelper.Attach(new FileManagerStub());
		}
		
		[Test]
		public void TestCreate()
		{
			FileHelper.Create(@"C:\File.txt");
		}
		
		[Test]
		public void TestCreateOnNullManager()
		{
			FileHelper.Attach(null);
            Assert.That(() => FileHelper.Create(@"C:\File.txt"),
               Throws.TypeOf<ArgumentNullException>());
			   
            FileHelper.Attach(new FileManagerStub());
		}
		
		[Test]
		public void TestReadToEnd()
		{
			Assert.AreEqual("Chuck Norris", FileHelper.ReadToEnd(@"C:\test.txt"));
		}
		
		[Test]
		public void TestReadToEndOnNullManager()
		{
			FileHelper.Attach(null);
            Assert.That(() => Assert.AreEqual("Chuck Norris", FileHelper.ReadToEnd(@"C:\test.txt")),
               Throws.TypeOf<ArgumentNullException>());
			   
            FileHelper.Attach(new FileManagerStub());
		}
		
		[Test]
		public void TestGetExtension()
		{
			Assert.AreEqual("", FileHelper.GetExtension(@"C:\test.exe"));
		}
		
		[Test]
		public void TestGetExtensionOnNullManager()
		{
			FileHelper.Attach(null);
            Assert.That(() => Assert.AreEqual("", FileHelper.GetExtension(@"C:\test.exe")),
               Throws.TypeOf<ArgumentNullException>());
			   
            FileHelper.Attach(new FileManagerStub());
		}
		
		[Test]
		public void TestCopy()
		{
			FileHelper.Copy(@"C:\Source.File", @"C:\Destination.File");
			Assert.IsTrue(FileHelper.Exists(@"C:\Destination.File"));
		}
		
		[Test]
		public void TestCopyOnNullManager()
		{
			FileHelper.Attach(null);
            Assert.That(() => FileHelper.Copy(@"C:\Source.File", @"C:\Destination.File"),
               Throws.TypeOf<ArgumentNullException>());
			   
            FileHelper.Attach(new FileManagerStub());
		}
		
		[Test]
		public void TestGetFileVersion()
		{
			Assert.AreEqual("3.0.0.0", FileHelper.GetFileVersion("test.exe").ToString());
		}
		
		[Test]
		public void TestGetFileVersionOnNullManager()
		{
			FileHelper.Attach(null);
            Assert.That(() => Assert.AreEqual("3.0.0.0", FileHelper.GetFileVersion("test.exe")),
               Throws.TypeOf<ArgumentNullException>());
			   
            FileHelper.Attach(new FileManagerStub());
		}
		
		[Test]
		public void TestDelete()
		{
			FileHelper.Delete(@"C:\Not.Found");
			Assert.IsFalse(FileHelper.Exists(@"C:\Not.Found"));
		}
		
		[Test]
		public void TestDeleteOnNullManager()
		{
			FileHelper.Attach(null);
            Assert.That(() => FileHelper.Delete(@"C:\Not.Found"),
               Throws.TypeOf<ArgumentNullException>());
			   
            FileHelper.Attach(new FileManagerStub());
		}
		
		[Test]
		public void TestDeleteAll()
		{
			FileHelper.DeleteAll(@"C:\Not.Found");
			Assert.IsFalse(FileHelper.Exists(@"C:\Not.Found"));
		}
		
		[Test]
		public void TestDeleteAllOnNullManager()
		{
			FileHelper.Attach(null);
            Assert.That(() => FileHelper.DeleteAll(@"C:\Not.Found"),
               Throws.TypeOf<ArgumentNullException>());
			   
            FileHelper.Attach(new FileManagerStub());
		}
		
		[Test]
		public void TestExists()
		{
			Assert.IsTrue(FileHelper.Exists(@"C:\Projects\finger\trunk\config\ClientConfiguration.xml"));
		}
		
		[Test]
		public void TestExistsOnNullManager()
		{
			FileHelper.Attach(null);
            Assert.That(() => Assert.IsTrue(FileHelper.Exists(@"C:\Projects\finger\trunk\config\ClientConfiguration.xml")),
               Throws.TypeOf<ArgumentNullException>());
			   
            FileHelper.Attach(new FileManagerStub());
		}
		
		[Test]
		public void TestValidFileName()
		{
			Assert.IsTrue(FileHelper.ValidFileName("test"));
		}
		
		[Test]
		public void TestValidFileNameOnNullManager()
		{
			FileHelper.Attach(null);
            Assert.That(() => Assert.IsTrue(FileHelper.ValidFileName("test")),
               Throws.TypeOf<ArgumentNullException>());
			   
            FileHelper.Attach(new FileManagerStub());
		}
		
		[Test]
		public void TestGetIniValue()
		{
			Assert.AreEqual("-1,-5,-10,-25,100,500,1000,2000", FileHelper.GetIniValue("Locale", "CashValueList", Path.Combine(iniTestFileDir, "Test.ini")));
		}
		
		[Test]
		public void TestGetIniValueOnNullManager()
		{
			FileHelper.Attach(null);
            Assert.That(() => Assert.AreEqual("-1,-5,-10,-25,100,500,1000,2000", FileHelper.GetIniValue("Locale", "CashValueList", Path.Combine(iniTestFileDir, "Test.ini"))),
               Throws.TypeOf<ArgumentNullException>());
			   
            FileHelper.Attach(new FileManagerStub());
		}
		
		[Test]
		public void TestWriteIniValue()
		{
			FileHelper.WriteIniValue("TestSection", "TestKey", "TestKeyName", Path.Combine(iniTestFileDir, "Test.ini"));
			Assert.AreEqual("TestKeyName", FileHelper.GetIniValue("TestSection", "TestKey", Path.Combine(iniTestFileDir, "Test.ini")));
		}
		
		[Test]
		public void TestWriteIniValueOnNullManager()
		{
			FileHelper.Attach(null);
            Assert.That(() => FileHelper.WriteIniValue("TestSection", "TestKey", "TestKeyName", Path.Combine(iniTestFileDir, "Test.ini")),
               Throws.TypeOf<ArgumentNullException>());
			   
            FileHelper.Attach(new FileManagerStub());
		}

        [Test]
        public void TestSetDumpProductVersion()
        {
            string expectedValue = "6.0.3";
            string testFile = "C:\\NCRRegDump.txt";
            string testVersionText = "\"Release Version\"=\"6.0.3\"";
            if (!File.Exists(testFile))
            {
                FileStream stream = File.Create(testFile);
                stream.Close();
            }
            File.WriteAllText(@testFile, testVersionText);
            string dumpFileLocation = testFile;
            FileHelper.SetDumpProductVersion(dumpFileLocation);
            Assert.AreEqual(expectedValue, FileHelper.DumpProductVersion);
        }

        [Test]
        public void TestGetDumpProductVersion()
        {
            string testValue = "6.0.3";
            FileHelper.DumpProductVersion = testValue;
            string dumpProdVersion = FileHelper.GetDumpProductVersion();
            Assert.AreEqual(testValue, dumpProdVersion);
        }
	}
}
