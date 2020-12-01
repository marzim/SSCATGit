// <copyright file="Scanner3207DeviceEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.DeviceEvents
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the Scanner3207DeviceEventAdder class
    /// </summary>
    public class Scanner3207DeviceEventAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the Scanner3207DeviceEventAdder class
        /// </summary>
        public Scanner3207DeviceEventAdder()
            : base(Constants.DeviceType.SCANNER)
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
            IDeviceEvent item = new DeviceEvent();
            while ((line = reader.ReadLine()) != null)
            {
                if ((m = Regex.Match(line, @"~(?<value>.*)>", RegexOptions.IgnoreCase)).Success)
                {
                    item.Value = string.Format("{0}~{1}", match.Groups["value"].Value, m.Groups["value"].Value);
                }

                if ((m = Regex.Match(line, @"(?<ms>\d{10}) .* \-isBarcodeValidOperatorPassword  <(?<value>.*)>", RegexOptions.IgnoreCase)).Success)
                {
                    item.Id = Id;
                    item.Value = string.Format("{0}~{1}", item.Value, m.Groups["value"].Value);
                    events.Add(item.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(match.Groups["ms"].Value, ",", string.Empty)), true));
                    break;
                }
            }

            if (line == null)
            {
                LoggingService.Warning("Scanner3207DeviceEventAdder: Parser Pattern not matched.");
            }
        }
    }
}
