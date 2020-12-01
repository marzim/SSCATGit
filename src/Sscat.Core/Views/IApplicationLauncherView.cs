// <copyright file="IApplicationLauncherView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Views
{
    using System;
    using Ncr.Core.Views;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the IApplicationLauncherView interface
    /// </summary>
    public interface IApplicationLauncherView : IView
    {
        /// <summary>
        /// Event handler for creating
        /// </summary>
        event EventHandler<ApplicationLauncherEventArgs> Creating;

        /// <summary>
        /// Gets or sets the application launcher
        /// </summary>
        IApplicationLauncherEvent ApplicationLauncher { get; set; }

        /// <summary>
        /// Creates the application launcher view
        /// </summary>
        void Create();
    }
}
