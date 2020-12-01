// <copyright file="CpuAndMemoryLogger.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the CpuAndMemoryLogger class
    /// </summary>
    public class CpuAndMemoryLogger
    {
        /// <summary>
        /// Whether or not the CPU has stopped
        /// </summary>
        private bool _hasStopped;

        /// <summary>
        /// Sleep time
        /// </summary>
        private int _sleep;

        /// <summary>
        /// Interface for the logger
        /// </summary>
        private ILogger _logger;

        /// <summary>
        /// Process name
        /// </summary>
        private string _processName;

        /// <summary>
        /// System process
        /// </summary>
        private Process _process;

        /// <summary>
        /// Start memory
        /// </summary>
        private float _startMem;

        /// <summary>
        /// Initializes a new instance of the CpuAndMemoryLogger class
        /// </summary>
        /// <param name="sleep">sleep time</param>
        /// <param name="logger">logger interface</param>
        /// <param name="processName">process name</param>
        public CpuAndMemoryLogger(int sleep, ILogger logger, string processName)
        {
            _sleep = sleep;
            _logger = logger;
            _processName = processName;
        }

        /// <summary>
        /// Initializes a new instance of the CpuAndMemoryLogger class
        /// </summary>
        /// <param name="sleep">sleep time</param>
        /// <param name="logger">logger interface</param>
        /// <param name="process">system process</param>
        public CpuAndMemoryLogger(int sleep, ILogger logger, Process process)
        {
            _sleep = sleep;
            _logger = logger;
            _process = process;
        }

        /// <summary>
        /// Stop checking the CPU and memory
        /// </summary>
        public virtual void Stop()
        {
            _hasStopped = true;
        }

        /// <summary>
        /// Start checking the CPU and memory
        /// </summary>
        public virtual void Start()
        {
            try
            {
                _hasStopped = false;
                int i = 0;
                float mem = 0;
                while (!_hasStopped)
                {
                    try
                    {
                        Process p = SystemProcess();
                        if (p != null)
                        {
                            PerformanceCounter c = new PerformanceCounter("Process", "% Processor Time", p.ProcessName);
                            c.NextValue();
                            ThreadHelper.Sleep(1000);
                            mem = p.PrivateMemorySize64 / 1024;
                            CpuAndMemory cpuAndMemory = new CpuAndMemory(c.NextValue(), mem);
                            _logger.Info(cpuAndMemory.ToString());
                            if (i++ <= 0)
                            {
                                _startMem = mem;
                            }
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        LoggingService.Error(ex.ToString());
                    }
                    catch (IOException ex)
                    {
                        LoggingService.Error(ex.ToString());
                    }

                    ThreadHelper.Sleep(_sleep);
                }

                float percentage = ((mem - _startMem) / _startMem) * 100;
                _logger.Info(string.Format(",,{0}%", percentage));
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                MessageService.ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Gets the system process
        /// </summary>
        /// <returns>Returns the system process</returns>
        private Process SystemProcess()
        {
            if (_process != null)
            {
                return _process;
            }
            else
            {
                Process[] processes = ProcessUtility.GetProcessesByName(_processName);
                if (processes.Length > 0)
                {
                    return processes[0];
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
