// <copyright file="CheckChangeDueAndTenderType.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the CheckChangeDueAndTenderType class
    /// </summary>
    public class CheckChangeDueAndTenderType : DeviceEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the CheckChangeDueAndTenderType class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public CheckChangeDueAndTenderType(IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Runs the check change due and tender type event
        /// </summary>
        public override void Run()
        {
            base.Run();
        }
    }
}
