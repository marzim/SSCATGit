// <copyright file="ReportUIValidationEvents.cs" company="NCR">
//     Copyright 2017 NCR ReportUIValidationEvents. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.Report
{
    using System;
    using System.Xml.Serialization;
    using Sscat.Core.Models.ScriptModel;

#if NET40

    /// <summary>
    /// Initializes a new instance of the ReportUIValidationEvents class
    /// </summary>
    [Serializable]
    public class ReportUIValidationEvents
    {
        /// <summary>
        /// Report UI Validation events
        /// </summary>
        private ReportUIValidationEvent[] _reportUIVEvents;
        
        /// <summary>
        /// Initializes a new instance of the ReportUIValidationEvents class
        /// </summary>
        public ReportUIValidationEvents()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ReportUIValidationEvents class
        /// </summary>
        /// <param name="reportUIValidationEvent">list of ui validation event report</param>
        public ReportUIValidationEvents(ReportUIValidationEvent[] reportUIValidationEvent)
        {
            ReportUIVEvents = new ReportUIValidationEvent[reportUIValidationEvent.Length];
            ReportUIVEvents = reportUIValidationEvent;
        }

        /// <summary>
        /// Gets or sets the UI Validation Events
        /// </summary>
        [XmlElement("UIValidationEvent")]
        public ReportUIValidationEvent[] ReportUIVEvents
        {
            get
            {
                if (_reportUIVEvents == null)
                {
                    return new ReportUIValidationEvent[0];
                }

                return _reportUIVEvents;
            }
            
            set
            {
                if (value != null)
                {
                    _reportUIVEvents = value;
                }
            }
        }
    }
#endif
}
