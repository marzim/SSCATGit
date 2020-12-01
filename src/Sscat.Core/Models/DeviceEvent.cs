// <copyright file="DeviceEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the DeviceEvent class
    /// </summary>
    [XmlRoot("Device"), Serializable()]
    public class DeviceEvent : AbstractDeviceEvent<DeviceEvent>
    {
        /// <summary>
        /// Initializes a new instance of the DeviceEvent class
        /// </summary>
        public DeviceEvent()
            : this(string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DeviceEvent class
        /// </summary>
        /// <param name="id">event id</param>
        /// <param name="val">event value</param>
        public DeviceEvent(string id, string val)
            : this(id, val, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DeviceEvent class
        /// </summary>
        /// <param name="id">event id</param>
        /// <param name="val">event value</param>
        /// <param name="seqId">sequence id</param>
        public DeviceEvent(string id, string val, int seqId)
            : base(id, val, seqId)
        {
        }

        /// <summary>
        /// Gets or sets the sequence ID
        /// </summary>
        [XmlAttribute("SeqId")]
        public override int SeqId
        {
            get { return base.SeqId; }
            set { base.SeqId = value; }
        }

        /// <summary>
        /// Gets or sets the event value
        /// </summary>
        [XmlAttribute("Value")]
        public override string Value
        {
            get { return base.Value; }
            set { base.Value = value; }
        }

        /// <summary>
        /// Gets or sets the event ID
        /// </summary>
        [XmlAttribute("Id")]
        public override string Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        /// <summary>
        /// Gets the type of event
        /// </summary>
        public override string Type
        {
            get { return "Device"; }
        }

        /// <summary>
        /// Creates the device event
        /// </summary>
        /// <returns>Returns the script event</returns>
        public override IScriptEvent CreateEvent()
        {
            return CreateEvent(0, true);
        }

        /// <summary>
        /// Creates the device event
        /// </summary>
        /// <param name="time">time of the event</param>
        /// <param name="enabled">whether or not it is enabled</param>
        /// <returns>Returns the script event</returns>
        public override IScriptEvent CreateEvent(int time, bool enabled)
        {
            return new ScriptEvent(time, enabled, this);
        }

        /// <summary>
        /// Creates the device event item
        /// </summary>
        /// <returns>Returns the script event</returns>
        public override IScriptEventItem ToEventItem()
        {
            return new DeviceEvent(Id, Value, SeqId);
        }
    }
}
