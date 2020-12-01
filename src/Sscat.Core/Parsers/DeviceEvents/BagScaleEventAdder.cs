// <copyright file="BagScaleEventAdder.cs" company="NCR">
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
    /// Initializes a new instance of the BagScaleEventAdder class
    /// </summary>
    public class BagScaleEventAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the BagScaleEventAdder class
        /// </summary>
        public BagScaleEventAdder()
            : base(Constants.DeviceType.BAG_SCALE)
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
            item.Id = Id;
            string val = ((match.Groups["value"] == null) || (match.Groups["value"].Value == string.Empty)) ? "ZeroWt" : match.Groups["value"].Value;
            System.DateTime dateTime = System.DateTime.ParseExact(match.Groups["datetime"].Value, @"MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            if (val == "ZeroWt")
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if ((m = Regex.Match(line, @"SM: .* (?<ms>(\d+,)+\d+) .* Message complete:  Transaction Expired", RegexOptions.IgnoreCase)).Success)
                    {
                        break;
                    }

                    if ((m = Regex.Match(line, "ResetTransaction", RegexOptions.IgnoreCase)).Success)
                    {
                        item.Value = "0";
                        events.Add(item.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(match.Groups["ms"].Value, ",", string.Empty)), dateTime, true));
                        break;
                    }
                }
            }
            else
            {
                item.Value = match.Groups["value"].Value;
                events.Add(item.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(match.Groups["ms"].Value, ",", string.Empty)), dateTime, true));
            }

            if (line == null)
            {
                LoggingService.Warning("BagScaleEventAdder: Parser Pattern not matched.");
            }
        }
    }
}
