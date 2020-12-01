// <copyright file="ReceiptItemDeviceEventAdder.cs" company="NCR">
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
    /// Initializes a new instance of the ReceiptItemDeviceEventAdder class
    /// </summary>
    public class ReceiptItemDeviceEventAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the ReceiptItemDeviceEventAdder class
        /// </summary>
        public ReceiptItemDeviceEventAdder()
            : base(Constants.DeviceType.RECEIPT_ITEM)
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
            decimal price = decimal.Parse(match.Groups["price"].Value) / 100;
            string val = match.Groups["description"].Value;
            item.Value = string.Format("{0}\t{1}", val, price.ToString("f2"));
            events.Add(item.CreateEvent(ConvertUtility.ToInt64(StringUtility.Replace(match.Groups["ms"].Value, ",", string.Empty)), true));
        }
    }
}
