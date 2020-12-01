// <copyright file="ScriptEventEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ScriptEventEventArgs class
    /// </summary>
    public class ScriptEventEventArgs : EventArgs
    {
        /// <summary>
        /// Interface for the script event
        /// </summary>
        private IScriptEvent _scriptEvent;

        /// <summary>
        /// Initializes a new instance of the ScriptEventEventArgs class
        /// </summary>
        /// <param name="scriptEvent">script event</param>
        public ScriptEventEventArgs(IScriptEvent scriptEvent)
        {
            Event = scriptEvent;
        }

        /// <summary>
        /// Gets or sets the script event
        /// </summary>
        public IScriptEvent Event
        {
            get { return _scriptEvent; }
            set { _scriptEvent = value; }
        }
    }
}
