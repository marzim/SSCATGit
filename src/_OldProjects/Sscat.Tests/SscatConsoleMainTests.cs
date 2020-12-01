//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using Ncr.Core.Views;
using NUnit.Framework;
using Sscat.Core.Emulators;
using Sscat.Core.Parsers;
using Sscat.Core.Services;
using Sscat.Core.Util;
using Sscat.Tests.Commands.Psx;
using Sscat.Tests.Config;
using Sscat.Tests.Emulators;
using Sscat.Tests.Models;
using Sscat.Tests.Repositories;

namespace Sscat.Tests
{
	[TestFixture]
	public class SscatConsoleMainTests
	{
		SscatLane lane;
		LaneService service;
		
		[SetUp]
		public void Setup()
		{
			RegistryHelper.Attach(new RegistryManagerStub()); // TODO: This still displays the show help in console mode, should inject it from here!
			
//			lane = SscatConsoleMain.GetLane();
			lane = new SscatLaneStub();
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
			); // TODO: Null CPU and memory logger?
		}
		
		[Test]
		public void TestRun()
		{
//			SscatConsoleMain.Run(new string[] { "lane.version" }, new ApplicationManagerStub(), new NoMessageProvider(), new Log4NetLogger(), new ConsoleWorkbench(), new ConsoleWorkbenchLayout(), lane, new SscatSecurityManager(), service);
			SscatConsoleMain.Run(new string[] { "scripts.play", "1", "0" }, new ApplicationManagerStub(), new NoMessageProvider(), new Log4NetLogger(), new ConsoleWorkbench(), new ConsoleWorkbenchLayout(), lane, new SscatSecurityManager(), service);
		}
		
		[Test]
		public void TestRunWithoutParameter()
		{
			SscatConsoleMain.Run(new string[] { }, new ApplicationManagerStub(), new NoMessageProvider(), new Log4NetLogger(), new ConsoleWorkbench(), new ConsoleWorkbenchLayout(), lane, new SscatSecurityManager(), service);
		}
		
		[Test]
		public void TestRunNotSupportedCommand()
		{
			SscatConsoleMain.Run(new string[] { "qwerty" }, new ApplicationManagerStub(), new NoMessageProvider(), new Log4NetLogger(), new ConsoleWorkbench(), new ConsoleWorkbenchLayout(), lane, new SscatSecurityManager(), service);
		}
		
		[Test]
		public void TestMain()
		{
			SscatConsoleMain.Main(new string[] { });
		}
	}
}
