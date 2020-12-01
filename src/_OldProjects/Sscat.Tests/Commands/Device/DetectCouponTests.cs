//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Commands;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Core.Services;
using Sscat.Tests.Config;

namespace Sscat.Tests.Commands.Device
{
	[TestFixture]
	public class DetectCouponTests
	{
		DetectCoupon command;
		IScotLogHook hook;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			SscatLane lane = new SscatLane();
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			lane.Hooks = lane.Configuration.GetHooks();
			hook = lane.Hooks["Traces"];
			command = new DetectCoupon(new MotionSensorCoupon(), hook, new DeviceEvent(), lane, 500, true);
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
			Assert.AreEqual(ResultType.Failed, command.Result.Type);
		}
		
		[Test]
		public void TestThrowExceptionOnNullMotionSensor()
		{
			Assert.That(() => command = new DetectCoupon(null, hook, null, null, 0, true), Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestRunWithException()
		{
			command = new DetectCoupon(new A(), hook, new DeviceEvent(), new SscatLane(), 500, true);
			Assert.That(() => command.Run(), Throws.TypeOf<NotImplementedException>());
		}
		
		class A : Emulator, IMotionSensorCoupon
		{
			public A() : base("A")
			{
			}
			
			public void Detect(int timeout)
			{
				throw new NotImplementedException();
			}
		}
	}
}
