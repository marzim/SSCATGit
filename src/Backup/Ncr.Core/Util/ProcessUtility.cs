// <copyright file="ProcessUtility.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Initializes static members of the ProcessUtility class
    /// </summary>
    public static class ProcessUtility
    {
        /// <summary>
        /// Process manager interface
        /// </summary>
        private static IProcessManager _manager;

        /// <summary>
        /// Initializes static members of the ProcessUtility class
        /// </summary>
        static ProcessUtility()
        {
            Attach(new ProcessManager());
        }

        /// <summary>
        /// Attach process manager
        /// </summary>
        /// <param name="manager">process manager</param>
        public static void Attach(IProcessManager manager)
        {
            ProcessUtility._manager = manager;
        }

        /// <summary>
        /// Get processes by name
        /// </summary>
        /// <param name="name">process name</param>
        /// <returns>Returns the process</returns>
        public static Process[] GetProcessesByName(string name)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("ProcessManager");
            }

            return _manager.GetProcessesByName(name);
        }

        /// <summary>
        /// Get current process
        /// </summary>
        /// <returns>Returns current process</returns>
        public static Process GetCurrentProcess()
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("ProcessManager");
            }

            return _manager.GetCurrentProcess();
        }

        /// <summary>
        /// Get standard output
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="arguments">process arguments</param>
        /// <returns>Returns the standard output of the process</returns>
        public static string GetStandardOutput(string filename, string arguments)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("ProcessManager");
            }

            return _manager.GetStandardOutput(filename, arguments);
        }

        /// <summary>
        /// Kill process
        /// </summary>
        /// <param name="name">process name</param>
        public static void Kill(string name)
        {
            Kill(name, false);
        }

        /// <summary>
        /// Kill process
        /// </summary>
        /// <param name="name">process name</param>
        /// <param name="waitForExit">whether or not to wait for exit</param>
        public static void Kill(string name, bool waitForExit)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("ProcessManager");
            }

            _manager.Kill(name, waitForExit);
        }

        /// <summary>
        /// Start the process
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="arguments">process arguments</param>
        /// <param name="waitForExit">whether or not to wait for process exit</param>
        /// <returns>Returns exit code</returns>
        public static int Start(string filename, string arguments, bool waitForExit)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("ProcessManager");
            }

            return _manager.Start(filename, arguments, waitForExit);
        }

        /// <summary>
        /// Start process
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="waitForExit">whether or not to wait for process exit</param>
        /// <param name="sleep">sleep time</param>
        public static void Start(string filename, bool waitForExit, int sleep)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("ProcessManager");
            }

            _manager.Start(filename, waitForExit, sleep);
        }

        /// <summary>
        /// Start process
        /// </summary>
        /// <param name="filename">file name</param>
        public static void Start(string filename)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("ProcessManager");
            }

            _manager.Start(filename);
        }

        /// <summary>
        /// Start the process
        /// </summary>
        /// <param name="startInfo">process start info</param>
        public static void Start(ProcessStartInfo startInfo)
        {
            Start(startInfo, false);
        }

        /// <summary>
        /// Start the process
        /// </summary>
        /// <param name="startInfo">process start info</param>
        /// <param name="waitForExit">whether or not to wait for process exit</param>
        public static void Start(ProcessStartInfo startInfo, bool waitForExit)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("ProcessManager");
            }

            _manager.Start(startInfo, waitForExit);
        }

        /// <summary>
        /// Check if process has started
        /// </summary>
        /// <param name="processName">process name</param>
        /// <returns>Returns true if started, false otherwise</returns>
        public static bool HasStarted(string processName)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("ProcessManager");
            }

            return _manager.HasStarted(processName);
        }

        /// <summary>
        /// Check if process has started
        /// </summary>
        /// <param name="processName">process name</param>
        /// <param name="includeExtraValue">Whether or not to include the extra value</param>
        /// <returns>Returns true if started, false otherwise</returns>
        public static bool HasStarted(string processName, bool includeExtraValue)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("ProcessManager");
            }

            return _manager.HasStarted(processName, includeExtraValue);
        }

        /// <summary>
        /// Checks if host name can be pinged
        /// </summary>
        /// <param name="hostname">host name</param>
        /// <returns>Returns true if able to ping, false otherwise</returns>
        public static bool CanPing(string hostname)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("ProcessManager");
            }

            return _manager.CanPing(hostname);
        }

        /// <summary>
        /// Start the process
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="arguments">process arguments</param>
        /// <param name="windowstyle">window style</param>
        /// <param name="createNoWindow">whether or not to create a window</param>
        public static void Start(string filename, string arguments, ProcessWindowStyle windowstyle, bool createNoWindow)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("ProcessManager");
            }

            _manager.Start(filename, arguments, windowstyle, createNoWindow);
        }
    }
}
