// <copyright file="ApplicationLauncherPane.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Gui
{
    using System;
    using System.Windows.Forms;
    using Ncr.Core.Gui;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ApplicationLauncherPane class
    /// </summary>
    public partial class ApplicationLauncherPane : BaseUserControl, IApplicationLauncherView
    {
        /// <summary>
        /// Interface for the application launcher event
        /// </summary>
        private IApplicationLauncherEvent _applicationLauncher;

        /// <summary>
        /// Initializes a new instance of the ApplicationLauncherPane class
        /// </summary>
        public ApplicationLauncherPane()
            : this(new ApplicationLauncherEvent())
        {
        }

        /// <summary>
        /// Initializes a new instance of the ApplicationLauncherPane class
        /// </summary>
        /// <param name="applicationLauncher">application launcher</param>
        public ApplicationLauncherPane(ApplicationLauncherEvent applicationLauncher)
        {
            InitializeComponent();
            SetTitle("Application Launcher Manager");
            this.ApplicationLauncher = applicationLauncher;
        }

        /// <summary>
        /// Event handler for creating
        /// </summary>
        public event EventHandler<ApplicationLauncherEventArgs> Creating;

        /// <summary>
        /// Gets or sets the application launcher
        /// </summary>
        public IApplicationLauncherEvent ApplicationLauncher
        {
            get
            {
                _applicationLauncher.ScriptFileName = textBoxScriptFileName.Text;
                _applicationLauncher.Host = textBoxHostName.Text;
                _applicationLauncher.ApplicationPath = textBoxApplicationPath.Text;
                return _applicationLauncher;
            }

            set
            {
                _applicationLauncher = value;
                textBoxScriptFileName.Text = _applicationLauncher.ScriptFileName;
                textBoxHostName.Text = _applicationLauncher.Host;
                textBoxApplicationPath.Text = _applicationLauncher.ApplicationPath;
            }
        }

        /// <summary>
        /// Create the button
        /// </summary>
        public void Create()
        {
            ButtonCreateClick(this, null);
        }

        /// <summary>
        /// Event for on creating
        /// </summary>
        /// <param name="e">application launcher event arguments</param>
        protected virtual void OnCreating(ApplicationLauncherEventArgs e)
        {
            if (Creating != null)
            {
                Creating(this, e);
            }
        }

        /// <summary>
        /// Event for creating the button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonCreateClick(object sender, EventArgs e)
        {
            this.buttonClose.Enabled = this.buttonCreate.Enabled = false;
            OnCreating(new ApplicationLauncherEventArgs(ApplicationLauncher));
            this.buttonClose.Enabled = this.buttonCreate.Enabled = true;
        }

        /// <summary>
        /// Event for closing the button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonCloseClick(object sender, EventArgs e)
        {
            OnViewClose(null);
        }

        /// <summary>
        /// Event for button that browses application path
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonBrowseApplicationPathClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxApplicationPath.Text = openFileDialog1.FileName;
            }
        }
    }
}
