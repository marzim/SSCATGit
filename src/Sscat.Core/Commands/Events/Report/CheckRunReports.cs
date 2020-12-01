// <copyright file="CheckRunReports.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the CheckRunReports class
    /// </summary>
    public class CheckRunReports : ReportEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the CheckRunReports class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">report event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public CheckRunReports(IScotLogHook hook, IReportEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Runs the check reports event
        /// </summary>
        public override void Run()
        {
            OnRunning(string.Format("Verify report '{0}' was run", Item.Value));
            base.Run();
            Lane.CaptureScreen(Item.Value, Item.Id);
        }
    }
}
