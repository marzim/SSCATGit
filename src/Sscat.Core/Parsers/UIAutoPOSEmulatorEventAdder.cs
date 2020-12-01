// <copyright file="UIAutoPOSEmulatorEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;
    using Sscat.Core.Finger;
    using Sscat.Core.Models;

    /// <summary>
    /// Initializes a new instance of the UIAutoPOSEmulatorEventAdder class
    /// </summary>
    public class UIAutoPOSEmulatorEventAdder : AbstractEventAdder
    {
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
        }

        /// <summary>
        /// Creates the auto POS emulator event
        /// </summary>
        /// <returns>Returns the event</returns>
        protected virtual IUIAutoPOSEmulatorEvent CreateEvent()
        {
            return new FingerUIAutoPOSEmulatorEvent();
        }
    }
}
