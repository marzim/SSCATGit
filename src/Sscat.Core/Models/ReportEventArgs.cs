// <copyright file="ReportEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;

    /// <summary>
    /// Initializes a new instance of the ReportEventArgs class
    /// </summary>
    public class ReportEventArgs : EventArgs
    {
        /// <summary>
        /// Interface for the report class
        /// </summary>
        private IReport _report;

        /// <summary>
        /// Initializes a new instance of the ReportEventArgs class
        /// </summary>
        /// <param name="report">the report</param>
        public ReportEventArgs(IReport report)
        {
            Report = report;
        }

        /// <summary>
        /// Gets or sets the report
        /// </summary>
        public IReport Report
        {
            get { return _report; }
            set { _report = value; }
        }
    }
}
