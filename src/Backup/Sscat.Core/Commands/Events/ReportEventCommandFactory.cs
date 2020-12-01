// <copyright file="ReportEventCommandFactory.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Sscat.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Sscat.Core.Commands.Events;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ReportEventCommandFactory class
    /// </summary>
    public class ReportEventCommandFactory : EventCommandFactory
    {
        /// <summary>
        /// Interface for the report event item
        /// </summary>
        private IReportEvent _item;

        /// <summary>
        /// Initializes a new instance of the ReportEventCommandFactory class
        /// </summary>
        /// <param name="item">report event item</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="hooks">scot log hook</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public ReportEventCommandFactory(IReportEvent item, SscatLane lane, Dictionary<string, IScotLogHook> hooks, int timeout, bool enableHook)
            : base(lane, hooks, timeout, enableHook)
        {
            _item = item;
        }

        /// <summary>
        /// Creates the report event command
        /// </summary>
        /// <returns>Returns event command</returns>
        public override IEventCommand CreateCommand()
        {
            switch (_item.Id)
            {
                case Constants.ReportEvent.RUN_REPORTS:
                    return new CheckRunReports(Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                case Constants.ReportEvent.REPORTS_MENU:
                    return new CheckReportsMenu(Hooks[ScotLogHook.Traces], _item, Lane, Timeout, EnableHook);
                default:
                    throw new NotSupportedException(string.Format("Report command '{0}' not supported.", _item.Id));
            }
        }
    }
}