// <copyright file="PsxUnsupportedEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the PsxUnsupportedEvent class
    /// </summary>
    public class PsxUnsupportedEvent : PsxEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the PsxUnsupportedEvent class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">psx event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public PsxUnsupportedEvent(IScotLogHook hook, IPsxEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Runs the unsupported PSX event
        /// </summary>
        public override void Run()
        {
            Result = new Result(ResultType.Skipped, "Unsupported PSX Event");
        }
    }
}
