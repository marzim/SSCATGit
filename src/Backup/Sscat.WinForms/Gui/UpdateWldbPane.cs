// <copyright file="UpdateWldbPane.cs" company="NCR">
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
    /// Initializes a new instance of the UpdateWldbPane class
    /// </summary>
    public partial class UpdateWldbPane : BaseUserControl, IWldbManagerView
    {
        /// <summary>
        /// Weight learning database event
        /// </summary>
        private IWldbEvent _wldb;

        /// <summary>
        /// Initializes a new instance of the UpdateWldbPane class
        /// </summary>
        public UpdateWldbPane()
            : this(new WldbEvent())
        {
        }

        /// <summary>
        /// Initializes a new instance of the UpdateWldbPane class
        /// </summary>
        /// <param name="wldb">weight learning database event</param>
        public UpdateWldbPane(WldbEvent wldb)
        {
            InitializeComponent();

            SetTitle("Update WLDB");
            Wldb = wldb;
        }

        /// <summary>
        /// Event handler for managing WLDB
        /// </summary>
        public event EventHandler<WldbEventArgs> Managing;

        /// <summary>
        /// Gets or sets the weight learning database event
        /// </summary>
        public IWldbEvent Wldb
        {
            get
            {
                _wldb.WldbFile = textBoxWLDB.Text;
                _wldb.SAConfigFile = textBoxSAConfig.Text;
                _wldb.Host = textBoxRemoteServer.Text;
                _wldb.ScriptFileName = " ";
                _wldb.User = textBoxServerUsername.Text;
                _wldb.Password = textBoxServerPasword.Text;
                return _wldb;
            }

            set
            {
                _wldb = value;
                textBoxWLDB.Text = _wldb.WldbFile;
                textBoxSAConfig.Text = _wldb.SAConfigFile;
                textBoxRemoteServer.Text = _wldb.Host;
                textBoxServerUsername.Text = _wldb.User;
                textBoxServerPasword.Text = _wldb.Password;
            }
        }

        /// <summary>
        /// Click the manage button
        /// </summary>
        public void Manage()
        {
            ButtonManageClick(this, null);
        }

        /// <summary>
        /// Event for on managing
        /// </summary>
        /// <param name="e">wldb event arguments</param>
        protected virtual void OnManaging(WldbEventArgs e)
        {
            if (Managing != null)
            {
                Managing(this, e);
            }
        }

        /// <summary>
        /// Event for clicking the manage button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonManageClick(object sender, EventArgs e)
        {
            try
            {
                buttonClose.Enabled = this.buttonManage.Enabled = false;
                OnManaging(new WldbEventArgs(Wldb, "UpdateWLDBFiles"));
            }
            catch
            {
            }
            finally
            {
                buttonClose.Enabled = this.buttonManage.Enabled = true;
            }
        }

        /// <summary>
        /// Event for clicking the close button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonCloseClick(object sender, EventArgs e)
        {
            OnViewClose(null);
        }

        /// <summary>
        /// Event for clicking the browse WLDB button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonBrowseWLDBClick(object sender, EventArgs e)
        {
            AssignFileToTextBoxWLDB(textBoxWLDB);
        }

        /// <summary>
        /// Event for clicking the browse security agents configuration button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonBrowseSAConfigClick(object sender, EventArgs e)
        {
            AssignFileToTextBoxSaConfig(textBoxSAConfig);
        }

        /// <summary>
        /// Assign file to WLDB text box
        /// </summary>
        /// <param name="textBox">text box</param>
        private void AssignFileToTextBoxWLDB(TextBox textBox)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Assign file to security agents configuration text box
        /// </summary>
        /// <param name="textBox">text box</param>
        private void AssignFileToTextBoxSaConfig(TextBox textBox)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = openFileDialog2.FileName;
            }
        }
    }
}