// <copyright file="LaneWorker.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Emulators
{
    using System.Diagnostics;
    using System.IO;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the LaneWorker class
    /// </summary>
    public class LaneWorker
    {
        /// <summary>
        /// Whether or not the lane worker is done
        /// </summary>
        private volatile bool _done;

        /// <summary>
        /// Whether or not the lane worker is NGUI
        /// </summary>
        private bool _isNGUI = false;

        /// <summary>
        /// Gets or sets a value indicating whether or not the lane is NGUI
        /// </summary>
        public bool IsNGUI
        {
            get { return _isNGUI; }
            set { _isNGUI = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the lane worker is done
        /// </summary>
        public bool Done
        {
            get { return _done; }
            set { _done = value; }
        }

        /// <summary>
        /// Force kill the process
        /// </summary>
        public void ForceKill()
        {
            ProcessUtility.Start(new ProcessStartInfo(Path.Combine(ApplicationUtility.ToolsDirectory, "stoplane.bat")), true);
            _done = true;
        }

        /// <summary>
        /// Stop the lane
        /// </summary>
        public void Stop()
        {
        }
    }
}
