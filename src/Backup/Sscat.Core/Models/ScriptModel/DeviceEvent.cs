// <copyright file="DeviceEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Sscat.Core.Models.ScriptModel;

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
            : base(id, val, 0)
        {
        }

        /// <summary>
        /// Gets the event type
        /// </summary>
        public override string Type
        {
            get { return "DeviceEventData"; }
        }

        /// <summary>
        /// Gets or sets the device ID
        /// </summary>
        [XmlAttribute("Id")]
        public override string Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        /// <summary>
        /// Gets or sets the device value
        /// </summary>
        [XmlAttribute("Value")]
        public override string Value
        {
            get { return base.Value; }
            set { base.Value = value; }
        }

        /// <summary>
        /// Gets or sets the sequence ID
        /// </summary>
        [XmlIgnore]
        public override int SeqId
        {
            get { return base.SeqId; }
            set { base.SeqId = value; }
        }

        /// <summary>
        /// Creates a new device event
        /// </summary>
        /// <returns>Returns new script event item</returns>
        public override IScriptEventItem ToEventItem()
        {
            return new DeviceEvent(Id, Value);
        }

        /// <summary>
        /// Creates event
        /// </summary>
        /// <returns>Returns script event</returns>
        public override IScriptEvent CreateEvent()
        {
            return CreateEvent(0, true);
        }

        /// <summary>
        /// Create event
        /// </summary>
        /// <param name="time">event time</param>
        /// <param name="enabled">whether or not to enable</param>
        /// <returns>Returns the script event</returns>
        public override IScriptEvent CreateEvent(long time, bool enabled)
        {
            return new SSCATScriptEvent(time, enabled, this);
        }
    }
}
