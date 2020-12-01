// <copyright file="WarningUIClippedTextEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.WarningEvents
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the WarningUIClippedTextEventAdder class
    /// </summary>
    public class WarningUIClippedTextEventAdder : WarningEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the WarningUIClippedTextEventAdder class
        /// </summary>
        public WarningUIClippedTextEventAdder()
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
            IWarningEvent item = CreateEvent();
            item.EventType = Constants.WarningEvent.CLIPPED_TEXT;
            item.WarningNotes = match.Groups["warningNotes"].Value;

            long time = Convert.ToInt64(match.Groups["ms"].Value.Replace(",", string.Empty));
            events.Add(item.CreateEvent(time, true));
        }
    }
}
