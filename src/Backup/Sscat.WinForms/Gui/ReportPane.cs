// <copyright file="ReportPane.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Sscat.Gui
{
    using Ncr.Core.Gui;
    using Sscat.Core.Models.Report;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ReportPane class
    /// </summary>
    public partial class ReportPane : BaseUserControl, IReportView
    {
        /// <summary>
        /// Instance of the report class
        /// </summary>
        private Report _report;

        /// <summary>
        /// Initializes a new instance of the ReportPane class
        /// </summary>
        public ReportPane()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the report
        /// </summary>
        public Report Report
        {
            get { return _report; }
            set { _report = value; }
        }
    }
}
