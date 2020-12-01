// <copyright file="FingerUIAutoTestEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.OldModel
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the FingerUIAutoTestEvent class
    /// </summary>
    [XmlRoot("UIAutoTestEvent"), Serializable()]
    public class FingerUIAutoTestEvent
    {
        /// <summary>
        /// Event sequence ID
        /// </summary>
        private int _seqId;

        /// <summary>
        /// Whether or not event is forgivable 
        /// </summary>
        private bool _isForgivable = false;

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
        /// Initializes a new instance of the FingerUIAutoTestEvent class
        /// </summary>
        public FingerUIAutoTestEvent()
        {
        }

        /// <summary>
        /// Gets or sets the sequence ID
        /// </summary>
        [XmlElement("seqId")]
        public int SeqId
        {
            get { return _seqId; }
            set { _seqId = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the event is forgivable
        /// </summary>
        [XmlElement("IsForgivable")]
        public bool IsForgivable
        {
            get { return _isForgivable; }
            set { _isForgivable = value; }
        }

        /// <summary>
        /// Gets or sets the event type
        /// </summary>
        [XmlElement("eventType")]
        public string EventType
        {
            get { return _eventType; }
            set { _eventType = value; }
        }

        /// <summary>
        /// Gets or sets the control name
        /// </summary>
        [XmlElement("controlName")]
        public string ControlName
        {
            get { return _controlName; }
            set { _controlName = value; }
        }

        /// <summary>
        /// Gets or sets the button name
        /// </summary>
        [XmlElement("buttonName")]
        public string ButtonName
        {
            get { return _buttonName; }
            set { _buttonName = value; }
        }

        /// <summary>
        /// Gets or sets the index
        /// </summary>
        [XmlElement("index")]
        public string Index
        {
            get { return _index; }
            set { _index = value; }
        }

        /// <summary>
        /// Gets or sets the button data
        /// </summary>
        [XmlElement("buttonData")]
        public string ButtonData
        {
            get { return _buttonData; }
            set { _buttonData = value; }
        }

        /// <summary>
        /// Gets or sets the context name
        /// </summary>
        [XmlElement("contextName")]
        public string ContextName
        {
            get { return _contextName; }
            set { _contextName = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether event is a valid login or not
        /// </summary>
        [XmlElement("validLogin")]
        public string ValidLogin
        {
            get { return _validLogin; }
            set { _validLogin = value; }
        }
    }
}
