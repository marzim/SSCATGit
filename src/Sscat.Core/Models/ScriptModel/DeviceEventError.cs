// <copyright file="DeviceEventError.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the DeviceEventError class
    /// </summary>
    [XmlRoot("DeviceError")]
    public class DeviceEventError : DeviceEvent
    {
        /// <summary>
        /// Error message
        /// </summary>
        private string _error;

        /// <summary>
        /// Gets or sets the error message
        /// </summary>
        [XmlAttribute("Error")]
        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }
    }
}
