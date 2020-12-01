// <copyright file="ClientConfigurationPane.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Gui
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Ncr.Core.Gui;
    using Ncr.Core.Util;
    using Sscat.Core.Config;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ClientConfigurationPane class
    /// </summary>
    public partial class ClientConfigurationPane : BaseUserControl, IClientConfigurationView
    {
        /// <summary>
        /// Client configuration
        /// </summary>
        private ClientConfiguration _clientConfiguration;

        /// <summary>
        /// Initializes a new instance of the ClientConfigurationPane class
        /// </summary>
        public ClientConfigurationPane()
        {
            InitializeComponent();
            numericUpDownLogHookTimeout.Maximum = int.MaxValue;
            numericUpDownShots.Maximum = 5;
            numericUpDownScreenCaptureDelay.Maximum = 500;
            numericUpDownScreenCaptureIntervalDelay.Maximum = 500;
            Font f = this.Font;
            tabPage1.Font = tabPage2.Font = tabPage3.Font = tabPage4.Font = f;

            SetTitle("Client Configuration");

            TextBox[] textBoxes = new TextBox[] { textBoxDiagTempPath, textBoxScriptOutputDirectory, textBoxScotConfigOutputDirectory };
            Button[] buttons = new Button[] { buttonDiagTempPath, buttonScriptsOutputDirectory, buttonScotConfigOutputDirectory };

            for (int i = 0; i < buttons.Length; i++)
            {
                Button b = buttons[i];
                TextBox t = textBoxes[i];
                b.Click += delegate(object sender, EventArgs e)
                {
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        t.Text = folderBrowserDialog1.SelectedPath;
                    }
                };
            }

            CheckBoxOverrideSecurityServerCheckedChanged(this, null);
            CheckBoxOverrideRapNameCheckedChanged(this, null);
            CheckBoxUseSmartExitCheckedChanged(this, null);
            CheckBoxStopOnErrorCheckedChanged(this, null);
            SetControlState();
        }

        /// <summary>
        /// Event handler for configuration save
        /// </summary>
        public event EventHandler<ClientConfigurationEventArgs> ConfigurationSave;

        /// <summary>
        /// Event handler for configuration default restore
        /// </summary>
        public event EventHandler ConfigurationDefaultRestore;

        /// <summary>
        /// Event handler for configuration changed
        /// </summary>
        public event EventHandler<ClientConfigurationEventArgs> ConfigurationChanged;

        /// <summary>
        /// Gets or sets the client configuration
        /// </summary>
        public ClientConfiguration Configuration
        {
            get
            {
                _clientConfiguration.GeneratorConfiguration.ScriptOutputDirectory = textBoxScriptOutputDirectory.Text;
                _clientConfiguration.GeneratorConfiguration.ScotConfigOutputDirectory = textBoxScotConfigOutputDirectory.Text;
                _clientConfiguration.GeneratorConfiguration.RapName = textBoxOverrideRapName.Text;
                _clientConfiguration.PlayerConfiguration.LogHookTimeout = (int)numericUpDownLogHookTimeout.Value;
                _clientConfiguration.PlayerConfiguration.WarningTimeout = (int)numericUpDownWarningTimeout.Value;
                _clientConfiguration.PlayerConfiguration.PlaybackRepetition = (int)numericUpDownRepetition.Value;
                _clientConfiguration.PlayerConfiguration.ScreenCaptureDelay = (int)numericUpDownScreenCaptureDelay.Value;
                _clientConfiguration.PlayerConfiguration.ScreenCaptureShots = (int)numericUpDownShots.Value;
                _clientConfiguration.PlayerConfiguration.OverrideSecurityServer = checkBoxOverrideSecurityServer.Checked;
                _clientConfiguration.PlayerConfiguration.SecurityServer = textBoxSecurityServer.Text;
                _clientConfiguration.PlayerConfiguration.OverrideRapName = checkBoxOverrideRapName.Checked;
                _clientConfiguration.PlayerConfiguration.RapName = textBoxOverrideRapName.Text;
                _clientConfiguration.PlayerConfiguration.CaptureScreenShot = checkBoxCaptureScreenShot.Checked;
                _clientConfiguration.PlayerConfiguration.MultipleShots = checkBoxMultipleShots.Checked;
                _clientConfiguration.PlayerConfiguration.GetDiagsOnError = checkBoxGetDiagFilesOnError.Checked;
                _clientConfiguration.PlayerConfiguration.LoadConfiguration = checkBoxLoadConfiguration.Checked;
                _clientConfiguration.PlayerConfiguration.SimulateUserTime = checkBoxSimulateUserTime.Checked;
                _clientConfiguration.PlayerConfiguration.LockedScreenshot = checkBoxLockScreenshot.Checked;
                _clientConfiguration.PlayerConfiguration.DiagTempPath = textBoxDiagTempPath.Text;
                _clientConfiguration.PlayerConfiguration.StopOnError = checkBoxStopOnError.Checked;
                _clientConfiguration.PlayerConfiguration.UseSmartExit = checkBoxUseSmartExit.Checked;
                _clientConfiguration.PlayerConfiguration.OverrideLogin = checkBoxOverrideLogin.Checked;
                _clientConfiguration.PlayerConfiguration.LoginId = textBoxLoginId.Text;
                _clientConfiguration.PlayerConfiguration.Password = textBoxPassword.Text;
                _clientConfiguration.PlayerConfiguration.OperatorBarcode = textBoxOperatorBarcode.Text;
                _clientConfiguration.PlayerConfiguration.EnableSkipForgivableEvents = checkBoxSkipForgivableEvents.Checked;
                return _clientConfiguration;
            }

            set
            {
                _clientConfiguration = value;
                OnConfigurationChanged(new ClientConfigurationEventArgs(_clientConfiguration));

                textBoxScriptOutputDirectory.Text = _clientConfiguration.GeneratorConfiguration.ScriptOutputDirectory;
                textBoxScotConfigOutputDirectory.Text = _clientConfiguration.GeneratorConfiguration.ScotConfigOutputDirectory;

                ConfigFilesFileChanged(this, null);

                numericUpDownLogHookTimeout.Value = ConvertUtility.Min(_clientConfiguration.PlayerConfiguration.LogHookTimeout, int.MaxValue);
                numericUpDownWarningTimeout.Value = ConvertUtility.Min(_clientConfiguration.PlayerConfiguration.WarningTimeout, int.MaxValue);
                numericUpDownRepetition.Value = ConvertUtility.Min(_clientConfiguration.PlayerConfiguration.PlaybackRepetition, 10000);
                numericUpDownScreenCaptureDelay.Value = ConvertUtility.Min(_clientConfiguration.PlayerConfiguration.ScreenCaptureDelay, int.MaxValue);
                numericUpDownScreenCaptureIntervalDelay.Value = ConvertUtility.Min(_clientConfiguration.PlayerConfiguration.ScreenCaptureIntervalDelay, int.MaxValue);
                numericUpDownShots.Value = ConvertUtility.Min(_clientConfiguration.PlayerConfiguration.ScreenCaptureShots, int.MaxValue);
                checkBoxOverrideSecurityServer.Checked = _clientConfiguration.PlayerConfiguration.OverrideSecurityServer;
                textBoxSecurityServer.Text = _clientConfiguration.PlayerConfiguration.SecurityServer;
                checkBoxOverrideRapName.Checked = _clientConfiguration.PlayerConfiguration.OverrideRapName;
                textBoxOverrideRapName.Text = _clientConfiguration.PlayerConfiguration.RapName;
                checkBoxCaptureScreenShot.Checked = _clientConfiguration.PlayerConfiguration.CaptureScreenShot;
                checkBoxMultipleShots.Checked = _clientConfiguration.PlayerConfiguration.MultipleShots;
                checkBoxGetDiagFilesOnError.Checked = _clientConfiguration.PlayerConfiguration.GetDiagsOnError;
                checkBoxLoadConfiguration.Checked = _clientConfiguration.PlayerConfiguration.LoadConfiguration;
                checkBoxSimulateUserTime.Checked = _clientConfiguration.PlayerConfiguration.SimulateUserTime;
                checkBoxLockScreenshot.Checked = _clientConfiguration.PlayerConfiguration.LockedScreenshot;
                textBoxDiagTempPath.Text = _clientConfiguration.PlayerConfiguration.DiagTempPath;
                checkBoxStopOnError.Checked = _clientConfiguration.PlayerConfiguration.StopOnError;
                checkBoxUseSmartExit.Checked = _clientConfiguration.PlayerConfiguration.UseSmartExit;
                checkBoxOverrideLogin.Checked = _clientConfiguration.PlayerConfiguration.OverrideLogin;
                textBoxLoginId.Text = _clientConfiguration.PlayerConfiguration.LoginId;
                textBoxPassword.Text = _clientConfiguration.PlayerConfiguration.Password;
                textBoxOperatorBarcode.Text = _clientConfiguration.PlayerConfiguration.OperatorBarcode;
                checkBoxSkipForgivableEvents.Checked = _clientConfiguration.PlayerConfiguration.EnableSkipForgivableEvents;
                UpdateMSRCardsList();
            }
        }

        /// <summary>
        /// Gets the selected configuration file
        /// </summary>
        public ConfigFile SelectedConfigFile
        {
            get
            {
                if (listViewConfigFiles.SelectedItems.Count > 0)
                {
                    return _clientConfiguration.Files.Files[listViewConfigFiles.SelectedItems[0].Index];
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the selected configuration files
        /// </summary>
        public List<ConfigFile> SelectedConfigFiles
        {
            get
            {
                List<ConfigFile> files = new List<ConfigFile>();
                foreach (ListViewItem li in listViewConfigFiles.SelectedItems)
                {
                    files.Add(_clientConfiguration.Files.Files[li.Index]);
                }

                return files;
            }
        }

        /// <summary>
        /// Gets the selected MSR card
        /// </summary>
        private MSRCard SelectedMSRCard
        {
            get
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    return _clientConfiguration.PlayerConfiguration.WalmartCards.Cards[listView1.SelectedItems[0].Index];
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the selected MSR cards
        /// </summary>
        private List<MSRCard> SelectedMSRCards
        {
            get
            {
                List<MSRCard> cards = new List<MSRCard>();
                foreach (ListViewItem li in listView1.SelectedItems)
                {
                    cards.Add(_clientConfiguration.PlayerConfiguration.WalmartCards.Cards[li.Index]);
                }

                return cards;
            }
        }

        /// <summary>
        /// Set control state
        /// </summary>
        public void SetControlState()
        {
#if NET40
            checkBoxOverrideLogin.Enabled = true;
            groupBox3.Enabled = true;
            textBoxLoginId.Enabled = true;
            textBoxPassword.Enabled = true;
            textBoxOperatorBarcode.Enabled = true;
#endif
        }

        /// <summary>
        /// Save the client configuration
        /// </summary>
        public void Save()
        {
            ToolStripButtonSaveClick(this, null);
        }

        /// <summary>
        /// Restore the default configuration
        /// </summary>
        public void Restore()
        {
            ToolStripButtonRestoreDefaultClick(this, null);
        }

        /// <summary>
        /// Event for on configuration changed
        /// </summary>
        /// <param name="e">client configuration event arguments</param>
        protected virtual void OnConfigurationChanged(ClientConfigurationEventArgs e)
        {
            if (ConfigurationChanged != null)
            {
                ConfigurationChanged(this, e);
            }
        }

        /// <summary>
        /// Event on configuration default restore
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnConfigurationDefaultRestore(EventArgs e)
        {
            if (ConfigurationDefaultRestore != null)
            {
                ConfigurationDefaultRestore(this, e);
            }
        }

        /// <summary>
        /// Event for on configuration save
        /// </summary>
        /// <param name="e">client configuration event arguments</param>
        protected virtual void OnConfigurationSave(ClientConfigurationEventArgs e)
        {
            if (ConfigurationSave != null)
            {
                ConfigurationSave(this, e);
            }
        }

        /// <summary>
        /// Update the MSR cards list
        /// </summary>
        private void UpdateMSRCardsList()
        {
            listView1.Items.Clear();
            foreach (MSRCard c in _clientConfiguration.PlayerConfiguration.WalmartCards.Cards)
            {
                ListViewItem li = listView1.Items.Add(c.Name);
                li.SubItems.Add(c.Track1);
                li.SubItems.Add(c.Track2);
                li.SubItems.Add(c.Track3);
            }
        }

        /// <summary>
        /// Event for configuration files changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ConfigFilesFileChanged(object sender, EventArgs e)
        {
            listViewConfigFiles.Items.Clear();
            foreach (ConfigFile f in _clientConfiguration.Files.Files)
            {
                ListViewItem li = listViewConfigFiles.Items.Add(f.Name);
                li.SubItems.Add(f.Host);
                li.SubItems.Add(f.Path);
            }
        }

        /// <summary>
        /// Event for configuration save
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ToolStripButtonSaveClick(object sender, EventArgs e)
        {
            OnConfigurationSave(new ClientConfigurationEventArgs(Configuration));
        }

        /// <summary>
        /// Event for clicking the add button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonAddClick(object sender, EventArgs e)
        {
            using (ConfigFileForm f = new ConfigFileForm())
            {
                f.ConfigSave += new EventHandler<ConfigFileEventArgs>(ConfigFileFormConfigSave);
                f.ShowDialog();
            }
        }

        /// <summary>
        /// Event for configuration file form configuration save
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">configuration file event arguments</param>
        private void ConfigFileFormConfigSave(object sender, ConfigFileEventArgs e)
        {
            _clientConfiguration.Files.AddFile(e.File);
            (sender as Form).Close();
            ConfigFilesFileChanged(this, null);
        }

        /// <summary>
        /// Event for clicking the edit button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonEditClick(object sender, EventArgs e)
        {
            if (SelectedConfigFile != null)
            {
                using (ConfigFileForm f = new ConfigFileForm(SelectedConfigFile))
                {
                    f.ConfigSave += delegate
                    {
                        f.Close();
                        ConfigFilesFileChanged(this, null);
                    };
                    f.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Event for clicking the delete button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            foreach (ConfigFile file in SelectedConfigFiles)
            {
                _clientConfiguration.Files.RemoveFile(file);
            }

            ConfigFilesFileChanged(this, null);
        }

        /// <summary>
        /// Event for clicking the player configuration button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event sender</param>
        private void ButtonPlayerConfigFileClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Event for clicking the restore default button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ToolStripButtonRestoreDefaultClick(object sender, EventArgs e)
        {
            OnConfigurationDefaultRestore(null);
        }

        /// <summary>
        /// Event for clicking the delete all button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonDeleteAllClick(object sender, EventArgs e)
        {
            _clientConfiguration.Files.Clear();
            ConfigFilesFileChanged(this, null);
        }

        /// <summary>
        /// Event for numeric up down repetition leave
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void NumericUpDownRepetitionLeave(object sender, EventArgs e)
        {
            if (numericUpDownRepetition.Text == string.Empty)
            {
                numericUpDownRepetition.Value = numericUpDownRepetition.Minimum;
                numericUpDownRepetition.Text = numericUpDownRepetition.Value.ToString();
            }
        }

        /// <summary>
        /// Event for checking the override security server check box
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void CheckBoxOverrideSecurityServerCheckedChanged(object sender, EventArgs e)
        {
            textBoxSecurityServer.Enabled = checkBoxOverrideSecurityServer.Checked;
        }

        /// <summary>
        /// Event for checking the override RAP name check box
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void CheckBoxOverrideRapNameCheckedChanged(object sender, EventArgs e)
        {
            textBoxOverrideRapName.Enabled = checkBoxOverrideRapName.Checked;
        }

        /// <summary>
        /// Event for clicking the add MSR card button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonAddMSRCardClick(object sender, EventArgs e)
        {
            using (MSRCardForm f = new MSRCardForm())
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    f.Card.Validate();
                    if (!f.Card.HasErrors && _clientConfiguration.PlayerConfiguration.WalmartCards.Contains(f.Card.Name) == false)
                    {
                        _clientConfiguration.PlayerConfiguration.WalmartCards.AddCard(f.Card);
                        UpdateMSRCardsList();
                    }
                    else
                    {
                        MessageService.ShowWarning(_clientConfiguration.PlayerConfiguration.WalmartCards.Errors.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Event for clicking the edit MSR card button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonEditMSRCardClick(object sender, EventArgs e)
        {
            if (SelectedMSRCard != null)
            {
                using (MSRCardForm f = new MSRCardForm(SelectedMSRCard))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        UpdateMSRCardsList();
                    }
                }
            }
        }

        /// <summary>
        /// Event for clicking the delete MSR card button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonDeleteMSRCardClick(object sender, EventArgs e)
        {
            foreach (MSRCard c in SelectedMSRCards)
            {
                _clientConfiguration.PlayerConfiguration.WalmartCards.RemoveCard(c);
            }

            UpdateMSRCardsList();
        }

        /// <summary>
        /// Event for clicking the delete all MSR card button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonDeleteAllMSRCardClick(object sender, EventArgs e)
        {
            _clientConfiguration.PlayerConfiguration.WalmartCards.Clear();
            UpdateMSRCardsList();
        }

        /// <summary>
        /// Event for checking the use smart exit check box
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void CheckBoxUseSmartExitCheckedChanged(object sender, EventArgs e)
        {
            checkBoxStopOnError.Checked = (checkBoxUseSmartExit.Checked && checkBoxStopOnError.Checked) ? false : checkBoxStopOnError.Checked;
        }

        /// <summary>
        /// Event for checking the use smart exit check box
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void CheckBoxCaptureScreenshotChanged(object sender, EventArgs e)
        {
            numericUpDownScreenCaptureDelay.Enabled = numericUpDownScreenCaptureIntervalDelay.Enabled = numericUpDownShots.Enabled = checkBoxCaptureScreenShot.Checked;
            checkBoxLockScreenshot.Enabled = checkBoxMultipleShots.Enabled = checkBoxCaptureScreenShot.Checked;
        }

        /// <summary>
        /// Event for checking the stop on error check box
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void CheckBoxStopOnErrorCheckedChanged(object sender, EventArgs e)
        {
            checkBoxUseSmartExit.Checked = (checkBoxStopOnError.Checked && checkBoxUseSmartExit.Checked) ? false : checkBoxUseSmartExit.Checked;
        }
    }
}
