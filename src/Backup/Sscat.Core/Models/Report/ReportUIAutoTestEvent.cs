// <copyright file="ReportUIAutoTestEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.Report
{
    using System;
    using System.Xml.Serialization;
    using Sscat.Core.Models.ScriptModel;
    
#if NET40

    /// <summary>
    /// Initializes a new instance of the ReportUIAutoTestEvent class
    /// </summary>
    [Serializable]
    public class ReportUIAutoTestEvent
    {
        /// <summary>
        /// Event type
        /// </summary>
        private string _eventType;

        /// <summary>
        /// Control name
        /// </summary>
        private string _controlName;

        /// <summary>
        /// Button name
        /// </summary>
        private string _buttonName;

        /// <summary>
        /// Event index
        /// </summary>
        private string _index;

        /// <summary>
        /// Button data
        /// </summary>
        private string _buttonData;

        /// <summary>
        /// Context name
        /// </summary>
        private string _contextName;

        /// <summary>
        /// Whether or not the event is a valid login
        /// </summary>
        private string _validLogin;

        /// <summary>
        /// Initializes a new instance of the ReportUIAutoTestEvent class
        /// </summary>
        public ReportUIAutoTestEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ReportUIAutoTestEvent class
        /// </summary>
        /// <param name="item">auto test event item</param>
        public ReportUIAutoTestEvent(IUIAutoTestEvent item)
        {
            EventType = item.EventType;
            ContextName = item.ContextName;
            ControlName = item.ControlName;
            ButtonName = item.ButtonName;
            ButtonData = item.ButtonData;
            Index = item.Index;
            ValidLogin = item.ValidLogin;
        }

        /// <summary>
        /// Gets or sets the event type
        /// </summary>
        [XmlAttribute("EventType")]
        public string EventType
        {
            get { return _eventType; }
            set { _eventType = value; }
        }

        /// <summary>
        /// Gets or sets the context name
        /// </summary>
        [XmlAttribute("ContextName")]
        public string ContextName
        {
            get { return _contextName; }
            set { _contextName = value; }
        }

        /// <summary>
        /// Gets or sets the control name
        /// </summary>
        [XmlAttribute("ControlName")]
        public string ControlName
        {
            get { return _controlName; }
            set { _controlName = value; }
        }

        /// <summary>
        /// Gets or sets the button name
        /// </summary>
        [XmlAttribute("ButtonName")]
        public string ButtonName
        {
            get { return _buttonName; }
            set { _buttonName = value; }
        }

        /// <summary>
        /// Gets or sets the button data
        /// </summary>
        [XmlAttribute("ButtonData")]
        public string ButtonData
        {
            get { return _buttonData; }
            set { _buttonData = value; }
        }

        /// <summary>
        /// Gets or sets the event index
        /// </summary>
        [XmlAttribute("Index")]
        public string Index
        {
            get { return _index; }
            set { _index = value; }
        }

        /// <summary>
        /// Gets or sets whether or not the event is a valid login
        /// </summary>
        [XmlAttribute("ValidLogin")]
        public string ValidLogin
        {
            get { return _validLogin; }
            set { _validLogin = value; }
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
#endif
}
