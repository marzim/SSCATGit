// <copyright file="ReportScript.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the ReportScript class
    /// </summary>
    [Serializable]
    public class ReportScript : IReportScript
    {
        /// <summary>
        /// Script name
        /// </summary>
        private string _scriptName;

        /// <summary>
        /// File name
        /// </summary>
        private string _fileName;

        /// <summary>
        /// Screenshot path
        /// </summary>
        private string _screenshotPath;

        /// <summary>
        /// Diagnostic path
        /// </summary>
        private string _diagnosticPath;

        /// <summary>
        /// Repetition index
        /// </summary>
        private int _repetitionIndex;

        /// <summary>
        /// Script duration
        /// </summary>
        private string _duration;

        /// <summary>
        /// Warning number
        /// </summary>
        private int _warningNumber;

        /// <summary>
        /// Report script events
        /// </summary>
        private ReportScriptEvent[] _events;

        /// <summary>
        /// Report warning events
        /// </summary>
        private ReportWarningEvent[] _warningEvents;

        /// <summary>
        /// Initializes a new instance of the ReportScript class
        /// </summary>
        public ReportScript()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ReportScript class
        /// </summary>
        /// <param name="scriptName">script name</param>
        /// <param name="fileName">file name</param>
        /// <param name="screenshotPath">screenshot path</param>
        /// <param name="diagnosticPath">diagnostic path</param>
        /// <param name="repetitionIndex">repetition index</param>
        /// <param name="duration">duration of the script playback</param>
        /// <param name="warningNumber">number of warnings</param>
        public ReportScript(string scriptName, string fileName, string screenshotPath, string diagnosticPath, int repetitionIndex, string duration, int warningNumber)
        {
            ScriptName = scriptName;
            FileName = fileName;
            ScreenshotPath = screenshotPath;
            DiagnosticPath = diagnosticPath;
            RepetitionIndex = repetitionIndex;
            Duration = duration;
            WarningNumber = warningNumber;
        }

        /// <summary>
        /// Initializes a new instance of the ReportScript class
        /// </summary>
        /// <param name="scriptName">script name</param>
        /// <param name="fileName">file name</param>
        /// <param name="screenshotPath">screenshot path</param>
        /// <param name="diagnosticPath">diagnostic path</param>
        /// <param name="duration">duration of the script playback</param>
        /// <param name="warningNumber">number of warnings</param>
        public ReportScript(string scriptName, string fileName, string screenshotPath, string diagnosticPath, string duration, int warningNumber)
        {
            ScriptName = scriptName;
            FileName = fileName;
            ScreenshotPath = screenshotPath;
            DiagnosticPath = diagnosticPath;
            Duration = duration;
            WarningNumber = warningNumber;
        }

        /// <summary>
        /// Initializes a new instance of the ReportScript class
        /// </summary>
        /// <param name="script">the script</param>
        public ReportScript(IScript script)
        {
            ScriptName = script.Name;
            FileName = script.FileName;
            ScreenshotPath = _screenshotPath;
            DiagnosticPath = _diagnosticPath;
            Duration = _duration;
            AddEvent(script.Events.Events);
        }

        /// <summary>
        /// Gets or sets the script events
        /// </summary>
        [XmlElement("Event")]
        public ReportScriptEvent[] Events
        {
            get
            {
                if (_events == null)
                {
                    return new ReportScriptEvent[0];
                }

                return _events;
            }

            set
            {
                _events = value;
            }
        }

        /// <summary>
        /// Gets or sets the warning script events
        /// </summary>
        [XmlElement("WarningEvent")]
        public ReportWarningEvent[] WarningEvents
        {
            get
            {
                if (_warningEvents == null)
                {
                    return new ReportWarningEvent[0];
                }

                return _warningEvents;
            }

            set
            {
                _warningEvents = value;
            }
        }

        /// <summary>
        /// Gets or sets the file name
        /// </summary>
        [XmlAttribute("FileName")]
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>
        /// Gets or sets the script name
        /// </summary>
        [XmlAttribute("Name")]
        public string ScriptName
        {
            get { return _scriptName; }
            set { _scriptName = value; }
        }

        /// <summary>
        /// Gets or sets the screenshot path
        /// </summary>
        [XmlAttribute("ScreenshotPath")]
        public string ScreenshotPath
        {
            get { return _screenshotPath; }
            set { _screenshotPath = value; }
        }

        /// <summary>
        /// Gets or sets the diagnostic path
        /// </summary>
        [XmlAttribute("DiagnosticPath")]
        public string DiagnosticPath
        {
            get { return _diagnosticPath; }
            set { _diagnosticPath = value; }
        }

        /// <summary>
        /// Gets or sets the repetition index
        /// </summary>
        [XmlAttribute("RepetitionIndex")]
        public int RepetitionIndex
        {
            get { return _repetitionIndex; }
            set { _repetitionIndex = value; }
        }

        /// <summary>
        /// Gets or sets the script duration
        /// </summary>
        [XmlAttribute("Duration")]
        public virtual string Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        /// <summary>
        /// Gets or sets the script duration
        /// </summary>
        [XmlAttribute("WarningNumber")]
        public virtual int WarningNumber
        {
            get { return _warningNumber; }
            set { _warningNumber = value; }
        }

        /// <summary>
        /// Add script events
        /// </summary>
        /// <param name="scriptEvents">script events to add</param>
        public void AddEvent(IScriptEvent[] scriptEvents)
        {
            foreach (IScriptEvent scriptEvent in scriptEvents)
            {
                AddEvent(scriptEvent);
            }
        }

        /// <summary>
        /// Add a script event
        /// </summary>
        /// <param name="scriptEvent">script event to add</param>
        public void AddEvent(IScriptEvent scriptEvent)
        {
            AddEvent(new ReportScriptEvent(scriptEvent));
        }

        /// <summary>
        /// Add a script event
        /// </summary>
        /// <param name="reportScriptEvent">report script event to add</param>
        public void AddEvent(ReportScriptEvent reportScriptEvent)
        {
            List<ReportScriptEvent> reportScriptEvents = new List<ReportScriptEvent>(Events);
            reportScriptEvents.Add(reportScriptEvent);
            _events = new ReportScriptEvent[reportScriptEvents.Count];
            reportScriptEvents.CopyTo(_events);
        }
    }
}
