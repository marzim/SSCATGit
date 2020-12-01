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
	public class ZipManagerTests
	{
		ZipManager zm;
		string zipFileName;
		string zipFileNameWithPassword;
		string sevenZipFileName;
		string sevenZipUnicodeFileName;
		string sevenZipAnsiFileName;
		string destinationFolder;
		string sourceDirectory;
		
		[SetUp]
		public void Setup()
		{
			FileHelper.Attach(new FileManager());
			ProcessUtility.Attach(new ProcessManager());
			DirectoryHelper.Attach(new DirectoryManager());
			
			zm = new ZipManager();

            string debugDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] trunkDir = debugDir.Split(new[] { "src" }, StringSplitOptions.None);

            zipFileName = System.IO.Path.Combine(trunkDir[0], @"scripts\Artifacts\ZipManagerTests\TestZip.zip");
            zipFileNameWithPassword = System.IO.Path.Combine(trunkDir[0], @"scripts\Artifacts\ZipManagerTests\TestZipWithPassword.zip");
            sevenZipFileName = System.IO.Path.Combine(trunkDir[0], @"scripts\Artifacts\ZipManagerTests\Test7Zip.7z");
            sevenZipUnicodeFileName = System.IO.Path.Combine(trunkDir[0], @"scripts\Artifacts\ZipManagerTests\Test7ZipUnicode.zip");
            sevenZipAnsiFileName = System.IO.Path.Combine(trunkDir[0], @"scripts\Artifacts\ZipManagerTests\Test7ZipAnsi.zip");
            destinationFolder = System.IO.Path.Combine(trunkDir[0], @"scripts\Artifacts\ZipManagerTests\TestZips");
            sourceDirectory = System.IO.Path.Combine(trunkDir[0], @"scripts\Artifacts\ZipManagerTests\TestZip");

            //zipFileName = @"C:\Projects\Finger\trunk\scripts\Artifacts\ZipManagerTests\TestZip.zip";
            //zipFileNameWithPassword = @"C:\Projects\Finger\trunk\scripts\Artifacts\ZipManagerTests\TestZipWithPassword.zip";
            //sevenZipFileName = @"C:\Projects\Finger\trunk\scripts\Artifacts\ZipManagerTests\Test7Zip.7z";
            //sevenZipUnicodeFileName = @"C:\Projects\Finger\trunk\scripts\Artifacts\ZipManagerTests\Test7ZipUnicode.zip";
            //sevenZipAnsiFileName = @"C:\Projects\Finger\trunk\scripts\Artifacts\ZipManagerTests\Test7ZipAnsi.zip";
            //destinationFolder = @"C:\Projects\Finger\trunk\scripts\Artifacts\ZipManagerTests\TestZips";
            //sourceDirectory = @"C:\Projects\Finger\trunk\scripts\Artifacts\ZipManagerTests\TestZip";
		}
		
		[TearDown]
		public void Teardown()
		{
			FileHelper.Delete(zipFileName);
			FileHelper.DeleteAll(destinationFolder);
			DirectoryHelper.DeleteDirectory(destinationFolder);
		}

		[Test]
		public void TestCompressFolder()
		{
			zm.CompressFolder(zipFileName, sourceDirectory);
			Assert.IsTrue(FileHelper.Exists(zipFileName));
			
			FileHelper.Delete(zipFileName);
		}
		
		[Test]
		public void TestExtractZip()
		{
			zm.CompressFolder(zipFileName, sourceDirectory);
			zm.Extract(zipFileName, destinationFolder, "", "SM.log");
			Assert.IsTrue(FileHelper.Exists(string.Format(@"{0}\SM.log", destinationFolder)));
			
			FileHelper.Delete(zipFileName);
			FileHelper.DeleteAll(destinationFolder);
			DirectoryHelper.DeleteDirectory(destinationFolder);
		}
		
		[Test]
		public void TestExtractZip2()
		{
			zm.CompressFolder(zipFileName, sourceDirectory);
			zm.Extract(zipFileName, destinationFolder, "", "SM.log", "SM.log");
			Assert.IsTrue(FileHelper.Exists(string.Format(@"{0}\SM.log", destinationFolder)));
			
			FileHelper.Delete(zipFileName);
			FileHelper.DeleteAll(destinationFolder);
			DirectoryHelper.DeleteDirectory(destinationFolder);
		}
		
		[Test]
		public void TestExtractZipWithPassword()
		{
			zm.Extract(zipFileNameWithPassword, destinationFolder, "password", "psx_LaunchPadNet.log");
			Assert.IsTrue(FileHelper.Exists(string.Format(@"{0}\psx_LaunchPadNet.log", destinationFolder)));
			
			FileHelper.Delete(zipFileName);
			FileHelper.DeleteAll(destinationFolder);
			DirectoryHelper.DeleteDirectory(destinationFolder);
		}
		
		[Test]
		public void TestExtract7ZipUnicode()
		{
			zm.Extract(sevenZipUnicodeFileName, destinationFolder, "", "psx_ScotAppU.log", "Psx");
			Assert.IsTrue(FileHelper.Exists(string.Format(@"{0}\psx_ScotAppU.log", destinationFolder)));
			
			FileHelper.DeleteAll(destinationFolder);
			DirectoryHelper.DeleteDirectory(destinationFolder);
		}
		
		[Test]
		public void TestExtract7ZipAnsi()
		{
			zm.Extract(sevenZipAnsiFileName, destinationFolder, "", "psx_ScotApp.log", "Psx");
			Assert.IsTrue(FileHelper.Exists(string.Format(@"{0}\psx_ScotApp.log", destinationFolder)));
			
			FileHelper.DeleteAll(destinationFolder);
			DirectoryHelper.DeleteDirectory(destinationFolder);
		}
		
		[Test]
		public void TestExtract7Zip()
		{
			zm.Extract(sevenZipFileName, destinationFolder, "", "psx_ScotAppU.log", "Psx");
			Assert.IsTrue(FileHelper.Exists(string.Format(@"{0}\psx_ScotAppU.log", destinationFolder)));
			
			FileHelper.DeleteAll(destinationFolder);
			DirectoryHelper.DeleteDirectory(destinationFolder);
		}
		
		[Test]
		public void TestApplication7ZipNotFoundException()
		{
			FileHelper.Attach(new F());
            Assert.That(() => zm.Extract(sevenZipUnicodeFileName, destinationFolder, "", "psx_ScotAppU.log", "Psx"),
                Throws.TypeOf<Application7ZipNotFoundException>());
		}
		
		class F : FileManagerStub
		{
			public override bool Exists(string path)
			{
				return false;
			}
		}
	}
}
