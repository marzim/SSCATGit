// <copyright file="DeviceEventCommandFactory.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Ncr.Core.Emulators;
    using Sscat.Core.Commands.Events;
    using Sscat.Core.Commands.Events.Device;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the DeviceEventCommandFactory class
    /// </summary>
    public class DeviceEventCommandFactory : EventCommandFactory
    {
        /// <summary>
        /// Interface for the device event
        /// </summary>
        private IDeviceEvent _item;

        /// <summary>
        /// Initializes a new instance of the DeviceEventCommandFactory class
        /// </summary>
        /// <param name="item">device event item</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="hooks">scot log hooks</param>
        /// <param name="timeout">timeout amount</param>
        /// <param name="enableHook">whether or not the hook is enabled</param>
        public DeviceEventCommandFactory(IDeviceEvent item, SscatLane lane, Dictionary<string, IScotLogHook> hooks, int timeout, bool enableHook)
            : base(lane, hooks, timeout, enableHook)
        {
            _item = item;
        }

        /// <summary>
        /// Creates the device event command
        /// </summary>
        /// <returns>Returns event command</returns>
        public override IEventCommand CreateCommand()
        {
            switch (_item.Id)
            {
                case Constants.DeviceType.AMOUNT_TAX_DUE:
                    return new CheckAmountAndTaxDue(Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.CHANGE_DUE_AND_TENDER_TYPE:
                    return new CheckChangeDueAndTenderType(Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.BAG_SCALE:
                    return new WeighBagScale(Lane.Emulators[Emulator.BagScaleCaption] as IBagScale, Hooks[ScotLogHook.SM], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.CASH_ACCEPTOR:
                    return new EscrowCash(Lane.Emulators[Emulator.CashAcceptorCaption] as ICashAcceptor, Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.CASH_TROUGH:
                    return new RemoveCashTrough(Lane.Emulators[Emulator.CashTroughCaption] as ICashTrough, Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.CASH_ACCEPTOR_ERROR:
                    return new InvokeCashAcceptorError(Lane.Emulators[Emulator.CashAcceptorCaption] as ICashAcceptor, Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.COIN_ACCEPTOR:
                    return new InsertCoin(Lane.Emulators[Emulator.CoinAcceptorCaption] as ICoinAcceptor, Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.COIN_ACCEPTOR_ERROR:
                    return new InvokeCoinAcceptorError(Lane.Emulators[Emulator.CoinAcceptorCaption] as ICoinAcceptor, Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.MSR:
                    return new SwipeMsr(Lane.Emulators[Emulator.MsrCaption] as IMsr, Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.PINPAD:
                    return new ExecutePinPad(Lane.Emulators[Emulator.PinPadCaption] as IPinPad, Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.RECEIPT_ITEM:
                    return new CheckReceiptItem(Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.SCALE:
                    return new WeighScale(Lane.Emulators[Emulator.ScaleCaption] as IScale, Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.SCANNER:
                    return new ScanCode(Lane.Emulators[Emulator.ScannerCaption] as IScanner, Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.SCANNER_ERROR:
                    return new InvokeScannerError(Lane.Emulators[Emulator.ScannerCaption] as IScanner, Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.COUPON_SLIP:
                    return new DetectCoupon(Lane.Emulators[Emulator.MotionSensorCaption] as IMotionSensorCoupon, Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.SIGNATURE_CAPTURE:
                    return new CaptureSignature(Lane.Emulators[Emulator.PCSignatureCaptureCaption] as IPCSignatureCapture, Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.TRI_COLOR_LIGHT:
                    return new CheckTriColorLight(Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.SAY_PHRASE:
                    return new CheckSayPhrase(Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.SAY_AMOUNT:
                    return new CheckSayAmount(Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.SAY_SECURITY:
                    return new CheckSaySecurity(Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.CM_DISPENSER_CAPACITY:
                    return new CheckCashStatus(Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.CM_COUNT_PERCENTAGE:
                    return new CheckCountPercentage(Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.CM_CASH_COUNT:
                    return new CheckCMCashCount(Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.TAB_TRANSPORT:
                    return new CheckTabTransport(Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.TAB_SMART_SCALE:
                    return new ResetTABSmartScale(Lane.Emulators[Emulator.BagScaleCaption] as IBagScale, Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.TAB_REVERSE:
                    return new CheckTabReverse(Hooks[ScotLogHook.TAB], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.POS_PRINTER:
                    return new InvokeCheckPrinterError(Lane.Emulators[Emulator.PosPrinterCaption] as IPosPrinter, Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.DeviceType.PRINTER_ERROR:
                    return new CheckPrinterError(Lane.Emulators[Emulator.PosPrinterCaption] as IPosPrinter, Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
#if NET40
                case Constants.DeviceType.ON_AUTOMATED_LOGIN:
                    return new OnAutomatedLogin(Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
#endif
                default:
                    throw new NotSupportedException(string.Format("Device command '{0}' not supported.", _item.Id));
            }
        }
    }
}
