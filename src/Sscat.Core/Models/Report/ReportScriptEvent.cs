// <copyright file="ReportScriptEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.Report
{
    using System;
    using System.Xml.Serialization;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ReportScriptEvent class
    /// </summary>
    [Serializable]
    public class ReportScriptEvent
    {
        /// <summary>
        /// Script event type
        /// </summary>
        private string _type;

        /// <summary>
        /// Script event result
        /// </summary>
        private string _result;

        /// <summary>
        /// Script event screenshot link
        /// </summary>
        private string _screenshotLink;

#if NET40
        /// <summary>
        /// Report UI Validation Events
        /// </summary>
        private ReportUIValidationEvent[] _reportUIValidationEvents = new ReportUIValidationEvent[0];
#endif

        /// <summary>
        /// Script event item
        /// </summary>
        private object _item;

        /// <summary>
        /// Initializes a new instance of the ReportScriptEvent class
        /// </summary>
        public ReportScriptEvent()
        {
        }

#if NET40
        /// <summary>
        /// Initializes a new instance of the ReportScriptEvent class
        /// </summary>
        /// <param name="scriptEvent">script event</param>
        /// <param name="reportUIValidationEvents">list of report ui validation events</param>
        public ReportScriptEvent(IScriptEvent scriptEvent, ReportUIValidationEvent[] reportUIValidationEvents)
            : this(scriptEvent)
        {
            _reportUIValidationEvents = new ReportUIValidationEvent[reportUIValidationEvents.Length];
            _reportUIValidationEvents = reportUIValidationEvents;
            Type = scriptEvent.Type;
            Result = scriptEvent.Result.ToString();
            Item = GetItem(scriptEvent.Item);
            ScreenshotLink = scriptEvent.ScreenshotLink;
        }
#endif

        /// <summary>
        /// Initializes a new instance of the ReportScriptEvent class
        /// </summary>
        /// <param name="scriptEvent">script event</param>
        public ReportScriptEvent(IScriptEvent scriptEvent)
        {
            Type = scriptEvent.Type;
            Result = scriptEvent.Result.ToString();
            Item = GetItem(scriptEvent.Item);
            ScreenshotLink = scriptEvent.ScreenshotLink;
        }
        
        /// <summary>
        /// Gets or sets the script event item
        /// </summary>
        [XmlElement("Psx", typeof(ReportPsxEvent)),
         XmlElement("LaunchPadPsx", typeof(ReportLaunchPadPsxEvent)),
#if NET40
        XmlElement("UIAutoTest", typeof(ReportUIAutoTestEvent)),
        XmlElement("UIValidation", typeof(ReportUIValidationEvents)),
        XmlElement("Utility", typeof(ReportUtilityEvent)),
#endif
        XmlElement("Device", typeof(ReportDeviceEvent)),
         XmlElement("Xm", typeof(ReportXmEvent)),
         XmlElement("ApplicationLauncher", typeof(ReportApplicationLauncherEvent)),
         XmlElement("Wldb", typeof(ReportWldbEvent)),
         XmlElement("Report", typeof(ReportReportEvent))]
        public object Item
        {
            get { return _item; }
            set { _item = value; }
        }

        /// <summary>
        /// Gets or sets the event type
        /// </summary>
        [XmlAttribute("Type")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Gets or sets the event result
        /// </summary>
        [XmlAttribute("Result")]
        public string Result
        {
            get { return _result; }
            set { _result = value; }
        }

        /// <summary>
        /// Gets or sets the screenshot link
        /// </summary>
        [XmlAttribute("ScreenshotLink")]
        public string ScreenshotLink
        {
            get { return _screenshotLink; }
            set { _screenshotLink = value; }
        }

        /// <summary>
        /// Checks what type of event item the given is
        /// </summary>
        /// <param name="item">script event item</param>
        /// <returns>Return script event item based on event type</returns>
        private object GetItem(object item)
        {
            if (item is IPsxEvent)
            {
                return new ReportPsxEvent(item as IPsxEvent);
            }
            else if (item is IDeviceEvent)
            {
                return new ReportDeviceEvent(item as IDeviceEvent);
            }
            else if (item is IXmEvent)
            {
                return new ReportXmEvent(item as IXmEvent);
            }
            else if (item is IWldbEvent)
            {
                return new ReportWldbEvent(item as IWldbEvent);
            }
            else if (item is IApplicationLauncherEvent)
            {
                return new ReportApplicationLauncherEvent(item as IApplicationLauncherEvent);
            }
            else if (item is IReportEvent)
            {
                return new ReportReportEvent(item as IReportEvent);
#if NET40
            }
            else if (item is IUIAutoTestEvent)
            {
                return new ReportUIAutoTestEvent(item as IUIAutoTestEvent);
            }
            else if (item is IUIValidationEvents)
            {
                return new ReportUIValidationEvents(_reportUIValidationEvents);
            }
            else if (item is IUtilityEvent)
            {
                return new ReportUtilityEvent(item as IUtilityEvent);
#endif
            }
            else
            {
                throw new NotSupportedException(string.Format("{0} for assigning to Playback script event item not supported", item.GetType().Name));
            }
        }
    }
}
