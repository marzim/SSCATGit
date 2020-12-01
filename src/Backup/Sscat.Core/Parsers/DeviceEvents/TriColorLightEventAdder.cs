// <copyright file="TriColorLightEventAdder.cs" company="NCR">
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
    /// Initializes a new instance of the TriColorLightEventAdder class
    /// </summary>
    public class TriColorLightEventAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the TriColorLightEventAdder class
        /// </summary>
        public TriColorLightEventAdder()
            : base(Constants.DeviceType.TRI_COLOR_LIGHT)
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
                if ((m = Regex.Match(line, @"(?<ms>\d{10}) .* \-setTriColorLight, color = .* state = (?<value>\d{0,1}), request = .*", RegexOptions.IgnoreCase)).Success)
                {
                    IDeviceEvent item = new DeviceEvent();
                    item.Id = Id;
                    item.Value = string.Format("{0}~{1}", match.Groups["value"].Value, m.Groups["value"].Value);
                    events.Add(item.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(m.Groups["ms"].Value, ",", string.Empty)), true));
                    break;
                }
            }
        }
    }
}
