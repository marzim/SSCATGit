// <copyright file="XmPrintDataEventAdder.cs" company="NCR">
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
    /// Initializes a new instance of the XmPrintDataEventAdder class
    /// </summary>
    public class XmPrintDataEventAdder : XmEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the XmPrintDataEventAdder class
        /// </summary>
        public XmPrintDataEventAdder()
            : base(Constants.XmEvent.XM_PRINT_DATA)
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
            IXmEvent item = new XmEvent();
            List<string> values = new List<string>();

            while ((line = reader.ReadLine()) != null)
            {
                if ((m = Regex.Match(line, @"XM: .* (?<ms>\d{4,10}).* Justified Data: \[(?<value>.*Report.*)\]", RegexOptions.IgnoreCase)).Success)
                {
                    values.Add(m.Groups["value"].Value);
                }

                if ((m = Regex.Match(line, @"XM: .* (?<ms>\d{4,10}).* PositionData: \[(?<value>.*)\]", RegexOptions.IgnoreCase)).Success)
                {
                    values.Add(m.Groups["value"].Value);
                }

                if ((m = Regex.Match(line, @"XM: .* (?<ms>\d{4,10}).* \-XMCashManagementBase::PrintReceipt", RegexOptions.IgnoreCase)).Success)
                {
                    item.Id = Id;
                    item.ValueCount = values.Count;
                    item.Values = values.ToArray();
                    events.Add(item.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(match.Groups["ms"].Value, ",", string.Empty)), true));
                    break;
                }
            }

            if (line == null)
            {
                LoggingService.Warning("XmPrintDataEventAdder: Parser Pattern not matched.");
            }
        }
    }
}
