// <copyright file="IPsx.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Models
{
    using PsxNet;

    /// <summary>
    /// Initializes a new instance of the IPsx interface
    /// </summary>
    public interface IPsx
    {
        /// <summary>
        /// Event handler for PSX event
        /// </summary>
        event PsxEventHandler PsxEvent;

        /// <summary>
        /// Gets or sets the Host name
        /// </summary>
        string HostName { get; set; }

        /// <summary>
        /// Gets or sets the Connection name
        /// </summary>
        string ConnectionName { get; set; }

        /// <summary>
        /// Gets or sets the Service name
        /// </summary>
        string ServiceName { get; set; }

        /// <summary>
        /// Gets a value indicating whether or not the PSX is connected
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Connect remote
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        void ConnectRemote(int timeout);

        /// <summary>
        /// Connect remote
        /// </summary>
        /// <param name="hostName">host name</param>
        /// <param name="serviceName">service name</param>
        /// <param name="connectionName">connection name</param>
        /// <param name="timeout">timeout amount</param>
        void ConnectRemote(string hostName, string serviceName, string connectionName, int timeout);

        /// <summary>
        /// Connect remote
        /// </summary>
        /// <param name="hostName">host name</param>
        /// <param name="serviceName">service name</param>
        /// <param name="connectionName">connection name</param>
        /// <param name="param">temporary parameter</param>
        /// <param name="timeout">timeout amount</param>
        void ConnectRemote(string hostName, string serviceName, string connectionName, ref object param, int timeout);

        /// <summary>
        /// Checks if the context names are the same
        /// </summary>
        /// <param name="contextName">context name</param>
        /// <returns>Returns true if match, false otherwise</returns>
        bool ContextEquals(string contextName);

        /// <summary>
        /// Checks if the PSX control is visible
        /// </summary>
        /// <param name="controlName">control name</param>
        /// <returns>Returns true if visible, false otherwise</returns>
        bool IsControlVisible(string controlName);

        /// <summary>
        /// Checks if PSX control is clickable
        /// </summary>
        /// <param name="controlName">control name</param>
        /// <returns>Returns true if clickable, false otherwise</returns>
        bool IsClickable(string controlName);

        /// <summary>
        /// Generate PSX event
        /// </summary>
        /// <param name="connectionName">connection name</param>
        /// <param name="controlName">control name</param>
        /// <param name="contextName">context name</param>
        /// <param name="eventName">event name</param>
        /// <param name="param">event parameter</param>
        void GenerateEvent(string connectionName, string controlName, string contextName, string eventName, object param);

        /// <summary>
        /// Get context from the display target
        /// </summary>
        /// <param name="displayTarget">Display target</param>
        /// <returns>Returns the context</returns>
        string GetContext(uint displayTarget);

        /// <summary>
        /// Get the control property
        /// </summary>
        /// <param name="controlName">control name</param>
        /// <param name="propertyName">property name</param>
        /// <returns>Returns the control property</returns>
        object GetControlProperty(string controlName, string propertyName);

        /// <summary>
        /// Send the control command
        /// </summary>
        /// <param name="controlName">control command</param>
        /// <param name="command">command name</param>
        /// <returns>Returns the command</returns>
        object SendControlCommand(string controlName, string command);

        /// <summary>
        /// Send the control command
        /// </summary>
        /// <param name="controlName">control command</param>
        /// <param name="command">command name</param>
        /// <param name="noParams">no parameters</param>
        /// <param name="commandParams">command parameters</param>
        /// <returns>Returns the command</returns>
        object SendControlCommand(string controlName, string command, int noParams, object[] commandParams);

        /// <summary>
        /// Disconnect remote connection
        /// </summary>
        void DisconnectRemote();

        /// <summary>
        /// Disconnect remote connection
        /// </summary>
        /// <param name="connectionName">connection name</param>
        void DisconnectRemote(string connectionName);

        /// <summary>
        /// PSX has stopped
        /// </summary>
        void Stop();
    }
}
