// <copyright file="ApplicationFactory.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Emulators
{
    /// <summary>
    /// Initializes a new instance of the ApplicationFactory class
    /// </summary>
    public static class ApplicationFactory
    {
        /// <summary>
        /// Get the application
        /// </summary>
        /// <param name="applications">list of applications</param>
        /// <returns>Returns the application that exists</returns>
        public static IApplication GetApplication(params IApplication[] applications)
        {
            foreach (IApplication application in applications)
            {
                if (application.Exists)
                {
                    return application;
                }
            }

            return null;
        }
    }
}
