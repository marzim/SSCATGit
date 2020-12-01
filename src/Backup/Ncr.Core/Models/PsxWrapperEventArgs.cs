// <copyright file="PsxWrapperEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Models
{
    using System;

    /// <summary>
    /// Initializes a new instance of the PsxWrapperEventArgs class
    /// </summary>
    public class PsxWrapperEventArgs : EventArgs
    {
        /// <summary>
        /// Host name
        /// </summary>
        private string _hostName;

        /// <summary>
        /// Service name
        /// </summary>
        private string _serviceName;

        /// <summary>
        /// Connection name
        /// </summary>
        private string _connectionName;

        /// <summary>
        /// Timeout amount
        /// </summary>
        private int _timeout;

        /// <summary>
        /// Initializes a new instance of the PsxWrapperEventArgs class
        /// </summary>
        /// <param name="host">host name</param>
        /// <param name="service">service name</param>
        /// <param name="connectionName">connection name</param>
        /// <param name="timeout">timeout amount</param>
        public PsxWrapperEventArgs(string host, string service, string connectionName, int timeout)
        {
            HostName = host;
            ServiceName = service;
            ConnectionName = connectionName;
            Timeout = timeout;
        }

        /// <summary>
        /// Gets or sets the timeout
        /// </summary>
        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        /// <summary>
        /// Gets or sets the connection name
        /// </summary>
        public string ConnectionName
        {
            get { return _connectionName; }
            set { _connectionName = value; }
        }

        /// <summary>
        /// Gets or sets the service name
        /// </summary>
        public string ServiceName
        {
            get { return _serviceName; }
            set { _serviceName = value; }
        }

        /// <summary>
        /// Gets or sets the host name
        /// </summary>
        public string HostName
        {
            get { return _hostName; }
            set { _hostName = value; }
        }
    }
}
