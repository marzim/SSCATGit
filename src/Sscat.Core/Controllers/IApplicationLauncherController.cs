// <copyright file="IApplicationLauncherController.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Controllers
{
    using Ncr.Core.Controllers;
    using Ncr.Core.Views;

    /// <summary>
    /// Initializes a new instance of the IApplicationLauncherController interface class
    /// </summary>
    public interface IApplicationLauncherController : IController
    {
        /// <summary>
        /// Creates the application launcher view
        /// </summary>
        /// <returns>Returns the application launcher view</returns>
        IView Create();
    }
}
