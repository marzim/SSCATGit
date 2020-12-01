// <copyright file="IControllerFactory.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Controllers
{
    /// <summary>
    /// Initializes a new instance of the IControllerFactory interface
    /// </summary>
    public interface IControllerFactory
    {
        /// <summary>
        /// Create controller
        /// </summary>
        /// <param name="controllerName">controller name</param>
        /// <param name="offset">offset amount</param>
        /// <returns>Returns the created controller</returns>
        IController CreateController(string controllerName, int offset);
    }
}
