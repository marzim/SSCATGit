// <copyright file="CheckXmPrintData.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the CheckXmPrintData class
    /// </summary>
    public class CheckXmPrintData : XmEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the CheckXmPrintData class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">cash management event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public CheckXmPrintData(IScotLogHook hook, IXmEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Runs the check cash management print data event
        /// </summary>
        public override void Run()
        {
            base.Run();
        }
    }
}
