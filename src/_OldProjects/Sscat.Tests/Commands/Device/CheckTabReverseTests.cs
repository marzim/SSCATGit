//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Commands;
using Sscat.Core.Emulators;
using Sscat.Core.Models;
using Sscat.Core.Util;
using Sscat.Tests.Config;

namespace Sscat.Tests.Commands.Device
{
	[TestFixture]
	public class CheckTabReverseTests
	{
		CheckTabReverse command;

        [OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			FileHelper.Create(@"C:\scot\logs\TakeawayBelt.log", "created during sscat unit test");
			SscatLane lane = new SscatLane();
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			lane.Hooks = lane.Configuration.GetHooks();
			command = new CheckTabReverse(lane.Hooks["TAB"], new DeviceEvent(), lane, 500, true);
			FileHelper.Delete(@"C:\scot\logs\TakeawayBelt.log");
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
			Assert.AreEqual(ResultType.Failed, command.Result.Type);
		}
	}
}