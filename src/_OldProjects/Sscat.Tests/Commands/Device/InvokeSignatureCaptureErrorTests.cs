//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
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
using Sscat.Core.Emulators;
using Sscat.Core.Finger;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Core.Util;
using Sscat.Tests.Emulators;
using Sscat.Core.Commands.Events.Device;

namespace Sscat.Tests.Commands.Device
{
	[TestFixture]
	public class InvokeSignatureCaptureErrorTests
	{
		InvokeSignatureCaptureError command;
		IScotLogHook hook;
		SscatLane lane;			
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			hook = MockRepository.GenerateMock<IScotLogHook>();
			lane = MockRepository.GenerateMock<SscatLane>();
			command = new InvokeSignatureCaptureError(new PCSignatureCapture(), hook, new FingerDeviceEvent(), lane, 500, true);
			command.Running += new EventHandler<NcrEventArgs>(AcceptorRunning);			
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			command.Running -= new EventHandler<NcrEventArgs>(AcceptorRunning);
		}
		
		[Test]
		public void TestMethod()
		{
			Assert.That(() => command.Run(), Throws.TypeOf<NotSupportedException>());
			//Assert.AreEqual(ResultType.Failed, command.Result.Type);
		}
		
		[Test]
		public void TestConstructorOnNullDevice()
		{
			Assert.That(() => command = new InvokeSignatureCaptureError(null, hook, new FingerDeviceEvent(), lane, 500, true),
                Throws.TypeOf<ArgumentNullException>());							
		}			
		
		[Test]
		public void TestMethodWithFailureValue()
		{
			command.Item.Value = Constants.SignatureCaptureError.FAILURE;
			command.Run();
		}	

		[Test]
		public void TestMethodWithNoHardwareValue()
		{
			command.Item.Value = Constants.SignatureCaptureError.NO_HARDWARE;
			command.Run();
		}

		[Test]
		public void TestMethodWithOfflineValue()
		{
			command.Item.Value = Constants.SignatureCaptureError.OFFLINE;
			command.Run();
		}
		
		void AcceptorRunning(object sender, NcrEventArgs e)
		{
		}		
	}
}
