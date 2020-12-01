// <copyright file="DnsManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System.Net;

    /// <summary>
    /// Initializes a new instance of the DnsManager class
    /// </summary>
    public class DnsManager : IDnsManager
    {
        /// <summary>
        /// Get local IP address
        /// </summary>
        /// <returns>Returns the local IP address</returns>
        public string GetLocalIPAddress()
        {
            return GetIPAddress("localhost");
        }

        /// <summary>
        /// Get host name
        /// </summary>
        /// <returns>Returns the host name</returns>
        public string GetHostName()
        {
            return Dns.GetHostName();
        }

        /// <summary>
        /// Checks for valid host name
        /// </summary>
        /// <param name="host">host name</param>
        /// <returns>Returns true if valid, false otherwise</returns>
        public bool ValidHostName(string host)
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry(host);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Get host by name
        /// </summary>
        /// <param name="hostName">host name</param>
        /// <returns>Returns the IP host entry</returns>
        public IPHostEntry GetHostByName(string hostName)
        {
            return Dns.GetHostEntry(hostName);
        }

        /// <summary>
        /// Get IP address
        /// </summary>
        /// <param name="host">host name</param>
        /// <returns>Returns the IP address</returns>
        public string GetIPAddress(string host)
        {
            host = (host.ToLower() == "localhost" || host == "127.0.0.1" || GetLocalIPAddress() == host) ? Dns.GetHostName() : host;
            IPHostEntry entry = Dns.GetHostEntry(host);
            string firstEntry = string.Empty;
            foreach (IPAddress ip in entry.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    firstEntry = ip.ToString();
                    LoggingService.Info(string.Format("IP address of {0} is {1}", host, firstEntry));
                    break;
                }
            }

            return firstEntry;
        }

        /// <summary>
        /// Checks if the DNS has host
        /// </summary>
        /// <param name="host">host name</param>
        /// <returns>Returns true if host is found, false otherwise</returns>
        public bool HasHost(string host)
        {
            return host != null && host != string.Empty && host != "localhost" && host != GetLocalIPAddress() && GetIPAddress(host) != GetLocalIPAddress();
        }
    }
}
