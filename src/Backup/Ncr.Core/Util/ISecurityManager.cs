// <copyright file="ISecurityManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    /// <summary>
    /// Initializes a new instance of the ISecurityManager interface
    /// </summary>
    public interface ISecurityManager
    {
        /// <summary>
        /// Update the weight learning database
        /// </summary>
        /// <param name="server">server name</param>
        /// <param name="wldbFile">wldb file</param>
        /// <param name="saConfigFile">security agent configuration file</param>
        /// <param name="user">user name</param>
        /// <param name="password">user password</param>
        void UpdateWldb(string server, string wldbFile, string saConfigFile, string user, string password);
    }
}
