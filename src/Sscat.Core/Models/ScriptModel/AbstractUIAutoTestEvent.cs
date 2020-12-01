// <copyright file="AbstractUIAutoTestEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the AbstractUIAutoTestEvent class
    /// </summary>
    /// <typeparam name="T">Base model</typeparam>
    [Serializable]
    public abstract class AbstractUIAutoTestEvent<T> : BaseModel<T>, IUIAutoTestEvent, IStimulus
    {
        /// <summary>
        /// Event type
        /// </summary>
        private string _eventType = string.Empty;
        
        /// <summary>
        /// Control name
        /// </summary>
        private string _controlName = string.Empty;

        /// <summary>
        /// Button name
        /// </summary>
        private string _buttonName = string.Empty;

        /// <summary>
        /// Event Index
        /// </summary>
        private string _index = string.Empty;

        /// <summary>
        /// Button data
        /// </summary>
        private string _buttonData = string.Empty;

        /// <summary>
        /// Context name
        /// </summary>
        private string _contextName = string.Empty;

        /// <summary>
        /// valid login
        /// </summary>
        private string _validLogin = string.Empty;

        /// <summary>
        /// Sequence ID
        /// </summary>
        private int _seqId = 0;

        /// <summary>
        /// Whether or not the event is forgivable
        /// </summary>
        private bool _isForgivable = false;

        /// <summary>
        /// Initializes a new instance of the AbstractUIAutoTestEvent class
        /// </summary>
        public AbstractUIAutoTestEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AbstractUIAutoTestEvent class
        /// </summary>
        /// <param name="eventType">event type</param>
        /// <param name="controlName">control name</param>
        /// <param name="buttonName">button name</param>
        /// <param name="index">the index</param>
        /// <param name="buttonData">button data</param>
        /// <param name="contextName">context name</param>
        /// <param name="validLogin">valid login</param>
        public AbstractUIAutoTestEvent(string eventType, string controlName, string buttonName, string index, string buttonData, string contextName, string validLogin)
        {
            EventType = eventType;
            ContextName = contextName;
            ControlName = controlName;
            ButtonName = buttonName;
            ButtonData = buttonData;
            Index = index;
            ValidLogin = validLogin;

            if (eventType.Equals(Constants.UIAutoTestEvent.CONTEXT_CHANGED))
            {
                switch (contextName)
                {
                    case "SmAuthorization":
                    case "SmVisualItems":
                        _isForgivable = true;
                        break;
                }
            }
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
        /// Gets or sets the context name
        /// </summary>
        [XmlIgnore]
        public virtual string ContextName
        {
            get { return _contextName; }
            set { _contextName = value; }
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
        /// Gets or sets the index
        /// </summary>
        [XmlIgnore]
        public virtual string Index
        {
            get { return _index; }
            set { _index = value; }
        }

        /// <summary>
        /// Gets or sets the button data
        /// </summary>
        [XmlIgnore]
        public virtual string ButtonData
        {
            get { return _buttonData; }
            set { _buttonData = value; }
        }

        /// <summary>
        /// Gets or sets the valid login
        /// </summary>
        [XmlIgnore]
        public virtual string ValidLogin
        {
            get { return _validLogin; }
            set { _validLogin = value; }
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
            // used in loghook
            try
            {
                switch (EventType)
                {
                    case Constants.UIAutoTestEvent.BUTTON_CLICK:
                        if (IsUNavSelect())
                        {
                            return string.Format("[UI] ButtonClick: Button={0} ButtonID={1} Context={2}", ButtonName, ButtonData, ContextName);
                        }
                        return string.Format("[UI] ButtonClick: Button={0} Context={1}", ButtonName, ContextName);

                    case Constants.UIAutoTestEvent.CATEGORY_CLICK:
                        return string.Format("[UI] CategoryButtonClick: Control={0} Index={1} Context={2}", ControlName, Index, ContextName);

                    case Constants.UIAutoTestEvent.KEYBOARD_BUTTON_CLICK:
                        return string.Format("[UI] KeyboardButtonClick: Button={0} ButtonData={1} Context={2}", ButtonName, ButtonData, ContextName);

                    case Constants.UIAutoTestEvent.LIST_BUTTON_CLICK:
                        return string.Format("[UI] ListButtonClick: Button={0} Control={1} Index={2} Context={3}", ButtonName, ControlName, Index, ContextName);

                    case Constants.UIAutoTestEvent.SLIDING_GRID_PAGE_CLICK:
                        return string.Format("[UI] GridPageClick: Control={0} Index={1} ButtonData={2} Context={3}", ControlName, Index, ButtonData, ContextName);

                    case Constants.UIAutoTestEvent.SWIPE_LEFT:
                        return string.Format("[UI] SwipeLeft: Control={0} Context={1}", ControlName, ContextName);

                    case Constants.UIAutoTestEvent.SWIPE_RIGHT:
                        return string.Format("[UI] SwipeRight: Control={0} Context={1}", ControlName, ContextName);

                    case Constants.UIAutoTestEvent.SIGN_SIGNATURE:
                        return string.Format("[UI] SignSignature: Control={0} Context={1}", ControlName, ContextName);

                    case Constants.UIAutoTestEvent.CONTEXT_CHANGED:
                        return string.Format("[UI] ContextChanged: Context={0}", ContextName);

                    case Constants.UIAutoTestEvent.HW_UNAV:
                        if (IsUNavSelect())
                        {
                            return string.Format("[UI] HW-UNAV: ButtonData={0} ButtonName={1} Context={2}", ButtonData, ButtonName, ContextName);
                        }

                        return string.Format("[UI] HW-UNAV: ButtonData={0} Context={1}", ButtonData, ContextName);

                    case Constants.UIAutoTestEvent.AUTOMATED_LOGIN:
                        return string.Format("[UI] AutomatedLogin");

                    case Constants.UIAutoTestEvent.CART_INDEX_CHANGED:
                        return string.Format("[UI] CartIndexChanged: ButtonData={0} Index={1}", ButtonData, Index);

                    default:
                        throw new NullReferenceException();
                        //return ToString();
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(string.Format("Event type {0} not found, please check for any mispelled events.", EventType));
            }
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

        /// <summary>
        /// Checks if the event is a UNav select event
        /// </summary>
        /// <returns>Returns true if UNav select event, false otherwise</returns>
        private bool IsUNavSelect()
        {
            /*
            if (ButtonData.Equals(TestAutomationCommon.Constants.UNavOperation.Select.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (_buttonName.Equals("UNavSelectButton"))
            {
                return true;
            }*/

            return false;
        }
    }
}
