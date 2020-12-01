// <copyright file="AbstractUIAutoPOSEmulatorEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the AbstractUIAutoPOSEmulatorEvent class
    /// </summary>
    /// <typeparam name="T">Base model</typeparam>
    [Serializable]
    public abstract class AbstractUIAutoPOSEmulatorEvent<T> : BaseModel<T>, IUIAutoPOSEmulatorEvent, IStimulus
    {
        /// <summary>
        /// Event type
        /// </summary>
        private string _eventType = string.Empty;

        /// <summary>
        /// Name of the control
        /// </summary>
        private string _controlName = string.Empty;

        /// <summary>
        /// Name of the button
        /// </summary>
        private string _buttonName = string.Empty;

        /// <summary>
        /// Name of the context
        /// </summary>
        private string _contextName = string.Empty;

        /// <summary>
        /// Sequence ID
        /// </summary>
        private int _seqId = 0;

        /// <summary>
        /// Whether or not the script event is forgivable
        /// </summary>
        private bool _isForgivable = false;

        /// <summary>
        /// Initializes a new instance of the AbstractUIAutoPOSEmulatorEvent class
        /// </summary>
        public AbstractUIAutoPOSEmulatorEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AbstractUIAutoPOSEmulatorEvent class
        /// </summary>
        /// <param name="eventType">event type</param>
        /// <param name="controlName">control name</param>
        /// <param name="buttonName">button name</param>
        /// <param name="contextName">context name</param>
        public AbstractUIAutoPOSEmulatorEvent(string eventType, string controlName, string buttonName, string contextName)
        {
            EventType = eventType;
            ControlName = controlName;
            ButtonName = buttonName;
            ContextName = contextName;
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
        /// Gets or sets the control name
        /// </summary>
        [XmlIgnore]
        public virtual string ControlName
        {
            get { return _controlName; }
            set { _controlName = value; }
        }

        /// <summary>
        /// Gets or sets the button name
        /// </summary>
        [XmlIgnore]
        public virtual string ButtonName
        {
            get { return _buttonName; }
            set { _buttonName = value; }
        }

        /// <summary>
        /// Gets or sets the context name
        /// </summary>
        [XmlIgnore]
        public virtual string ContextName
        {
            get { return _contextName; }
            set { _contextName = value; }
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
        /// Gets or sets a value indicating whether or not the script event is forgivable
        /// </summary>
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
                return EventType != Constants.UIAutoPOSEmulatorEvent.CONTEXT_CHANGED;
            }
        }
        
        /// <summary>
        /// Gets the type of event
        /// </summary>
        public abstract string Type { get; }
        
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
        /// Creates a string about the script event
        /// </summary>
        /// <returns>Returns the script event information</returns>
        public override string ToString()
        {
            switch (EventType)
            {
                case Constants.UIAutoPOSEmulatorEvent.BUTTON_CLICK:
                    return string.Format("UIAutoPOSEmulatorEvent: Clicking Button {0} on Context {1}", ButtonName, ContextName);
                case Constants.UIAutoPOSEmulatorEvent.CONTEXT_CHANGED:
                    return string.Format("UIAutoPOSEmulatorEvent: Context changed to {0}", ContextName);
                default:
                    return ToString();
            }
        }

        /// <summary>
        /// Creates a string about the script event
        /// </summary>
        /// <returns>Returns the script event information</returns>
        public override string ToRepresentation()
        {
            return ToString();
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
        public abstract IScriptEvent CreateEvent(int time, bool enabled);

        /// <summary>
        /// Creates the script event item
        /// </summary>
        /// <returns>Returns the script event</returns>
        public abstract IScriptEventItem ToEventItem();
    }
}
