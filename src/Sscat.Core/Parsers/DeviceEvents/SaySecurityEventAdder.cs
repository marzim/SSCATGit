// <copyright file="SaySecurityEventAdder.cs" company="NCR">
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
    /// Initializes a new instance of the SaySecurityEventAdder class
    /// </summary>
    public class SaySecurityEventAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the SaySecurityEventAdder class
        /// </summary>
        public SaySecurityEventAdder()
            : base(Constants.DeviceType.SAY_SECURITY)
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

            Match m;
            IDeviceEvent item = new DeviceEvent();
            item.Id = Id;
            item.Value = match.Groups["value"].Value;

            if (!item.IsExempted)
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if ((m = Regex.Match(line, @".* DM-DMp.* \+SaySecurity, (?<value>.*).", RegexOptions.IgnoreCase)).Success)
                    {
                        item.Value = m.Groups["value"].Value;
                    }

                    if ((m = Regex.Match(line, @".* SM-SMdmBase.* \-DMSaySecurity (?<value>.*)", RegexOptions.IgnoreCase)).Success)
                    {
                        item.Value = string.Format("{0}~{1}", match.Groups["value"].Value, m.Groups["value"].Value);
                        events.Add(item.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(match.Groups["ms"].Value, ",", string.Empty)), dateTime, true));
                        break;
                    }
                }
            }

            if (line == null)
            {
                LoggingService.Warning("SaySecurityEventAdder: Parser Pattern not matched.");
            }
        }
    }
}
