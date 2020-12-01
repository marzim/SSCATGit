// <copyright file="AbstractUIValidationEvents.cs" company="NCR">
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
    /// Initializes a new instance of the AbstractUIValidationEvents class
    /// </summary>
    /// <typeparam name="T">Base model</typeparam>
    [Serializable]
    public abstract class AbstractUIValidationEvents<T> : BaseModel<T>, IUIValidationEvents, IStimulus
    {
        /// <summary>
        /// Sequence ID
        /// </summary>
        private int _seqId = 0;

        /// <summary>
        /// Whether or not the event is forgivable
        /// </summary>
        private bool _isForgivable = true;

        /// <summary>
        /// Array of UIValidationEvents
        /// </summary>
        private UIValidationEvent[] _uiValidationEvents;

        /// <summary>
        /// Initializes a new instance of the AbstractUIValidationEvents class
        /// </summary>
        public AbstractUIValidationEvents()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AbstractUIValidationEvents class
        /// </summary>
        /// <param name="uiValidationEvents">UI Validation Events</param>
        public AbstractUIValidationEvents(UIValidationEvent[] uiValidationEvents)
        {
            UIValidationEvnts = uiValidationEvents;
        }

        /// <summary>
        /// Gets the type of event
        /// </summary>
        public abstract string Type { get; }

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
        /// Gets or sets the ui validation events
        /// </summary>
        [XmlIgnore]
        public virtual UIValidationEvent[] UIValidationEvnts
        {
            get
            {
                if (_uiValidationEvents == null)
                {
                    return new UIValidationEvent[0];
                }

                return _uiValidationEvents;
            }

            set
            {
                if (value != null)
                {
                    _uiValidationEvents = value;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not the script event is a stimulus
        /// </summary>
        public bool IsStimulus
        {
            get
            {
                return false;
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

        /// <summary>
        /// Creates a string about the script event
        /// </summary>
        /// <returns>Returns the script event information</returns>
        public override string ToString()
        {
            return "[UIValidationEvents] PropertyChange ";
        }
    }
}