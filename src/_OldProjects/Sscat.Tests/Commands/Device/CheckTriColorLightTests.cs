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
using Sscat.Tests.Config;

namespace Sscat.Tests.Commands.Device
{
	[TestFixture]
	public class CheckTriColorLightTests
	{
		CheckTriColorLight command;

        [OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			SscatLane lane = new SscatLane();
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			lane.Hooks = lane.Configuration.GetHooks();
			command = new CheckTriColorLight(lane.Hooks["Traces"], new DeviceEvent(), lane, 500, true);
		}
		[Test]
		public void TestMethod()
		{
			command.Run();
			Assert.AreEqual(ResultType.Failed, command.Result.Type);
		}
	}
}
