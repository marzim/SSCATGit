// <copyright file="ServerForm.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Server.Gui
{
    using System;
    using System.Windows.Forms;
    using Ncr.Core;
    using Ncr.Core.Gui;
    using Ncr.Core.Net;
    using Ncr.Core.Util;
    using Ncr.Core.Views;
    using Sscat.Core.Models;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ServerForm class
    /// </summary>
    public partial class ServerForm : BaseForm, IServerView, IWorkbench
    {
        /// <summary>
        /// Interface for the server
        /// </summary>
        private IServer _server;

        /// <summary>
        /// Workbench settings
        /// </summary>
        private WorkbenchSettings _settings;

        /// <summary>
        /// Interface for the workbench layout
        /// </summary>
        private IWorkbenchLayout _layout;

        /// <summary>
        /// Server log
        /// </summary>
        private Log _log = new Log();

        /// <summary>
        /// Initializes a new instance of the ServerForm class
        /// </summary>
        public ServerForm()
        {
            InitializeComponent();
            SetTitle(ApplicationUtility.ProductNameAndVersion);

            ServerStart += new EventHandler(FormServerStart);
            ServerStop += new EventHandler(FormServerStop);
            _log.Changed += new EventHandler(LogChanged);
        }

        /// <summary>
        /// Event handler for server start
        /// </summary>
        public event EventHandler ServerStart;

        /// <summary>
        /// Event handler for server stop
        /// </summary>
        public event EventHandler ServerStop;

        /// <summary>
        /// Event handler for save settings
        /// </summary>
        public event EventHandler<WorkbenchSettingsEventArgs> SettingsSave;

        /// <summary>
        /// Gets or sets the server
        /// </summary>
        public IServer Server
        {
            get
            {
                return _server;
            }

            set
            {
                _server = value;
                _server.Serving += new EventHandler<NcrEventArgs>(ServerServing);
                _server.Starting += new EventHandler(ServerStarting);
                _server.Stopping += new EventHandler(ServerStopping);
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
        /// Gets or sets the workbench settings
        /// </summary>
        public WorkbenchSettings Settings
        {
            get { return _settings; }
            set { _settings = value; }
        }

        /// <summary>
        /// Sets the Main Menu
        /// </summary>
        public MenuStrip MainMenu
        {
            set
            {
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
        /// Clears the logs
        /// </summary>
        public void ClearLogs()
        {
            ToolStripButtonClearLogsClick(this, null);
        }

        /// <summary>
        /// Shows the view
        /// </summary>
        /// <param name="view">view interface</param>
        public void ShowView(IView view)
        {
            _layout.ShowView(view);
        }

        /// <summary>
        /// Saves the settings
        /// </summary>
        /// <param name="setings">workbench settings</param>
        public void SaveSettings(WorkbenchSettings setings)
        {
            OnSettingsSave(new WorkbenchSettingsEventArgs(_settings));
        }

        /// <summary>
        /// Event for on settings save
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
        /// Event for on server start
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnServerStart(EventArgs e)
        {
            if (ServerStart != null)
            {
                ServerStart(this, e);
            }
        }

        /// <summary>
        /// Event for on server stop
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnServerStop(EventArgs e)
        {
            if (ServerStop != null)
            {
                ServerStop(this, e);
            }
        }

        /// <summary>
        /// Event for on form closing
        /// </summary>
        /// <param name="e">form closing event arguments</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _server.Stop();
            _server.Serving -= new EventHandler<NcrEventArgs>(ServerServing);
            _server.Starting -= new EventHandler(ServerStarting);
            _server.Stopping -= new EventHandler(ServerStopping);
            _server.Dispose();

            base.OnFormClosing(e);

            // HACK: Research a good way to end the Server to prevent Sscat.Server to stay in the windows process after closing. Improve the stopping in EasyServer.
            LoggingService.Info("Server is now closing");
            ProcessUtility.Kill("Sscat.Server");
        }

        /// <summary>
        /// Event for server stopping
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ServerStopping(object sender, EventArgs e)
        {
            OnServerStop(e);
        }

        /// <summary>
        /// Event for server starting
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ServerStarting(object sender, EventArgs e)
        {
            OnServerStart(e);
        }

        /// <summary>
        /// Event for log changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void LogChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(LogChanged), new object[] { sender, e });
            }
            else
            {
                if (!this.IsDisposed && richTextBoxMessage != null && !richTextBoxMessage.IsDisposed)
                {
                    richTextBoxMessage.Text = _log.ToString();
                    richTextBoxMessage.SelectionStart = richTextBoxMessage.Text.Length;
                    richTextBoxMessage.ScrollToCaret();
                }
            }
        }

        /// <summary>
        /// Event for server serving
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ServerServing(object sender, NcrEventArgs e)
        {
            _log.AppendLog(string.Format("{0} {1}", DateTimeUtility.Now(), e.Message));
        }

        /// <summary>
        /// Event for form server stop
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void FormServerStop(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(FormServerStop), new object[] { sender, e });
            }
            else
            {
                if (!this.IsDisposed && panel1 != null && !panel1.IsDisposed)
                {
                    panel1.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Event for form server start
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void FormServerStart(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(FormServerStart), new object[] { sender, e });
            }
            else
            {
                if (!this.IsDisposed && panel1 != null && !panel1.IsDisposed)
                {
                    panel1.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Event for tool strip button clear logs click
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ToolStripButtonClearLogsClick(object sender, EventArgs e)
        {
            _log.Clear();
        }
    }
}
