﻿//	<file>
//		<license></license>
//		<owner name="Jonathan Cabriana" email="jc185114@ncr.com"/>
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
	public class CheckCountPercentageTests
	{
		CheckCountPercentage command;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			SscatLane lane = new SscatLane();
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			lane.Hooks = lane.Configuration.GetHooks();
			command = new CheckCountPercentage(lane.Hooks["Traces"], new DeviceEvent(), lane, 500, true);
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
			Assert.AreEqual(ResultType.Skipped, command.Result.Type);
		}
	}
}