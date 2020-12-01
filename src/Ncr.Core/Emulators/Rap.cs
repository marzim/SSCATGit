// <copyright file="Rap.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Emulators
{
    using System;
    using System.Diagnostics;
    using Ncr.Core.Util;

    /// <summary>
    /// RAP states
    /// </summary>
    public enum RapState
    {
        /// <summary>
        /// RAP state running
        /// </summary>
        Running,

        /// <summary>
        /// RAP state not running
        /// </summary>
        NotRunning
    }

    /// <summary>
    /// Initializes a new instance of the Rap class
    /// </summary>
    public class Rap : Emulator
    {
        /// <summary>
        /// Timeout amount
        /// </summary>
        private int _timeout;

        /// <summary>
        /// Whether or not the RAP has stopped
        /// </summary>
        private volatile bool _hasStopped;

        /// <summary>
        /// Initializes a new instance of the Rap class
        /// </summary>
        public Rap()
            : this(60000 * 3)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Rap class
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public Rap(int timeout)
            : base("UIControlWindowClass", Emulator.RapCaption)
        {
            _timeout = timeout;
        }

        /// <summary>
        /// Gets the file name
        /// </summary>
        public override string FileName
        {
            get { return @"C:\scot\bin\RapNet.exe"; }
        }

        /// <summary>
        /// Gets the process name
        /// </summary>
        public override string ProcessName
        {
            get { return "RapNet"; }
        }

        /// <summary>
        /// RAP has stopped
        /// </summary>
        public void Stop()
        {
            _hasStopped = true;
        }

        /// <summary>
        /// Get the RAP state
        /// </summary>
        /// <returns>Returns the RAP state</returns>
        public RapState GetState()
        {
            OnEmulating("Getting state of RAP");
            int now = Environment.TickCount;
            bool attractFound = false;
            while ((Environment.TickCount - now) < _timeout && !attractFound)
            {
                if (_hasStopped)
                {
                    break;
                }

                string query = ProcessUtility.GetStandardOutput(@"C:\scot\bin\SendSCOT.exe", "-raprunning");
                if (query.Contains("RAP is active") || query.Contains("RAPRunning"))
                {
                    attractFound = true;
                }

                ThreadHelper.Sleep(500);
            }

            return attractFound ? RapState.Running : RapState.NotRunning;
        }

        /// <summary>
        /// Starts the RAP
        /// </summary>
        public override void Start()
        {
            Start(false);
        }

        /// <summary>
        /// Starts the RAP
        /// </summary>
        /// <param name="throwOnException">Whether or not to throw on exception</param>
        public void Start(bool throwOnException)
        {
            _hasStopped = false;
            if (!ProcessUtility.HasStarted("LaunchpadNet"))
            {
                OnEmulating("Starting LaunchpadNet");
                ProcessUtility.Start(new ProcessStartInfo(@"C:\scot\bin\LaunchpadNet.exe"), false);
            }

            if (GetState() == RapState.Running)
            {
                OnEmulating("RAP ready");
            }
            else if (throwOnException)
            {
                throw new Exception("RAP is not ready");
            }
        }
    }
}
