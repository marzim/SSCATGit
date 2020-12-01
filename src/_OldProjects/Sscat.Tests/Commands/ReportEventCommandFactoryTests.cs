//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using System.Collections;
using System.Collections.Generic;
using Ncr.Core.Emulators;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Commands;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Core.Services;
using Sscat.Core.Util;
using Sscat.Tests.Config;

namespace Sscat.Tests.Commands
{
	[TestFixture]
	public class ReportEventCommandFactoryTests
	{
		SscatLane lane;
		Dictionary<string, IScotLogHook> hooks;
		
		[SetUp]
		public void Setup()
		{
			lane = new SscatLane();
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			lane.Hooks = lane.Configuration.GetHooks();
			hooks = lane.Hooks;
		}
		
//		public ReportEventCommand(IScotLogHook hook, IReportEvent item, SscatLane lane, int timeout, bool enableHook) : base(hook, item, lane, timeout, enableHook)
//		{
//		}
		[Test]
		public void TestReportsMenu()
		{
			//IPsxEvent e = new PsxEvent("1", "", "", "ChangeContext", "", "", 1);
			IReportEvent e = new ReportEvent("ReportsMenu", "TestValue");
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(CheckReportsMenu), ReportEventCommandFactory.GetCommandFactory(new ScriptEvent(e), lane, hooks, 500, true).CreateCommand());
		}
		
		[Test]
		public void TestRunReports()
		{
			//IPsxEvent e = new PsxEvent("1", "", "", "ChangeContext", "", "", 1);
			IReportEvent e = new ReportEvent("RunReports", "TestValue");
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(CheckRunReports), ReportEventCommandFactory.GetCommandFactory(new ScriptEvent(e), lane, hooks, 500, true).CreateCommand());
		}

		[Test]
		public void TestWithException()
		{
			//IPsxEvent e = new PsxEvent("1", "", "", "ChangeContext", "", "", 1);
			IReportEvent e = new ReportEvent("Error", "TestValue");
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.That(() => Assert.IsInstanceOf(typeof(CheckRunReports), ReportEventCommandFactory.GetCommandFactory(new ScriptEvent(e), lane, hooks, 500, true).CreateCommand()),
                Throws.TypeOf<NotSupportedException>());
		}		
	}
}
