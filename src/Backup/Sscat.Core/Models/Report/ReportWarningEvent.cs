// <copyright file="ReportWarningEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.Report
{
    using System;
    using System.Xml.Serialization;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ReportWarningEvent class
    /// </summary>
    [Serializable]
    public class ReportWarningEvent
    {
        /// <summary>
        /// Warning Type
        /// </summary>
        private string _type;

        /// <summary>
        /// Warning Notes
        /// </summary>
        private string _warningNotes;

        /// <summary>
        /// Initializes a new instance of the ReportWarningEvent class
        /// </summary>
        public ReportWarningEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ReportWarningEvent class
        /// </summary>
        /// <param name="warningEvent">warning event</param>
        public ReportWarningEvent(IWarningEvent warningEvent)
        {
            _type = warningEvent.EventType;
            _warningNotes = warningEvent.WarningNotes;
        }

        /// <summary>
        /// Gets or sets the warning type
        /// </summary>
        [XmlAttribute("Type")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Gets or sets the event type
        /// </summary>
        [XmlAttribute("WarningNotes")]
        public string WarningNotes
        {
            get { return _warningNotes; }
            set { _warningNotes = value; }
        }

        /// <summary>
        /// Formats ToString method for the warning events
        /// </summary>
        /// <returns>Returns the formatted string</returns>
        public override string ToString()
        {
            return string.Format("WarningEvent: Type:{0} Notes:{1}", _type, _warningNotes);
        }
    }
}
