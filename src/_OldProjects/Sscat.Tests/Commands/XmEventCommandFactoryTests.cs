//	<file>
//		<license></license>
//		<owner name="Apple Leo Chiong" email="Apple_Leo_Derilo.Chiong@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Sscat.Core.Commands;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Tests.Config;

namespace Sscat.Tests.Commands
{
	[TestFixture]
	public class XmEventCommandFactoryTests
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
		
		[Test]
		public void TestXmPrintData()
		{
			IXmEvent e = new XmEvent("XmPrintData", 1, new string[] {"TestValue" });
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(CheckXmPrintData), XmEventCommandFactory.GetCommandFactory(new ScriptEvent(e), lane, hooks, 500, true).CreateCommand());
		}
		
		[Test]
		public void TestXmCountChanges()
		{
			IXmEvent e = new XmEvent("XmCountChanges", 1, new string[] {"TestValue" });
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(CheckXmCountChanges), XmEventCommandFactory.GetCommandFactory(new ScriptEvent(e), lane, hooks, 500, true).CreateCommand());
		}
		
		[Test]
		public void TestWithException()
		{
			IXmEvent e = new XmEvent("NotSupportedXmEvent", 1, new string[] {"TestValue" });
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.That(() => Assert.IsInstanceOf(typeof(CheckXmPrintData), XmEventCommandFactory.GetCommandFactory(new ScriptEvent(e), lane, hooks, 500, true).CreateCommand()),
                Throws.TypeOf<NotSupportedException>());
		}
	}
}
