﻿// <copyright file="ChangeDueAndTenderTypeEventAdder.cs" company="NCR">
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
    /// Initializes a new instance of the ChangeDueAndTenderTypeEventAdder class
    /// </summary>
    public class ChangeDueAndTenderTypeEventAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the ChangeDueAndTenderTypeEventAdder class
        /// </summary>
        public ChangeDueAndTenderTypeEventAdder()
            : base(Constants.DeviceType.CHANGE_DUE_AND_TENDER_TYPE)
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
            IDeviceEvent item = new DeviceEvent(Id, string.Format("{0};{1};{2};{3}", match.Groups["tender"].Value, match.Groups["balance"].Value, match.Groups["change"].Value, match.Groups["tenderType"].Value));
            events.Add(item.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(match.Groups["ms"].Value, ",", string.Empty)), true));
        }
    }
}
