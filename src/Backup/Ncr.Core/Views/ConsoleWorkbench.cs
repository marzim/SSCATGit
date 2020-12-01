// <copyright file="ConsoleWorkbench.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Views
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the ConsoleWorkbench class
    /// </summary>
    public class ConsoleWorkbench : IWorkbench
    {
        /// <summary>
        /// Workbench layout interface
        /// </summary>
        private IWorkbenchLayout _layout;

        /// <summary>
        /// Workbench settings
        /// </summary>
        private WorkbenchSettings _settings;

        /// <summary>
        /// Initializes a new instance of the ConsoleWorkbench class
        /// </summary>
        public ConsoleWorkbench()
        {
            Settings = new WorkbenchSettings();
        }

        /// <summary>
        /// Event handler for saving the settings
        /// </summary>
        public event EventHandler<WorkbenchSettingsEventArgs> SettingsSave;

        /// <summary>
        /// Gets or sets the settings
        /// </summary>
        public WorkbenchSettings Settings
        {
            get { return _settings; }
            set { _settings = value; }
        }

        /// <summary>
        /// Gets or sets the workbench layout
        /// </summary>
        public IWorkbenchLayout WorkbenchLayout
        {
            get { return _layout; }
            set { _layout = value; }
        }

        /// <summary>
        /// Sets the main menu
        /// </summary>
        public MenuStrip MainMenu
        {
            set
            {
            }
        }

        /// <summary>
        /// Sets the toolbar
        /// </summary>
        public Control ToolBar
        {
            set
            {
            }
        }

        /// <summary>
        /// Sets the status bar
        /// </summary>
        public Control StatusBar
        {
            set
            {
            }
        }

        /// <summary>
        /// Save the settings
        /// </summary>
        /// <param name="settings">workbench settings</param>
        public void SaveSettings(WorkbenchSettings settings)
        {
            OnSettingsSave(new WorkbenchSettingsEventArgs(settings));
        }

        /// <summary>
        /// Show view
        /// </summary>
        /// <param name="view">view interface</param>
        public virtual void ShowView(IView view)
        {
            view.ShowView();
        }

        /// <summary>
        /// Close all windows
        /// </summary>
        public void CloseAllWindows()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Close active window
        /// </summary>
        public void CloseActiveWindow()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event for saving settings
        /// </summary>
        /// <param name="e">workbench settings event arguments</param>
        protected virtual void OnSettingsSave(WorkbenchSettingsEventArgs e)
        {
            if (SettingsSave != null)
            {
                SettingsSave(this, e);
            }
        }
    }
}
