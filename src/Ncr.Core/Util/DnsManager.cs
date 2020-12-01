// <copyright file="DnsManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;

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
            string returnAddress = string.Empty;

            // Get a list of all network interfaces (usually one per network card, dialup, and VPN connection)
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface network in networkInterfaces)
            {
                // Read the IP configuration for each network
                IPInterfaceProperties properties = network.GetIPProperties();

                if (network.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                       network.OperationalStatus == OperationalStatus.Up &&
                       !network.Description.ToLower().Contains("virtual") &&
                       !network.Description.ToLower().Contains("pseudo"))
                {
                    // Each network interface may have multiple IP addresses
                    foreach (IPAddressInformation address in properties.UnicastAddresses)
                    {
                        // We're only interested in IPv4 addresses for now
                        if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                        {
                            continue;
                        }
                            
                        // Ignore loopback addresses (e.g., 127.0.0.1)
                        if (IPAddress.IsLoopback(address.Address))
                        {
                            continue;
                        }   

                        returnAddress = address.Address.ToString();
                        LoggingService.Info(string.Format(address.Address.ToString() + " (" + network.Name + " - " + network.Description + ")"));
                    }
                }
            }

            return returnAddress;
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
