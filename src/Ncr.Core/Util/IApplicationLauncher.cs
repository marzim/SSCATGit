// <copyright file="IApplicationLauncher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    /// <summary>
    /// Initializes a new instance of the IApplicationLauncher interface
    /// </summary>
    public interface IApplicationLauncher
    {
        /// <summary>
        /// Launch application
        /// </summary>
        /// <param name="host">host name</param>
        /// <param name="path">path name</param>
        void LaunchApplication(string host, string path);
    }
}
