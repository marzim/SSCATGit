// <copyright file="CheckXmCountChanges.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the CheckXmCountChanges class
    /// </summary>
    public class CheckXmCountChanges : XmEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the CheckXmCountChanges class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">cash management event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public CheckXmCountChanges(IScotLogHook hook, IXmEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Runs the check external mode count changes event
        /// </summary>
        public override void Run()
        {
            base.Run();
        }
    }
}
