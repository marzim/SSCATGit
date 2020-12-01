// <copyright file="DeviceEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the DeviceEventAdder class
    /// </summary>
    public class DeviceEventAdder : AbstractEventAdder
    {
        /// <summary>
        /// Device ID
        /// </summary>
        private string _id;

        /// <summary>
        /// Initializes a new instance of the DeviceEventAdder class
        /// </summary>
        /// <param name="id">device ID</param>
        public DeviceEventAdder(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets the device ID
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { _id = value; }
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

            // Note: Bagscale event with "m_wLastWeight:" pattern and with negative values is not yet handled, don't know where it was used. (From SMParser)
            item.Value = ((match.Groups["value"] == null) || (match.Groups["value"].Value == string.Empty)) ? "0" : match.Groups["value"].Value;
            events.Add(item.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(match.Groups["ms"].Value, ",", string.Empty)), true));
        }
    }
}
