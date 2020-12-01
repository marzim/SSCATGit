// <copyright file="UIValidationPropertyChangeEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.UIValidationEvents
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the UIValidationPropertyChangeEventAdder class
    /// </summary>
    public class UIValidationPropertyChangeEventAdder : UIValidationEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the UIValidationPropertyChangeEventAdder class
        /// </summary>
        public UIValidationPropertyChangeEventAdder()
            : base()
        {
        }

        /// <summary>
        /// Adds the event
        /// </summary>
        /// <param name="line">line to check</param>
        /// <param name="match">match to check</param>
        /// <param name="reader">extended text reader</param>
        /// <param name="events">script events</param>
        /// <param name="eventValue">event value</param>
        public override void Add(string line, Match match, IExtendedTextReader reader, List<IScriptEvent> events, string eventValue)
        {
            IUIValidationEvent item = CreateEvent();
            item.EventType = Constants.UIValidationEvent.PROPERTY_CHANGE;
            item.ControlName = match.Groups["controlName"].Value;
            item.ControlType = match.Groups["controlType"].Value;
            item.Property = match.Groups["property"].Value;
            item.PropertyValue = match.Groups["propertyValue"].Value;

            long time = Convert.ToInt64(match.Groups["ms"].Value.Replace(",", string.Empty));
            events.Add(item.CreateEvent(time, true));
        }
    }
}
