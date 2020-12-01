// <copyright file="SSCATScript.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the SSCATScript class
    /// </summary>
    [XmlRoot("SSCATScript"), Serializable()]
    public class SSCATScript : AbstractScript<SSCATScript>, IScript
    {
        /// <summary>
        /// SSCAT script events
        /// </summary>
        private SSCATScriptEvent[] _scriptEvents;

        /// <summary>
        /// DateTime of the script on script conversion
        /// </summary>
        private string _dateTimeConverted = string.Empty;

        /// <summary>
        /// SSCAT Version of the script on script conversion
        /// </summary>
        private string _sscatVersionConverted = string.Empty;

        /// <summary>
        /// Initializes a new instance of the SSCATScript class
        /// </summary>
        public SSCATScript()
        {
        }

        /// <summary>
        /// Initializes a new instance of the SSCATScript class
        /// </summary>
        /// <param name="name">script name</param>
        /// <param name="description">script description</param>
        public SSCATScript(string name, string description)
            : this(name, description, string.Empty, string.Empty, new List<IScriptEvent>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the SSCATScript class
        /// </summary>
        /// <param name="name">script name</param>
        /// <param name="description">script description</param>
        /// <param name="build">sscat version</param>
        /// <param name="sscoBuild">ssco build</param>
        /// <param name="item">script event item</param>
        public SSCATScript(string name, string description, string build, string sscoBuild, SSCATScriptEvent item)
            : this(name, description, build, sscoBuild, new SSCATScriptEvent[] { item })
        {
        }

        /// <summary>
        /// Initializes a new instance of the SSCATScript class
        /// </summary>
        /// <param name="name">script name</param>
        /// <param name="description">script description</param>
        /// <param name="build">sscat version</param>
        /// <param name="sscoBuild">ssco build</param>
        /// <param name="events">script events</param>
        public SSCATScript(string name, string description, string build, string sscoBuild, SSCATScriptEvent[] events)
            : this(name, description, build, sscoBuild, new List<IScriptEvent>(events))
        {
        }

        /// <summary>
        /// Initializes a new instance of the SSCATScript class
        /// </summary>
        /// <param name="name">script name</param>
        /// <param name="description">script description</param>
        /// <param name="build">sscat version</param>
        /// <param name="sscoBuild">ssco build</param>
        /// <param name="events">script events</param>
        public SSCATScript(string name, string description, string build, string sscoBuild, List<IScriptEvent> events)
            : this(name, description, build, sscoBuild, string.Empty, events)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SSCATScript class
        /// </summary>
        /// <param name="name">script name</param>
        /// <param name="description">script description</param>
        /// <param name="build">sscat version</param>
        /// <param name="sscoBuild">ssco build</param>
        /// <param name="filename">script file name</param>
        /// <param name="events">script events</param>
        public SSCATScript(string name, string description, string build, string sscoBuild, string filename, List<IScriptEvent> events)
        {
            Name = name;
            SscatVersion = build;
            SscoVersion = sscoBuild;
            FileName = filename;
            Description = description;
            DateTime = System.DateTime.Now.ToString();
            ScriptEvents = new SSCATScriptEvent[events.Count];
            events.CopyTo(ScriptEvents);
            Events.AddEvents(ScriptEvents);
        }

        /// <summary>
        /// Gets or sets the result
        /// </summary>
        [XmlElement("Result")]
        public override Result Result
        {
            get { return base.Result; }
            set { base.Result = value; }
        }

        /// <summary>
        /// Gets or sets the index
        /// </summary>
        [XmlAttribute("Index")]
        public override int Index
        {
            get { return base.Index; }
            set { base.Index = value; }
        }

        /// <summary>
        /// Gets or sets the script events
        /// </summary>
        [XmlIgnoreAttribute]
        public override ScriptEvents Events
        {
            get { return base.Events; }
            set { base.Events = value; }
        }

        /// <summary>
        /// Gets or sets the sscat version
        /// </summary>
        [XmlElement("SscatVersion")]
        public override string SscatVersion
        {
            get { return base.SscatVersion; }
            set { base.SscatVersion = value; }
        }

        /// <summary>
        /// Gets or sets the script name
        /// </summary>
        [XmlElement("ScriptName")]
        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        /// <summary>
        /// Gets or sets the script description
        /// </summary>
        [XmlElement("ScriptDescription")]
        public override string Description
        {
            get { return base.Description; }
            set { base.Description = value; }
        }

        /// <summary>
        /// Gets or sets the ssco version
        /// </summary>
        [XmlElement("SscoVersion")]
        public override string SscoVersion
        {
            get { return base.SscoVersion; }
            set { base.SscoVersion = value; }
        }

        /// <summary>
        /// Gets or sets the date time
        /// </summary>
        [XmlElement("DateTime")]
        public override string DateTime
        {
            get { return base.DateTime; }
            set { base.DateTime = value; }
        }

        /// <summary>
        /// Gets or sets the date time
        /// </summary>
        [XmlElement("DateTimeConverted")]
        public string DateTimeConverted
        {
            get { return _dateTimeConverted; }
            set { _dateTimeConverted = value; }
        }

        /// <summary>
        /// Gets or sets the date time
        /// </summary>
        [XmlElement("SscatVersionConverted")]
        public string SscatVersionConverted
        {
            get { return _sscatVersionConverted; }
            set { _sscatVersionConverted = value; }
        }

        /// <summary>
        /// Gets or sets the file name
        /// </summary>
        [XmlElement("FileName")]
        public override string FileName
        {
            get { return base.FileName; }
            set { base.FileName = value; }
        }

        /// <summary>
        /// Gets or sets the event data
        /// </summary>
        [XmlElement("Event")]
        public SSCATScriptEvent[] ScriptEvents
        {
            get
            {
                if (_scriptEvents == null)
                {
                    return new SSCATScriptEvent[0];
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

        /// <summary>
        /// Gets or sets the version
        /// </summary>
        [XmlIgnoreAttribute]
        public override string Version
        {
            get { return base.Version; }
            set { base.Version = value; }
        }

        /// <summary>
        /// Deserializes the script by given file name
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the script</returns>
        public static new SSCATScript Deserialize(string filename)
        {
            SSCATScript script = null;
            if (filename != null)
            {
                try
                {
                    script = Deserialize(new StreamReader(filename));
                    script.FileName = filename;
                }
                catch (FileNotFoundException)
                {
                    throw new Exception(string.Format("Could not find '{0}'! Please make sure the file(s) exist(s).", filename));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return script;
        }

        /// <summary>
        /// Deserializes the script by given text reader
        /// </summary>
        /// <param name="reader">text reader</param>
        /// <returns>Returns the script</returns>
        public static new SSCATScript Deserialize(TextReader reader)
        {
            SSCATScript script = BaseSerializable<SSCATScript>.Deserialize(reader);
            script.Events.AddEvents(script.ScriptEvents);
            return script;
        }

        /// <summary>
        /// Get Warning List
        /// </summary>
        /// <returns>an array of WarningEvent</returns>
        public SSCATScriptEvent[] GetWarningList()
        {
            List<SSCATScriptEvent> warningEvents = new List<SSCATScriptEvent>();
            try
            {
                foreach (SSCATScriptEvent e in ScriptEvents)
                {
                    if (e.Item is IWarningEvent)
                    {
                        warningEvents.Add(new SSCATScriptEvent(e.Item as IWarningEvent));
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.ToString());
            }

            return warningEvents.ToArray();
        }

#if NET40
        /// <summary>
        /// Get Warning List
        /// </summary>
        /// <returns>an array of WarningEvent</returns>
        public SSCATScriptEvent[] GetUIValidationEvents()
        {
            List<SSCATScriptEvent> uiValidationEvents = new List<SSCATScriptEvent>();
            try
            {
                foreach (SSCATScriptEvent e in ScriptEvents)
                {
                    if (e.Item is IUIValidationEvents)
                    {
                        uiValidationEvents.Add(e);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.ToString());
            }

            return uiValidationEvents.ToArray();
        }
#endif
        
        /// <summary>
        /// Refresh Script Events
        /// </summary>
        /// <param name="listEvent">list events</param>
        public void RefreshScriptEvents(List<IScriptEvent> listEvent)
        {
            SSCATScriptEvent[] tempScriptEvent = ScriptEvents;
            ScriptEvents = new SSCATScriptEvent[listEvent.Count];

            int i = 0;
            foreach (IScriptEvent s in listEvent)
            {
                if (s.Item is IWarningEvent)
                {
                    ScriptEvents[i] = new SSCATScriptEvent(s.Item as IScriptEventItem);
                    ScriptEvents[i].Result = s.Result;
                }
                else
                {
                    ScriptEvents[i] = tempScriptEvent[i];
                }

                i++;
            }
        }

        /// <summary>
        /// Creates to script
        /// </summary>
        /// <returns>Returns a script</returns>
        public IScript ToScript()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Revises all MS cards
        /// </summary>
        /// <param name="nameOfMSCardToUse">names of the MS cards</param>
        /// <returns>Returns true if able to revise, false otherwise</returns>
        public bool ReviseAllMSCardsUsedTo(string nameOfMSCardToUse)
        {
            return base.ReviseAllMSCardsUsedTo(nameOfMSCardToUse);
        }

        /// <summary>
        /// ShouldSerialize* pattern for DateTimeConverted
        /// </summary>
        /// <returns>returns if DateTimeConverted is null or empty</returns>
        public bool ShouldSerializeDateTimeConverted()
        {
            return !string.IsNullOrEmpty(DateTimeConverted);
        }

        /// <summary>
        /// ShouldSerialize* pattern for VersionConverted
        /// </summary>
        /// <returns>returns if VersionConverted is null or empty</returns>
        public bool ShouldSerializeSscatVersionConverted()
        {
            return !string.IsNullOrEmpty(SscatVersionConverted);
        }
    }
}
