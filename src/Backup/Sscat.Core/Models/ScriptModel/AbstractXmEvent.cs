// <copyright file="AbstractXmEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the AbstractXmEvent class
    /// </summary>
    /// <typeparam name="T">Base model</typeparam>
    [Serializable]
    public abstract class AbstractXmEvent<T> : BaseModel<T>, IXmEvent, IStimulus
    {
        /// <summary>
        /// Event ID
        /// </summary>
        private string _id;

        /// <summary>
        /// Event values
        /// </summary>
        private string[] _values;

        /// <summary>
        /// Value count
        /// </summary>
        private int _valueCount;

        /// <summary>
        /// Sequential ID
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
        /// Initializes a new instance of the AbstractXmEvent class
        /// </summary>
        /// <param name="id">event id</param>
        /// <param name="valueCount">value count</param>
        /// <param name="values">event values</param>
        /// <param name="seqId">sequence ID</param>
        public AbstractXmEvent(string id, int valueCount, string[] values, int seqId)
        {
            Id = id;
            ValueCount = valueCount;
            Values = values;
            SeqId = seqId;

            switch (id)
            {
                case Constants.XmEvent.XM_PRINT_DATA:
                case Constants.XmEvent.XM_COUNT_CHANGES:
                    _isForgivable = true;
                    break;
            }
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
        /// Gets or sets the event value count
        /// </summary>
        [XmlIgnore]
        public virtual int ValueCount
        {
            get { return _valueCount; }
            set { _valueCount = value; }
        }

        /// <summary>
        /// Gets or sets the event values
        /// </summary>
        [XmlIgnore]
        public virtual string[] Values
        {
            get
            {
                if (_values != null)
                {
                    return _values;
                }

                return new string[] { };
            }

            set
            {
                _values = value;
            }
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
        /// Gets a value indicating whether or not the event is a stimulus
        /// </summary>
        public bool IsStimulus
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
        /// Gets a value indicating whether the event is exempted
        /// </summary>
        public bool IsExempted
        {
            get { return _isExempted; }
        }

        /// <summary>
        /// Gets the type of event
        /// </summary>
        public abstract string Type { get; }

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
        /// Creates the script event item
        /// </summary>
        /// <returns>Returns the script event</returns>
        public abstract IScriptEventItem ToEventItem();

        /// <summary>
        /// Checks if the event item given is same type as script event
        /// </summary>
        /// <param name="eventItemToCompareWith">event item to compare with</param>
        /// <returns>Returns true if event item type is the same, false otherwise</returns>
        public virtual bool IsSimilarEventItemWith(IScriptEventItem eventItemToCompareWith)
        {
            bool isSimilar = false;
            if (eventItemToCompareWith != null && eventItemToCompareWith is IXmEvent &&
                (eventItemToCompareWith as IXmEvent).Id.Equals(this.Id))
            {
                isSimilar = true;
            }

            return isSimilar;
        }

        /// <summary>
        /// Creates a string about the script event
        /// </summary>
        /// <returns>Returns the script event information</returns>
        public override string ToString()
        {
            return string.Format("Checking {0}", Id);
        }

        /// <summary>
        /// Creates a string about the script event
        /// </summary>
        /// <returns>Returns the script event information</returns>
        public override string ToRepresentation()
        {
            switch (Id)
            {
                case Constants.XmEvent.XM_PRINT_DATA:
                    return string.Format("Checking Cash Management Print Data Report");
                case Constants.XmEvent.XM_COUNT_CHANGES:
                    return string.Format("Checking Cash Management count after changes");
                default:
                    return ToString();
            }
        }
    }
}
