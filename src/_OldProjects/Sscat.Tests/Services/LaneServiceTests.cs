//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//		<owner name="Apple Leo Chiong" email="ac185120@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.IO;
using Ncr.Core;
using Ncr.Core.Models;
using Ncr.Core.Tests.Models;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Core.Repositories;
using Sscat.Core.Services;
using Sscat.Tests.Commands.Psx;
using Sscat.Tests.Config;
using Sscat.Tests.Emulators;
using Sscat.Tests.Models;
using Sscat.Tests.Repositories;
using Sscat.Tests.Util;

namespace Sscat.Tests.Services
{
	[TestFixture]
	public class LaneServiceTests
	{
		LaneService service;
		LaneConfiguration config;
		SscatLane lane;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			FileHelper.Attach(new FileManagerStub());
			ProcessUtility.Attach(new ProcessManagerStub(true, false, "SMAttract"));
			DnsHelper.Attach(new DnsManagerStub());
			
			lane = new SscatLaneStub();
			config = new LaneConfigurationRepositoryStub().Read("");
			
			service = new LaneService(
				lane,
				new ScriptRepositoryStub(),
				new ConfigFileRepositoryStub(),
				new ConfigFilesRepositoryStub(),
				new PlayerConfigurationRepositoryStub(),
				new GeneratorConfigurationRepositoryStub(),
				new LaneConfigurationRepositoryStub(),
				new ReportRepositoryStub(),
				new PsxDisplayRepositoryStub(),
				new CpuAndMemoryLoggerStub(),
				new CpuAndMemoryLoggerStub()
			);
			service.Servicing += new EventHandler<NcrEventArgs>(ServiceServicing);
			service.CheckConfigOnServer += new EventHandler<ConfigFileEventArgs>(ServiceCheckConfigOnServer);
			service.LoadConfigOnServer += new EventHandler<ConfigFileEventArgs>(ServiceLoadConfigOnServer);
			service.CopyConfigOnServer += new EventHandler<ConfigFileEventArgs>(ServiceCopyConfigOnServer);
			lane.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			service.Servicing -= new EventHandler<NcrEventArgs>(ServiceServicing);
			service.CheckConfigOnServer -= new EventHandler<ConfigFileEventArgs>(ServiceCheckConfigOnServer);
			service.LoadConfigOnServer -= new EventHandler<ConfigFileEventArgs>(ServiceLoadConfigOnServer);
			service.CopyConfigOnServer -= new EventHandler<ConfigFileEventArgs>(ServiceCopyConfigOnServer);
			lane.ConnectionAdding -= new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
		}
		
		[Test]
		public void TestGetConfiguration()
		{
			service.GetConfiguration(config.Files, "test");
		}
		
