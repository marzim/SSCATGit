//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>
namespace Sscat.Tests.Commands
{
    using System.Collections.Generic;
    using Ncr.Core.Emulators;
    using NUnit.Framework;
    using Sscat.Core.Commands;
    using Sscat.Core.Commands.Events.Device;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Util;
    using Sscat.Tests.Config;

    [TestFixture]
    public class DeviceEventCommandFactoryTests
    {
        SscatLane lane;
        Dictionary<string, IScotLogHook> hooks;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            lane = new SscatLane();
            lane.AddEmulator(new BagScale());
            lane.AddEmulator(new CashAcceptor());
            lane.AddEmulator(new CoinAcceptor());
            lane.AddEmulator(new Msr());
            lane.AddEmulator(new PinPad());
            lane.AddEmulator(new Scale());
            lane.AddEmulator(new Scanner());
            lane.AddEmulator(new MotionSensorCoupon());
            lane.AddEmulator(new PCSignatureCapture());
            lane.AddEmulator(new POSPrinter());

            lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
            hooks = lane.Configuration.GetHooks();
        }

        [Test]
        public void TestNotSupportedEvent()
        {
            Assert.That(() => DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("Qwerty", "")), lane, hooks, 500, true).CreateCommand(),
                Throws.TypeOf<System.NotSupportedException>());
        }

        [Test]
        public void TestCaptureSignature()
        {
            Assert.IsInstanceOf(typeof(CaptureSignature), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent(Constants.DeviceType.SIGNATURE_CAPTURE, "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestDetectCoupon()
        {
            Assert.IsInstanceOf(typeof(DetectCoupon), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("CouponSlip", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestScanCode()
        {
            Assert.IsInstanceOf(typeof(ScanCode), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("Scanner", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestWeighScale()
        {
            Assert.IsInstanceOf(typeof(WeighScale), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("Scale", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestCheckReceiptItem()
        {
            Assert.IsInstanceOf(typeof(CheckReceiptItem), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("ReceiptItem", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestExecutePinPad()
        {
            Assert.IsInstanceOf(typeof(ExecutePinPad), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("PinPad", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestWeighBagScale()
        {
            Assert.IsInstanceOf(typeof(WeighBagScale), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("BagScale", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestCheckAmountAndTaxDue()
        {
            Assert.IsInstanceOf(typeof(CheckAmountAndTaxDue), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("AmountDue;TaxDue", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestCheckChangeDueAndTenderType()
        {
            Assert.IsInstanceOf(typeof(CheckChangeDueAndTenderType), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("ChangeDueAndTenderType", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestEscrowCash()
        {
            Assert.IsInstanceOf(typeof(EscrowCash), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("CashAcceptor", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestInsertCoin()
        {
            Assert.IsInstanceOf(typeof(InsertCoin), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("CoinAcceptor", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestSwipeMsr()
        {
            Assert.IsInstanceOf(typeof(SwipeMsr), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("MSR", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestTriColorLight()
        {
            Assert.IsInstanceOf(typeof(CheckTriColorLight), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("TriColorLight", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestCheckSayPhrase()
        {
            Assert.IsInstanceOf(typeof(CheckSayPhrase), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("SayPhrase", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestCheckSayAmount()
        {
            Assert.IsInstanceOf(typeof(CheckSayAmount), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("SayAmount", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestCheckSaySecurity()
        {
            Assert.IsInstanceOf(typeof(CheckSaySecurity), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("SaySecurity", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestCashAcceptorError()
        {
            Assert.IsInstanceOf(typeof(InvokeCashAcceptorError), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("CashAcceptorError", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestCoinAcceptorError()
        {
            Assert.IsInstanceOf(typeof(InvokeCoinAcceptorError), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("CoinAcceptorError", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestScannerError()
        {
            Assert.IsInstanceOf(typeof(InvokeScannerError), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("ScannerError", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestCheckCountPercentage()
        {
            Assert.IsInstanceOf(typeof(CheckCountPercentage), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("CMCountPercentage", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestCheckCashStatus()
        {
            Assert.IsInstanceOf(typeof(CheckCashStatus), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("CMDispenserCapacity", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestCheckCMCashCount()
        {
            Assert.IsInstanceOf(typeof(CheckCMCashCount), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("CMCashCount", "")), lane, hooks, 500, true).CreateCommand());
        }
        [Test]
        public void TestCheckPrinterError()
        {
            Assert.IsInstanceOf(typeof(InvokeCheckPrinterError), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("POSPrinter", "")), lane, hooks, 500, true).CreateCommand());
        }
        [Test]
        public void TestCheckPrinting()
        {
            Assert.IsInstanceOf(typeof(CheckPrinterError), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("PrinterError", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestCheckTabTransport()
        {
            Assert.IsInstanceOf(typeof(CheckTabTransport), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("TABTransport", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestResetTABSmartScale()
        {
            Assert.IsInstanceOf(typeof(ResetTABSmartScale), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("TABSmartScale", "")), lane, hooks, 500, true).CreateCommand());
        }

        [Test]
        public void TestCheckTabReverse()
        {
            Assert.IsInstanceOf(typeof(CheckTabReverse), DeviceEventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("TABReverse", "")), lane, hooks, 500, true).CreateCommand());
        }
    }
}