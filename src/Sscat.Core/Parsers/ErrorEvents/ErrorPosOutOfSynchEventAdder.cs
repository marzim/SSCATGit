// <copyright file="ErrorPosOutOfSynchEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.ErrorEvents
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ErrorPosOutOfSynchEventAdder class
    /// </summary>
    public class ErrorPosOutOfSynchEventAdder : ErrorEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the ErrorPosOutOfSynchEventAdder class
        /// </summary>
        public ErrorPosOutOfSynchEventAdder()
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
            IErrorEvent item = CreateEvent();
            item.EventType = Constants.ErrorEvent.POS_OUT_OF_SYNCH;
            item.ErrorNotes = @"Timedout in SMInProgress while waiting to hear from TB !!!!, potential out-of-synch situation between TB and SCOT";
            long time = Convert.ToInt64(match.Groups["ms"].Value.Replace(",", string.Empty));
            events.Add(item.CreateEvent(time, true));
        }
    }
}
