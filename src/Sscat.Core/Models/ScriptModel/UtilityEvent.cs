// <copyright file="UtilityEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the UtilityEvent class
    /// </summary>
    [XmlRoot("Utility"), Serializable()]
    public class UtilityEvent : AbstractUtilityEvent<UtilityEvent>
    {
        /// <summary>
        /// Initializes a new instance of the UtilityEvent class
        /// </summary>
        public UtilityEvent()
            : this(string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the UtilityEvent class
        /// </summary>
        /// <param name="eventType">event type</param>
        /// <param name="value">event value</param>
        public UtilityEvent(string eventType, string value)
            : base(eventType, value, 0)
        {
        }

        /// <summary>
        /// Gets or sets the event type
        /// </summary>
        [XmlAttribute("Event")]
        public override string EventType
        {
            get { return base.EventType; }
            set { base.EventType = value; }
        }

        /// <summary>
        /// Gets or sets the context name
        /// </summary>
        [XmlAttribute("Value")]
        public override string Value
        {
            get { return base.Value; }
            set { base.Value = value; }
        }

        /// <summary>
        /// Gets the event type
        /// </summary>
        public override string Type
        {
            get { return "UtilityEventData"; }
        }

        /// <summary>
        /// Creates a new utility event
        /// </summary>
        /// <returns>Returns new script event item</returns>
        public override IScriptEventItem ToEventItem()
        {
            return new UtilityEvent(EventType, Value);
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
    }
}