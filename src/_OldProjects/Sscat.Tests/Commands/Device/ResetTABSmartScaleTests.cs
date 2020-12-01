//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
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
	public class ResetTABSmartScaleTests
	{
		ResetTABSmartScale command;
		ResetTABSmartScale command2;
		SscatLane lane;
		
		[SetUp]
		public void Setup()
		{
			ApiHelper.Attach(new ApiManagerStub());
			lane = new SscatLane();
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			lane.Hooks = lane.Configuration.GetHooks();
			command = new ResetTABSmartScale(new BagScale(), lane.Hooks["Traces"], new DeviceEvent(), lane, 500, true);
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
			Assert.AreEqual(ResultType.Failed, command.Result.Type);
		}
		
		[Test]
		public void TestConstructorWithNullBagScale()
		{
			Assert.That(() => command2 = new ResetTABSmartScale(null, lane.Hooks["Traces"], new DeviceEvent(), lane, 500, true),
                Throws.TypeOf<ArgumentNullException>());
		}		
	}
}