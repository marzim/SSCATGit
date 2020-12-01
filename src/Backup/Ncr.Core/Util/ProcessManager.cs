// <copyright file="ProcessManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System.Diagnostics;
    using System.IO;
    using System.Threading;

    /// <summary>
    /// Initializes a new instance of the ProcessManager class
    /// </summary>
    public class ProcessManager : IProcessManager
    {
        /// <summary>
        /// Get standard output
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="arguments">process arguments</param>
        /// <returns>Returns the standard output of the process</returns>
        public string GetStandardOutput(string filename, string arguments)
        {
            Process process = new Process();
            ProcessStartInfo info = new ProcessStartInfo(filename, arguments);
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
            info.RedirectStandardInput = true;
            info.RedirectStandardOutput = true;
            process.StartInfo = info;
            process.Start();
            process.WaitForExit();
            return process.StandardOutput.ReadToEnd();
        }

        /// <summary>
        /// Kill process
        /// </summary>
        /// <param name="name">process name</param>
        /// <param name="waitForExit">whether or not to wait for exit</param>
        public void Kill(string name, bool waitForExit)
        {
            Process[] processes = Process.GetProcessesByName(name);
            foreach (Process p in processes)
            {
                if (!p.HasExited)
                {
                    p.Kill();
                    if (waitForExit)
                    {
                        p.WaitForExit();
                    }
                }
            }
        }

        /// <summary>
        /// Get processes by name
        /// </summary>
        /// <param name="name">process name</param>
        /// <returns>Returns process with given names</returns>
        public Process[] GetProcessesByName(string name)
        {
            return Process.GetProcessesByName(name);
        }

        /// <summary>
        /// Get current process
        /// </summary>
        /// <returns>Returns current process</returns>
        public Process GetCurrentProcess()
        {
            return Process.GetCurrentProcess();
        }

        /// <summary>
        /// Checks if host name can be pinged
        /// </summary>
        /// <param name="hostname">host name</param>
        /// <returns>Returns true if able to ping, false otherwise</returns>
        public virtual bool CanPing(string hostname)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "ping.exe";
                p.StartInfo.Arguments = hostname;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.Start();
                while (!p.HasExited)
                {
                    string s = p.StandardOutput.ReadLine();
                    if (s != null && !s.Equals(string.Empty))
                    {
                        if (StringUtility.Contains(s, "Request timed out") || StringUtility.Contains(s, "could not find host") || StringUtility.Contains(s, "Destination host unreachable"))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Check if process has started
        /// </summary>
        /// <param name="processName">process name</param>
        /// <returns>Returns true if started, false otherwise</returns>
        public bool HasStarted(string processName)
        {
            return Process.GetProcessesByName(processName).Length > 0;
        }

        /// <summary>
        /// Check if process has started
        /// </summary>
        /// <param name="processName">process name</param>
        /// <param name="includeExtraValue">Whether or not to include the extra value</param>
        /// <returns>Returns true if started, false otherwise</returns>
        public bool HasStarted(string processName, bool includeExtraValue)
        {
            int extraValue = includeExtraValue ? 1 : 0;
            return Process.GetProcessesByName(processName).Length > extraValue;
        }

        /// <summary>
        /// Start the process
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="arguments">process arguments</param>
        /// <param name="waitForExit">whether or not to wait for process exit</param>
        /// <returns>Returns exit code</returns>
        public int Start(string filename, string arguments, bool waitForExit)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(filename, arguments);
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process process = Process.Start(startInfo);
            if (waitForExit)
            {
                process.WaitForExit();
            }

            return process.ExitCode;
        }

        /// <summary>
        /// Start the process
        /// </summary>
        /// <param name="startInfo">process start info</param>
        /// <param name="waitForExit">whether or not to wait for process exit</param>
        public void Start(ProcessStartInfo startInfo, bool waitForExit)
        {
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            
            if (waitForExit)
            {
                process.WaitForExit();
            }
        }

        /// <summary>
        /// Start process
        /// </summary>
        /// <param name="filename">file name</param>
        public void Start(string filename)
        {
            if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(filename)).Length <= 0)
            {
                ProcessStartInfo info = new ProcessStartInfo(filename);
                Process process = new Process();
                process.StartInfo = info;
                process.Start();
            }
        }

        /// <summary>
        /// Start process
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="waitForExit">whether or not to wait for process exit</param>
        /// <param name="sleep">sleep time</param>
        public void Start(string filename, bool waitForExit, int sleep)
        {
            Process p = new Process();
            p.StartInfo.FileName = filename;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            if (waitForExit)
            {
                p.WaitForExit();
            }

            Thread.Sleep(sleep);
        }

        /// <summary>
        /// Start the process
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="arguments">process arguments</param>
        /// <param name="windowstyle">window style</param>
        /// <param name="createNoWindow">whether or not to create a window</param>
        public void Start(string filename, string arguments, ProcessWindowStyle windowstyle, bool createNoWindow)
        {
            Process p = new Process();

            p.StartInfo.FileName = filename;
            p.StartInfo.Arguments = "/p";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
        }
    }
}
