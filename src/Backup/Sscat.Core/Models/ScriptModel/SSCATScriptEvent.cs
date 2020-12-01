// <copyright file="SSCATScriptEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml;
    using System.Xml.Serialization;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the SSCATScriptEvent class
    /// </summary>
    [XmlRoot("Event"), Serializable()]
    public class SSCATScriptEvent : AbstractScriptEvent<SSCATScriptEvent>
    {
        /// <summary>
        /// Initializes a new instance of the SSCATScriptEvent class
        /// </summary>
        public SSCATScriptEvent()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SSCATScriptEvent class
        /// </summary>
        /// <param name="item">script event item</param>
        public SSCATScriptEvent(IScriptEventItem item)
            : this(true, item)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SSCATScriptEvent class
        /// </summary>
        /// <param name="time">script time</param>
        /// <param name="enabled">whether or not to enable</param>
        public SSCATScriptEvent(long time, bool enabled)
            : this(time, enabled, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SSCATScriptEvent class
        /// </summary>
        /// <param name="enabled">whether or not to enable</param>
        /// <param name="item">script event item</param>
        public SSCATScriptEvent(bool enabled, IScriptEventItem item)
            : this(0, enabled, item)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SSCATScriptEvent class
        /// </summary>
        /// <param name="time">script time</param>
        /// <param name="enabled">whether or not to enable</param>
        /// <param name="item">script event item</param>
        public SSCATScriptEvent(long time, bool enabled, IScriptEventItem item)
            : this(time, enabled, item, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SSCATScriptEvent class
        /// </summary>
        /// <param name="time">script time</param>
        /// <param name="enabled">whether or not to enable</param>
        /// <param name="item">script event item</param>
        /// <param name="screenshotLink">screenshot link</param>
        public SSCATScriptEvent(long time, bool enabled, IScriptEventItem item, string screenshotLink)
        {
            Time = time;
            Enabled = enabled;
            Item = item;
            ScreenshotLink = screenshotLink;
        }

        /// <summary>
        /// Gets or sets the event's sequence id
        /// </summary>
        [XmlAttribute("SeqID")]
        public override int SequenceID
        {
            get { return base.SequenceID; }
            set { base.SequenceID = value; }
        }

        /// <summary>
        /// Gets or sets the script index
        /// </summary>
        [XmlIgnore]
        public override int ScriptIndex
        {
            get { return base.ScriptIndex; }
            set { base.ScriptIndex = value; }
        }

        /// <summary>
        /// Gets or sets the index
        /// </summary>
        [XmlIgnore]
        public override int Index
        {
            get { return base.Index; }
            set { base.Index = value; }
        }

        /// <summary>
        /// Gets or sets the screenshot link
        /// </summary>
        [XmlIgnore]
        public override string ScreenshotLink
        {
            get { return base.ScreenshotLink; }
            set { base.ScreenshotLink = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not to enable
        /// </summary>
        [XmlIgnore]
        public override bool Enabled
        {
            get { return base.Enabled; }
            set { base.Enabled = value; }
        }

        /// <summary>
        /// Gets or sets the event time MS
        /// </summary>
        [XmlAttribute("TimeMS")]
        public override long Time
        {
            get { return base.Time; }
            set { base.Time = value; }
        }

        /// <summary>
        /// Gets or sets the event type
        /// </summary>
        [XmlIgnore]
        public override string Type
        {
            get { return base.Type; }
            set { base.Type = value; }
        }

        /// <summary>
        /// Gets or sets the script event item
        /// </summary>
        [XmlElement("Psx", typeof(PsxEvent)),
         XmlElement("Device", typeof(DeviceEvent)),
#if NET40
        XmlElement("UIAutoTest", typeof(UIAutoTestEvent)),
        XmlElement("UIValidationEvents", typeof(UIValidationEvents)),
        XmlElement("Warning", typeof(WarningEvent)),
        XmlElement("Error", typeof(ErrorEvent)),
        XmlElement("Utility", typeof(UtilityEvent)),
#endif
        XmlElement("Xm", typeof(XmEvent)),
         XmlElement("DeviceError", typeof(DeviceEventError)),
         XmlElement("WLDB", typeof(WldbEvent)),
         XmlElement("LaunchPadPsx", typeof(LaunchPadPsxEvent)),
         XmlElement("ApplicationLauncher", typeof(ApplicationLauncherEvent)),
         XmlElement("Report", typeof(ReportEvent))]
        public override object Item
        {
            get
            {
                return base.Item;
            }

            set
            {
                if (value != null)
                {
                    base.Item = value;
                    Type = (base.Item as IScriptEventItem).Type;
                }
            }
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
        /// Creates a new script event
        /// </summary>
        /// <returns>Returns the script</returns>
        public override IScriptEvent ToEvent()
        {
            return new ScriptEvent(Time, Enabled, (Item as IScriptEventItem).ToEventItem(), (Item as ISequential).SeqId, ScreenshotLink);
        }
    }
}
