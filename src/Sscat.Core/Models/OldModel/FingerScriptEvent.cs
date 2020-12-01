// <copyright file="FingerScriptEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.OldModel
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the FingerScriptEvent class
    /// </summary>
    [XmlRoot("FingerEventData"), Serializable()]
    public class FingerScriptEvent
    {
        /// <summary>
        /// Script event item
        /// </summary>
        private object _item;

        /// <summary>
        /// Script index
        /// </summary>
        private int _scriptIndex;

        /// <summary>
        /// Script event index
        /// </summary>
        private int _index;

        /// <summary>
        /// Script screenshot link
        /// </summary>
        private string _screenShotLink;

        /// <summary>
        /// Whether script event is enabled
        /// </summary>
        private bool _enabled;

        /// <summary>
        /// Event TimeStamp in millisecond
        /// </summary>
        private int _eventTimeMS;

        /// <summary>
        /// Script event type
        /// </summary>
        private string _eventType;

        /// <summary>
        /// Script event result
        /// </summary>
        private Result _result;

        /// <summary>
        /// Initializes a new instance of the FingerScriptEvent class
        /// </summary>
        public FingerScriptEvent()
        {
        }
        
        /// <summary>
        /// Gets or sets the script index
        /// </summary>
        [XmlAttribute("ScriptIndex")]
        public int ScriptIndex
        {
            get { return _scriptIndex; }
            set { _scriptIndex = value; }
        }

        /// <summary>
        /// Gets or sets the index
        /// </summary>
        [XmlAttribute("Index")]
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        /// <summary>
        /// Gets or sets the screenshot link
        /// </summary>
        [XmlAttribute("ScreenshotLink")]
        public string ScreenshotLink
        {
            get { return _screenShotLink; }
            set { _screenShotLink = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not to enable
        /// </summary>
        [XmlElement("enable")]
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        /// <summary>
        /// Gets or sets the event time MS
        /// </summary>
        [XmlElement("eventTimeMS")]
        public int Time
        {
            get { return _eventTimeMS; }
            set { _eventTimeMS = value; }
        }

        /// <summary>
        /// Gets or sets the event type
        /// </summary>
        [XmlElement("eventType")]
        public string Type
        {
            get { return _eventType; }
            set { _eventType = value; }
        }

        /// <summary>
        /// Gets or sets the script event item
        /// </summary>
        [XmlElement("PsxEventData", typeof(FingerPsxEvent)),
         XmlElement("DeviceEventData", typeof(FingerDeviceEvent)),
         XmlElement("UIAutoTestEventData", typeof(FingerUIAutoTestEvent))]
        public object Item
        {
            get
            {
                return _item;
            }

            set
            {
                if (value != null)
                {
                    _item = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the result
        /// </summary>
        [XmlElement("Result")]
        public Result Result
        {
            get { return _result; }
            set { _result = value; }
        }
    }
}
