//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Emulators;
using Ncr.Core.Models;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using Ncr.Core.Views;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Controllers;
using Sscat.Core.Emulators;
using Sscat.Core.Parsers;
using Sscat.Core.Repositories;
using Sscat.Core.Services;
using Sscat.Tests.Commands.Gui;
using Sscat.Tests.Commands.Psx;
using Sscat.Tests.Config;
using Sscat.Tests.Models;
using Sscat.Tests.Repositories;
using Sscat.Tests.Services;
using Sscat.Views;

namespace Sscat.Tests.Controllers
{
	[TestFixture]
	public class LaneControllerTests
	{
		LaneController controller;
		LaneController controller2;
		IScriptRepository scriptRepository;
		SscatLane lane;
		LaneService service;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			RegistryHelper.Attach(new RegistryManagerStub());
			ProcessUtility.Attach(new ProcessManagerStub(true, false, "SMAttract"));
			DnsHelper.Attach(new DnsManagerStub());
			ApiHelper.Attach(new ApiManagerStub());
			MessageService.Attach(new NoMessageProvider());
			ApplicationUtility.Attach(new ApplicationManagerStub());
			DirectoryHelper.Attach(new DirectoryManagerStub());
			FileHelper.Attach(new FileManagerStub());
			
			WorkbenchSingleton.Attach(new ConsoleWorkbench(), new ConsoleWorkbenchLayout());
			scriptRepository = new ScriptRepositoryStub();
			
			lane = new SscatLane();
			lane.AddEmulator(new BagScale(), new Scale());
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			lane.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
			
			service = new LaneServiceStub(
				lane,
				scriptRepository,
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
			
			controller = new LaneController(
				lane,
				service,
				new ConsolePlayerView(scriptRepository.GetScripts(new string[] { }), 1),
				new ConsoleScriptGeneratorView("test", "", "", true, @"C:\Projects\finger\trunk\tests", false, 0),
				//new ConsoleCustomGeneratorView(),
				new ConsoleScriptListView()
			);
			
			controller2 = new LaneController(
				new ConsoleCustomGeneratorView(),				
				lane,
				service
			);			
		}
		
		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			lane.ConnectionAdding -= new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
		}
		
		[Test]
		public void TestPlay()
		{
			WorkbenchSingleton.ShowView(controller.Play());
		}
		
		[Test]	
		public void TestGenerate()
		{
			Assert.That(() => WorkbenchSingleton.ShowView(controller.Generate()),
                Throws.TypeOf<Exception>());
		}
		
		[Test]
		public void TestCustomGenerate()
		{
			WorkbenchSingleton.ShowView(controller2.CustomGenerate());
		}		

		void LaneConnectionAdding(object sender, PsxWrapperEventArgs e)
		{
			lane.PsxConnections.Add(service.CreatePsx(e.HostName, e.ServiceName, e.ConnectionName, e.Timeout));
		}
	}
}
