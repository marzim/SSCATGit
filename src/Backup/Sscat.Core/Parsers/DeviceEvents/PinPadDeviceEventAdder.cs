﻿// <copyright file="PinPadDeviceEventAdder.cs" company="NCR">
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
    /// Initializes a new instance of the PinPadDeviceEventAdder class
    /// </summary>
    public class PinPadDeviceEventAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the PinPadDeviceEventAdder class
        /// </summary>
        public PinPadDeviceEventAdder()
            : base(Constants.DeviceType.PINPAD)
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
            IDeviceEvent item = new DeviceEvent();
            item.Id = Id;
            item.Value = "1234"; // FIXME: Actual value has garbage characters.
            events.Add(item.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(match.Groups["ms"].Value, ",", string.Empty)), true));
        }
    }
}
