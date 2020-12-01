//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Controllers;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Tests.Views;
using Ncr.Core.Util;
using Ncr.Core.Views;
using NUnit.Framework;
using Sscat.Commands;
using Sscat.Core;
using Sscat.Core.Commands.Gui;
using Sscat.Core.Config;
using Sscat.Core.Controllers;
using Sscat.Core.Emulators;
using Sscat.Core.Parsers;
using Sscat.Core.Services;
using Sscat.Tests.Commands.Psx;
using Sscat.Tests.Config;
using Sscat.Tests.Models;
using Sscat.Tests.Repositories;
using Sscat.Tests.Services;
using Sscat.Views;

namespace Sscat.Tests.Commands.Gui
{
	[TestFixture]
	public class GenerateScriptsTests
	{
		GenerateScripts command;
		LaneService service;
		SscatLane lane;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			RegistryHelper.Attach(new RegistryManagerStub());
			ApplicationUtility.Attach(new ApplicationManagerStub());
			MessageService.Attach(new NoMessageProvider());
			
			WorkbenchSingleton.Attach(new ConsoleWorkbench(), new ConsoleWorkbenchLayout());
			
			SscatContext.Lane = new SscatLane();
			
			lane = SscatContext.Lane;
			lane.AddEmulator(new BagScale());

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

			command = new GenerateScripts(new LaneController(
				lane,
				service,
				new ConsolePlayerView(),
				new ConsoleScriptGeneratorView("test", "", "", true, @"C:\Projects\finger\trunk\tests", false, 0),
				//new ConsoleCustomGeneratorView(),
				new ConsoleScriptListView()
			));
		}
		
		[Test]
		public void TestRun()
		{
            Assert.That(() => command.Run(),
                Throws.TypeOf<Exception>());
		}
		
		[Test]
		public void TestOnEmptyConstructor()
		{
			ControllerBuilder.SetControllerFactory(new PlayScriptsTests.C(lane, service));
			command = new GenerateScripts();
		}
		
		[Test]
		public void TestRunOnException()
		{
			WorkbenchSingleton.Attach(new PlayScriptsTests.W());
			Assert.That(() => command.Run(),
                Throws.TypeOf<Exception>());
		}
	}
}
