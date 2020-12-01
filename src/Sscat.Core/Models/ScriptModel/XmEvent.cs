// <copyright file="XmEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the XmEvent class
    /// </summary>
    [XmlRoot("Xm"), Serializable()]
    public class XmEvent : AbstractXmEvent<XmEvent>
    {
        /// <summary>
        /// Initializes a new instance of the XmEvent class
        /// </summary>
        public XmEvent()
            : this(string.Empty, 0, new string[] { })
        {
        }

        /// <summary>
        /// Initializes a new instance of the XmEvent class
        /// </summary>
        /// <param name="id">xm ID</param>
        /// <param name="valueCount">xm value count</param>
        /// <param name="values">xm values</param>
        public XmEvent(string id, int valueCount, string[] values)
            : base(id, valueCount, values, 0)
        {
        }

        /// <summary>
        /// Gets or sets the XM ID
        /// </summary>
        [XmlElement("XMId")]
        public override string Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        /// <summary>
        /// Gets or sets the XM value count
        /// </summary>
        [XmlElement("XMValueCount")]
        public override int ValueCount
        {
            get { return base.ValueCount; }
            set { base.ValueCount = value; }
        }

        /// <summary>
        /// Gets or sets the XM value
        /// </summary>
        [XmlElement("XMValue")]
        public override string[] Values
        {
            get { return base.Values; }
            set { base.Values = value; }
        }

        /// <summary>
        /// Gets or sets the sequence ID
        /// </summary>
        [XmlElement("SeqId")]
        public override int SeqId
        {
            get { return base.SeqId; }
            set { base.SeqId = value; }
        }

        /// <summary>
        /// Gets the event type
        /// </summary>
        public override string Type
        {
            get { return "XmEventData"; }
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

        /// <summary>
        /// Creates the script event
        /// </summary>
        /// <param name="time">time of the event</param>
        /// <param name="dateTime">date and time</param>
        /// <param name="enabled">whether or not it is enabled</param>
        /// <returns>Returns the script event</returns>
        public override IScriptEvent CreateEvent(long time, DateTime dateTime, bool enabled)
        {
            return new SSCATScriptEvent(time, dateTime, enabled, this);
        }

        /// <summary>
        /// Creates a new XM event
        /// </summary>
        /// <returns>Returns the script event item</returns>
        public override IScriptEventItem ToEventItem()
        {
            return new XmEvent(Id, ValueCount, Values);
        }
    }
}
