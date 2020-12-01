// <copyright file="DnsHelper.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Util
{
    using System;
    using System.Net;

    /// <summary>
    /// Initializes static members of the DnsHelper class
    /// </summary>
    public static class DnsHelper
    {
        /// <summary>
        /// Domain name server manager interface
        /// </summary>
        private static IDnsManager _manager;

        /// <summary>
        /// Initializes static members of the DnsHelper class
        /// </summary>
        static DnsHelper()
        {
            Attach(new DnsManager());
        }

        /// <summary>
        /// Attach DNS manager
        /// </summary>
        /// <param name="manager">DNS manager</param>
        public static void Attach(IDnsManager manager)
        {
            DnsHelper._manager = manager;
        }

        /// <summary>
        /// Get host by name
        /// </summary>
        /// <param name="hostName">host name</param>
        /// <returns>Returns the IP host entry</returns>
        public static IPHostEntry GetHostByName(string hostName)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("DnsManager");
            }

            return _manager.GetHostByName(hostName);
        }

        /// <summary>
        /// Checks if the DNS has host
        /// </summary>
        /// <param name="host">host name</param>
        /// <returns>Returns true if host is found, false otherwise</returns>
        public static bool HasHost(string host)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("DnsManager");
            }

            return _manager.HasHost(host);
        }

        /// <summary>
        /// Get local IP address
        /// </summary>
        /// <returns>Returns the local IP address</returns>
        public static string GetLocalIPAddress()
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("DnsManager");
            }

            return GetIPAddress("localhost");
        }

        /// <summary>
        /// Checks for valid host name
        /// </summary>
        /// <param name="host">host name</param>
        /// <returns>Returns true if valid, false otherwise</returns>
        public static bool ValidHostName(string host)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("DnsManager");
            }

            return _manager.ValidHostName(host);
        }

        /// <summary>
        /// Get IP address
        /// </summary>
        /// <param name="host">host name</param>
        /// <returns>Returns the IP address</returns>
        public static string GetIPAddress(string host)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("DnsManager");
            }

            return _manager.GetIPAddress(host);
        }

        /// <summary>
        /// Get host name
        /// </summary>
        /// <returns>Returns the host name</returns>
        public static string GetHostName()
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("DnsManager");
            }

            return _manager.GetHostName();
        }
    }
}
