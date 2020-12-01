//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ncr.Core.Controllers;
using NUnit.Framework;
using Sscat.Core.Commands.Gui;
using Sscat.Core.Controllers;
using Sscat.Core.Emulators;
using Sscat.Core.Gui;
using Sscat.Core.Models;
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
	public class ShowCardEventEditorTests
	{
		SscatLane lane;
		LaneService service;
		ShowCardEventEditorStub command;
		
		[SetUp]
		public void Setup()
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
		public void TestConstructor()
		{
			ControllerBuilder.SetControllerFactory(new C(lane, service));
			command = new ShowCardEventEditorStub(lane, service);
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
		}		
	}
	
	public class ShowCardEventEditorStub : ShowCardEventEditor
	{
		SscatLane lane;
		LaneService service;
		OpenFileDialog openFileDialogLoadScripts;
		CardEventEditor cardEventEditorForm;
		
		public ShowCardEventEditorStub(SscatLane lane, LaneService service)
		{
			this.lane = lane;
			this.service = service;
			openFileDialogLoadScripts = new OpenFileDialog();
			cardEventEditorForm = new CardEventEditor("", true);
		}
		
		public override bool IsShowOpenFileDialog()
		{
			openFileDialogLoadScripts.Filter = "Script Files (*.xml, *.finger)|*.xml;*.finger";
			openFileDialogLoadScripts.FilterIndex = 1;
			openFileDialogLoadScripts.Multiselect = true;
			openFileDialogLoadScripts.InitialDirectory = @"C:\SSCAT\Scripts";				
			return true;
		}
//		
//		public override void ShowWarning()
//		{
//		}
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