//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Rhino.Mocks;
using Sscat.Core.Commands;
using Sscat.Core.Emulators;
using Sscat.Core.Finger;
using Sscat.Core.Log;
using Sscat.Core.Models;

namespace Sscat.Tests.Commands.Device
{
	[TestFixture]
	public class CaptureSignatureTests
	{
		CaptureSignature command;
		IScotLogHook hook;
		SscatLane lane;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			hook = MockRepository.GenerateMock<IScotLogHook>();
			lane = MockRepository.GenerateMock<SscatLane>();
			command = new CaptureSignature(new PCSignatureCapture(), hook, new DeviceEvent(), lane, 100, true);
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
		}
		
		[Test]
		public void TestConstructorOnNullDevice()
		{
            Assert.That(() => command = new CaptureSignature(null, hook, new DeviceEvent(), lane, 100, true),
               Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestRunWithException()
		{
			command = new CaptureSignature(new A(), hook, new DeviceEvent(), lane, 100, true);
            Assert.That(() => command.Run(),
               Throws.TypeOf<NotImplementedException>());
		}
		
		class A : PCSignatureCapture, IPCSignatureCapture
		{
			public A()
			{
			}
			
			public override void Sign(int timeout)
			{
				throw new NotImplementedException();
			}
		}
	}
}
