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
    using Sscat.Core.Util;

    [TestFixture]
    public class InvokeCashAcceptorErrorTests
    {
        InvokeCashAcceptorError command;
        IScotLogHook hook;
        SscatLane lane;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ApiHelper.Attach(new ApiManagerStub());
            hook = MockRepository.GenerateMock<IScotLogHook>();
            lane = MockRepository.GenerateMock<SscatLane>();
            command = new InvokeCashAcceptorError(new CashAcceptor(), hook, new FingerDeviceEvent(), lane, 500, true);
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
            try
            {
                command.Run();
            }
            catch (Exception)
            {
                Assert.That(() => command.Run(),
                   Throws.TypeOf<FormatException>());
            }

        }

        [Test]
        public void TestConstructorOnNullDevice()
        {
            Assert.That(() => command = new InvokeCashAcceptorError(null, hook, new FingerDeviceEvent(), lane, 500, true),
               Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void TestJam()
        {
            command.Item.Value = Constants.CashAcceptorError.JAM;
            command.Run();
        }

        [Test]
        public void TestFail()
        {
            command.Item.Value = Constants.CashAcceptorError.FAIL;
            command.Run();
        }

        [Test]
        public void TestReset()
        {
            command.Item.Value = Constants.CashAcceptorError.RESET;
            command.Run();
        }

        void AcceptorRunning(object sender, NcrEventArgs e)
        {
        }
    }
}
