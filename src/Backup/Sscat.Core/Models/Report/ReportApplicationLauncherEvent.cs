// <copyright file="ReportApplicationLauncherEvent.cs" company="NCR">
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
    /// Initializes a new instance of the ReportApplicationLauncherEvent class
    /// </summary>
    [Serializable]
    public class ReportApplicationLauncherEvent
    {
        /// <summary>
        /// Host name
        /// </summary>
        private string _hostName;

        /// <summary>
        /// Application path
        /// </summary>
        private string _applicationPath;

        /// <summary>
        /// Initializes a new instance of the ReportApplicationLauncherEvent class
        /// </summary>
        public ReportApplicationLauncherEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ReportApplicationLauncherEvent class
        /// </summary>
        /// <param name="item">application launcher event</param>
        public ReportApplicationLauncherEvent(IApplicationLauncherEvent item)
        {
            Host = item.Host;
            Path = item.ApplicationPath;
        }

        /// <summary>
        /// Gets or sets the host name
        /// </summary>
        [XmlAttribute("Host")]
        public string Host
        {
            get { return _hostName; }
            set { _hostName = value; }
        }

        /// <summary>
        /// Gets or sets the application path
        /// </summary>
        [XmlAttribute("Path")]
        public string Path
        {
            get { return _applicationPath; }
            set { _applicationPath = value; }
        }
    }
}
