// <copyright file="IWorkbench.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Views
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Workbench interface
    /// </summary>
    public interface IWorkbench
    {
        /// <summary>
        /// Event handler for save settings
        /// </summary>
        event EventHandler<WorkbenchSettingsEventArgs> SettingsSave;

        /// <summary>
        /// Gets or sets the workbench layout
        /// </summary>
        IWorkbenchLayout WorkbenchLayout { get; set; }

        /// <summary>
        /// Gets or sets the workbench settings
        /// </summary>
        WorkbenchSettings Settings { get; set; }

        /// <summary>
        /// Sets the main menu
        /// </summary>
        MenuStrip MainMenu { set; }

        /// <summary>
        /// Sets the tool bar
        /// </summary>
        Control ToolBar { set; }

        /// <summary>
        /// Sets the status bar
        /// </summary>
        Control StatusBar { set; }

        /// <summary>
        /// Show view
        /// </summary>
        /// <param name="view">view interface</param>
        void ShowView(IView view);

        /// <summary>
        /// Save settings
        /// </summary>
        /// <param name="setings">workbench settings</param>
        void SaveSettings(WorkbenchSettings setings);
    }
}
