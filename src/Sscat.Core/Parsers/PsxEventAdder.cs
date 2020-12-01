// <copyright file="PsxEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Ncr.Core.Emulators;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the LaunchPadPsxEventAdder class
    /// </summary>
    public class PsxEventAdder : AbstractEventAdder
    {
        /// <summary>
        /// Current lane
        /// </summary>
        private Lane _lane = new Lane();

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
            IPsxEvent item = CreateEvent();
            item.Event = match.Groups["event"].Value;
            item.Context = match.Groups["context"].Value;
            item.Param = match.Groups["param"].Value;
            item.RemoteConnection = match.Groups["connection"].Value;

            DateTime dateTime = DateTime.ParseExact(match.Groups["datetime"].Value, @"MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            if (!SSCOHelper.IsNGUI() || ((!item.IsExempted) && !(SSCOHelper.IsNGUI() && item.RemoteConnection.Equals(string.Empty))))
            {
                item.Id = match.Groups["id"].Value;
                item.Control = match.Groups["control"].Value;
                long time = Convert.ToInt64(match.Groups["fired"].Value);
                events.Add(item.CreateEvent(time, dateTime, true));
            }
        }

        /// <summary>
        /// Creates the PSX event
        /// </summary>
        /// <returns>Returns the event</returns>
        protected virtual IPsxEvent CreateEvent()
        {
            return new PsxEvent();
        }
    }
}
