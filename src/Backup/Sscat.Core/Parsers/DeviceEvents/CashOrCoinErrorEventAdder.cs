// <copyright file="CashOrCoinErrorEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.DeviceEvents
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the CashOrCoinErrorEventAdder class
    /// </summary>
    public class CashOrCoinErrorEventAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the CashOrCoinErrorEventAdder class
        /// </summary>
        /// <param name="id">device ID</param>
        public CashOrCoinErrorEventAdder(string id)
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
            string val = ((match.Groups["value"] == null) || (match.Groups["value"].Value == string.Empty)) ? "0" : match.Groups["value"].Value;

            if (IsValidValue(val))
            {
                IDeviceEvent item = new DeviceEvent();
                item.Id = Id;
                item.Value = val;
                events.Add(item.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(match.Groups["ms"].Value, ",", string.Empty)), true));
            }
        }

        /// <summary>
        /// Checks for if the value is valid
        /// </summary>
        /// <param name="val">value to check</param>
        /// <returns>Returns true if valid, false otherwise</returns>
        protected virtual bool IsValidValue(string val)
        {
            return true;
        }
    }
}
