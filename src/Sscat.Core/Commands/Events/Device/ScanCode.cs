// <copyright file="ScanCode.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
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
    /// Initializes a new instance of the ScanCode class
    /// </summary>
    public class ScanCode : DeviceEventCommand
    {
        /// <summary>
        /// Interface for the scanner
        /// </summary>
        private IScanner _scanner;

        /// <summary>
        /// Initializes a new instance of the ScanCode class
        /// </summary>
        /// <param name="scanner">interface for the scanner</param>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public ScanCode(IScanner scanner, IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
            if (scanner == null)
            {
                throw new ArgumentNullException("Scanner");
            }

            _scanner = scanner;
        }

        /// <summary>
        /// Runs the scanner emulator
        /// </summary>
        public override void Run()
        {
            try
            {
                _scanner.Emulating += new EventHandler<EmulatorEventArgs>(ScannerEmulating);
                _scanner.Scan(Item.Value, Timeout);
                base.Run();
            }
            catch (EmulatorTimeoutException ex)
            {
                Result = new Result(ResultType.Failed, Regex.Replace(ex.Message, @"\t|\n|\r", "; "));
            }
            catch (Exception ex)
            {
                Result = new Result(ResultType.Failed, Regex.Replace(ex.Message, @"\t|\n|\r", "; "));
            }
            finally
            {
#if NET40
                NextGenUITestClient.Instance.CheckConnection();
#endif
                _scanner.Emulating -= new EventHandler<EmulatorEventArgs>(ScannerEmulating);
            }
        }

        /// <summary>
        /// Runs the scanner emulator
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">emulator event arguments</param>
        private void ScannerEmulating(object sender, EmulatorEventArgs e)
        {
            OnRunning(e.Message);
        }
    }
}
