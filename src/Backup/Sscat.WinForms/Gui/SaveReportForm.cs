// <copyright file="SaveReportForm.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Gui
{
    using System;
    using System.Windows.Forms;
    using Ncr.Core.Util;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the SaveReportForm class
    /// </summary>
    public partial class SaveReportForm : Form
    {
        /// <summary>
        /// Save report information
        /// </summary>
        private SaveReport _saveReportInfo;

        /// <summary>
        /// Initializes a new instance of the SaveReportForm class
        /// </summary>
        /// <param name="saveReportInfo">save report info</param>
        public SaveReportForm(SaveReport saveReportInfo)
        {
            InitializeComponent();
            _saveReportInfo = saveReportInfo;
            buttonOk.Enabled = this.buttonOpenContainingFolder.Enabled = false;
        }

        /// <summary>
        /// Event handler for the report save
        /// </summary>
        public event EventHandler<SaveReportEventArgs> ReportSave;

        /// <summary>
        /// Gets the save report information
        /// </summary>
        public SaveReport SaveReportInfo
        {
            get
            {
                _saveReportInfo.ReportFilename = textBoxReportFilename.Text;
                _saveReportInfo.ReportOutputDirectory = textBoxReportOutputDirectory.Text;
                return _saveReportInfo;
            }
        }

        /// <summary>
        /// Click the ok button
        /// </summary>
        public void ClickButtonOK()
        {
            ButtonOkClick(this, null);
        }

        /// <summary>
        /// Click the open containing folder button
        /// </summary>
        public void ClickButtonOpenContainingFolder()
        {
            ButtonOpenContainingFolderClick(this, null);
        }

        /// <summary>
        /// Click the cancel button
        /// </summary>
        public void ClickButtonCancel()
        {
            ButtonCancelClick(this, null);
        }

        /// <summary>
        /// Event for save report
        /// </summary>
        /// <param name="e">save report event arguments</param>
        protected virtual void OnReportSave(SaveReportEventArgs e)
        {
            if (ReportSave != null)
            {
                ReportSave(this, e);
            }
        }

        /// <summary>
        /// Event for clicking the report output directory button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonReportOutputDirectoryClick(object sender, EventArgs e)
        {
            if (folderBrowserDialogReportOutputDirectory.ShowDialog() == DialogResult.OK)
            {
                textBoxReportOutputDirectory.Text = folderBrowserDialogReportOutputDirectory.SelectedPath;
            }
        }

        /// <summary>
        /// Event for clicking the ok button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonOkClick(object sender, EventArgs e)
        {
            SaveReportInfo.Validate();
            if (!SaveReportInfo.HasErrors)
            {
                OnReportSave(new SaveReportEventArgs(SaveReportInfo));
            }
            else
            {
                MessageService.ShowWarning(SaveReportInfo.Errors.ToString());
            }
        }

        /// <summary>
        /// Event for clicking the open containing folder button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonOpenContainingFolderClick(object sender, EventArgs e)
        {
            SaveReportInfo.Validate();
            if (!SaveReportInfo.HasErrors)
            {
                OnReportSave(new SaveReportEventArgs(SaveReportInfo));
                ProcessUtility.Start(SaveReportInfo.ReportOutputDirectory);
            }
            else
            {
                MessageService.ShowWarning(SaveReportInfo.Errors.ToString());
            }
        }

        /// <summary>
        /// Event for clicking the cancel button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Event for report file name text box changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void TextBoxReportFilenameTextChanged(object sender, EventArgs e)
        {
            if (textBoxReportFilename.Text != string.Empty)
            {
                buttonOk.Enabled = buttonOpenContainingFolder.Enabled = true;
            }
            else
            {
                buttonOk.Enabled = buttonOpenContainingFolder.Enabled = false;
            }
        }
    }
}
