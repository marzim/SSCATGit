// <copyright file="UpdateWldbScriptPane.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Sscat.Gui
{
    using System;
    using System.Windows.Forms;
    using Ncr.Core.Gui;
    using Ncr.Core.Util;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Views;    

    /// <summary>
    /// Initializes a new instance of the UpdateWldbScriptPane class
    /// </summary>
    public partial class UpdateWldbScriptPane : BaseUserControl, IWldbManagerView
    {
        /// <summary>
        /// Weight learning database event
        /// </summary>
        private IWldbEvent _wldb;

        /// <summary>
        /// Initializes a new instance of the UpdateWldbScriptPane class
        /// </summary>
        public UpdateWldbScriptPane()
            : this(new WldbEvent())
        {
        }

        /// <summary>
        /// Initializes a new instance of the UpdateWldbScriptPane class
        /// </summary>
        /// <param name="wldb">weight learning database</param>
        public UpdateWldbScriptPane(WldbEvent wldb)
        {
            InitializeComponent();

            SetTitle("Create Update WLDB Script");
            Wldb = wldb;
        }

        /// <summary>
        /// Event handler for managing
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
                _wldb.ScriptFileName = textBoxScriptFilename.Text;
                _wldb.User = textBoxServerUsername.Text;
                _wldb.Password = CryptographyHelper.Encrypt(textBoxServerPasword.Text, textBoxServerUsername.Text);
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
                textBoxScriptFilename.Text = _wldb.ScriptFileName;
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
            buttonClose.Enabled = this.buttonManage.Enabled = false;
            OnManaging(new WldbEventArgs(Wldb, "CreateUpdateScript"));
            buttonClose.Enabled = this.buttonManage.Enabled = true;
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
        /// Event for clicking the browse weight learning database button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonBrowseWLDBClick(object sender, EventArgs e)
        {
            AssignFileToTextBoxWLDB(textBoxWLDB);
        }

        /// <summary>
        /// Event for clicking the browse security agent configuration button
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
        /// Assign file to SA configuration text box
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