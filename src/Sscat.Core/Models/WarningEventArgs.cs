// <copyright file="WarningEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the WarningEventArgs class
    /// </summary>
    public class WarningEventArgs : EventArgs
    {
        /// <summary>
        /// Interface for the warning event
        /// </summary>
        private IWarningEvent _warningEvent;

        /// <summary>
        /// Initializes a new instance of the WarningEventArgs class
        /// </summary>
        /// <param name="warningEvent">warning event</param>
        public WarningEventArgs(IWarningEvent warningEvent)
        {
            Event = warningEvent;
        }

        /// <summary>
        /// Gets or sets the warning event
        /// </summary>
        public IWarningEvent Event
        {
            get { return _warningEvent; }
            set { _warningEvent = value; }
        }
    }
}
