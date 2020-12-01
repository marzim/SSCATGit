// <copyright file="ScotLogHookEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Log
{
    using System.Collections.Generic;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ScotLogHookEventArgs class
    /// </summary>
    public class ScotLogHookEventArgs : LogHookEventArgs
    {
        /// <summary>
        /// Interface for the script events
        /// </summary>
        private List<IScriptEvent> _scriptEvents;

        /// <summary>
        /// Initializes a new instance of the ScotLogHookEventArgs class
        /// </summary>
        /// <param name="events">script events</param>
        public ScotLogHookEventArgs(List<IScriptEvent> events)
            : base(string.Empty)
        {
            Events = events;
        }

        /// <summary>
        /// Gets or sets the script events
        /// </summary>
        public List<IScriptEvent> Events
        {
            get { return _scriptEvents; }
            set { _scriptEvents = value; }
        }
    }
}
