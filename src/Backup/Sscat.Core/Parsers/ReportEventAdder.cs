// <copyright file="ReportEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ReportEventAdder class
    /// </summary>
    public class ReportEventAdder : AbstractEventAdder
    {
        /// <summary>
        /// Event ID
        /// </summary>
        private string _eventID;

        /// <summary>
        /// Initializes a new instance of the ReportEventAdder class
        /// </summary>
        /// <param name="id">report event ID</param>
        public ReportEventAdder(string id)
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
            Match m;
            while ((line = reader.ReadLine()) != null)
            {
                if ((m = Regex.Match(line, @"(?<ms>\d{10}) .* ParseString Input 18 [[Session Closed]", RegexOptions.IgnoreCase)).Success)
                {
                    IReportEvent item = new ReportEvent();
                    item.Id = _eventID;
                    item.Value = "1"; // TODO: Need to find the exact value entry point for parsing reports
                    events.Add(item.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(m.Groups["ms"].Value, ",", string.Empty)), true));
                    break;
                }
            }
        }
    }
}