//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using NUnit.Framework;
using Sscat.Core.Emulators;

namespace Sscat.Tests.Regressions.Emulators
{
	[TestFixture]
	public class EmulatorTests
	{
		SscatLane lane;
		
		[SetUp]
		public void Setup()
		{
			lane = new SscatLane();
			lane.Start();
		}
		
		[Test]
		public void TestAvailability()
		{
			Assert.IsTrue(new BagScale().Available());
			Assert.IsTrue(new CashAcceptor().Available());
			Assert.IsTrue(new CoinAcceptor().Available());
			Assert.IsTrue(new MotionSensorCoupon().Available());
			Assert.IsTrue(new Msr().Available());
//			Assert.IsTrue(new PCSignatureCapture().Available());
//			Assert.IsTrue(new PinPad().Available());
			Assert.IsTrue(new Scale().Available());
			Assert.IsTrue(new Scanner().Available());
		}
	}
}
