// <copyright file="CheckPrinterError.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System;
    using Ncr.Core.Emulators;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the CheckPrinterError class
    /// </summary>
    public class CheckPrinterError : EmulatorEventCommand
    {
        /// <summary>
        /// Interface for POS printer
        /// </summary>
        private IPosPrinter _posprinter;

        /// <summary>
        /// Initializes a new instance of the CheckPrinterError class
        /// </summary>
        /// <param name="posprinter">POS Printer</param>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public CheckPrinterError(IPosPrinter posprinter, IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, posprinter, lane, timeout, enableHook)
        {
            if (posprinter == null)
            {
                throw new ArgumentNullException("POS Printer");
            }

            _posprinter = posprinter;
        }

        /// <summary>
        /// Runs the point of sale printer for the duration of the timeout
        /// </summary>
        public override void Run()
        {
            try
            {
                _posprinter.Printing(Timeout);
                Result = new Result(ResultType.Passed, "OK");
            }
            catch
            {
                throw;
            }
        }
    }
}