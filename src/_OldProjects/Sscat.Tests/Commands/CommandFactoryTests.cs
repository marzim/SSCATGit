//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Controllers;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Commands;
using Sscat.Core.Config;
using Sscat.Core.Controllers;
using Sscat.Core.Emulators;
using Sscat.Core.Parsers;
using Sscat.Core.Services;
using Sscat.Core.Util;
using Sscat.Tests.Commands.Psx;
using Sscat.Tests.Config;
using Sscat.Tests.Models;
using Sscat.Tests.Repositories;
using Sscat.Views;

namespace Sscat.Tests.Commands
{
	[TestFixture]
	public class CommandFactoryTests
	{
		SscatLane lane;
		LaneService service;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApplicationUtility.Attach(new ApplicationManager());
			DirectoryHelper.Attach(new DirectoryManagerStub());
			FileHelper.Attach(new FileManagerStub());
			LoggingService.DetachAll();
			
			lane = new SscatLane();
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
				null,
				null
			);
			
			lane.Configuration = service.ReadLaneConfiguration("");
		}
		
		[Test]
		public void TestShowHelp()
		{
			new CommandFactory(new string[] { }).CreateCommand("help");
		}
		
		[Test]
		public void TestKillSsco()
		{
			new CommandFactory(new string[] { }).CreateCommand("lane.kill");
		}
		
		[Test]
		public void TestLaunchSsco()
		{
			new CommandFactory(new string[] { }).CreateCommand("lane.start");
		}
		
		[Test]
		public void TestShowSscoVersion()
		{
			new CommandFactory(new string[] { }).CreateCommand("lane.version");
		}
		
		[Test]
		public void TestDeleteScotLogs()
		{
			new CommandFactory(new string[] { }).CreateCommand("logs.delete");
		}
		
		[Test]
		public void TestHookLogs()
		{
			new CommandFactory(new string[] { "logs.hook", "0:Psx" }).CreateCommand("logs.hook");
		}
		
		[Test]
		public void TestListFiles()
		{
			new CommandFactory(new string[] { }).CreateCommand("logs.list");
		}
		
		[Test]
		public void TestListScripts()
		{
			new CommandFactory(new string[] { }).CreateCommand("scripts.list");
		}
		
		[Test]
		public void TestGenerateScripts()
		{
			string[] args = new string[] { Constants.ConsoleCommand.GENERATE_SCRIPTS, "test", "", @"C:\Projects\finger\trunk\tests" };
			ControllerBuilder.SetControllerFactory(new ConsoleControllerFactory(args, lane, service));
			new CommandFactory(args).CreateCommand("scripts.generate");
		}
		
		[Test]
		public void TestPlayScripts()
		{
			string[] args = new string[] { Constants.ConsoleCommand.PLAY_SCRIPTS, "test" };
			ControllerBuilder.SetControllerFactory(new ConsoleControllerFactory(args, lane, service));
			new CommandFactory(args).CreateCommand(Constants.ConsoleCommand.PLAY_SCRIPTS);
		}
		
		[Test]
		public void TestNotSupportedCommand()
		{
			Assert.That(() => new CommandFactory(new string[] { }).CreateCommand("qwerty"), Throws.TypeOf<NotSupportedException>());
		}
	}
}
