// <copyright file="ApplicationLauncherEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ApplicationLauncherEventArgs class
    /// </summary>
    public class ApplicationLauncherEventArgs : EventArgs
    {
        /// <summary>
        /// Status message
        /// </summary>
        private string _statusMessage;

        /// <summary>
        /// Interface for the application launcher event
        /// </summary>
        private IApplicationLauncherEvent _applicationLauncherEvent;

        /// <summary>
        /// Initializes a new instance of the ApplicationLauncherEventArgs class
        /// </summary>
        /// <param name="applicationLauncherEvent">application launcher event</param>
        public ApplicationLauncherEventArgs(IApplicationLauncherEvent applicationLauncherEvent)
        {
            LauncherEvent = applicationLauncherEvent;
        }

        /// <summary>
        /// Initializes a new instance of the ApplicationLauncherEventArgs class
        /// </summary>
        /// <param name="statusMessage">status message</param>
        public ApplicationLauncherEventArgs(string statusMessage)
        {
            StatusMessage = statusMessage;
        }

        /// <summary>
        /// Gets or sets the launcher event
        /// </summary>
        public IApplicationLauncherEvent LauncherEvent
        {
            get { return _applicationLauncherEvent; }
            set { _applicationLauncherEvent = value; }
        }

        /// <summary>
        /// Gets or sets the status message
        /// </summary>
        public string StatusMessage
        {
            get { return _statusMessage; }
            set { _statusMessage = value; }
        }
    }
}
