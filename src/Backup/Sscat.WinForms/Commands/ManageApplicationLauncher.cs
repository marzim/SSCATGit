// <copyright file="ManageApplicationLauncher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Commands
{
    using System;
    using Ncr.Core.Commands;
    using Ncr.Core.Views;
    using Sscat.Core.Controllers;
    using Sscat.Core.Util;
    using Sscat.Core.Views;
    using Sscat.Gui;

    /// <summary>
    /// Initializes a new instance of the ManageApplicationLauncher class
    /// </summary>
    public class ManageApplicationLauncher : AbstractCommand
    {
        /// <summary>
        /// Initializes a new instance of the ManageApplicationLauncher class
        /// </summary>
        public ManageApplicationLauncher()
        {
        }

        /// <summary>
        /// Runs the manage application launcher
        /// </summary>
        public override void Run()
        {
            IApplicationLauncherController controller = new ApplicationLauncherController(new SscatApplicationLauncher(), new ApplicationLauncherPane());
            IApplicationLauncherView applicationLauncherView = controller.Create() as IApplicationLauncherView;
            WorkbenchSingleton.ShowView(applicationLauncherView);
        }
    }
}
