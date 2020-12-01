// <copyright file="ErrorEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ErrorEvent class
    /// </summary>
    [XmlRoot("ErrorEvent"), Serializable()]
    public class ErrorEvent : AbstractErrorEvent<ErrorEvent>
    {
        /// <summary>
        /// Initializes a new instance of the ErrorEvent class
        /// </summary>
        public ErrorEvent()
            : this(string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ErrorEvent class
        /// </summary>
        /// <param name="eventType">event type</param>
        /// <param name="errorNotes">error notes</param>
        public ErrorEvent(string eventType, string errorNotes)
        {
            EventType = eventType;
            ErrorNotes = errorNotes;
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
        /// Gets or sets the error notes
        /// </summary>
        [XmlAttribute("ErrorNotes")]
        public override string ErrorNotes
        {
            get { return base.ErrorNotes; }
            set { base.ErrorNotes = value; }
        }

        /// <summary>
        /// Gets the event type
        /// </summary>
        public override string Type
        {
            get { return "Error"; }
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
        /// Creates a new error event
        /// </summary>
        /// <returns>Returns the script event item</returns>
        public override IScriptEventItem ToEventItem()
        {
            return new ErrorEvent(EventType, ErrorNotes);
        }
    }
}
