// <copyright file="ReportWldbEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.Report
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Ncr.Core.Net;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ReportWldbEvent class
    /// </summary>
    [Serializable]
    public class ReportWldbEvent
    {
        /// <summary>
        /// Event action
        /// </summary>
        private string _action;

        /// <summary>
        /// Host name
        /// </summary>
        private string _host;

        /// <summary>
        /// Configuration file
        /// </summary>
        private string _saConfigFile;

        /// <summary>
        /// Weight learning database file
        /// </summary>
        private string _wldbFile;

        /// <summary>
        /// Initializes a new instance of the ReportWldbEvent class
        /// </summary>
        public ReportWldbEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ReportWldbEvent class
        /// </summary>
        /// <param name="item">wldb event item</param>
        public ReportWldbEvent(IWldbEvent item)
        {
            Action = item.Action;
            Host = item.Host;
            SAConfigFile = item.SAConfigFile;
            WldbFile = item.WldbFile;
        }

        /// <summary>
        /// Gets or sets the WLDB file
        /// </summary>
        [XmlAttribute("WldbFile")]
        public string WldbFile
        {
            get { return _wldbFile; }
            set { _wldbFile = value; }
        }

        /// <summary>
        /// Gets or sets the security agent configuration file
        /// </summary>
        [XmlAttribute("SAConfigFile")]
        public string SAConfigFile
        {
            get { return _saConfigFile; }
            set { _saConfigFile = value; }
        }

        /// <summary>
        /// Gets or sets the host name
        /// </summary>
        [XmlAttribute("Host")]
        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }

        /// <summary>
        /// Gets or sets the action
        /// </summary>
        [XmlAttribute("Action")]
        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }
    }
}
