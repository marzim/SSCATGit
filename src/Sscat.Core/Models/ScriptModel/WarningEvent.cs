// <copyright file="WarningEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the WarningEvent class
    /// </summary>
    [XmlRoot("WarningEvent"), Serializable()]
    public class WarningEvent : AbstractWarningEvent<WarningEvent>
    {
        /// <summary>
        /// Initializes a new instance of the WarningEvent class
        /// </summary>
        public WarningEvent()
            : this(string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the WarningEvent class
        /// </summary>
        /// <param name="eventType">event type</param>
        /// <param name="warningNotes">warning notes</param>
        public WarningEvent(string eventType, string warningNotes)
        {
            EventType = eventType;
            WarningNotes = warningNotes;
        }

        /// <summary>
        /// Gets or sets the event type
        /// </summary>
        [XmlAttribute("EventType")]
        public override string EventType
        {
            get { return base.EventType; }
            set { base.EventType = value; }
        }

        /// <summary>
        /// Gets or sets the warning notes
        /// </summary>
        [XmlAttribute("WarningNotes")]
        public override string WarningNotes
        {
            get { return base.WarningNotes; }
            set { base.WarningNotes = value; }
        }

        /// <summary>
        /// Gets the event type
        /// </summary>
        public override string Type
        {
            get { return "Warning"; }
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
        /// Creates a new warning event
        /// </summary>
        /// <returns>Returns the script event item</returns>
        public override IScriptEventItem ToEventItem()
        {
            return new WarningEvent(EventType, WarningNotes);
        }
    }
}
