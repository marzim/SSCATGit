// <copyright file="ScriptEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using System.Xml.Serialization;

    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ScriptEvent class
    /// </summary>
    [XmlRoot("Event"), Serializable()]
    public class ScriptEvent : AbstractScriptEvent<ScriptEvent>, ISequential
    {
        /// <summary>
        /// Sequence ID
        /// </summary>
        private int _seqId;

        /// <summary>
        /// Initializes a new instance of the ScriptEvent class
        /// </summary>
        public ScriptEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ScriptEvent class
        /// </summary>
        /// <param name="item">script event item</param>
        public ScriptEvent(IScriptEventItem item)
            : this(0, true, item)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ScriptEvent class
        /// </summary>
        /// <param name="time">time of the event</param>
        /// <param name="enabled">whether or not it is enabled</param>
        /// <param name="item">script event item</param>
        public ScriptEvent(long time, bool enabled, IScriptEventItem item)
            : this(time, enabled, item, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ScriptEvent class
        /// </summary>
        /// <param name="time">time of the event</param>
        /// <param name="enabled">whether or not it is enabled</param>
        /// <param name="item">script event item</param>
        /// <param name="seqId">sequence ID</param>
        public ScriptEvent(long time, bool enabled, IScriptEventItem item, int seqId)
            : this(time, enabled, item, 0, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ScriptEvent class
        /// </summary>
        /// <param name="time">time of the event</param>
        /// <param name="enabled">whether or not it is enabled</param>
        /// <param name="item">script event item</param>
        /// <param name="seqId">sequence ID</param>
        /// <param name="screenshotLink">screenshot link</param>
        public ScriptEvent(long time, bool enabled, IScriptEventItem item, int seqId, string screenshotLink)
        {
            Time = time;
            Enabled = enabled;
            Item = item;
            SeqId = seqId;
            ScreenshotLink = screenshotLink;
            Result = new Result();
        }

        /// <summary>
        /// Gets or sets the script event result
        /// </summary>
        [XmlElement("Result")]
        public override Result Result
        {
            get { return base.Result; }
            set { base.Result = value; }
        }

        /// <summary>
        /// Gets or sets the script index
        /// </summary>
        [XmlAttribute("ScriptIndex")]
        public override int ScriptIndex
        {
            get { return base.ScriptIndex; }
            set { base.ScriptIndex = value; }
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
        /// Gets or sets the sequence ID
        /// </summary>
        [XmlAttribute("SeqId")]
        public int SeqId
        {
            get { return _seqId; }
            set { _seqId = value; }
        }

        /// <summary>
        /// Gets or sets the script event item
        /// </summary>
        [XmlElement("PsxEventData", typeof(PsxEvent)),
        XmlElement("DeviceEventData", typeof(DeviceEvent)),
#if NET40
        XmlElement("UIAutoTestEventData", typeof(UIAutoTestEvent)),
        XmlElement("UIValidationEvents", typeof(UIValidationEvents)),
        XmlElement("WarningEventData", typeof(WarningEvent)),
        XmlElement("ErrorEventData", typeof(ErrorEvent)),
        XmlElement("UtilityEventData", typeof(UtilityEvent)),
#endif
        XmlElement("XmEventData", typeof(XmEvent)),
        XmlElement("DeviceEventDataError", typeof(DeviceEventError)),
        XmlElement("WLDBEventData", typeof(WldbEvent)),
        XmlElement("LaunchPadPsxEventData", typeof(LaunchPadPsxEvent)),
        XmlElement("ApplicationLauncherEventData", typeof(ApplicationLauncherEvent)),
        XmlElement("ReportEventData", typeof(ReportEvent))]
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
        /// Gets a value indicating whether the event is enabled
        /// </summary>
        [XmlAttribute("Enabled")]
        public override bool Enabled
        {
            get { return base.Enabled; }
            set { base.Enabled = value; }
        }

        /// <summary>
        /// Gets or sets the script event time
        /// </summary>
        [XmlAttribute("Time")]
        public override long Time
        {
            get { return base.Time; }
            set { base.Time = value; }
        }

        /// <summary>
        /// Gets the event type
        /// </summary>
        [XmlAttribute("Type")]
        public override string Type
        {
            get { return base.Type; }
            set { base.Type = value; }
        }

        /// <summary>
        /// Gets or sets the screenshot link
        /// </summary>
        [XmlAttribute("ScreenshotLink")]
        public override string ScreenshotLink
        {
            get { return base.ScreenshotLink; }
            set { base.ScreenshotLink = value; }
        }

        /// <summary>
        /// Creates the script event item
        /// </summary>
        /// <returns>Returns the script event</returns>
        public override IScriptEvent ToEvent()
        {
            return new SSCATScriptEvent();
        }
    }
}
