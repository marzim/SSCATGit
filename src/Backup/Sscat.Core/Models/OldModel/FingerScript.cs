// <copyright file="FingerScript.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.OldModel
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the DeviceEvent class
    /// </summary>
    [XmlRoot("FingerScript"), Serializable()]
    public class FingerScript
    {
        /// <summary>
        /// Script index
        /// </summary>
        private int _index;

        /// <summary>
        /// Script screenshot path
        /// </summary>
        private string _screenShotPath;

        /// <summary>
        /// Script diagnostic path
        /// </summary>
        private string _diagnosticPath;

        /// <summary>
        /// Script duration
        /// </summary>
        private int _duration;

        /// <summary>
        /// Finger build
        /// </summary>
        private string _fingerBuild;

        /// <summary>
        /// Script name
        /// </summary>
        private string _scriptName;

        /// <summary>
        /// Script description
        /// </summary>
        private string _scriptDescription;

        /// <summary>
        /// Fastlane build
        /// </summary>
        private string _flBuild;

        /// <summary>
        /// Script date time
        /// </summary>
        private string _dateTime;

        /// <summary>
        /// Script file name
        /// </summary>
        private string _fileName;

        /// <summary>
        /// Script events
        /// </summary>
        private FingerScriptEvent[] _scriptEvents;

        /// <summary>
        /// Initializes a new instance of the FingerScript class
        /// </summary>
        public FingerScript()
        {
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
        /// Gets or sets the screenshot path
        /// </summary>
        [XmlElement("ScreenshotPath")]
        public string ScreenshotPath
        {
            get { return _screenShotPath; }
            set { _screenShotPath = value; }
        }

        /// <summary>
        /// Gets or sets the diagnostic path
        /// </summary>
        [XmlElement("DiagnosticPath")]
        public string DiagnosticPath
        {
            get { return _diagnosticPath; }
            set { _diagnosticPath = value; }
        }

        /// <summary>
        /// Gets or sets the script duration
        /// </summary>
        [XmlElement("Duration")]
        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        /// <summary>
        /// Gets or sets the sscat version
        /// </summary>
        [XmlElement("fingerBuild")]
        public string FingerBuild
        {
            get { return _fingerBuild; }
            set { _fingerBuild = value; }
        }

        /// <summary>
        /// Gets or sets the script name
        /// </summary>
        [XmlElement("scriptName")]
        public string ScriptName
        {
            get { return _scriptName; }
            set { _scriptName = value; }
        }

        /// <summary>
        /// Gets or sets the script description
        /// </summary>
        [XmlElement("scriptDescription")]
        public string ScriptDescription
        {
            get { return _scriptDescription; }
            set { _scriptDescription = value; }
        }

        /// <summary>
        /// Gets or sets the ssco version
        /// </summary>
        [XmlElement("flBuild")]
        public string FLBuild
        {
            get { return _flBuild; }
            set { _flBuild = value; }
        }

        /// <summary>
        /// Gets or sets the date time
        /// </summary>
        [XmlElement("dateTime")]
        public string DateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        /// <summary>
        /// Gets or sets the file name
        /// </summary>
        [XmlElement("FileName")]
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>
        /// Gets or sets the event data
        /// </summary>
        [XmlElement("FingerEventData")]
        public FingerScriptEvent[] FingerScriptEvents
        {
            get
            {
                if (_scriptEvents == null)
                {
                    return new FingerScriptEvent[0];
                }

                return _scriptEvents;
            }

            set
            {
                if (value != null)
                {
                    _scriptEvents = value;
                }
            }
        }
    }
}