// <copyright file="ApplicationLauncherController.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Controllers
{
    using System;
    using Ncr.Core.Controllers;
    using Ncr.Core.Util;
    using Ncr.Core.Views;
    using Sscat.Core.Models;
    using Sscat.Core.Util;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ApplicationLauncherController class
    /// </summary>
    public class ApplicationLauncherController : AbstractController, IApplicationLauncherController
    {
        /// <summary>
        /// Interface for the SSCAT application launcher
        /// </summary>
        private ISscatApplicationLauncher _applicationLauncher;

        /// <summary>
        /// Interface for the application launcher view
        /// </summary>
        private IApplicationLauncherView _applicationLauncherView;

        /// <summary>
        /// Initializes a new instance of the ApplicationLauncherController class
        /// </summary>
        /// <param name="applicationLauncher">sscat application launcher</param>
        /// <param name="applicationLauncherView">application launcher view</param>
        public ApplicationLauncherController(ISscatApplicationLauncher applicationLauncher, IApplicationLauncherView applicationLauncherView)
        {
            _applicationLauncher = applicationLauncher;
            _applicationLauncherView = applicationLauncherView;

            applicationLauncher.ApplicationLauncherManage += new EventHandler<ApplicationLauncherEventArgs>(ApplicationLauncherManaging);
            applicationLauncherView.Creating += new EventHandler<ApplicationLauncherEventArgs>(ApplicationLauncherCreating);
        }

        /// <summary>
        /// Finalizes an instance of the ApplicationLauncherController class
        /// </summary>
        ~ApplicationLauncherController()
        {
            _applicationLauncher.ApplicationLauncherManage -= new EventHandler<ApplicationLauncherEventArgs>(ApplicationLauncherManaging);
            _applicationLauncherView.Creating -= new EventHandler<ApplicationLauncherEventArgs>(ApplicationLauncherCreating);
        }

        /// <summary>
        /// Creates the application launcher view
        /// </summary>
        /// <returns>Returns the application launcher view</returns>
        public IView Create()
        {
            return _applicationLauncherView;
        }

        /// <summary>
        /// Event for application launcher manager
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">application launcher event arguments</param>
        private void ApplicationLauncherManaging(object sender, ApplicationLauncherEventArgs e)
        {
            MessageService.ShowInfo(e.StatusMessage);
        }

        /// <summary>
        /// Event for application launcher creation
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">application launcher event arguments</param>
        private void ApplicationLauncherCreating(object sender, ApplicationLauncherEventArgs e)
        {
            _applicationLauncher.CreateLaunchApplication(e.LauncherEvent);
        }
    }
}
