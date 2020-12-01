// <copyright file="IProcessManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System.Diagnostics;

    /// <summary>
    /// Initializes a new instance of the IProcessManager interface
    /// </summary>
    public interface IProcessManager
    {
        /// <summary>
        /// Get processes by name
        /// </summary>
        /// <param name="name">process name</param>
        /// <returns>Returns the process</returns>
        Process[] GetProcessesByName(string name);

        /// <summary>
        /// Get standard output
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="arguments">process arguments</param>
        /// <returns>Returns the standard output of the process</returns>
        string GetStandardOutput(string filename, string arguments);

        /// <summary>
        /// Start the process
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="arguments">process arguments</param>
        /// <param name="waitForExit">whether or not to wait for process exit</param>
        /// <returns>Returns exit code</returns>
        int Start(string filename, string arguments, bool waitForExit);

        /// <summary>
        /// Start the process
        /// </summary>
        /// <param name="startInfo">process start info</param>
        /// <param name="waitForExit">whether or not to wait for process exit</param>
        void Start(ProcessStartInfo startInfo, bool waitForExit);

        /// <summary>
        /// Start process
        /// </summary>
        /// <param name="filename">file name</param>
        void Start(string filename);

        /// <summary>
        /// Start process
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="waitForExit">whether or not to wait for process exit</param>
        /// <param name="sleep">sleep time</param>
        void Start(string filename, bool waitForExit, int sleep);

        /// <summary>
        /// Start the process
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="arguments">process arguments</param>
        /// <param name="windowstyle">window style</param>
        /// <param name="createNoWindow">whether or not to create a window</param>
        void Start(string filename, string arguments, ProcessWindowStyle windowstyle, bool createNoWindow);

        /// <summary>
        /// Check if process has started
        /// </summary>
        /// <param name="processName">process name</param>
        /// <returns>Returns true if started, false otherwise</returns>
        bool HasStarted(string processName);

        /// <summary>
        /// Check if process has started
        /// </summary>
        /// <param name="processName">process name</param>
        /// <param name="includeExtraValue">Whether or not to include the extra value</param>
        /// <returns>Returns true if started, false otherwise</returns>
        bool HasStarted(string processName, bool includeExtraValue);

        /// <summary>
        /// Checks if host name can be pinged
        /// </summary>
        /// <param name="hostname">host name</param>
        /// <returns>Returns true if able to ping, false otherwise</returns>
        bool CanPing(string hostname);

        /// <summary>
        /// Kill process
        /// </summary>
        /// <param name="name">process name</param>
        /// <param name="waitForExit">whether or not to wait for exit</param>
        void Kill(string name, bool waitForExit);

        /// <summary>
        /// Get current process
        /// </summary>
        /// <returns>Returns current process</returns>
        Process GetCurrentProcess();
    }
}
