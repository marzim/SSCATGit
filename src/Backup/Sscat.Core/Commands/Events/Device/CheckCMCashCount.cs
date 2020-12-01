// <copyright file="CheckCMCashCount.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the CheckCMCashCount class
    /// </summary>
    public class CheckCMCashCount : DeviceEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the CheckCMCashCount class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public CheckCMCashCount(IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Runs the check CM cash count event
        /// </summary>
        public override void Run()
        {
            Result = new Result(ResultType.Skipped, "Skipped because it is only use to synchronize cash count before script playback.");
        }
    }
}
