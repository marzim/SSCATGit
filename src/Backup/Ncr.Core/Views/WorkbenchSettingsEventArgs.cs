// <copyright file="WorkbenchSettingsEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Views
{
    using System;

    /// <summary>
    /// Initializes a new instance of the WorkbenchSettingsEventArgs class
    /// </summary>
    public class WorkbenchSettingsEventArgs : EventArgs
    {
        /// <summary>
        /// Workbench settings
        /// </summary>
        private WorkbenchSettings _settings;

        /// <summary>
        /// Initializes a new instance of the WorkbenchSettingsEventArgs class
        /// </summary>
        /// <param name="settings">workbench settings</param>
        public WorkbenchSettingsEventArgs(WorkbenchSettings settings)
        {
            Settings = settings;
        }

        /// <summary>
        /// Gets or sets the workbench settings
        /// </summary>
        public WorkbenchSettings Settings
        {
            get { return _settings; }
            set { _settings = value; }
        }
    }
}
