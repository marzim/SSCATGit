//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>
namespace Sscat.Tests.Commands.Device
{
    using System;
    using Ncr.Core;
    using Ncr.Core.Emulators;
    using Ncr.Core.Tests.Util;
    using Ncr.Core.Util;
    using NUnit.Framework;
    using Rhino.Mocks;
    using Sscat.Core.Commands.Events.Device;
    using Sscat.Core.Emulators;
    using Sscat.Core.Finger;
    using Sscat.Core.Log;
    using Sscat.Core.Models;

    [TestFixture]
    public class InvokeScannerErrorTests
    {
        InvokeScannerError command;
        IScotLogHook hook;
        SscatLane lane;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ApiHelper.Attach(new ApiManagerStub());
            hook = MockRepository.GenerateMock<IScotLogHook>();
            lane = MockRepository.GenerateMock<SscatLane>();
            command = new InvokeScannerError(new Scanner(), hook, new FingerDeviceEvent(), lane, 500, true);
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
            command.Run();
            //Assert.AreEqual(ResultType.Failed, command.Result.Type);
        }

        [Test]
        public void TestConstructorOnNullDevice()
        {
            Assert.That(() => command = new InvokeScannerError(null, hook, new FingerDeviceEvent(), lane, 500, true),
                Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void TestRunWithException()
        {
            command = new InvokeScannerError(new A(), hook, new DeviceEvent(), lane, 100, true);
            command.Run();
        }

        void AcceptorRunning(object sender, NcrEventArgs e)
        {
        }

        class A : Scanner, IScanner
        {
            public A()
            {
            }

            public override void Error(int timeout)
            {
                throw new EmulatorTimeoutException("");
            }
        }
    }
}
