// <copyright file="ReportReportEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.Report
{
    using System;
    using System.Xml.Serialization;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ReportReportEvent class
    /// </summary>
    [Serializable]
    public class ReportReportEvent
    {
        /// <summary>
        /// Report ID
        /// </summary>
        private string _reportID;

        /// <summary>
        /// Report value
        /// </summary>
        private string _reportValue;
        
        /// <summary>
        /// Initializes a new instance of the ReportReportEvent class
        /// </summary>
        public ReportReportEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ReportReportEvent class
        /// </summary>
        /// <param name="item">report event item</param>
        public ReportReportEvent(IReportEvent item)
        {
            Id = item.Id;
            Val = item.Value;
        }

        /// <summary>
        /// Gets or sets the report ID
        /// </summary>
        [XmlAttribute("Id")]
        public string Id
        {
            get { return _reportID; }
            set { _reportID = value; }
        }

        /// <summary>
        /// Gets or sets the report value
        /// </summary>
        [XmlAttribute("Value")]
        public string Val
        {
            get { return _reportValue; }
            set { _reportValue = value; }
        }
    }
}
