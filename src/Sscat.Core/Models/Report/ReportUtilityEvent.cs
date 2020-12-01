// <copyright file="ReportUtilityEvent.cs" company="NCR">
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
    /// Initializes a new instance of the ReportUtilityEvent class
    /// </summary>
    [Serializable]
    public class ReportUtilityEvent
    {
        /// <summary>
        /// Device ID
        /// </summary>
        private string _eventType;

        /// <summary>
        /// Device value
        /// </summary>
        private string _value;

        /// <summary>
        /// Initializes a new instance of the ReportUtilityEvent class
        /// </summary>
        public ReportUtilityEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ReportUtilityEvent class
        /// </summary>
        /// <param name="utililtyEvent">utility event item</param>
        public ReportUtilityEvent(IUtilityEvent utililtyEvent)
        {
            EventType = utililtyEvent.EventType;
            Value = utililtyEvent.Value;
        }

        /// <summary>
        /// Gets or sets the device ID
        /// </summary>
        [XmlAttribute("EventType")]
        public string EventType
        {
            get { return _eventType; }
            set { _eventType = value; }
        }

        /// <summary>
        /// Gets or sets the device value
        /// </summary>
        [XmlAttribute("Value")]
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
