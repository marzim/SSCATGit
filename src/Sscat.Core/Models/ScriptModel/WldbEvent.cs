// <copyright file="WldbEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Xml.Serialization;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the WldbEvent class
    /// </summary>
    [XmlRoot("Wldb"), Serializable()]
    public class WldbEvent : AbstractScriptEventItem<WldbEvent>, IWldbEvent
    {
        /// <summary>
        /// Server name
        /// </summary>
        private string _host;

        /// <summary>
        /// Name of the action
        /// </summary>
        private string _action;

        /// <summary>
        /// Weight learning database file
        /// </summary>
        private string _wldbFile;

        /// <summary>
        /// Configuration file
        /// </summary>
        private string _saConfigFile;

        /// <summary>
        /// Script file name
        /// </summary>
        private string _scriptFileName;

        /// <summary>
        /// User name
        /// </summary>
        private string _user;

        /// <summary>
        /// The password
        /// </summary>
        private string _password;

        /// <summary>
        /// Initializes a new instance of the WldbEvent class
        /// </summary>
        public WldbEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the WldbEvent class
        /// </summary>
        /// <param name="host">host name</param>
        /// <param name="wldbFile">wldb file</param>
        /// <param name="saConfigFile">configuration file</param>
        /// <param name="user">user name</param>
        /// <param name="password">the password</param>
        public WldbEvent(string host, string wldbFile, string saConfigFile, string user, string password)
            : this(string.Empty, host, wldbFile, saConfigFile, user, password)
        {
        }

        /// <summary>
        /// Initializes a new instance of the WldbEvent class
        /// </summary>
        /// <param name="action">action name</param>
        /// <param name="host">host name</param>
        /// <param name="wldbFile">wldb file</param>
        /// <param name="saConfigFile">security agent configuration file</param>
        /// <param name="user">user name</param>
        /// <param name="password">the password</param>
        public WldbEvent(string action, string host, string wldbFile, string saConfigFile, string user, string password)
        {
            Action = action;
            Host = host;
            WldbFile = wldbFile;
            SAConfigFile = saConfigFile;
            User = user;
            Password = password;
        }

        /// <summary>
        /// Gets the event type
        /// </summary>
        [XmlIgnoreAttribute]
        public override string Type
        {
            get { return "WLDBEventData"; }
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
        /// Gets or sets the server name
        /// </summary>
        [XmlElement("Servername")]
        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }

        /// <summary>
        /// Gets or sets the action
        /// </summary>
        [XmlElement("Action")]
        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }

        /// <summary>
        /// Gets or sets the WLDB file path
        /// </summary>
        [XmlElement("WLDBFilePath")]
        public string WldbFile
        {
            get { return _wldbFile; }
            set { _wldbFile = value; }
        }

        /// <summary>
        /// Gets or sets the security agent configuration file path
        /// </summary>
        [XmlElement("SAConfigFilePath")]
        public string SAConfigFile
        {
            get { return _saConfigFile; }
            set { _saConfigFile = value; }
        }

        /// <summary>
        /// Gets or sets the user name
        /// </summary>
        [XmlElement("User")]
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        /// <summary>
        /// Gets or sets the password
        /// </summary>
        [XmlElement("Password")]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
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
        /// Validates the script
        /// </summary>
        public override void Validate()
        {
            base.Validate();

            // Same as SscatLane ValidateScriptname method
            if (ScriptFileName.EndsWith(".xml", true, CultureInfo.CurrentCulture))
            {
                ScriptFileName = ScriptFileName.Remove(ScriptFileName.Length - 4);
            }

            AddErrorIf("- Missing WLDB Script File Name", ScriptFileName == null || ScriptFileName == string.Empty);
            AddErrorIf("- Missing Remote Server Name", Host == string.Empty);
            AddErrorIf("- Enter at least one mdb file or location", WldbFile == string.Empty && SAConfigFile == string.Empty);
            AddErrorIf("- WLDB File Name is Invalid. It should be 'WLDB.mdb'", WldbFile != string.Empty && !Path.GetFileName(WldbFile).ToLower().Equals("wldb.mdb"));
            AddErrorIf("- SAConfig File Name is Invalid. It should be 'SACONFIG.mdb'", SAConfigFile != string.Empty && !Path.GetFileName(SAConfigFile).ToLower().Equals("saconfig.mdb"));
            AddErrorIf("- WLDB Script File Name already exists", DirectoryHelper.GetFiles(@"C:\sscat\Scripts", ScriptFileName + ".xml").Length > 0);
        }

        /// <summary>
        /// Creates a new WLDB event item
        /// </summary>
        /// <returns>Returns the script event item</returns>
        public override IScriptEventItem ToEventItem()
        {
            return new WldbEvent(Action, Host, WldbFile, SAConfigFile, User, Password);
        }

        /// <summary>
        /// Create event
        /// </summary>
        /// <returns>Returns the script event</returns>
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
        /// Formats the event info
        /// </summary>
        /// <returns>Returns the formatted string</returns>
        public override string ToString()
        {
            return string.Format("{0}: {1}", WldbFile, Host);
        }

        /// <summary>
        /// Checks if the event item given is same type as wldb event
        /// </summary>
        /// <param name="eventItemToCompareWith">event item to compare with</param>
        /// <returns>Returns true if event item type is the same, false otherwise</returns>
        public override bool IsSimilarEventItemWith(IScriptEventItem eventItemToCompareWith)
        {
            return (eventItemToCompareWith != null) ? this.Type.Equals(eventItemToCompareWith.Type) : false;
        }
    }
}
