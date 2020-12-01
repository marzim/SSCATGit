// <copyright file="AbstractUtilityEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the AbstractUtilityEvent class
    /// </summary>
    /// <typeparam name="T">Base model</typeparam>
    [Serializable]
    public abstract class AbstractUtilityEvent<T> : BaseModel<T>, IUtilityEvent, IStimulus
    {
        /// <summary>
        /// Event ID
        /// </summary>
        private string _eventType;

        /// <summary>
        /// Event value
        /// </summary>
        private string _value;

        /// <summary>
        /// Event sequence ID
        /// </summary>
        private int _seqId;

        /// <summary>
        /// Whether or not event is forgivable 
        /// </summary>
        private bool _isForgivable = false;

        /// <summary>
        /// Whether or not event is exempted
        /// </summary>
        private bool _isExempted = false;

        /// <summary>
        /// Initializes a new instance of the AbstractUtilityEvent class
        /// </summary>
        /// <param name="eventType">event type</param>
        /// <param name="value">event value</param>
        /// <param name="seqId">sequence id</param>
        public AbstractUtilityEvent(string eventType, string value, int seqId)
        {
            EventType = eventType;
            Value = value;
            SeqId = seqId;
        }

        /// <summary>
        /// Gets a value indicating whether the event is exempted
        /// </summary>
        public bool IsExempted
        {
            get { return false; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the event is forgivable
        /// </summary>
        [XmlIgnore]
        public bool IsForgivable
        {
            get { return _isForgivable; }
            set { _isForgivable = value; }
        }

        /// <summary>
        /// Gets or sets the sequence ID
        /// </summary>
        [XmlIgnore]
        public virtual int SeqId
        {
            get { return _seqId; }
            set { _seqId = value; }
        }

        /// <summary>
        /// Gets or sets the event value
        /// </summary>
        [XmlIgnore]
        public virtual string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        /// Gets or sets the event type
        /// </summary>
        [XmlIgnore]
        public virtual string EventType
        {
            get { return _eventType; }
            set { _eventType = value; }
        }

        /// <summary>
        /// Gets a value indicating whether or not the event is a stimulus
        /// </summary>
        public bool IsStimulus
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the type of event
        /// </summary>
        public abstract string Type { get; }

        /// <summary>
        /// Creates a string about the utility event
        /// </summary>
        /// <returns>Returns the utility event information</returns>
        public override string ToString()
        {
            return string.Format("{0}: {1}", _eventType, _value);
        }

        /// <summary>
        /// Creates a string about the utility event
        /// </summary>
        /// <returns>Returns the utility event information</returns>
        public override string ToRepresentation()
        {
            string prefix = string.Empty;

            switch (EventType)
            {
                case Constants.UtilityEvent.UTILITY_SLEEP:
                    return string.Format("{0}[Utility] Sleep: Value={1}(ms)", prefix, Value);
                default:
                    return ToString();
            }
        }

        /// <summary>
        /// Checks if the event item given is same type as script event
        /// </summary>
        /// <param name="eventItemToCompareWith">event item to compare with</param>
        /// <returns>Returns true if event item type is the same, false otherwise</returns>
        public bool IsSimilarEventItemWith(IScriptEventItem eventItemToCompareWith)
        {
            bool isSimilar = false;
            return isSimilar;
        }

        /// <summary>
        /// Creates the script event
        /// </summary>
        /// <returns>Returns the script event</returns>
        public abstract IScriptEvent CreateEvent();

        /// <summary>
        /// Creates the script event
        /// </summary>
        /// <param name="time">time of the event</param>
        /// <param name="enabled">whether or not it is enabled</param>
        /// <returns>Returns the script event</returns>
        public abstract IScriptEvent CreateEvent(long time, bool enabled);

        /// <summary>
        /// Creates the script event
        /// </summary>
        /// <param name="time">time of the event</param>
        /// <param name="dateTime">date and time</param>
        /// <param name="enabled">whether or not it is enabled</param>
        /// <returns>Returns the script event</returns>
        public abstract IScriptEvent CreateEvent(long time, DateTime dateTime, bool enabled);

        /// <summary>
        /// Creates the script event item
        /// </summary>
        /// <returns>Returns the script event</returns>
        public abstract IScriptEventItem ToEventItem();
    }
}