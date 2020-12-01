// <copyright file="SayAmountEventAdder.cs" company="NCR">
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
    /// Initializes a new instance of the SayAmountEventAdder class
    /// </summary>
    public class SayAmountEventAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the SayAmountEventAdder class
        /// </summary>
        public SayAmountEventAdder()
            : base(Constants.DeviceType.SAY_AMOUNT)
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
            item.Value = match.Groups["value"].Value;
            while ((line = reader.ReadLine()) != null)
            {
                if ((m = Regex.Match(line, @".* DM-DMp.* SCOTPriceSoundSayPrice (?<value>.*)", RegexOptions.IgnoreCase)).Success)
                {
                    item.Value = string.Format("{0}~SCOTPriceSoundSayPrice~{1}", item.Value, m.Groups["value"].Value);
                }

                if ((m = Regex.Match(line, @".* SM-SMdmBase.* \-DMSayAmount (?<value>.*)", RegexOptions.IgnoreCase)).Success)
                {
                    item.Id = Id;
                    item.Value = string.Format("{0}~{1}", item.Value, m.Groups["value"].Value);
                    events.Add(item.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(match.Groups["ms"].Value, ",", string.Empty)), true));
                    break;
                }
            }

            if (line == null)
            {
                LoggingService.Warning("SayAmountEventAdder: Parser Pattern not matched.");
            }
        }
    }
}
