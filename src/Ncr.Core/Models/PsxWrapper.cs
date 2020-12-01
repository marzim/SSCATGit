// <copyright file="PsxWrapper.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Models
{
    using System;
    using Ncr.Core.Util;
    using PsxNet;

    /// <summary>
    /// Initializes a new instance of the PsxWrapper class
    /// </summary>
    public class PsxWrapper : IPsx
    {
        /// <summary>
        /// Connection name
        /// </summary>
        private string _connectionName;

        /// <summary>
        /// Host name
        /// </summary>
        private string _hostName;

        /// <summary>
        /// Service name
        /// </summary>
        private string _serviceName;

        /// <summary>
        /// Instance of PSX
        /// </summary>
        private Psx _psx;

        /// <summary>
        /// Timeout amount
        /// </summary>
        private int _timeout;

        /// <summary>
        /// Whether or not the PSX wrapper has stopped
        /// </summary>
        private bool _hasStopped;

         /// <summary>
        /// Initializes a new instance of the PsxWrapper class
        /// </summary>
        /// <param name="host">host name</param>
        /// <param name="service">service name</param>
        /// <param name="connection">connection name</param>
        /// <param name="timeout">timeout amount</param>
        public PsxWrapper(string host, string service, string connection, int timeout)
            : this(host, service, connection, timeout, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PsxWrapper class
        /// </summary>
        /// <param name="host">host name</param>
        /// <param name="service">service name</param>
        /// <param name="connection">connection name</param>
        /// <param name="timeout">timeout amount</param>
        /// <param name="instantiate">whether or not to instantiate</param>
        public PsxWrapper(string host, string service, string connection, int timeout, bool instantiate)
        {
            if (instantiate)
            {
                _psx = new PsxNet.Psx();
                ConnectRemote(host, service, connection, timeout);
                _psx.PsxEvent += new PsxEventHandler(PsxPsxEvent);
            }
        }

        /// <summary>
        /// Event handler for PSX event
        /// </summary>
        public event PsxEventHandler PsxEvent;

        /// <summary>
        /// Gets or sets the timeout
        /// </summary>
        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        /// <summary>
        /// Gets a value indicating whether or not the PSX is connected
        /// </summary>
        public bool IsConnected
        {
            get
            {
                foreach (string s in _psx.RemoteConnections)
                {
                    if (s == _connectionName)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Gets the remote connections
        /// </summary>
        public string[] RemoteConnections
        {
            get { return _psx.RemoteConnections; }
        }

        /// <summary>
        /// Gets or sets the Service name
        /// </summary>
        public string ServiceName
        {
            get { return _serviceName; }
            set { _serviceName = value; }
        }

        /// <summary>
        /// Gets or sets the Host name
        /// </summary>
        public string HostName
        {
            get { return _hostName; }
            set { _hostName = value; }
        }

        /// <summary>
        /// Gets or sets the Connection name
        /// </summary>
        public string ConnectionName
        {
            get { return _connectionName; }
            set { _connectionName = value; }
        }

        /// <summary>
        /// Disconnect remote connection
        /// </summary>
        public void DisconnectRemote()
        {
            _psx.DisconnectRemote();
        }

        /// <summary>
        /// Disconnect remote connection
        /// </summary>
        /// <param name="connectionName">connection name</param>
        public void DisconnectRemote(string connectionName)
        {
            _psx.DisconnectRemote(connectionName);
        }

        /// <summary>
        /// Checks if the context names are the same
        /// </summary>
        /// <param name="contextName">context name</param>
        /// <returns>Returns true if match, false otherwise</returns>
        public bool ContextEquals(string contextName)
        {
            Reconnect();
            return GetContext(1).Equals(contextName);
        }

        /// <summary>
        /// Checks if the PSX control is visible
        /// </summary>
        /// <param name="controlName">control name</param>
        /// <returns>Returns true if visible, false otherwise</returns>
        public bool IsControlVisible(string controlName)
        {
            Reconnect();
            return (bool)_psx.GetControlProperty(controlName, "Visible");
        }

        /// <summary>
        /// Checks if PSX control is clickable
        /// </summary>
        /// <param name="controlName">control name</param>
        /// <returns>Returns true if clickable, false otherwise</returns>
        public bool IsClickable(string controlName)
        {
            Reconnect();
            return ((int)_psx.GetControlProperty(controlName, "State") == 2) ? false : true;
        }

        /// <summary>
        /// Generate PSX event
        /// </summary>
        /// <param name="connectionName">connection name</param>
        /// <param name="controlName">control name</param>
        /// <param name="contextName">context name</param>
        /// <param name="eventName">event name</param>
        /// <param name="param">event parameter</param>
        public void GenerateEvent(string connectionName, string controlName, string contextName, string eventName, object param)
        {
            Reconnect();
            LoggingService.Info(string.Format("Generating Event. connectionName: {0}; controlname: {1}; contextName: {2}; eventName: {3}; param: {4}", connectionName, controlName, contextName, eventName, param));
            _psx.GenerateEvent(connectionName, controlName, contextName, eventName, param);
        }

        /// <summary>
        /// Get context from the display target
        /// </summary>
        /// <param name="displayTarget">Display target</param>
        /// <returns>Returns the context</returns>
        public string GetContext(uint displayTarget)
        {
            Reconnect();
            return _psx.GetContext(displayTarget);
        }

        /// <summary>
        /// Get the control property
        /// </summary>
        /// <param name="controlName">control name</param>
        /// <param name="propertyName">property name</param>
        /// <returns>Returns the control property</returns>
        public object GetControlProperty(string controlName, string propertyName)
        {
            Reconnect();
            return _psx.GetControlProperty(controlName, propertyName);
        }

        /// <summary>
        /// Send the control command
        /// </summary>
        /// <param name="controlName">control command</param>
        /// <param name="command">command name</param>
        /// <returns>Returns the command</returns>
        public object SendControlCommand(string controlName, string command)
        {
            Reconnect();
            return _psx.SendControlCommand(controlName, command);
        }

        /// <summary>
        /// Send the control command
        /// </summary>
        /// <param name="controlName">control command</param>
        /// <param name="command">command name</param>
        /// <param name="noParams">no parameters</param>
        /// <param name="commandParams">command parameters</param>
        /// <returns>Returns the command</returns>
        public object SendControlCommand(string controlName, string command, int noParams, object[] commandParams)
        {
            return _psx.SendControlCommand(controlName, command, noParams, commandParams);
        }

        /// <summary>
        /// Connect remote
        /// </summary>
        public void ConnectRemote()
        {
            ConnectRemote(Timeout);
        }

        /// <summary>
        /// Connect remote
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public void ConnectRemote(int timeout)
        {
            object param = string.Empty;
            ConnectRemote(HostName, ServiceName, ConnectionName, ref param, timeout);
        }

        /// <summary>
        /// Connect remote
        /// </summary>
        /// <param name="hostName">host name</param>
        /// <param name="serviceName">service name</param>
        /// <param name="connectionName">connection name</param>
        /// <param name="timeout">timeout amount</param>
        public void ConnectRemote(string hostName, string serviceName, string connectionName, int timeout)
        {
            object param = string.Empty;
            ConnectRemote(hostName, serviceName, connectionName, ref param, timeout);
        }

        /// <summary>
        /// PSX has stopped
        /// </summary>
        public void Stop()
        {
            _hasStopped = true;
        }

        /// <summary>
        /// Connect remote
        /// </summary>
        /// <param name="hostName">host name</param>
        /// <param name="serviceName">service name</param>
        /// <param name="connectionName">connection name</param>
        /// <param name="param">temporary parameter</param>
        /// <param name="timeout">timeout amount</param>
        public void ConnectRemote(string hostName, string serviceName, string connectionName, ref object param, int timeout)
        {
            HostName = hostName;
            ServiceName = serviceName;
            ConnectionName = connectionName;
            Timeout = timeout;

            int now = Environment.TickCount;
            bool connected = false;
            object tempparam = param;

            _hasStopped = false;

            while ((Environment.TickCount - now) < timeout && !connected)
            {
                if (_hasStopped)
                {
                    break;
                }

                try
                {
                    param = tempparam;
                    _psx.ConnectRemote(hostName, serviceName, connectionName, ref param, 5000);
                    connected = true;
                }
                catch (PsxException ex)
                {
                    LoggingService.Error(string.Format("({0}) PsxException: {1}", ex.Source, ex.Message));
                    if (ex.Error.Equals(PsxError.ConnectionExists))
                    {
                        break;
                    }

                    ThreadHelper.Sleep(500);
                }
            }
        }

        /// <summary>
        /// Perform the PSX event
        /// </summary>
        public void PerformPsxEvent()
        {
            OnPsxEvent(null);
        }

        /// <summary>
        /// Event on PSX event
        /// </summary>
        /// <param name="e">psx event arguments</param>
        protected virtual void OnPsxEvent(PsxEventArgs e)
        {
            if (PsxEvent != null)
            {
                PsxEvent(this, e);
            }
        }

        /// <summary>
        /// Reconnect PSX
        /// </summary>
        protected virtual void Reconnect()
        {
            if (!IsConnected)
            {
                ConnectRemote();
            }
        }

        /// <summary>
        /// Event on PSX event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">psx event arguments</param>
        private void PsxPsxEvent(object sender, PsxEventArgs e)
        {
            OnPsxEvent(e);
        }
    }
}
