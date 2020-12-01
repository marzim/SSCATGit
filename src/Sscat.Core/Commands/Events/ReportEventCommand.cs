// <copyright file="ReportEventCommand.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ReportEventCommand class
    /// </summary>
    public class ReportEventCommand : AbstractEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the ReportEventCommand class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">report event item</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public ReportEventCommand(IScotLogHook hook, IReportEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Gets the report event item
        /// </summary>
        public IReportEvent Item
        {
            get { return ScriptEventItem as IReportEvent; }
        }
    }
}