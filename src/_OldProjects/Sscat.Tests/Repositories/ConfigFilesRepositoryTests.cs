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
using Sscat.Core.Config;
using Sscat.Core.Repositories;
using Sscat.Core.Repositories.IO;

namespace Sscat.Tests.Repositories
{
	[TestFixture]
	public class ConfigFilesRepositoryTests
	{
		IOConfigFilesRepository repository;
		ConfigFiles files;
		
		[SetUp]
		public void Setup()
		{
			DnsHelper.Attach(new DnsManagerStub());
			
			repository = new IOConfigFilesRepository();
			files = ConfigFiles.Deserialize(new StringReader(@"<Files Destination='C:\Projects\finger\trunk\ScotConfig' Source='C:\Projects\finger\trunk\ScotConfig'>
	<File Name='test.txt'/>
	<File Name='test2.xml' Host='g2lane-ian' DifferentFromScotConfig='true'/>
</Files>"));
			FileHelper.Create(@"C:\Projects\finger\trunk\ScotConfig\test\test.txt", "hello world");
			
			repository.CheckConfigOnServer += new EventHandler<ConfigFileEventArgs>(RepositoryCheckConfigOnServer);
			repository.LoadConfigOnServer += new EventHandler<ConfigFileEventArgs>(RepositoryLoadConfigOnServer);
			repository.CopyConfigOnServer += new EventHandler<ConfigFileEventArgs>(RepositoryCopyConfigOnServer);
		}
		
		[TearDown]
		public void Teardown()
		{
			repository.CheckConfigOnServer -= new EventHandler<ConfigFileEventArgs>(RepositoryCheckConfigOnServer);
			repository.LoadConfigOnServer -= new EventHandler<ConfigFileEventArgs>(RepositoryLoadConfigOnServer);

			DirectoryHelper.DeleteDirectory(@"C:\Projects\finger\trunk\ScotConfig");
		}
		
		[Test]
		public void TestManage()
		{
			repository.Get(files, "test");
		}
		
		[Test]
		public void TestDiffersFromScotConfig()
		{
			Assert.IsTrue(repository.DiffersFromScotConfig(files));
		}
		
		[Test]
		public void TestStop()
		{
			repository.Stop();
		}
		
		[Test]
		public void TestLoad()
		{
			repository.Load(files);
		}
		
		[Test]
		public void TestReadConfiguration()
		{
			repository.Read(@"C:\Projects\finger\trunk\ScotConfig\test", files);
			Assert.IsFalse(files.None);
			ConfigFile f1 = files.Files[0];
			Assert.AreEqual("hello world", f1.Content);
			ConfigFile f2 = files.Files[1];
			Assert.IsFalse(f2.Exists);
		}
		
		[Test]
		public void TestReadNoConfiguration()
		{
			repository.Read(@"C:\Projects\finger\trunk\ScotConfig\qwerty", files);
			Assert.IsTrue(files.None);
		}

		void RepositoryCopyConfigOnServer(object sender, ConfigFileEventArgs e)
		{
		}

		void RepositoryLoadConfigOnServer(object sender, ConfigFileEventArgs e)
		{
		}

		void RepositoryCheckConfigOnServer(object sender, ConfigFileEventArgs e)
		{
		}
	}
	
	public class ConfigFilesRepositoryStub : IOConfigFilesRepository
	{
		public ConfigFiles Read(string name, string[] files)
		{
			return ConfigFiles.Deserialize(new StringReader(@"<Files Name='ConfigFiles' Source='C:\scot\config' Destination='C:\SSCAT\ScotConfig'>
		<File Name='Scotopts.dat' Host='test' DifferentFromScotConfig='true'/>
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
		}
		
		public override IConfigFileRepository CreateConfigFileRepository()
		{
			return new ConfigFileRepositoryStub();
		}
		
		public override void Get(ConfigFiles files, string configName)
		{
//			base.Get(files, configName);
		}
	}
}
