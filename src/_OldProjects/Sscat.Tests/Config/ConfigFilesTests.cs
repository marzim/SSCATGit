//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using System.Net.Sockets;
using Ncr.Core;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Config;
using Sscat.Core.Repositories;

namespace Sscat.Tests.Config
{
	[TestFixture]
	public class ConfigFilesTests
	{
		ConfigFiles files;
		
		[OneTimeSetUp]
		public void Setup()
		{
			DnsHelper.Attach(new DnsManagerStub());
			files = ConfigFiles.Deserialize(new StringReader(@"<Files Source='C:\scot\config' Destination='C:\SSCAT\ScotConfig' None='false'>
	            <File Name='Scotopts.dat' Host='g2lane-ian'/>
                <File Name='Scotopts.000' />
	            <File Name='Scotopts.001' />
	            <File Name='Scotopts.002' Exists='false'/>
                <File Name='Scottend.dat' />
	            <File Name='Scottend.000' />
                <File Name='SecurityConfig.xml' />
	            <File Name='SecurityConfig.000' />
	            <File Name='AssistMenuConfig.xml' />
	            <File Name='ScotTare.dat' />
	            <File Name='RCMConfig.xml' />
	            <File Name='RCMConfig.000' />
            </Files>"));
			
            //files.FileAdded += new EventHandler(FilesFileAdded);
		}
		
		//[OneTimeTearDown]
		//TODO: Either remove or fix empty teardown
		public void OneTimeTearDown()
		{
            //files.FileAdded -= new EventHandler(FilesFileAdded);
		}
		
		[Test]
		public void TestConstructorWithConfigFile()
		{
			ConfigFiles f = new ConfigFiles(new ConfigFile());
			Assert.AreEqual(1, f.Files.Length);
		}
		
		[Test]
		public void TestConstructorWithString()
		{
			ConfigFiles f = new ConfigFiles(@"C:\Projects\finger\trunk\test");
			Assert.AreEqual(@"C:\Projects\finger\trunk\test", f.DestinationDirectory);
		}
		
		[Test]
		public void TestFileLengthValue()
		{
            files = ConfigFiles.Deserialize(new StringReader(@"<Files Source='C:\scot\config' Destination='C:\SSCAT\ScotConfig' None='false'>
	            <File Name='Scotopts.dat' Host='g2lane-ian'/>
                <File Name='Scotopts.000' />
	            <File Name='Scotopts.001' />
	            <File Name='Scotopts.002' Exists='false'/>
                <File Name='Scottend.dat' />
	            <File Name='Scottend.000' />
                <File Name='SecurityConfig.xml' />
	            <File Name='SecurityConfig.000' />
	            <File Name='AssistMenuConfig.xml' />
	            <File Name='ScotTare.dat' />
	            <File Name='RCMConfig.xml' />
	            <File Name='RCMConfig.000' />
            </Files>"));
			Assert.AreEqual(12, files.Files.Length);
//			Assert.IsTrue(files.DiffersFromScotConfig(new ConfigFileRepositoryStub()));
		}

        [Test]
        public void TestFilesNameValue()
        {
            Assert.IsNull(files.Name); 
        }

        [Test]
        public void TestFilesSourceDirectoryValue()
        {
            Assert.AreEqual(@"C:\scot\config", files.SourceDirectory);
        }

        [Test]
        public void TestFilesDestinationDirectoryValue()
        {
            Assert.AreEqual(@"C:\SSCAT\ScotConfig", files.DestinationDirectory);
        }

        [Test]
        public void TestFilesExistValue()
        {
            Assert.IsFalse(files.None);
        }
		
		[Test]
		public void TestClear()
		{
			files.Clear();
		}
		
		[Test]
		public void TestRemoveFile()
		{
			ConfigFile x = new ConfigFile("test");
            int length = files.Files.Length;
			files.AddFile(x);
			Assert.AreEqual(length + 1, files.Files.Length);
			files.RemoveFile(x);
			Assert.AreEqual(length, files.Files.Length);
		}
		
		[Test]
		public void TestNullFiles()
		{
			files.Files = null;
			Assert.AreEqual(0, files.Files.Length);
		}
		
		[Test]
		public void TestSameConfigFiles()
		{
			ConfigFiles f = ConfigFiles.Deserialize(new StringReader(@"<Files Source='C:\scot\config' Destination='C:\SSCAT\ScotConfig'>
	            <File Name='Scotopts.000' Exists='true'>hello world</File>
            </Files>"));
            //f.Loading += delegate(object sender, SscatEventArgs e) {
            //	Console.WriteLine(e.Message);
            //};
            //Assert.IsFalse(f.DiffersFromScotConfig(new ConfigFileRepositoryStub()));
		}
		
		[Test]
		public void TestDiffersInExistenceInScot()
		{
			ConfigFiles f = ConfigFiles.Deserialize(new StringReader(@"<Files Source='C:\scot\config' Destination='C:\SSCAT\ScotConfig'>
	            <File Name='notexists' Exists='true'/>
            </Files>"));
            //f.Loading += delegate(object sender, SscatEventArgs e) {
            //	Console.WriteLine(e.Message);
            //};
            //Assert.IsTrue(f.DiffersFromScotConfig(new ConfigFileRepositoryStub()));
		}
		
		[Test]
		public void TestDiffersInExistence()
		{
			ConfigFiles f = ConfigFiles.Deserialize(new StringReader(@"<Files Source='C:\scot\config' Destination='C:\SSCAT\ScotConfig'>
	            <File Name='Scotopts.000' Exists='false'/>
            </Files>"));
            //f.Loading += delegate(object sender, SscatEventArgs e) {
            //	Console.WriteLine(e.Message);
            //};
            //Assert.IsTrue(f.DiffersFromScotConfig(new ConfigFileRepositoryStub()));
		}
		
		[Test]
		public void TestDiffersOnContent()
		{
			ConfigFiles f = ConfigFiles.Deserialize(new StringReader(@"<Files Source='C:\scot\config' Destination='C:\SSCAT\ScotConfig'>
	            <File Name='Scotopts.dat' Exists='true'/>
            </Files>"));
            //f.Loading += delegate(object sender, SscatEventArgs e) {
            //	Console.WriteLine(e.Message);
            //};
            //Assert.IsTrue(f.DiffersFromScotConfig(new ConfigFileRepositoryStub()));
		}
		
		[Test]
		public void TestLoad()
		{
			ConfigFiles f = ConfigFiles.Deserialize(new StringReader(@"<Files Source='C:\scot\config' Destination='C:\SSCAT\ScotConfig'>
	            <File Name='Scotopts.dat' Exists='true'/>
	            <File Name='Scotopts.000' Exists='true'/>
            </Files>"));
            //			f.Loading += delegate(object sender, SscatEventArgs e) {
            //				Console.WriteLine(e.Message);
            //			};
            //			f.Load(new ConfigFileRepositoryStub());
		}

		void FilesFileAdded(object sender, EventArgs e)
		{
		}
//
//		void FilesLoading(object sender, SscatEventArgs e)
//		{
//		}
//
//		void FilesLoadConfigOnServer(object sender, ConfigFileEventArgs e)
//		{
//		}
//
//		void FilesCheckConfigOnServer(object sender, ConfigFileEventArgs e)
//		{
//		}
	}
}
