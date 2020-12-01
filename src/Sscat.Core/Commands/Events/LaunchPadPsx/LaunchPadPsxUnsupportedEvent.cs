// <copyright file="LaunchPadPsxUnsupportedEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.LaunchPadPsx
{
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the LaunchPadPsxUnsupportedEvent class
    /// </summary>
    public class LaunchPadPsxUnsupportedEvent : LaunchPadPsxEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the LaunchPadPsxUnsupportedEvent class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">launch pad psx event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public LaunchPadPsxUnsupportedEvent(IScotLogHook hook, ILaunchPadPsxEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, null, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Skips due to unsupported launch pad psx event
        /// </summary>
        public override void Run()
        {
            Result = new Result(ResultType.Skipped, "Unsupported LaunchPadPsx");
        }
    }
}
