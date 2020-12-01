// <copyright file="PsxKeyPress.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the PsxKeyPress class
    /// </summary>
    public class PsxKeyPress : PsxKeyDown
    {
        /// <summary>
        /// Initializes a new instance of the PsxKeyPress class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="item">psx event</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public PsxKeyPress(IScotLogHook hook, SscatLane lane, IPsxEvent item, int timeout, bool enableHook)
            : base(hook, lane, item, timeout, enableHook)
        {
        }

        /// <summary>
        /// Runs the PSX key press event
        /// </summary>
        public override void Run()
        {
            this.Result = new Result(ResultType.Skipped, "Skipped");
        }
    }
}
