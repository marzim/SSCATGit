//	<file>
//		<license></license>
//		<owner name="Apple Leo Chiong" email="Apple_Leo_Derilo.Chiong@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Commands;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Tests.Config;
using Sscat.Core.Commands.Events.Launcher;

namespace Sscat.Tests.Commands
{
	[TestFixture]
	public class ApplicationLauncherCommandFactoryTests
	{
		SscatLane lane;
		Dictionary<string, IScotLogHook> hooks;

        [OneTimeSetUp]
        public void OneTimeSetUp()
		{
			lane = new SscatLane();
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			hooks = lane.Configuration.GetHooks();
		}
		
		[Test]
		public void TestLaunchApplication()
		{
			IApplicationLauncherEvent a = new ApplicationLauncherEvent("", "", "");
			Assert.IsInstanceOf(typeof(LaunchApplication), ApplicationLauncherCommandFactory.GetCommandFactory(new ScriptEvent(a), lane, hooks, 500, true).CreateCommand());
		}
	}
}