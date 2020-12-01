// <copyright file="ControllerBuilder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Controllers
{
    /// <summary>
    /// Initializes a new instance of the ControllerBuilder class
    /// </summary>
    public static class ControllerBuilder
    {
        /// <summary>
        /// Controller factory interface
        /// </summary>
        private static IControllerFactory controllerFactory;

        /// <summary>
        /// Get the controller factory
        /// </summary>
        /// <returns>Returns the controller factory</returns>
        public static IControllerFactory GetControllerFactory()
        {
            return controllerFactory;
        }

        /// <summary>
        /// Set the controller factory
        /// </summary>
        /// <param name="controllerFactory">controller factory</param>
        public static void SetControllerFactory(IControllerFactory controllerFactory)
        {
            ControllerBuilder.controllerFactory = controllerFactory;
        }
    }
}
