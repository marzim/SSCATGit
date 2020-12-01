//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Ncr.Core.Controllers;
using Ncr.Core.Emulators;
using Ncr.Core.Models;
using Ncr.Core.Tests.Models;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using Ncr.Core.Views;
using NUnit.Framework;
using Sscat.Core.Commands.Gui;
using Sscat.Core.Config;
using Sscat.Core.Controllers;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Core.Repositories;
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
	public class ShowScriptsTests
	{
		ShowScripts command;
		SscatLane lane;
		LaneService service;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			RegistryHelper.Attach(new RegistryManagerStub());
			MessageService.Attach(new NoMessageProvider());
			FileHelper.Attach(new FileManagerStub());
			ProcessUtility.Attach(new ProcessManagerStub(true, false, "SMAttract"));
			ApiHelper.Attach(new ApiManagerStub());
			DnsHelper.Attach(new DnsManagerStub());
			
			WorkbenchSingleton.Attach(new ConsoleWorkbench(), new ConsoleWorkbenchLayout());
			
			lane = new SscatLane();
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
		}
		
		[Test]
		public void TestEmptyConstructor()
		{
			ControllerBuilder.SetControllerFactory(new C(lane, service));
			command = new ShowScripts();
		}
		
		[Test]
		public void TestRun()
		{
			IScriptRepository r = new ScriptRepositoryStub();
			List<ScriptFile> scripts = r.GetScripts(new string[] { });
			command = new ShowScripts(new LaneController(
				lane,
				new LaneServiceStub(
					lane,
					r,
					new ConfigFileRepositoryStub(),
					new ConfigFilesRepositoryStub(),
					new PlayerConfigurationRepositoryStub(),
					new GeneratorConfigurationRepositoryStub(),
					new LaneConfigurationRepositoryStub(),
					new ReportRepositoryStub(),
					new PsxDisplayRepositoryStub(),
					null,
					null
				),
				new ConsolePlayerView(scripts, 1),
				new ConsoleScriptGeneratorView("test", "", "", true, @"C:\Projects\finger\trunk\tests", false, 0),
				//new ConsoleCustomGeneratorView(),
				new ConsoleScriptListView()
			));
			command.Run();
		}
		
		[Test]
		public void TestRunOnException()
		{
			WorkbenchSingleton.Attach(new W());
			command.Run();
		}
		
		public class W : ConsoleWorkbench
		{
			public override void ShowView(IView view)
			{
				throw new Exception();
			}
		}
		
		public class C : IControllerFactory
		{
			SscatLane lane;
			LaneService service;
			
			public C(SscatLane lane, LaneService service)
			{
				this.lane = lane;
				this.service = service;
			}
			
			public IController CreateController(string controllerName, int offset)
			{
				return new LaneController(
					lane,
					service,
					new ConsolePlayerView(),
					new ConsoleScriptGeneratorView("", "", "", true, "", false, 0),
					//new ConsoleCustomGeneratorView(),
					new ConsoleScriptListView()
				);
			}
		}
	}
}
