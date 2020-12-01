// <copyright file="IWldbController.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Controllers
{
    using Ncr.Core.Controllers;
    using Ncr.Core.Views;

    /// <summary>
    /// Initializes a new instance of the IWldbController interface
    /// </summary>
    public interface IWldbController : IController
    {
        /// <summary>
        /// Manage view
        /// </summary>
        /// <returns>Returns manager view</returns>
        IView Manage();
    }
}
