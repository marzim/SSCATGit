// <copyright file="UIAutoTestListButtonClickEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.UIAutoTestEvents
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the UIAutoTestListButtonClickEventAdder class
    /// </summary>
    public class UIAutoTestListButtonClickEventAdder : UIAutoTestEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the UIAutoTestListButtonClickEventAdder class
        /// </summary>
        public UIAutoTestListButtonClickEventAdder()
            : base()
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
            IUIAutoTestEvent item = CreateEvent();
            item.EventType = Constants.UIAutoTestEvent.LIST_BUTTON_CLICK;
            item.ControlName = match.Groups["controlname"].Value;
            item.Index = match.Groups["index"].Value;
            item.ButtonName = match.Groups["buttonname"].Value;
            item.ContextName = match.Groups["contextname"].Value;

            DateTime dateTime = DateTime.ParseExact(match.Groups["datetime"].Value, @"MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            long time = Convert.ToInt64(match.Groups["ms"].Value.Replace(",", string.Empty));
            events.Add(item.CreateEvent(time, dateTime, true));
        }
    }
}
