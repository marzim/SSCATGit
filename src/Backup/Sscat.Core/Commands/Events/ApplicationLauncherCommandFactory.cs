// <copyright file="ApplicationLauncherCommandFactory.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Sscat.Core.Commands
{
    using Sscat.Core.Commands.Events;
    using Sscat.Core.Commands.Events.Launcher;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ApplicationLauncherCommandFactory class
    /// </summary>
    public class ApplicationLauncherCommandFactory : EventCommandFactory
    {
        /// <summary>
        /// Interface for the application launcher event
        /// </summary>
        private IApplicationLauncherEvent _item;

        /// <summary>
        /// Interface for the SSCAT application launcher
        /// </summary>
        private ISscatApplicationLauncher _applicationLauncher;

        /// <summary>
        /// Initializes a new instance of the ApplicationLauncherCommandFactory class
        /// </summary>
        /// <param name="item">application launcher event</param>
        /// <param name="applicationLauncher">SSCAT application launcher</param>
        public ApplicationLauncherCommandFactory(IApplicationLauncherEvent item, ISscatApplicationLauncher applicationLauncher)
        {
            _item = item;
            _applicationLauncher = applicationLauncher;
        }

        /// <summary>
        /// Creates an application launcher command
        /// </summary>
        /// <returns>Return the event command</returns>
        public override IEventCommand CreateCommand()
        {
            return new LaunchApplication(_item, _applicationLauncher);
        }
    }
}
