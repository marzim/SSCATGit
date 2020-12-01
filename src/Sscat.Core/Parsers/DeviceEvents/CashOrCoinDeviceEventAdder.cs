// <copyright file="CashOrCoinDeviceEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.DeviceEvents
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the CashOrCoinDeviceEventAdder class
    /// </summary>
    public class CashOrCoinDeviceEventAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the CashOrCoinDeviceEventAdder class
        /// </summary>
        /// <param name="id">device ID</param>
        public CashOrCoinDeviceEventAdder(string id)
            : base(id)
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
            List<string> patterns = new List<string>();
            patterns.Add(@"(?<datetime>\d{2}/\d{2} \d{2}:\d{2}:\d{2});(?<ms>\d{10}) .*\[SummaryX\](?<value>\d+)\&comma\;(?<value2>\d+) .* inserted");
            patterns.Add(@"(?<datetime>\d{2}/\d{2} \d{2}:\d{2}:\d{2});(?<ms>\d{10}) .*\[SummaryX\](.)?(?<value>\d+)\&comma\;(?<value2>\d+) .* inserted");
            patterns.Add(@"(?<datetime>\d{2}/\d{2} \d{2}:\d{2}:\d{2});(?<ms>\d{10}) .*\[SummaryX\](?<value>\d+)\&comma\;(?<value2>\d+) .* įdėta");
            patterns.Add(@"(?<datetime>\d{2}/\d{2} \d{2}:\d{2}:\d{2});(?<ms>\d{10}) .*\[SummaryX\](?<value>\d+)\&comma\;(?<value2>\d+) .* hineingesteckt");
            patterns.Add(@"(?<datetime>\d{2}/\d{2} \d{2}:\d{2}:\d{2});(?<ms>\d{10}) .*\[SummaryX\](?<value>\d+)\&comma\;(?<value2>\d+) Kč vložen"); // TescoCZ
            patterns.Add(@"(?<datetime>\d{2}/\d{2} \d{2}:\d{2}:\d{2});(?<ms>\d{10}) .*\[SummaryX\](?<value>\d+)\&comma\;(?<value2>\d+) € insertado"); // ECI PDS2 Castilian (Spain) 0C0A EURO
            patterns.Add(@"(?<datetime>\d{2}/\d{2} \d{2}:\d{2}:\d{2});(?<ms>\d{10}) .*\[SummaryX\]Włożono (?<value>\d+)\&comma\;(?<value2>\d+) zł"); // Poland
            patterns.Add(@"(?<datetime>\d{2}/\d{2} \d{2}:\d{2}:\d{2});(?<ms>\d{10}) .*\[SummaryX\](?<value>\d+)\&comma\;(?<value2>\d+) EUR behelyezve"); // TescoHU EUR Configuration
            patterns.Add(@"(?<datetime>\d{2}/\d{2} \d{2}:\d{2}:\d{2});(?<ms>\d{10}) .*\[SummaryX\](?<value>\d+)\&comma\;(?<value2>\d+) Ft behelyezve"); // TescoHU HUF Base - [SummaryX]200&comma;00 Ft behelyezve
            patterns.Add(@"(?<datetime>\d{2}/\d{2} \d{2}:\d{2}:\d{2});(?<ms>\d{10}) .*\[SummaryX\](?<value>\d+)\&comma\;(?<value2>\d+) € Inséré"); // Monoprix French EUR 040C - [SummaryX]5&comma;00 € Inséré
            patterns.Add(@"(?<datetime>\d{2}/\d{2} \d{2}:\d{2}:\d{2});(?<ms>\d{10}) .*\[SummaryX\]已插入HK\$(?<value>\d+).(?<value2>\d+)"); // ASW-Global Parknshop HK$ [SummaryX]已插入HK$10.00 or [SummaryX]已插入HK$100.00
            patterns.Add(@"(?<datetime>\d{2}/\d{2} \d{2}:\d{2}:\d{2});(?<ms>\d{10}) .*\[SummaryX\]€(?<value>\d+)\&comma\;(?<value2>\d+) vložené"); // Tesco Central Europe (primary Slovak)

            List<string> patterns2 = new List<string>(); // For cash/coin pattern that is more than 2 decimals, example: [SummaryX]1 000 Ft behelyezve
            patterns2.Add(@"(?<datetime>\d{2}/\d{2} \d{2}:\d{2}:\d{2});(?<ms>\d{10}) .*\[SummaryX\](?<value>\d+)\s(?<value2>\d+) Ft behelyezve"); // TescoHU Hungarian Forint HUF
            patterns2.Add(@"(?<datetime>\d{2}/\d{2} \d{2}:\d{2}:\d{2});(?<ms>\d{10}) .*\[SummaryX\]kr (?<value>\d{1}.\d{3})\&comma\;(?<value2>\d+) indsat"); // Danish Krone DKK - [SummaryX]kr 1.000&comma;00 indsat
            patterns2.Add(@"(?<datetime>\d{2}/\d{2} \d{2}:\d{2}:\d{2});(?<ms>\d{10}) .*\[SummaryX\]kr (?<value>\d+)\&comma\;(?<value2>\d+) indsat"); // Danish Krone DKK - Match other denomination

            List<string> patterns3 = new List<string>(); // For cash/coin pattern that has only one value, example: [SummaryX]500 Ft behelyezve
            patterns3.Add(@"(?<datetime>\d{2}/\d{2} \d{2}:\d{2}:\d{2});(?<ms>\d{10}) .*\[SummaryX\](?<value>\d+) Ft behelyezve"); // TescoHU Hungarian Forint HUF single value
            
            while ((line = reader.ReadLine()) != null)
            {
                foreach (string pattern in patterns)
                {
                    if ((m = Regex.Match(line, pattern, RegexOptions.IgnoreCase)).Success)
                    {
                        System.DateTime dateTime = System.DateTime.ParseExact(m.Groups["datetime"].Value, @"MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                        IDeviceEvent item = new DeviceEvent();
                        item.Id = Id;
                        double val = double.Parse(m.Groups["value"].Value) + (double.Parse(m.Groups["value2"].Value) * 0.01);
                        item.Value = (val * 100).ToString();
                        events.Add(item.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(m.Groups["ms"].Value, ",", string.Empty)), dateTime, true));
                        return;
                    }
                }

                foreach (string pattern in patterns2)
                {
                    if ((m = Regex.Match(line, pattern, RegexOptions.IgnoreCase)).Success)
                    {
                        System.DateTime dateTime = System.DateTime.ParseExact(m.Groups["datetime"].Value, @"MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                        IDeviceEvent item = new DeviceEvent();
                        item.Id = Id;
                        string val = StringUtility.Replace(m.Groups["value"].Value.Equals("0") ? string.Empty : m.Groups["value"].Value, ".", string.Empty);
                        item.Value = string.Format("{0}{1}", val, m.Groups["value2"].Value);
                        events.Add(item.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(m.Groups["ms"].Value, ",", string.Empty)), dateTime, true));
                        return;
                    }
                }

                foreach (string pattern in patterns3)
                {
                    if ((m = Regex.Match(line, pattern, RegexOptions.IgnoreCase)).Success)
                    {
                        System.DateTime dateTime = System.DateTime.ParseExact(m.Groups["datetime"].Value, @"MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                        IDeviceEvent item = new DeviceEvent();
                        item.Id = Id;
                        item.Value = m.Groups["value"].Value;
                        events.Add(item.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(m.Groups["ms"].Value, ",", string.Empty)), dateTime, true));
                        return;
                    }
                }

                if ((m = Regex.Match(line, @"(?<datetime>\d{2}/\d{2} \d{2}:\d{2}:\d{2});(?<ms>\d{10}) .*\[SummaryX\](.)?(?<value>\d+.\d+) (inserted|insertado)", RegexOptions.IgnoreCase)).Success)
                {
                    System.DateTime dateTime = System.DateTime.ParseExact(m.Groups["datetime"].Value, @"MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                    IDeviceEvent item = new DeviceEvent();
                    item.Id = Id;
                    double val = double.Parse(m.Groups["value"].Value);
                    item.Value = (val * 100).ToString();
                    events.Add(item.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(m.Groups["ms"].Value, ",", string.Empty)), dateTime, true));
                    return;
                }
            }

            if (line == null)
            {
                LoggingService.Warning("CashOrCoinDeviceEventAdder: Parser Pattern not matched.");
            }
        }
    }
}
