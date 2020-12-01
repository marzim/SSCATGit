// <copyright file="MainForm.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Sscat.Gui
{
    using System;
    using System.Collections;
    using System.Drawing;
    using System.Windows.Forms;
    using Ncr.Core.Gui;
    using Ncr.Core.Util;
    using Ncr.Core.Views;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the MainForm class
    /// </summary>
    public partial class MainForm : BaseForm, IWorkbench, IClientListView
    {
        /// <summary>
        /// Workbench layout
        /// </summary>
        private IWorkbenchLayout _layout;

        /// <summary>
        /// Workbench settings
        /// </summary>
        private WorkbenchSettings _settings = new WorkbenchSettings();

        /// <summary>
        /// List of Clients
        /// </summary>
        private Hashtable _clients = new Hashtable();

        /// <summary>
        /// Initializes a new instance of the MainForm class
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            SetTitle(ApplicationUtility.ProductNameAndVersion);
        }

        /// <summary>
        /// Delegate for the view event handler
        /// </summary>
        /// <param name="view">view interface</param>
        private delegate void ViewEventHandler(IView view);

        /// <summary>
        /// Event handler for saving the settings
        /// </summary>
        public event EventHandler<WorkbenchSettingsEventArgs> SettingsSave;

        /// <summary>
        /// Gets the clients
        /// </summary>
        public Hashtable Clients
        {
            get { return _clients; }
        }

        /// <summary>
        /// Gets or sets the workbench settings
        /// </summary>
        public WorkbenchSettings Settings
        {
            get
            {
                _settings.Size = string.Format("{0},{1}", Size.Width, Size.Height);
                _settings.Location = string.Format("{0},{1}", Bounds.Location.X, Bounds.Location.Y);
                return _settings;
            }

            set
            {
                _settings = value;
                string[] size = _settings.Size.Split(',');
                Size = new Size(int.Parse(size[0]), int.Parse(size[1]));
                string[] location = _settings.Location.Split(',');
                Location = new Point(int.Parse(location[0]), int.Parse(location[1]));
            }
        }

        /// <summary>
        /// Gets or sets the workbench layout
        /// </summary>
        public IWorkbenchLayout WorkbenchLayout
        {
            get
            {
                return _layout;
            }

            set
            {
                _layout = value;
                _layout.Workbench = this;
            }
        }

        /// <summary>
        /// Sets the MainMenu
        /// </summary>
        public MenuStrip MainMenu
        {
            set
            {
                this.MainMenuStrip = value;
                Controls.Add(value);
            }
        }

        /// <summary>
        /// Sets the tool bar control
        /// </summary>
        public Control ToolBar
        {
            set
            {
                Controls.Add(value);
            }
        }

        /// <summary>
        /// Sets the status bar control
        /// </summary>
        public Control StatusBar
        {
            set
            {
                Controls.Add(value);
            }
        }

        /// <summary>
        /// Show the given view
        /// </summary>
        /// <param name="view">view to show</param>
        public void ShowView(IView view)
        {
            if (InvokeRequired)
            {
                Invoke(new ViewEventHandler(ShowView), new object[] { view });
            }
            else
            {
                WorkbenchLayout.ShowView(view);
            }
        }

        /// <summary>
        /// Close all windows
        /// </summary>
        public void CloseAllWindows()
        {
            WorkbenchLayout.CloseAllWindows();
        }

        /// <summary>
        /// Close the active window
        /// </summary>
        public void CloseActiveWindow()
        {
            WorkbenchLayout.CloseActiveWindow();
        }

        /// <summary>
        /// Save the workbench settings
        /// </summary>
        /// <param name="settings">workbench settings</param>
        public void SaveSettings(WorkbenchSettings settings)
        {
            OnSettingsSave(new WorkbenchSettingsEventArgs(settings));
        }

        /// <summary>
        /// Event for when the settings are being saved
        /// </summary>
        /// <param name="e">workbench settings event arguments</param>
        protected virtual void OnSettingsSave(WorkbenchSettingsEventArgs e)
        {
            if (SettingsSave != null)
            {
                SettingsSave(this, e);
            }
        }

        /// <summary>
        /// Event for when the form is closing
        /// </summary>
        /// <param name="e">form closing event arguments</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveSettings(Settings);
            base.OnFormClosing(e);

            //// HACK: Research a good way to end the Client to prevent Sscat.Winforms to stay in the windows process after closing. Improve the stopping in EasyServer.
            LoggingService.Info("Client is now closing");
            ProcessUtility.Kill("Sscat.Winforms");
        }
    }
}
