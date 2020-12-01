// <copyright file="AbstractReportEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;

    /// <summary>
    /// Initializes a new instance of the AbstractReportEvent class
    /// </summary>
    /// <typeparam name="T">Base model</typeparam>
    [Serializable]
    public abstract class AbstractReportEvent<T> : AbstractScriptEventItem<T>, IReportEvent
    {
        /// <summary>
        /// Event ID
        /// </summary>
        private string _id;

        /// <summary>
        /// Event value
        /// </summary>
        private string _val;

        /// <summary>
        /// Initializes a new instance of the AbstractReportEvent class
        /// </summary>
        /// <param name="id">event id</param>
        /// <param name="val">event value</param>
        /// <param name="seqId">sequence id</param>
        public AbstractReportEvent(string id, string val, int seqId)
        {
            Id = id;
            Value = val;
            SeqId = seqId;
        }

        /// <summary>
        /// Gets or sets the event value
        /// </summary>
        [XmlIgnore]
        public virtual string Value
        {
            get { return _val; }
            set { _val = value; }
        }

        /// <summary>
        /// Gets or sets the event ID
        /// </summary>
        [XmlIgnore]
        public virtual string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Event detail
        /// </summary>
        /// <returns>Returns the event detail</returns>
        public string EventDetail()
        {
            return string.Format("{0}: {1}", Id, Value);
        }

        /// <summary>
        /// Creates a string about the report event
        /// </summary>
        /// <returns>Returns the report event information</returns>
        public override string ToString()
        {
            return string.Format("{0}: {1}", Id, Value);
        }

        /// <summary>
        /// Checks if the event item given is same type as report event
        /// </summary>
        /// <param name="eventItemToCompareWith">event item to compare with</param>
        /// <returns>Returns true if event item type is the same, false otherwise</returns>
        public override bool IsSimilarEventItemWith(IScriptEventItem eventItemToCompareWith)
        {
            return (eventItemToCompareWith != null) ? this.Type.Equals(eventItemToCompareWith.Type) : false;
        }
    }
}
