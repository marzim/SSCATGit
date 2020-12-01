// <copyright file="ReportDeviceEvent.cs" company="NCR">
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
    /// Initializes a new instance of the ReportDeviceEvent class
    /// </summary>
    [Serializable]
    public class ReportDeviceEvent
    {
        /// <summary>
        /// Device ID
        /// </summary>
        private string _deviceID;

        /// <summary>
        /// Device value
        /// </summary>
        private string _deviceValue;

        /// <summary>
        /// Initializes a new instance of the ReportDeviceEvent class
        /// </summary>
        public ReportDeviceEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ReportDeviceEvent class
        /// </summary>
        /// <param name="deviceEventItem">device event item</param>
        public ReportDeviceEvent(IDeviceEvent deviceEventItem)
        {
            Id = deviceEventItem.Id;
            Value = deviceEventItem.Value;
        }

        /// <summary>
        /// Gets or sets the device ID
        /// </summary>
        [XmlAttribute("Id")]
        public string Id
        {
            get { return _deviceID; }
            set { _deviceID = value; }
        }

        /// <summary>
        /// Gets or sets the device value
        /// </summary>
        [XmlAttribute("Value")]
        public string Value
        {
            get { return _deviceValue; }
            set { _deviceValue = value; }
        }
    }
}
