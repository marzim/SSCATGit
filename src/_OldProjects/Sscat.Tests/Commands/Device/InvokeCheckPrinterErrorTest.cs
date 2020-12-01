namespace Sscat.Tests.Commands.Device
{
    using System;
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
    public class InvokeCheckPrinterErrorTest
    {
        InvokeCheckPrinterError command;
        IScotLogHook hook;
        SscatLane lane;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ApiHelper.Attach(new ApiManagerStub());
            hook = MockRepository.GenerateMock<IScotLogHook>();
            lane = MockRepository.GenerateMock<SscatLane>();
            command = new InvokeCheckPrinterError(new POSPrinter(), hook, new FingerDeviceEvent(), lane, 500, true);
        }

        [Test]
        public void TestConstructorOnNullDevice()
        {
            Assert.That(() => command = new InvokeCheckPrinterError(null, hook, new FingerDeviceEvent(), lane, 500, true),
                Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void TestCoverOpen()
        {
            command.Item.Value = Constants.PrinterReceiptError.COVER_OPEN;
            command.Run();
        }

        [Test]
        public void TestNonCoverOpen()
        {
            command.Item.Value = "0";
            Assert.That(() => command.Run(),
                Throws.TypeOf<NotSupportedException>());
        }
    }
}
