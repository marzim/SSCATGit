//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Commands;
using Sscat.Core.Emulators;
using Sscat.Core.Services;
using Sscat.Tests.Commands.Psx;
using Sscat.Tests.Config;
using Sscat.Tests.Models;
using Sscat.Tests.Repositories;
using Sscat.Tests.Services;

namespace Sscat.Tests.Commands
{
	[TestFixture]
	public class CustomScriptGeneratorTests
	{
		SscatLane lane;
		LaneService service;
		CustomScriptGenerator command;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			lane = new SscatLane();
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			
			service = new LaneServiceStub(
				lane,
				new ScriptRepositoryStub(),
				new ConfigFileRepositoryStub(),
				new ConfigFilesRepositoryStub(),
				new PlayerConfigurationRepositoryStub(),
				new GeneratorConfigurationRepositoryStub(),
				new LaneConfigurationRepositoryStub(),
				new ReportRepositoryStub(),
				new PsxDisplayRepositoryStub(),
				null,
				null
			);			
		}
		
		[Test]
		public void TestEmptyConstructor()
		{
			command = new CustomScriptGenerator();
		}
		
		[Test]
		public void TestConstructor()
		{
			command = new CustomScriptGenerator(lane, service);
		}		
		
		[Test]
		public void TestRun()
		{
			Assert.That(() => command.Run(), Throws.TypeOf<System.IO.DirectoryNotFoundException>());
		}			
	}
}
