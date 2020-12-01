// <copyright file="InvokeScannerError.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Events.Device
{
    using System;
    using System.Text.RegularExpressions;
    using Ncr.Core.Emulators;
#if NET40
    using Sscat.Core.Commands.Events.UIAutoTest;
#endif
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the InvokeScannerError class
    /// </summary>
    public class InvokeScannerError : DeviceEventCommand
    {
        /// <summary>
        /// Interface for the scanner
        /// </summary>
        private IScanner _scanner;

        /// <summary>
        /// Initializes a new instance of the InvokeScannerError class
        /// </summary>
        /// <param name="scanner">interface for the scanner</param>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public InvokeScannerError(IScanner scanner, IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
            if (scanner == null)
            {
                throw new ArgumentNullException("Scanner");
            }

            _scanner = scanner;
        }

        /// <summary>
        /// Runs the scanner error checks
        /// </summary>
        public override void Run()
        {
            try
            {
                _scanner.Error(Timeout);
                base.Run();
            }
            catch (Exception ex)
            {
                Result = new Result(ResultType.Failed, Regex.Replace(ex.Message, @"\t|\n|\r", "; "));
            }
        }
    }
}
