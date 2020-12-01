// <copyright file="WldbEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using Sscat.Core.Models.ScriptModel;
    
    /// <summary>
    /// Initializes a new instance of the WldbEventArgs class
    /// </summary>
    public class WldbEventArgs : EventArgs
    {
        /// <summary>
        /// Event message
        /// </summary>
        private string _message;

        /// <summary>
        /// Event mode
        /// </summary>
        private string _mode;

        /// <summary>
        /// Whether or not the event is for an update
        /// </summary>
        private bool _forUpdate;

        /// <summary>
        /// WLDB event
        /// </summary>
        private IWldbEvent _wldbEvent;

        /// <summary>
        /// Initializes a new instance of the WldbEventArgs class
        /// </summary>
        /// <param name="wldbEvent">WLDB event</param>
        /// <param name="forUpdate">Whether or not the event is for an update</param>
        public WldbEventArgs(IWldbEvent wldbEvent, bool forUpdate)
        {
            Event = wldbEvent;
            ForUpdate = forUpdate;
        }

        /// <summary>
        /// Initializes a new instance of the WldbEventArgs class
        /// </summary>
        /// <param name="wldbEvent">wldb event</param>
        /// <param name="mode">event mode</param>
        public WldbEventArgs(IWldbEvent wldbEvent, string mode)
            : this(wldbEvent, true)
        {
            Event = wldbEvent;
            Mode = mode;
        }

        /// <summary>
        /// Initializes a new instance of the WldbEventArgs class
        /// </summary>
        /// <param name="message">event message</param>
        public WldbEventArgs(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Gets or sets the event mode
        /// </summary>
        public string Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the vent is for an update
        /// </summary>
        public bool ForUpdate
        {
            get { return _forUpdate; }
            set { _forUpdate = value; }
        }

        /// <summary>
        /// Gets or sets the WLDB event
        /// </summary>
        public IWldbEvent Event
        {
            get { return _wldbEvent; }
            set { _wldbEvent = value; }
        }

        /// <summary>
        /// Gets or sets the event message
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
