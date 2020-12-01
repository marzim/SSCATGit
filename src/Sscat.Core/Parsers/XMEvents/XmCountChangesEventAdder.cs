// <copyright file="XmCountChangesEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.XMEvents
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the XmCountChangesEventAdder class
    /// </summary>
    public class XmCountChangesEventAdder : XmEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the XmCountChangesEventAdder class
        /// </summary>
        public XmCountChangesEventAdder()
            : base(Constants.XmEvent.XM_COUNT_CHANGES)
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
            IXmEvent item = new XmEvent();
            item.Id = Id;
            item.ValueCount = 2;

            List<string> values = new List<string>();
            values.Add(match.Groups["coinValue"].Value);
            values.Add(match.Groups["billValue"].Value);
            item.Values = values.ToArray();

            events.Add(item.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(match.Groups["ms"].Value, ",", string.Empty)), true));
        }
    }
}
