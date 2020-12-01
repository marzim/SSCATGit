//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Repositories;
using Sscat.Core.Repositories.IO;

namespace Sscat.Tests.Repositories
{
	[TestFixture]
	public class ConfigFileRepositoryTests
	{
		IOConfigFileRepository repository;
		string f = @"C:\Projects\finger\trunk\tests\scotopts.000";
		string f2 = @"C:\Projects\finger\trunk\tests\scotopts.001";
		string f3 = @"C:\Projects\finger\trunk\tests\scotopts.002";
		string dir = @"C:\Projects\finger\trunk\tests";
		
		[SetUp]
		public void Setup()
		{
			FileHelper.Attach(new FileManager());
			DirectoryHelper.Attach(new DirectoryManager());
			DirectoryHelper.CreateDirectory(dir);
			
			FileHelper.Create(f, "hello world");
			
			repository = new IOConfigFileRepository();
			repository.Accessing += new EventHandler<NcrEventArgs>(RepositoryAccessing);
			repository.CheckOnServer += new EventHandler<ConfigFileEventArgs>(RepositoryCheckOnServer);
			repository.LoadOnServer += new EventHandler<ConfigFileEventArgs>(RepositoryLoadOnServer);
		}
		
		[TearDown]
		public void Teardown()
		{
			repository.Accessing -= new EventHandler<NcrEventArgs>(RepositoryAccessing);
			FileHelper.Delete(f);
			FileHelper.Delete(f2);
		}
		
		[Test]
		public void TestDiffers()
		{
			ConfigFile c = ConfigFile.Deserialize(new StringReader(@"<File Name='scotopts.000' Exists='true' Destination='C:\Projects\finger\trunk\tests'/>"));
			Assert.IsTrue(repository.Differs(c, @"C:\Projects\finger\trunk\tests", @"C:\Projects\finger\trunk\tests"));
		}
		
		[Test]
		public void TestLoad()
		{
			ConfigFile c = ConfigFile.Deserialize(new StringReader(@"<File Name='scotopts.000' Exists='true' Destination='C:\Projects\finger\trunk\tests'/>"));
			repository.Load(c, @"C:\Projects\finger\trunk\tests\", @"C:\Projects\finger\trunk\tests");
		}
		
		[Test]
		public void TestCreate()
		{
			DirectoryHelper.DeleteDirectory(dir);
			ConfigFile c = ConfigFile.Deserialize(new StringReader(@"<File Name='scotopts.000' Exists='true' Destination='C:\Projects\finger\trunk\tests'/>"));
			repository.Create(c);
		}
		
		[Test]
		public void TestCreateWithHost()
		{
			DirectoryHelper.DeleteDirectory(dir);
			ConfigFile c = ConfigFile.Deserialize(new StringReader(@"<File Name='scotopts.000' Host='g2lane-ian' Exists='true' Destination='C:\Projects\finger\trunk\tests'/>"));
			repository.Create(c);
		}
		
		[Test]
		public void TestCreateNonExistentFile()
		{
			DirectoryHelper.DeleteDirectory(dir);
			ConfigFile c = ConfigFile.Deserialize(new StringReader(@"<File Name='scotopts.000' Destination='C:\Projects\finger\trunk\tests'/>"));
			repository.Create(c);
		}
		
		[Test]
		public void TestCreateNonExistentFileWithHost()
		{
			DirectoryHelper.DeleteDirectory(dir);
			ConfigFile c = ConfigFile.Deserialize(new StringReader(@"<File Name='scotopts.000' Host='g2lane-ian' Destination='C:\Projects\finger\trunk\tests'/>"));
			repository.Create(c);
		}
		
		[Test]
		public void TestRead()
		{
			ConfigFile c = ConfigFile.Deserialize(new StringReader(@"<File Name='scotopts.000' Host='g2lane-ian' Source='C:\Projects\finger\trunk\tests'/>"));
			repository.Read(c);
			Assert.AreEqual("hello world", c.Content);
		}
		
		[Test]
		public void TestReadOnNotFound()
		{
			FileHelper.Delete(f3);
			ConfigFile c = ConfigFile.Deserialize(new StringReader(@"<File Name='scotopts.002' Source='C:\Projects\finger\trunk\tests'/>"));
			repository.Read(c);
			Assert.IsFalse(c.Exists);
			Assert.AreEqual("", c.Content);
		}
		
		[Test]
		public void TestReadName()
		{
			ConfigFile c = ConfigFile.Deserialize(new StringReader(@"<File Name='scotopts.000'/>"));
			repository.Read(@"C:\Projects\finger\trunk\tests", c);
			Assert.AreEqual("hello world", c.Content);
		}
		
		[Test]
		public void TestReadNameOnNotFound()
		{
			FileHelper.Delete(f3);
			ConfigFile c = ConfigFile.Deserialize(new StringReader(@"<File Name='scotopts.002' Exists='true'/>"));
			repository.Read(@"C:\Projects\finger\trunk\tests", c);
			Assert.IsFalse(c.Exists);
			Assert.IsEmpty(c.Content);
		}
		
		[Test]
		public void TestReadFileName()
		{
			ConfigFile c = repository.Read(f);
			Assert.AreEqual("hello world", c.Content);
		}
		
		[Test]
		public void TestReadFileNameOnDirectoryNotFound()
		{
			DirectoryHelper.DeleteDirectory(dir);
			ConfigFile c;
            Assert.That(() => c = repository.Read(f), Throws.TypeOf<DirectoryNotFoundException>());
		}
		
		[Test]
		public void TestReadFileNameOnFileNotFound()
		{
			FileHelper.Delete(f3);
			ConfigFile c = repository.Read(f3);
		}
		
		[Test]
		public void TestExists()
		{
			Assert.IsTrue(repository.Exists(f));
		}
		
		[Test]
		public void TestRename()
		{
			repository.Rename(f, f2);
		}

		void RepositoryLoadOnServer(object sender, ConfigFileEventArgs e)
		{
		}

		void RepositoryCheckOnServer(object sender, ConfigFileEventArgs e)
		{
		}

		void RepositoryAccessing(object sender, NcrEventArgs e)
		{
		}
	}
	
	public class ConfigFileRepositoryStub : IOConfigFileRepository
	{
		public override void Create(ConfigFile file)
		{
//			OnAccessing(Path.Combine(file.Destination, file.Name));
		}
		
		public override bool Exists(string file)
		{
			return file.Contains("notexists") ? false : true;
		}
		
		public override void Rename(string source, string dest)
		{
			OnAccessing(string.Format("Copying {0} to {1}", source, dest));
		}
		
		public override void Read(ConfigFile file)
		{
			OnAccessing(string.Format("Reading {0}", file.Name));
			file.Content = "hello world";
		}
		
		public override void Read(string name, ConfigFile file)
		{
			file.Name = name;
			Read(file);
		}
		
		public override ConfigFile Read(string file)
		{
			ConfigFile f = new ConfigFile();
			f.Exists = true;
			f.Content = "hello world";
			return f;
		}
	}
}
