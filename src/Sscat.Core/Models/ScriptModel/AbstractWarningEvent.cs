// <copyright file="AbstractWarningEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the AbstractWarningEvent class
    /// </summary>
    /// <typeparam name="T">Base model</typeparam>
    [Serializable]
    public abstract class AbstractWarningEvent<T> : BaseModel<T>, IWarningEvent, IStimulus
    {
        /// <summary>
        /// Event type
        /// </summary>
        private string _eventType = string.Empty;

        /// <summary>
        /// Warning Notes
        /// </summary>
        private string _warningNotes = string.Empty;

        /// <summary>
        /// Sequence ID
        /// </summary>
        private int _seqId = 0;

        /// <summary>
        /// Whether or not the event is forgivable
        /// </summary>
        private bool _isForgivable = false;

        /// <summary>
        /// Initializes a new instance of the AbstractWarningEvent class
        /// </summary>
        public AbstractWarningEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AbstractWarningEvent class
        /// </summary>
        /// <param name="eventType">event type</param>
        /// <param name="warningNotes">warning notes</param>
        public AbstractWarningEvent(string eventType, string warningNotes)
        {
            EventType = eventType;
            WarningNotes = warningNotes;
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
        /// Gets or sets the warning notes
        /// </summary>
        [XmlIgnore]
        public virtual string WarningNotes
        {
            get { return _warningNotes; }
            set { _warningNotes = value; }
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
        /// Gets or sets a value indicating whether or not the script event is forgivable
        /// </summary>
        [XmlIgnore]
        public bool IsForgivable
        {
            get { return _isForgivable; }
            set { _isForgivable = value; }
        }

        /// <summary>
        /// Gets a value indicating whether or not the script event is a stimulus
        /// </summary>
        public bool IsStimulus
        {
            get
            {
                return EventType != Constants.UIAutoTestEvent.CONTEXT_CHANGED;
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not the script event is exempted
        /// </summary>
        public bool IsExempted
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
        /// Creates a string about the script event
        /// </summary>
        /// <returns>Returns the script event information</returns>
        public override string ToString()
        {
            return string.Format("[Warning] {0}: WarningNotes={1}", EventType, WarningNotes.Replace("{", "{{").Replace("}", "}}"));
        }

        /// <summary>
        /// Creates a string about the script event
        /// </summary>
        /// <returns>Returns the script event information</returns>
        public override string ToRepresentation()
        {
            // used in ui
            return ToString();
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
