// <copyright file="ISscatApplicationLauncher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System;
    using Ncr.Core.Util;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ISscatApplicationLauncher interface
    /// </summary>
    public interface ISscatApplicationLauncher : IApplicationLauncher
    {
        /// <summary>
        /// Event handler for application launcher manage
        /// </summary>
        event EventHandler<ApplicationLauncherEventArgs> ApplicationLauncherManage;

        /// <summary>
        /// Launch application
        /// </summary>
        /// <param name="item">application launcher event item</param>
        void LaunchApplication(IApplicationLauncherEvent item);

        /// <summary>
        /// Create launch application
        /// </summary>
        /// <param name="item">application launcher event item</param>
        void CreateLaunchApplication(IApplicationLauncherEvent item);
    }
}
