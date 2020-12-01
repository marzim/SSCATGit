// <copyright file="ApplicationLauncherEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ApplicationLauncherEvent class
    /// </summary>
    [XmlRoot("ApplicationLauncherEventData"), Serializable()]
    public class ApplicationLauncherEvent : AbstractScriptEventItem<ApplicationLauncherEvent>, IApplicationLauncherEvent
    {
        /// <summary>
        /// Host name
        /// </summary>
        private string _host;

        /// <summary>
        /// Application path
        /// </summary>
        private string _applicationPath;
        
        /// <summary>
        /// Script file name
        /// </summary>
        private string _scriptFileName;

        /// <summary>
        /// Initializes a new instance of the ApplicationLauncherEvent class
        /// </summary>
        public ApplicationLauncherEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ApplicationLauncherEvent class
        /// </summary>
        /// <param name="host">host name</param>
        /// <param name="path">application path</param>
        public ApplicationLauncherEvent(string host, string path)
        {
            Host = host;
            ApplicationPath = path;
        }

        /// <summary>
        /// Gets the type
        /// </summary>
        [XmlIgnoreAttribute]
        public override string Type
        {
            get { return "ApplicationLauncher"; }
        }

        /// <summary>
        /// Gets or sets the script file name
        /// </summary>
        [XmlIgnoreAttribute]
        public string ScriptFileName
        {
            get { return _scriptFileName; }
            set { _scriptFileName = value; }
        }

        /// <summary>
        /// Gets or sets the host
        /// </summary>
        [XmlAttribute("Host")]
        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }

        /// <summary>
        /// Gets or sets the application path
        /// </summary>
        [XmlAttribute("Path")]
        public string ApplicationPath
        {
            get { return _applicationPath; }
            set { _applicationPath = value; }
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
        /// Gets or sets a value indicating whether or not the script event is forgivable
        /// </summary>
        [XmlIgnore]
        public override bool IsForgivable
        {
            get { return base.IsForgivable; }
            set { base.IsForgivable = value; }
        }

        /// <summary>
        /// Validates the script file name and application path
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            AddErrorIf("- Missing Script File Name", _scriptFileName == string.Empty);
            AddErrorIf("- Please enter application path", _applicationPath == string.Empty);
        }

        /// <summary>
        /// Creates script event item
        /// </summary>
        /// <returns>Returns script event item</returns>
        public override IScriptEventItem ToEventItem()
        {
            return new ApplicationLauncherEvent(Host, ApplicationPath);
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
        /// Creates a string about the device event
        /// </summary>
        /// <returns>Returns the device event information</returns>
        public override string ToRepresentation()
        {
            return string.Format("{0}; {1}", this.Host, this.ApplicationPath);
        }

        /// <summary>
        /// Get event details
        /// </summary>
        /// <returns>Returns event details</returns>
        public string GetEventDetails()
        {
            return string.Format("{0}; {1}", this.Host, this.ApplicationPath);
        }

        /// <summary>
        /// Checks if the event item given is same type as application launcher event
        /// </summary>
        /// <param name="eventItemToCompareWith">event item to compare with</param>
        /// <returns>Returns true if event item type is the same, false otherwise</returns>
        public override bool IsSimilarEventItemWith(IScriptEventItem eventItemToCompareWith)
        {
            return (eventItemToCompareWith != null) ? Type.Equals(eventItemToCompareWith.Type) : false;
        }
    }
}
