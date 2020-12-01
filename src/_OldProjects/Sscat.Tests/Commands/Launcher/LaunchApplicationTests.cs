//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using NUnit.Framework;
using Sscat.Core.Commands;
using Sscat.Core.Emulators;
using Sscat.Core.Models;
using Sscat.Core.Util;
using Sscat.Tests.Config;
using Sscat.Tests.Util;
using Sscat.Core.Commands.Events.Launcher;

namespace Sscat.Tests.Commands.Launcher
{
	[TestFixture]
	public class LaunchApplicationTests
	{
		LaunchApplication command;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			SscatLane lane = new SscatLane();
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			//lane.Hooks = lane.Configuration.GetHooks();
			IApplicationLauncherEvent a = new ApplicationLauncherEvent("", "", "");
			lane.ApplicationLauncher = new ApplicationLauncherStub();
			command = new LaunchApplication(a, lane.ApplicationLauncher);
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
			Assert.AreEqual(ResultType.Passed, command.Result.Type);
		}
		
		[Test]
		public void TestRunWithException()
		{
			command.Item.Host = null;
			command.Item.ApplicationPath = null;
			command.Run();
		}
	}
}