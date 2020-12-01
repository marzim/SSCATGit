//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using NUnit.Framework;
using Sscat.Commands;
using Sscat.Core.Controllers;
using Sscat.Core.Emulators;
using Sscat.Core.Parsers;
using Sscat.Core.Services;
using Sscat.Tests.Commands.Psx;
using Sscat.Tests.Config;
using Sscat.Tests.Models;
using Sscat.Tests.Repositories;

namespace Sscat.Tests.Controllers
{
	[TestFixture]
	public class ControllerFactoryTests
	{
		ConsoleControllerFactory factory;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			SscatLane lane = new SscatLane();
			LaneService service = new LaneService(
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
			lane.Configuration = service.ReadLaneConfiguration("");
			
			factory = new ConsoleControllerFactory(new string[] { }, lane, service);
		}
		
		[Test]
		public void TestCreateController()
		{
			Assert.IsInstanceOf(typeof(LaneController), factory.CreateController("Lane", 2));
		}
		
		[Test]
		public void TestCreateNullController()
		{
			Assert.IsNull(factory.CreateController("Qwerty", 2));
		}
	}
}
