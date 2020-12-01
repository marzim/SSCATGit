// <copyright file="RunReportsEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.ReportEvents
{
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the RunReportsEventAdder class
    /// </summary>
    public class RunReportsEventAdder : ReportEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the RunReportsEventAdder class
        /// </summary>
        public RunReportsEventAdder()
            : base(Constants.ReportEvent.RUN_REPORTS)
        {
        }
    }
}
