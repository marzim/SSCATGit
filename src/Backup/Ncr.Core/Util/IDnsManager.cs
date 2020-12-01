// <copyright file="IDnsManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System.Net;

    /// <summary>
    /// Initializes a new instance of the IDnsManager interface
    /// </summary>
    public interface IDnsManager
    {
        /// <summary>
        /// Checks if the DNS has host
        /// </summary>
        /// <param name="host">host name</param>
        /// <returns>Returns true if host is found, false otherwise</returns>
        bool HasHost(string host);

        /// <summary>
        /// Get IP address
        /// </summary>
        /// <param name="host">host name</param>
        /// <returns>Returns the IP address</returns>
        string GetIPAddress(string host);

        /// <summary>
        /// Get local IP address
        /// </summary>
        /// <returns>Returns the local IP address</returns>
        string GetLocalIPAddress();

        /// <summary>
        /// Checks for valid host name
        /// </summary>
        /// <param name="host">host name</param>
        /// <returns>Returns true if valid, false otherwise</returns>
        bool ValidHostName(string host);

        /// <summary>
        /// Get host by name
        /// </summary>
        /// <param name="hostName">host name</param>
        /// <returns>Returns the IP host entry</returns>
        IPHostEntry GetHostByName(string hostName);

        /// <summary>
        /// Get host name
        /// </summary>
        /// <returns>Returns the host name</returns>
        string GetHostName();
    }
}
