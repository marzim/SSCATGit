// <copyright file="ReportUIValidationEvent.cs" company="NCR">
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
    public class ReportUIValidationEvent
    {
        /// <summary>
        /// Script event result
        /// </summary>
        private string _result = string.Empty;

        /// <summary>
        /// Event type
        /// </summary>
        private string _eventType = string.Empty;

        /// <summary>
        /// Control Name
        /// </summary>
        private string _controlName = string.Empty;

        /// <summary>
        /// Control Type
        /// </summary>
        private string _controlType = string.Empty;

        /// <summary>
        /// Property Name
        /// </summary>
        private string _property = string.Empty;

        /// <summary>
        /// Property Value
        /// </summary>
        private string _propertyValue = string.Empty;

        /// <summary>
        /// Initializes a new instance of the ReportUIValidationEvent class
        /// </summary>
        public ReportUIValidationEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ReportUIValidationEvent class
        /// </summary>
        /// <param name="uiValidationEventItem">UI Validation Event Item</param>
        /// <param name="result">Result of the ui validation event</param>
        public ReportUIValidationEvent(IUIValidationEvent uiValidationEventItem, ResultType result)
        {
            Result = result.ToString();
            EventType = uiValidationEventItem.EventType;
            ControlName = uiValidationEventItem.ControlName;
            ControlType = uiValidationEventItem.ControlType;
            Property = uiValidationEventItem.Property;
            PropertyValue = uiValidationEventItem.PropertyValue;
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
        /// Gets or sets the event type
        /// </summary>
        [XmlAttribute("Type")]
        public string EventType
        {
            get { return _eventType; }
            set { _eventType = value; }
        }

        /// <summary>
        /// Gets or sets the control name
        /// </summary>
        [XmlAttribute("Control")]
        public string ControlName
        {
            get { return _controlName; }
            set { _controlName = value; }
        }

        /// <summary>
        /// Gets or sets the control type
        /// </summary>
        [XmlAttribute("ControlType")]
        public string ControlType
        {
            get { return _controlType; }
            set { _controlType = value; }
        }

        /// <summary>
        /// Gets or sets the Property
        /// </summary>
        [XmlAttribute("Property")]
        public string Property
        {
            get { return _property; }
            set { _property = value; }
        }

        /// <summary>
        /// Gets or sets the Property Value
        /// </summary>
        [XmlAttribute("PropertyValue")]
        public string PropertyValue
        {
            get { return _propertyValue; }
            set { _propertyValue = value; }
        }
    }

#endif
}