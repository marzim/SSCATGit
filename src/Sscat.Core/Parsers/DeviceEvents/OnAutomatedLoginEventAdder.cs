// <copyright file="OnAutomatedLoginEventAdder.cs" company="NCR">
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
    /// Initializes a new instance of the OnAutomatedLoginEventAdder class
    /// </summary>
    public class OnAutomatedLoginEventAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the OnAutomatedLoginEventAdder class
        /// </summary>
        public OnAutomatedLoginEventAdder()
            : base(Constants.DeviceType.ON_AUTOMATED_LOGIN)
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
#if NET40
            base.Add(line, match, reader, events, eventValue);
#endif
        }
    }
}
