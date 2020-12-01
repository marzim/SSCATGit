// <copyright file="UIValidationEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the UIValidationEventAdder class
    /// </summary>
    public class UIValidationEventAdder : AbstractEventAdder
    {
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
        }

        /// <summary>
        /// Creates UIValidation events
        /// </summary>
        /// <returns>Returns the event</returns>
        protected virtual IUIValidationEvent CreateEvent()
        {
            return new UIValidationEvent();
        }
    }
}
