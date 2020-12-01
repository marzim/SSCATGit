// <copyright file="ReportLaunchPadPsxEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.Report
{
    using System;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ReportLaunchPadPsxEvent class
    /// </summary>
    [Serializable]
    public class ReportLaunchPadPsxEvent : ReportPsxEvent
    {
        /// <summary>
        /// Initializes a new instance of the ReportLaunchPadPsxEvent class
        /// </summary>
        public ReportLaunchPadPsxEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ReportLaunchPadPsxEvent class
        /// </summary>
        /// <param name="item">launchpad psx event item</param>
        public ReportLaunchPadPsxEvent(ILaunchPadPsxEvent item)
        {
            Id = item.Id;
            Context = item.Context;
            RemoteConnection = item.RemoteConnection;
            Event = item.Event;
        }
    }
}
