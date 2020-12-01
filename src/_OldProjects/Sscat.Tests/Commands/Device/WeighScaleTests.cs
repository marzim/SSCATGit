//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//		<owner name="Apple Leo Chiong" email="Apple_Leo_Derilo.Chiong@ncr.com"/>
//	</file>

using System;
using Ncr.Core;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Rhino.Mocks;
using Sscat.Core.Commands;
using Sscat.Core.Finger;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Tests.Emulators;

namespace Sscat.Tests.Commands.Device
{
	[TestFixture]
	public class WeighScaleTests
	{
		AbstractEventCommand command;
		IScotLogHook hook;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			hook = MockRepository.GenerateMock<IScotLogHook>();
			command = new WeighScale(new Scale(), hook, new FingerDeviceEvent("Scale", "800"), new SscatLaneStub(), 5000, true);
			command.Running += new EventHandler<NcrEventArgs>(ScaleRunning);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			command.Running -= new EventHandler<NcrEventArgs>(ScaleRunning);
		}
		
		[Test]
		public void TestZeroAndInSeqLessThanFive()
		{
			command = new WeighScale(new Scale(), hook, new FingerDeviceEvent("Scale", "0"), new SscatLaneStub(), 5000, true);
			command.Run();
		}
		
		[Test]
		public void TestArgumentNullException()
		{
            Assert.That(() => command = new WeighScale(null, hook, new FingerDeviceEvent(), new SscatLaneStub(), 5000, true),
               Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
		}
		
		[Test]
		public void TestRunWithException()
		{
			command = new WeighScale(new A(), hook, new FingerDeviceEvent("Scale", "800"), new SscatLaneStub(), 5000, true);
            Assert.That(() => command.Run(),
               Throws.TypeOf<NotImplementedException>());
		}

		void ScaleRunning(object sender, NcrEventArgs e)
		{
		}
		
		class A : Emulator, IScale
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
