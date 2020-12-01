// <copyright file="UIValidationPropertyChange.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.Report;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the UIValidationPropertyChange class
    /// </summary>
    public class UIValidationPropertyChange : UIValidationEventCommand
    {
        /// <summary>
        /// Report UI Validation events
        /// </summary>
        private ReportUIValidationEvent[] _reportUIVEvents;

        /// <summary>
        /// Initializes a new instance of the UIValidationPropertyChange class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">ngui automated event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public UIValidationPropertyChange(IScotLogHook hook, IUIValidationEvents item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
            ReportUIVEvents = new ReportUIValidationEvent[0];
        }

        /// <summary>
        /// Gets or sets the UI Validation Events
        /// </summary>
        public ReportUIValidationEvent[] ReportUIVEvents
        {
            get
            {
                if (_reportUIVEvents == null)
                {
                    return new ReportUIValidationEvent[0];
                }

                return _reportUIVEvents;
            }

            set
            {
                if (value != null)
                {
                    _reportUIVEvents = value;
                }
            }
        }

        /// <summary>
        /// Runs the automated next gen UI end of transaction event
        /// </summary>
        public override void Run()
        {
            int i = 0;
            ReportUIVEvents = new ReportUIValidationEvent[Item.UIValidationEvnts.Length];
            foreach (UIValidationEvent evt in Item.UIValidationEvnts)
            {
                ReportUIVEvents[i] = new ReportUIValidationEvent(evt, ResultType.Skipped);
                i++;
            }

            this.Result = new Result(ResultType.Skipped, "Not yet implemented");
        }
    }
}