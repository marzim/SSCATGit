// <copyright file="UIValidationEvents.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the UIValidationEvents class
    /// </summary>
    [XmlRoot("UIValidationEvents"), Serializable()]
    public class UIValidationEvents : AbstractUIValidationEvents<UIValidationEvents>
    {
        /// <summary>
        /// SSCAT script events
        /// </summary>
        private UIValidationEvent[] _uiValidationEvents;

        /// <summary>
        /// SSCAT script events
        /// </summary>
        private List<UIValidationEvent> _uiValidationEvnts;

        /// <summary>
        /// Initializes a new instance of the UIValidationEvents class
        /// </summary>
        public UIValidationEvents()
        {
            UIValidationEvnts = new UIValidationEvent[0];
        }

        /// <summary>
        /// Initializes a new instance of the UIValidationEvents class
        /// </summary>
        /// <param name="uiValidationEvents">array of UIValidationEvent</param>
        public UIValidationEvents(List<UIValidationEvent> uiValidationEvents)
        {
            _uiValidationEvnts = uiValidationEvents;
            UIValidationEvnts = new UIValidationEvent[uiValidationEvents.Count];
            uiValidationEvents.CopyTo(UIValidationEvnts);
        }

        /// <summary>
        /// Gets or sets the UI Validation Events
        /// </summary>
        [XmlElement("UIValidation")]
        public override UIValidationEvent[] UIValidationEvnts
        {
            get
            {
                if (_uiValidationEvents == null)
                {
                    return new UIValidationEvent[0];
                }

                return _uiValidationEvents;
            }

            set
            {
                if (value != null)
                {
                    _uiValidationEvents = value;
                }
            }
        }

        /// <summary>
        /// Gets the event type
        /// </summary>
        public override string Type
        {
            get { return "UIValidationEvents"; }
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
        /// Creates a new device event
        /// </summary>
        /// <returns>Returns new script event item</returns>
        public override IScriptEventItem ToEventItem()
        {
            List<UIValidationEvent> uiValEvents = new List<UIValidationEvent>();
            uiValEvents.AddRange(UIValidationEvnts);
            return new UIValidationEvents(uiValEvents);
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
    }
}