		[Test]
		public void TestGetConfigurationWithException()
		{
			service = new LaneService(
				lane,
				new ScriptRepositoryStub(),
				new ConfigFileRepositoryStub(),
				new C(),
				new PlayerConfigurationRepositoryStub(),
				new GeneratorConfigurationRepositoryStub(),
				new LaneConfigurationRepositoryStub(),
				new ReportRepositoryStub(),
				new PsxDisplayRepositoryStub(),
				new CpuAndMemoryLoggerStub(),
				new CpuAndMemoryLoggerStub()
			);
			Assert.That(() =>service.GetConfiguration(config.Files, "test"), 
                Throws.TypeOf<NotImplementedException>());
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
		
//		[Test]
//		public void TestCreateHooks()
//		{
//			service.CreateHooks();
//		}
//
//		[Test]
//		public void TestCreateParsers()
//		{
//			service.CreateParsers();
//		}
//
//		[Test]
//		//Deprecated in NUnit 3 
//		//[ExpectedException(typeof(Exception))]
//		public void TestCreatePsx()
//		{
//			service.CreatePsx("localhost", "FastLaneRemoteServer", "AUTOMATION", 100);
//		}
//
		[Test]
		public void TestLoadConfiguration()
		{
			ConfigFiles f = ConfigFiles.Deserialize(new StringReader(@"<Files>
	            <File Name='test.txt' Host='test' DifferentFromScotConfig='true'/>
            </Files>"));
			service.LoadConfiguration(f, true);
            //service.LoadConfiguration(f);
		}
		
		[Test]
		public void TestLoadConfigurationOnForceStop()
		{
			service.LoadConfiguration(config.Files, true);
            //service.LoadConfiguration(config.Files);
		}
		
		[Test]
		public void TestLoadConfigurationWithException()
		{
			ConfigFiles f = ConfigFiles.Deserialize(new StringReader(@"<Files>
	            <File Name='test.txt' Host='test' DifferentFromScotConfig='true'/>
            </Files>"));
			service = new LaneService(
				new L(),
				new ScriptRepositoryStub(),
				new ConfigFileRepositoryStub(),
				new ConfigFilesRepositoryStub(),
				new PlayerConfigurationRepositoryStub(),
				new GeneratorConfigurationRepositoryStub(),
				new LaneConfigurationRepositoryStub(),
				new ReportRepositoryStub(),
				new PsxDisplayRepositoryStub(),
				new CpuAndMemoryLoggerStub(),
				new CpuAndMemoryLoggerStub()
			);
			Assert.That(() => service.LoadConfiguration(f, true), Throws.TypeOf<NotImplementedException>());
            //service.LoadConfiguration(f);
		}

		[Test]
		public void TestGetScripts()
		{
			service.GetScripts(new string[] { });
		}
		
		[Test]
		public void TestSaveConfigFiles()
		{
			foreach (ConfigFile f in config.Files.Files) {
				f.Destination = config.Files.DestinationDirectory;
			}
			service.SaveConfigFiles(config.Files.Files);
		}

		[Test]
		public void TestReadScript()
		{
			service.ReadScript("");
		}
		
		[Test]
		public void TestSaveScripts()
		{
			service.SaveScripts(new IScript[] { });
		}
		
		[Test]
		public void TestReadConfigFiles()
		{
			service.ReadConfigFiles("", new ConfigFiles());
		}
		
		[Test]
		public void TestReadConfigFile()
		{
			service.ReadConfigFile(new ConfigFile());
		}
		
		[Test]
		public void TestReadGeneratorConfiguration()
		{
			service.ReadGeneratorConfiguration("");
		}
		
		[Test]
		public void TestReadPlayerConfiguration()
		{
			service.ReadPlayerConfiguration("");
		}
		
		[Test]
		public void TestReadLaneConfiguration()
		{
			service.ReadLaneConfiguration("");
		}
		
		[Test]
		public void TestSaveReportWithText()
		{
			service.SaveReport(new Report(), "");
		}
		
		[Test]
		public void TestSaveReport()
		{
			service.SaveReport(new Report());
		}
		
		[Test]
		public void TestLoadNoConfiguration()
		{
			config.Files.None = true;
			service.LoadConfiguration(config.Files, false);
            //service.LoadConfiguration(config.Files);
		}

		void ServiceCopyConfigOnServer(object sender, ConfigFileEventArgs e)
		{
		}

		void ServiceLoadConfigOnServer(object sender, ConfigFileEventArgs e)
		{
		}

		void ServiceCheckConfigOnServer(object sender, ConfigFileEventArgs e)
		{
		}

		void ServiceServicing(object sender, NcrEventArgs e)
		{
		}
		
		void LaneConnectionAdding(object sender, PsxWrapperEventArgs e)
		{
			lane.PsxConnections.Add(new N("localhost", "FastLaneRemoteServer", "AUTOMATION", 5000));
		}
		
		class C : ConfigFilesRepositoryStub
		{
			public override void Get(ConfigFiles files, string configName)
			{
				throw new NotImplementedException();
			}
		}
		
		class L : SscatLaneStub
		{
			public override void ForceKill()
			{
				throw new NotImplementedException();
			}
		}
		
		class N : PsxStub
		{
			public N(string host, string service, string connection, int timeout) : base(host, service, connection, timeout)
			{
			}
			
			public override object GetControlProperty(string controlName, string propertyName)
			{
				int i = 0;
				return i;
			}
		}
	}
	
	public class LaneServiceStub : LaneService
	{
		public LaneServiceStub(SscatLane lane, IScriptRepository scriptRepository, IConfigFileRepository configFileRepository, IConfigFilesRepository configFilesRepository, IPlayerConfigurationRepository playerConfigRepository, IGeneratorConfigurationRepository generatorConfigRepository, ILaneConfigurationRepository laneConfigRepository, IReportRepository reportRepository, IPsxDisplayRepository psxDisplayRepository, CpuAndMemoryLogger sscatLogger, CpuAndMemoryLogger scotLogger)
			: base(lane, scriptRepository, configFileRepository, configFilesRepository, playerConfigRepository, generatorConfigRepository, laneConfigRepository, reportRepository, psxDisplayRepository, sscatLogger, scotLogger)
		{
		}
		
		public override IPsx CreatePsx(string host, string service, string connection, int timeout)
		{
			return new PsxStub(host, service, connection, timeout);
		}
	}
}
