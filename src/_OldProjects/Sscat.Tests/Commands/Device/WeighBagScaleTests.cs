//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Commands;
using Sscat.Core.Emulators;
using Sscat.Core.Finger;
using Sscat.Core.Log;
using Sscat.Core.Parsers;
using Sscat.Core.Services;
using Sscat.Tests.Config;
using Sscat.Tests.Emulators;

namespace Sscat.Tests.Commands.Device
{
	[TestFixture]
	public class WeighBagScaleTests
	{
		WeighBagScale command;
		IScotLogHook hook;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			SscatLane lane = new SscatLane();
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			lane.Hooks = lane.Configuration.GetHooks();
			hook = lane.Hooks["Traces"];
			command = new WeighBagScale(new BagScale(), hook, new FingerDeviceEvent("BagScale", "400"), lane, 100, true);
			command.Running += new EventHandler<NcrEventArgs>(BagScaleRunning);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			command.Running -= new EventHandler<NcrEventArgs>(BagScaleRunning);
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
		}
		
		[Test]
		public void TestRunWithException()
		{
			command = new WeighBagScale(new A(), hook, new FingerDeviceEvent("BagScale", "400"), new SscatLaneStub(), 5000, true);
            Assert.That(() => command.Run(),
               Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestArgumentNullException()
		{
            Assert.That(() => command = new WeighBagScale(null, hook, new FingerDeviceEvent("BagScale", "400"), new SscatLaneStub(), 5000, true),
              Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestLessThan35()
		{
			command = new WeighBagScale(new BagScale(), hook, new FingerDeviceEvent("BagScale", "10"), new SscatLaneStub(), 5000, true);
			command.Run();
		}

		void BagScaleRunning(object sender, NcrEventArgs e)
		{
		}
		
		class A : Emulator, IBagScale
		{
			public A() : base("A")
			{
			}
			
			public int Weight {
				get {
					throw new NotImplementedException();
				}
			}
			
			public void Weigh(int weight, int timeout)
			{
				throw new NotImplementedException();
			}
		}
	}
}
