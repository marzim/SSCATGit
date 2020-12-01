//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Models;
using Sscat.Core.Services;
using Sscat.Tests.Config;
using Sscat.Tests.Repositories;
using Sscat.Tests.Util;

namespace Sscat.Tests.Services
{
	[TestFixture]
	public class ClientServiceTests
	{
		ClientService service;
		LaneConfiguration config;
		
		[SetUp]
		public void Setup()
		{
			service = new ClientService(
				new ClientConfigurationRepositoryStub(),
				new ConfigFilesRepositoryStub(),
				new ConfigFileRepositoryStub(),
				new ScriptRepositoryStub(),
				new CpuAndMemoryLoggerStub()
			);
			
			config = new LaneConfigurationRepositoryStub().Read("");
		}
		
		[Test]
		public void TestPreparePlayerConfiguration()
		{
			service.PreparePlayerConfiguration(config.PlayerConfiguration, new ScriptFile(""));
		}
		
		[Test]
		public void TestReadConfigFiles()
		{
			service.ReadConfigFiles("", config.Files);
		}
		
		[Test]
		public void TestReadScript()
		{
			service.ReadScript("");
		}
		
		[Test]
		public void TestSaveClientConfiguration()
		{
			service.SaveClientConfiguration(new ClientConfigurationRepositoryStub().Read(""));
		}
		
		[Test]
		public void TestReadClientConfiguration()
		{
			service.ReadClientConfiguration("");
		}
		
		[Test]
		public void TestSaveScripts()
		{
			service.SaveScripts(new IScript[] { new Script() });
		}
		
		[Test]
		public void TestCreateConfigFiles()
		{
			foreach (ConfigFile file in config.Files.Files) {
				file.Destination = config.Files.DestinationDirectory;
			}
			service.CreateConfigFiles(config.Files);
		}
		
		[Test]
		public void TestStartLogger()
		{
			service.StartLogger();
		}
		
		[Test]
		public void TestStopLogger()
		{
			service.StopLogger();
		}
	}
}
