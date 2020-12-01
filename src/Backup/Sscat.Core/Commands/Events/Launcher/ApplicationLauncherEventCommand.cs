// <copyright file="ApplicationLauncherEventCommand.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ApplicationLauncherEventCommand class
    /// </summary>
    public class ApplicationLauncherEventCommand : AbstractEventCommand
    {
        /// <summary>
        /// Interface for the application launcher
        /// </summary>
        private ISscatApplicationLauncher _applicationLauncher;

        /// <summary>
        /// Initializes a new instance of the ApplicationLauncherEventCommand class
        /// </summary>
        /// <param name="item">application launcher event</param>
        /// <param name="applicationLauncher">application launcher</param>
        public ApplicationLauncherEventCommand(IApplicationLauncherEvent item, ISscatApplicationLauncher applicationLauncher)
        {
            ScriptEventItem = item;
            ApplicationLauncher = applicationLauncher;
        }

        /// <summary>
        /// Gets or sets the application launcher
        /// </summary>
        public ISscatApplicationLauncher ApplicationLauncher
        {
            get { return _applicationLauncher; }
            set { _applicationLauncher = value; }
        }

        /// <summary>
        /// Gets the application launcher event
        /// </summary>
        public IApplicationLauncherEvent Item
        {
            get { return ScriptEventItem as IApplicationLauncherEvent; }
        }

        /// <summary>
        /// Prior to the run
        /// </summary>
        public override void PreRun()
        {
        }
    }
}
