// <copyright file="AbstractUIValidationEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the AbstractUIValidationEvent class
    /// </summary>
    /// <typeparam name="T">Base model</typeparam>
    [Serializable]
    public abstract class AbstractUIValidationEvent<T> : BaseModel<T>, IUIValidationEvent, IStimulus
    {
        /// <summary>
        /// Event type
        /// </summary>
        private string _eventType = string.Empty;

        /// <summary>
        /// Control Name
        /// </summary>
        private string _controlName = string.Empty;

        /// <summary>
        /// Control Type
        /// </summary>
        private string _controlType = string.Empty;

        /// <summary>
        /// Property Name
        /// </summary>
        private string _property = string.Empty;

        /// <summary>
        /// Property Value
        /// </summary>
        private string _propertyValue = string.Empty;

        /// <summary>
        /// Sequence ID
        /// </summary>
        private int _seqId = 0;

        /// <summary>
        /// Whether or not the event is forgivable
        /// </summary>
        private bool _isForgivable = false;

        /// <summary>
        /// Initializes a new instance of the AbstractUIValidationEvent class
        /// </summary>
        public AbstractUIValidationEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AbstractUIValidationEvent class
        /// </summary>
        /// <param name="eventType">event type</param>
        /// <param name="controlName">control name</param>
        /// <param name="controlType">control type</param>
        /// <param name="property">property name</param>
        /// <param name="propertyValue">property value</param>
        public AbstractUIValidationEvent(string eventType, string controlName, string controlType, string property, string propertyValue)
        {
            EventType = eventType;
            ControlName = controlName;
            ControlType = controlType;
            Property = property;
            PropertyValue = propertyValue;
        }

        /// <summary>
        /// Gets the type of event
        /// </summary>
        public abstract string Type { get; }

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
        /// Gets or sets the control name
        /// </summary>
        [XmlIgnore]
        public virtual string ControlName
        {
            get { return _controlName; }
            set { _controlName = value; }
        }

        /// <summary>
        /// Gets or sets the control type
        /// </summary>
        [XmlIgnore]
        public virtual string ControlType
        {
            get { return _controlType; }
            set { _controlType = value; }
        }

        /// <summary>
        /// Gets or sets the Property
        /// </summary>
        [XmlIgnore]
        public virtual string Property
        {
            get { return _property; }
            set { _property = value; }
        }

        /// <summary>
        /// Gets or sets the Property Value
        /// </summary>
        [XmlIgnore]
        public virtual string PropertyValue
        {
            get { return _propertyValue; }
            set { _propertyValue = value; }
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
        /// Creates a string about the script event
        /// </summary>
        /// <returns>Returns the script event information</returns>
        public override string ToString()
        {
            return string.Format("[UIValidation] ControlPropertyChange: ControlName={0}, ControlType={1}, Property={2}, PropertyValue={3}", ControlName, ControlType, Property, PropertyValue);
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
