// <copyright file="AbstractScriptEventItem.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;

    /// <summary>
    /// Initializes a new instance of the AbstractScriptEventItem class
    /// </summary>
    /// <typeparam name="T">Base model</typeparam>
    [Serializable]
    public abstract class AbstractScriptEventItem<T> : BaseModel<T>, IScriptEventItem
    {
        /// <summary>
        /// Sequence ID
        /// </summary>
        private int _seqId;
        
        /// <summary>
        /// Whether or not the script event item is forgivable
        /// </summary>
        private bool _isForgivable = false;

        /// <summary>
        /// Whether or not the script event item is exempted
        /// </summary>
        private bool _isExempted = false;

        /// <summary>
        /// Gets a value indicating whether or not the event is a stimulus
        /// </summary>
        public virtual bool IsStimulus
        {
            get { return false; }
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
        /// Gets or sets a value indicating whether or not the script event item is forgivable
        /// </summary>
        [XmlIgnore]
        public virtual bool IsForgivable
        {
            get { return _isForgivable; }
            set { _isForgivable = value; }
        }

        /// <summary>
        /// Gets a value indicating whether or not the script event item is exempted
        /// </summary>
        public virtual bool IsExempted
        {
            get { return _isExempted; }
        }

        /// <summary>
        /// Gets the event type
        /// </summary>
        public abstract string Type { get; }

        /// <summary>
        /// Checks if the event item given is same type as the script event
        /// </summary>
        /// <param name="eventItemToCompareWith">event item to compare with</param>
        /// <returns>Returns true if event item type is the same, false otherwise</returns>
        public abstract bool IsSimilarEventItemWith(IScriptEventItem eventItemToCompareWith);

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
    }
}
