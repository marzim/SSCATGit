// <copyright file="ReportEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ReportEvent class
    /// </summary>
    [XmlRoot("Report"), Serializable()]
    public class ReportEvent : AbstractReportEvent<ReportEvent>
    {
        /// <summary>
        /// Initializes a new instance of the ReportEvent class
        /// </summary>
        public ReportEvent()
            : this(string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ReportEvent class
        /// </summary>
        /// <param name="id">event id</param>
        /// <param name="val">event value</param>
        public ReportEvent(string id, string val)
            : base(id, val, 0)
        {
        }

        /// <summary>
        /// Gets or sets the report ID
        /// </summary>
        [XmlElement("ReportId")]
        public override string Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        /// <summary>
        /// Gets or sets the report value
        /// </summary>
        [XmlElement("ReportValue")]
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
        /// Gets the event type
        /// </summary>
        public override string Type
        {
            get { return "ReportEventData"; }
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
        /// Creates a new report event
        /// </summary>
        /// <returns>Returns the script event item</returns>
        public override IScriptEventItem ToEventItem()
        {
            return new ReportEvent(Id, Value);
        }

        /// <summary>
        /// Checks if the event item given is same type as report event
        /// </summary>
        /// <param name="eventItemToCompareWith">event item to compare with</param>
        /// <returns>Returns true if event item type is the same, false otherwise</returns>
        public override bool IsSimilarEventItemWith(IScriptEventItem eventItemToCompareWith)
        {
            return (eventItemToCompareWith != null) ? Type.Equals(eventItemToCompareWith.Type) : false;
        }
    }
}
