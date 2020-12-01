// <copyright file="WldbManagerPane.cs" company="NCR">
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
    /// Initializes a new instance of the WldbManagerPane class
    /// </summary>
    public partial class WldbManagerPane : BaseUserControl, IWldbManagerView
    {
        /// <summary>
        /// Weight learning database event
        /// </summary>
        private IWldbEvent _wldb;

        /// <summary>
        /// WLDB mode
        /// </summary>
        private string _mode;

        /// <summary>
        /// Initializes a new instance of the WldbManagerPane class
        /// </summary>
        public WldbManagerPane()
            : this(new WldbEvent())
        {
        }

        /// <summary>
        /// Initializes a new instance of the WldbManagerPane class
        /// </summary>
        /// <param name="wldb">weight learning database event</param>
        public WldbManagerPane(WldbEvent wldb)
        {
            InitializeComponent();
            SetTitle("WLDB Manager");
            Wldb = wldb;

            radioButtonUpdate.Checked = true;
        }

        /// <summary>
        /// Event handler for managing WLDB
        /// </summary>
        public event EventHandler<WldbEventArgs> Managing;

        /// <summary>
        /// Gets or sets the WLDB event
        /// </summary>
        public IWldbEvent Wldb
        {
            get
            {
                _wldb.WldbFile = textBoxWLDB.Text;
                _wldb.SAConfigFile = textBoxSAConfig.Text;
                _wldb.Host = textBoxRemoteServer.Text;
                _wldb.ScriptFileName = textBoxScriptFileName.Text;
                return _wldb;
            }

            set
            {
                _wldb = value;
                textBoxWLDB.Text = _wldb.WldbFile;
                textBoxSAConfig.Text = _wldb.SAConfigFile;
                textBoxRemoteServer.Text = _wldb.Host;
                textBoxScriptFileName.Text = _wldb.ScriptFileName;
            }
        }

        /// <summary>
        /// Clicking the manage button
        /// </summary>
        public void Manage()
        {
            ButtonManageClick(this, null);
        }

        /// <summary>
        /// Events for on managing
        /// </summary>
        /// <param name="e">WLDB event arguments</param>
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
            OnManaging(new WldbEventArgs(Wldb, _mode));
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
        /// Event for clicking the browse WLDB button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonBrowseWLDBClick(object sender, EventArgs e)
        {
            AssignFileToTextBox(textBoxWLDB, _mode);
        }

        /// <summary>
        /// Event for clicking the SA configuration button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonBrowseSAConfigClick(object sender, EventArgs e)
        {
            AssignFileToTextBox(textBoxSAConfig, _mode);
        }

        /// <summary>
        /// Assign file to text box
        /// </summary>
        /// <param name="textBox">text box</param>
        /// <param name="mode">wldb mode</param>
        private void AssignFileToTextBox(TextBox textBox, string mode)
        {
            if (mode == "UpdateWLDBFiles" || mode == "CreateUpdateScript")
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox.Text = openFileDialog1.FileName;
                }
            }
            else
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }

        /// <summary>
        /// Event for radio button update changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void RadioButtonUpdateCheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButtonMode = sender as RadioButton;
            if (radioButtonMode != null)
            {
                switch (radioButtonMode.Name)
                {
                    case "radioButtonUpdate":
                        buttonManage.Text = "Update";
                        _mode = "UpdateWLDBFiles";
                        textBoxScriptFileName.Enabled = false;
                        textBoxScriptFileName.Text = " ";
                        break;
                    case "radioButtonBackup":
                        buttonManage.Text = "Backup";
                        _mode = "BackupWLDBFiles";
                        textBoxScriptFileName.Enabled = false;
                        textBoxScriptFileName.Text = " ";
                        break;
                    case "radioButtonCreateUpdateWLDBScript":
                        buttonManage.Text = "Create";
                        _mode = "CreateUpdateScript";
                        textBoxScriptFileName.Enabled = true;
                        textBoxScriptFileName.Text = string.Empty;
                        break;
                    case "radioButtonCreateBackupWLDBScript":
                        buttonManage.Text = "Create";
                        _mode = "CreateBackupScript";
                        textBoxScriptFileName.Enabled = true;
                        textBoxScriptFileName.Text = string.Empty;
                        break;
                    default:
                        buttonManage.Text = "Select Mode";
                        _mode = string.Empty;
                        break;
                }
            }
        }
    }
}
