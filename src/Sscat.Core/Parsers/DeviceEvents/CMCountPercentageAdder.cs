// <copyright file="CMCountPercentageAdder.cs" company="NCR">
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
    /// Initializes a new instance of the CMCountPercentageAdder class
    /// </summary>
    public class CMCountPercentageAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the CMCountPercentageAdder class
        /// </summary>
        public CMCountPercentageAdder()
            : base(Constants.DeviceType.CM_COUNT_PERCENTAGE)
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
            System.DateTime dateTime = System.DateTime.ParseExact(match.Groups["datetime"].Value, @"MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            IDeviceEvent itemCount = new DeviceEvent();
            itemCount.Id = Constants.DeviceType.CM_CASH_COUNT;
            List<string> tempCoinCount = new List<string>();
            List<string> tempBillCount = new List<string>();

            IDeviceEvent itemValue = new DeviceEvent();
            itemValue.Id = Id;
            List<string> tempCoinValue = new List<string>();
            List<string> tempBillValue = new List<string>();

            Match m;

            if (match.Groups["denom"].Value.Contains("-"))
            {
                tempCoinCount.Add(string.Format("{0}:{1}", match.Groups["denom"].Value, match.Groups["count"].Value));
                tempCoinValue.Add(string.Format("{0},{1},{2},{3},{4}", match.Groups["denom"].Value, match.Groups["count"].Value, match.Groups["countPercentage"].Value, match.Groups["capacity"].Value, match.Groups["lowLevel"].Value));
            }
            else
            {
                tempBillCount.Add(string.Format("{0}:{1}", match.Groups["denom"].Value, match.Groups["count"].Value));
                tempBillValue.Add(string.Format("{0},{1},{2},{3},{4}", match.Groups["denom"].Value, match.Groups["count"].Value, match.Groups["countPercentage"].Value, match.Groups["capacity"].Value, match.Groups["lowLevel"].Value));
            }

            while ((line = reader.ReadLine()) != null)
            {
                if ((m = Regex.Match(line, @".*SM-SMdmBase.* Count Percentage : (?<countPercentage>.*)\. denom : (?<denom>.*)\. count (?<count>.*)\. capacity (?<capacity>.*)\.low level: (?<lowLevel>.*)", RegexOptions.IgnoreCase)).Success)
                {
                    if (m.Groups["denom"].Value.Contains("-"))
                    {
                        tempCoinCount.Add(string.Format("{0}:{1}", m.Groups["denom"].Value, m.Groups["count"].Value));
                        tempCoinValue.Add(string.Format("{0},{1},{2},{3},{4}", m.Groups["denom"].Value, m.Groups["count"].Value, m.Groups["countPercentage"].Value, m.Groups["capacity"].Value, m.Groups["lowLevel"].Value));
                    }
                    else
                    {
                        tempBillCount.Add(string.Format("{0}:{1}", m.Groups["denom"].Value, m.Groups["count"].Value));
                        tempBillValue.Add(string.Format("{0},{1},{2},{3},{4}", m.Groups["denom"].Value, m.Groups["count"].Value, m.Groups["countPercentage"].Value, m.Groups["capacity"].Value, m.Groups["lowLevel"].Value));
                    }
                }

                if ((m = Regex.Match(line, @".*DM-DMp.* \+GetPrinterPaperLow.*", RegexOptions.IgnoreCase)).Success)
                {
                    string coinCount = string.Join(",", tempCoinCount.ToArray());
                    string billCount = string.Join(",", tempBillCount.ToArray());
                    itemCount.Value = string.Format("{0};{1}", coinCount, billCount);
                    events.Add(itemCount.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(match.Groups["ms"].Value, ",", string.Empty)), dateTime, true));

                    string coinValue = string.Join("~", tempCoinValue.ToArray());
                    string billValue = string.Join("~", tempBillValue.ToArray());
                    itemValue.Value = string.Format("{0};{1}", coinValue, billValue);
                    events.Add(itemValue.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(match.Groups["ms"].Value, ",", string.Empty)), dateTime, true));
                    break;
                }
            }

            if (line == null)
            {
                LoggingService.Warning("CMCountPercentageAdder: Parser Pattern not matched.");
            }
        }
    }
}
