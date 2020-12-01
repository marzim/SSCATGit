// <copyright file="InvokeCheckPrinterError.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Events.Device
{
    using System;
    using Ncr.Core.Emulators;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the InvokeCheckPrinterError class
    /// </summary>
    public class InvokeCheckPrinterError : EmulatorEventCommand
    {
        /// <summary>
        /// Interface for POS printer
        /// </summary>
        private IPosPrinter _posprinter;

        /// <summary>
        /// Initializes a new instance of the InvokeCheckPrinterError class
        /// </summary>
        /// <param name="posprinter">POS Printer</param>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public InvokeCheckPrinterError(IPosPrinter posprinter, IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, posprinter, lane, timeout, enableHook)
        {
            if (posprinter == null)
            {
                throw new ArgumentNullException("POS Printer");
            }

            _posprinter = posprinter;
        }

        /// <summary>
        /// Runs and checks for printer receipt error or cover being opened
        /// </summary>
        public override void Run()
        {
            try
            {
                if (Item.Value == Constants.PrinterReceiptError.COVER_OPEN || Item.Value == "-99")
                {
                    _posprinter.CoverOpen(Timeout);
                }
                else
                {
                    throw new NotSupportedException(string.Format("Printer Receipt error '{0}' not supported.", Item.Value));
                }

                base.Run();
            }
            catch
            {
                throw;
            }
        }
    }
}
