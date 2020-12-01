// <copyright file="HandleScannerDataEventAdder.cs" company="NCR">
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
    /// Initializes a new instance of the HandleScannerDataEventAdder class
    /// </summary>
    public class HandleScannerDataEventAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the HandleScannerDataEventAdder class
        /// </summary>
        public HandleScannerDataEventAdder()
            : base(Constants.DeviceType.SCANNER)
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

            while ((line = reader.ReadLine()) != null)
            {
                if ((m = Regex.Match(line, @"(?<ms>\d{10}) .* \+isBarcodeValidOperatorPassword  <(?<value>.*)>", RegexOptions.IgnoreCase)).Success)
                {
                    item.Value = string.Format("{0}~{1}", m.Groups["value"].Value, "0"); // 0 is hardcoded at the end because there is no -isBarcodeValidOperatorPassword
                    item.Value = item.Value.Replace(" ", string.Empty);
                    events.Add(item.CreateEvent(ConvertUtility.ToInt32(StringUtility.Replace(match.Groups["ms"].Value, ",", string.Empty)), dateTime, true));
                    break;
                }
            }
        }
    }
}
