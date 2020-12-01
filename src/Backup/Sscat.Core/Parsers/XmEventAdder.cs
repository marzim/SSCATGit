// <copyright file="XmEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the XmEventAdder class
    /// </summary>
    public class XmEventAdder : AbstractEventAdder
    {
        /// <summary>
        /// Event ID
        /// </summary>
        private string _eventID;

        /// <summary>
        /// Initializes a new instance of the XmEventAdder class
        /// </summary>
        /// <param name="id">event ID</param>
        public XmEventAdder(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets the event ID
        /// </summary>
        public string Id
        {
            get { return _eventID; }
            set { _eventID = value; }
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
            IXmEvent item = new XmEvent();
            item.Id = _eventID;
            item.ValueCount = 1;

            List<string> values = new List<string>();
            values.Add(((match.Groups["value"].Value == null) || (match.Groups["value"].Value == string.Empty)) ? "0" : match.Groups["value"].Value);
            item.Values = values.ToArray();

            events.Add(item.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(match.Groups["ms"].Value, ",", string.Empty)), true));
        }
    }
}
