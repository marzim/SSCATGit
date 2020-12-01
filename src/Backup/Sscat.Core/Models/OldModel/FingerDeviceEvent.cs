// <copyright file="FingerDeviceEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.OldModel
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the FingerDeviceEvent class
    /// </summary>
    [XmlRoot("DeviceEventData"), Serializable()]
    public class FingerDeviceEvent
    {
        /// <summary>
        /// Event sequence ID
        /// </summary>
        private int _seqId;

        /// <summary>
        /// Whether or not event is forgivable 
        /// </summary>
        private bool _isForgivable = false;
        
        /// <summary>
        /// Event ID
        /// </summary>
        private string _id;

        /// <summary>
        /// Event value
        /// </summary>
        private string _val;

        /// <summary>
        /// Initializes a new instance of the FingerDeviceEvent class
        /// </summary>
        public FingerDeviceEvent()
        {
        }

        /// <summary>
        /// Gets or sets the sequence ID
        /// </summary>
        [XmlElement("seqId")]
        public int SeqId
        {
            get { return _seqId; }
            set { _seqId = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the event is forgivable
        /// </summary>
        [XmlElement("IsForgivable")]
        public bool IsForgivable
        {
            get { return _isForgivable; }
            set { _isForgivable = value; }
        }

        /// <summary>
        /// Gets or sets the device ID
        /// </summary>
        [XmlElement("deviceId")]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Gets or sets the device value
        /// </summary>
        [XmlElement("deviceValue")]
        public string Value
        {
            get { return _val; }
            set { _val = value; }
        }
    }
}
