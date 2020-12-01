// <copyright file="UIAutoTestEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the UIAutoTestEvent class
    /// </summary>
    [XmlRoot("UIAutoTest"), Serializable()]
    public class UIAutoTestEvent : AbstractUIAutoTestEvent<UIAutoTestEvent>
    {
        /// <summary>
        /// Initializes a new instance of the UIAutoTestEvent class
        /// </summary>
        public UIAutoTestEvent()
            : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the UIAutoTestEvent class
        /// </summary>
        /// <param name="eventType">type of event</param>
        /// <param name="controlName">name of the control</param>
        /// <param name="buttonName">name of the button</param>
        /// <param name="index">index of the button</param>
        /// <param name="buttonData">button data</param>
        /// <param name="contextName">name of the context</param>
        /// <param name="validLogin">whether or not event is a valid login</param>
        public UIAutoTestEvent(string eventType, string controlName, string buttonName, string index, string buttonData, string contextName, string validLogin)
        {
            EventType = eventType;
            ControlName = controlName;
            ButtonName = buttonName;
            Index = index;
            ButtonData = buttonData;
            ContextName = contextName;
            ValidLogin = validLogin;

            if (eventType.Equals(Constants.UIAutoTestEvent.CONTEXT_CHANGED) && contextName.Contains("Sm"))
            {
                IsForgivable = true;
            }
        }

        /// <summary>
        /// Gets or sets the event type
        /// </summary>
        [XmlAttribute("Event")]
        public override string EventType
        {
            get { return base.EventType; }
            set { base.EventType = value; }
        }

        /// <summary>
        /// Gets or sets the context name
        /// </summary>
        [XmlAttribute("Context")]
        public override string ContextName
        {
            get { return base.ContextName; }
            set { base.ContextName = value; }
        }

        /// <summary>
        /// Gets or sets the control name
        /// </summary>
        [XmlAttribute("Control")]
        public override string ControlName
        {
            get { return base.ControlName; }
            set { base.ControlName = value; }
        }

        /// <summary>
        /// Gets or sets the button name
        /// </summary>
        [XmlAttribute("Button")]
        public override string ButtonName
        {
            get { return base.ButtonName; }
            set { base.ButtonName = value; }
        }

        /// <summary>
        /// Gets or sets the index
        /// </summary>
        [XmlAttribute("Index")]
        public override string Index
        {
            get { return base.Index; }
            set { base.Index = value; }
        }

        /// <summary>
        /// Gets or sets the button data
        /// </summary>
        [XmlAttribute("ButtonData")]
        public override string ButtonData
        {
            get { return base.ButtonData; }
            set { base.ButtonData = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether event is a valid login or not
        /// </summary>
        [XmlAttribute("ValidLogin")]
        public override string ValidLogin
        {
            get { return base.ValidLogin; }
            set { base.ValidLogin = value; }
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
            get { return "UIAutoTest"; }
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
        /// Creates a new UI auto test event
        /// </summary>
        /// <returns>Returns the script event item</returns>
        public override IScriptEventItem ToEventItem()
        {
            return new UIAutoTestEvent(EventType, ControlName, ButtonName, Index, ButtonData, ContextName, ValidLogin);
        }
        
        /// <summary>
        /// ShouldSerialize* pattern for ContextName
        /// </summary>
        /// <returns>returns if ContextName is null or empty</returns>
        public bool ShouldSerializeContextName()
        {
            return !string.IsNullOrEmpty(ContextName);
        }

        /// <summary>
        /// ShouldSerialize* pattern for ControlName
        /// </summary>
        /// <returns>returns if ControlName is null or empty</returns>
        public bool ShouldSerializeControlName()
        {
            return !string.IsNullOrEmpty(ControlName);
        }

        /// <summary>
        /// ShouldSerialize* pattern for ButtonName
        /// </summary>
        /// <returns>returns if ButtonName is null or empty</returns>
        public bool ShouldSerializeButtonName()
        {
            return !string.IsNullOrEmpty(ButtonName);
        }

        /// <summary>
        /// ShouldSerialize* pattern for ButtonData
        /// </summary>
        /// <returns>returns if ButtonData is null or empty</returns>
        public bool ShouldSerializeButtonData()
        {
            return !string.IsNullOrEmpty(ButtonData);
        }

        /// <summary>
        /// ShouldSerialize* pattern for Index
        /// </summary>
        /// <returns>returns if Index is null or empty</returns>
        public bool ShouldSerializeIndex()
        {
            return !string.IsNullOrEmpty(Index);
        }

        /// <summary>
        /// ShouldSerialize* pattern for ValidLogin
        /// </summary>
        /// <returns>returns if ValidLogin is null or empty</returns>
        public bool ShouldSerializeValidLogin()
        {
            return !string.IsNullOrEmpty(ValidLogin);
        }
    }
}
