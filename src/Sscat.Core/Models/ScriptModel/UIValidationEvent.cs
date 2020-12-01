// <copyright file="UIValidationEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the UIValidationEvent class
    /// </summary>
    [XmlRoot("UIValidation"), Serializable()]
    public class UIValidationEvent : AbstractUIValidationEvent<UIValidationEvent>
    {
        /// <summary>
        /// Initializes a new instance of the UIValidationEvent class
        /// </summary>
        public UIValidationEvent()
            : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the UIValidationEvent class
        /// </summary>
        /// <param name="eventType">event type</param>
        /// <param name="controlName">control name</param>
        /// <param name="controlType">control type</param>
        /// <param name="property">property name</param>
        /// <param name="propertyValue">property value</param>
        public UIValidationEvent(string eventType, string controlName, string controlType, string property, string propertyValue)
            : base(eventType, controlName, controlType, property, propertyValue)
        {
        }

        /// <summary>
        /// Gets the event type
        /// </summary>
        public override string Type
        {
            get { return "UIValidationEventData"; }
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
        /// Gets or sets the event type
        /// </summary>
        [XmlAttribute("Type")]
        public override string EventType
        {
            get { return base.EventType; }
            set { base.EventType = value; }
        }

        /// <summary>
        /// Gets or sets the control name
        /// </summary>
        [XmlAttribute("Control")]
        public override string ControlName
        {
            get { return base.ControlName; }
            set { base.ControlName = value; }
        }

        /// <summary>
        /// Gets or sets the control type
        /// </summary>
        [XmlAttribute("ControlType")]
        public override string ControlType
        {
            get { return base.ControlType; }
            set { base.ControlType = value; }
        }

        /// <summary>
        /// Gets or sets the Property
        /// </summary>
        [XmlAttribute("Property")]
        public override string Property
        {
            get { return base.Property; }
            set { base.Property = value; }
        }

        /// <summary>
        /// Gets or sets the Property Value
        /// </summary>
        [XmlAttribute("PropertyValue")]
        public override string PropertyValue
        {
            get { return base.PropertyValue; }
            set { base.PropertyValue = value; }
        }

        /// <summary>
        /// Creates a new device event
        /// </summary>
        /// <returns>Returns new script event item</returns>
        public override IScriptEventItem ToEventItem()
        {
            return new UIValidationEvent(EventType, ControlName, ControlType, Property, PropertyValue);
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
        /// ShouldSerialize* pattern for ControlName
        /// </summary>
        /// <returns>returns if ControlName is null or empty</returns>
        public bool ShouldSerializeControlName()
        {
            return !string.IsNullOrEmpty(ControlName);
        }

        /// <summary>
        /// ShouldSerialize* pattern for ControlType
        /// </summary>
        /// <returns>returns if ControlType is null or empty</returns>
        public bool ShouldSerializeControlType()
        {
            return !string.IsNullOrEmpty(ControlType);
        }

        /// <summary>
        /// ShouldSerialize* pattern for Property
        /// </summary>
        /// <returns>returns if Property is null or empty</returns>
        public bool ShouldSerializeProperty()
        {
            return !string.IsNullOrEmpty(Property);
        }

        /// <summary>
        /// ShouldSerialize* pattern for PropertyValue
        /// </summary>
        /// <returns>returns if PropertyValue is null or empty</returns>
        public bool ShouldSerializePropertyValue()
        {
            return !string.IsNullOrEmpty(PropertyValue);
        }
    }
}