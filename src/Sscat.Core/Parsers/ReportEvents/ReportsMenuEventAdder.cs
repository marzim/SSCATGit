// <copyright file="ReportsMenuEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.ReportEvents
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ReportsMenuEventAdder class
    /// </summary>
    public class ReportsMenuEventAdder : ReportEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the ReportsMenuEventAdder class
        /// </summary>
        public ReportsMenuEventAdder()
            : base(Constants.ReportEvent.REPORTS_MENU)
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
            Match m;
            while ((line = reader.ReadLine()) != null)
            {
                if ((m = Regex.Match(line, @"(?<ms>\d{10}) .* ParsePrompt - REDRAW is set to TRUE,m_bProcessingMenus 1 m_bInitialMenu 0", RegexOptions.IgnoreCase)).Success)
                {
                    IReportEvent item = new ReportEvent();
                    item.Id = Id;
                    item.Value = match.Groups["value"].Value;
                    events.Add(item.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(m.Groups["ms"].Value, ",", string.Empty)), true));
                    break;
                }
            }
        }
    }
}
