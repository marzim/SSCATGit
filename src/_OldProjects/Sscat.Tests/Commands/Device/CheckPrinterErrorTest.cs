//	<file>
//		<license></license>
//		<owner name="Jonathan Cabriana" email="jc185114@ncr.com"/>
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
	public class CheckPrinterErrorTest
	{
		AbstractEventCommand command;
		IScotLogHook hook;

        [OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			hook = MockRepository.GenerateMock<IScotLogHook>();
			command = new CheckPrinterError(new POSPrinter(), hook, new FingerDeviceEvent(), new SscatLaneStub(), 5000, true);
		}
		
		[Test]
		public void TestWithNullCashAcceptor()
		{
            Assert.That(() => command = new CheckPrinterError(null, hook, new FingerDeviceEvent(), new SscatLaneStub(), 5000, true),
               Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestRunWithException()
		{
			command = new CheckPrinterError(new A(), hook, new FingerDeviceEvent(), new SscatLaneStub(), 5000, true);
            Assert.That(() => command.Run(),
               Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
		}
		
		class A : POSPrinter, IPosPrinter
		{
			public override void Printing(int timeout)
			{
				throw new NotImplementedException();
			}
		}
	}
}
