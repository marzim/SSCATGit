// <copyright file="GeneratorPane.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Gui
{
    using System;
    using System.Windows.Forms;
    using Ncr.Core.Gui;
    using Ncr.Core.Util;
    using Sscat.Core.Config;
    using Sscat.Core.Repositories.Xml;
    using Sscat.Core.Util;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the GeneratorPane class
    /// </summary>
    public partial class GeneratorPane : BaseUserControl, IScriptGeneratorView
    {
        /// <summary>
        /// Generator configuration
        /// </summary>
        private GeneratorConfiguration _config;

        /// <summary>
        /// Server name
        /// </summary>
        private string _serverName;

        /// <summary>
        /// Initializes a new instance of the GeneratorPane class
        /// </summary>
        public GeneratorPane()
        {
            InitializeComponent();
            SetTitle("Script Generator");
            buttonStop.Enabled = false;
            buttonGenerateScript.Enabled = true;
            checkBoxSegmented.Enabled = true;
            checkBoxUIValidation.Enabled = true;

            Generate += new EventHandler<GeneratorConfigurationEventArgs>(GeneratorGenerating);
            Stopping += new EventHandler(GeneratorStopping);
            Disable += new EventHandler(GeneratorDisable);
        }

        /// <summary>
        /// Finalizes an instance of the GeneratorPane class
        /// </summary>
        ~GeneratorPane()
        {
            Generate -= new EventHandler<GeneratorConfigurationEventArgs>(GeneratorGenerating);
            Stopping -= new EventHandler(GeneratorStopping);
            Disable -= new EventHandler(GeneratorDisable);
        }

        /// <summary>
        /// Delegate for the set configuration event handler
        /// </summary>
        /// <param name="config">generator configuration</param>
        private delegate void SetConfigurationEventHandler(GeneratorConfiguration config);

        /// <summary>
        /// Event handler for generate
        /// </summary>
        public event EventHandler<GeneratorConfigurationEventArgs> Generate;

        /// <summary>
        /// Event handler for stop
        /// </summary>
        public event EventHandler Stop;

        /// <summary>
        /// Event handler for stopping
        /// </summary>
        public event EventHandler Stopping;

        /// <summary>
        /// Event handler for disable
        /// </summary>
        public event EventHandler Disable;

        /// <summary>
        /// Gets or sets the generator configuration
        /// </summary>
        public GeneratorConfiguration Configuration
        {
            get
            {
                _config.ScriptName = textBoxName.Text;
                _config.ScriptDescription = textBoxDescription.Text;
                _config.SegmentedScripts = checkBoxSegmented.Checked;
                _config.GenerateLast = checkBoxLastScripts.Checked;
                _config.UIValidation = checkBoxUIValidation.Checked;
                _config.LastScriptsNumber = (int)numericUpDownLastScripts.Value;
                _config.DontShowMSCardEditor = chkBoxDontShowMSCardEditor.Checked;
                _config.DefaultMSCard = textBoxDefaultMSCard.Text.Trim();
                return _config;
            }

            set
            {
                _config = value;
                SetConfiguration(_config);
            }
        }

        /// <summary>
        /// Reflect default settings at UI
        /// </summary>
        /// <param name="serverName">server name</param>
        public void ReflectDefaultSettingsAtUI(string serverName)
        {
            // PRECONDITION 1: Server name should not be empty or null
            if (serverName == null || serverName == string.Empty)
            {
                LoggingService.Error("GeneratorPane->ReflectDefaultSettingsAtUI(): " +
                                     "Operation failed due to server name passed is null/empty.");
                return;
            }

            // PROCESS 1: Save server name for future reference
            _serverName = serverName;

            // PROCESS 2: Reflect current default MS Card
            XmlClientConfigurationRepository configFileReader = new XmlClientConfigurationRepository();
            ClientConfiguration configFile = configFileReader.Read(ApplicationUtility.ClientConfigurationFileName(serverName));
            if (configFile.GeneratorConfiguration.DefaultMSCard == null ||
                configFile.GeneratorConfiguration.DefaultMSCard.Trim().Equals(string.Empty))
            {
                this.textBoxDefaultMSCard.Text = Constants.MSCard.NAME_OF_DEFAULT_MS_CARD;
            }
            else
            {
                this.textBoxDefaultMSCard.Text = configFile.GeneratorConfiguration.DefaultMSCard.Trim();
            }

            // PROCESS 3: Display previous setting for showing of Defaul MS Card Editor Window
            if (configFile.GeneratorConfiguration.DontShowMSCardEditor == false)
            {
                this.chkBoxDontShowMSCardEditor.Checked = false;
            }
            else
            {
                this.chkBoxDontShowMSCardEditor.Checked = true;
            }

            // PROCESS 4: Display previous setting of attract-to-attract testing and last run scripts
            checkBoxSegmented.Checked = configFile.GeneratorConfiguration.SegmentedScripts;
            checkBoxLastScripts.Checked = configFile.GeneratorConfiguration.GenerateLast;
            numericUpDownLastScripts.Value = (configFile.GeneratorConfiguration.LastScriptsNumber == 0) ?
                                             1 :
                                             Convert.ToDecimal(configFile.GeneratorConfiguration.LastScriptsNumber);

            LoggingService.Info(string.Format("GeneratorPane->ReflectDefaultSettingsAtUI(): Successfully reflected default script generation settings at Generation Pane for server: {0}.", serverName));
        }

        /// <summary>
        /// Perform the disable
        /// </summary>
        public void PerformDisable()
        {
            OnDisable(null);
        }

        /// <summary>
        /// Perform the stopping
        /// </summary>
        public void PerformStopping()
        {
            OnStopping(null);
        }

        /// <summary>
        /// Perform the stop
        /// </summary>
        public void PerformStop()
        {
            OnStop(null);
        }

        /// <summary>
        /// Perform the generate
        /// </summary>
        public void PerformGenerate()
        {
            ButtonGenerateScriptClick(this, null);
        }

        /// <summary>
        /// Perform the generating
        /// </summary>
        public void PerformGenerating()
        {
            OnGenerating(null);
        }

        /// <summary>
        /// Event for on stop
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnStop(EventArgs e)
        {
            if (Stop != null)
            {
                Stop(this, e);
            }
        }

        /// <summary>
        /// Event for on disable
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnDisable(EventArgs e)
        {
            if (Disable != null)
            {
                Disable(this, e);
            }
        }

        /// <summary>
        /// Event for on stopping
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnStopping(EventArgs e)
        {
            if (Stopping != null)
            {
                Stopping(this, e);
            }
        }

        /// <summary>
        /// Event for on generating
        /// </summary>
        /// <param name="e">generator configuration event arguments</param>
        protected virtual void OnGenerating(GeneratorConfigurationEventArgs e)
        {
            if (Generate != null)
            {
                Generate(this, e);
            }
        }

        /// <summary>
        /// Set generator configuration
        /// </summary>
        /// <param name="config">generator configuration</param>
        private void SetConfiguration(GeneratorConfiguration config)
        {
            if (InvokeRequired)
            {
                this.Invoke(new SetConfigurationEventHandler(SetConfiguration), new object[] { config });
            }
            else
            {
                textBoxName.Text = config.ScriptName;
                textBoxDescription.Text = config.ScriptDescription;
                checkBoxSegmented.Checked = config.SegmentedScripts;
                checkBoxUIValidation.Checked = config.UIValidation;
                checkBoxLastScripts.Checked = false;
                numericUpDownLastScripts.Value = 1;
            }
        }

        /// <summary>
        /// Event for on generator disable
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void GeneratorDisable(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EventHandler(GeneratorDisable), new object[] { sender, e });
            }
            else
            {
                groupBoxHowToGenerate.Enabled = false;
                groupBoxScriptDetails.Enabled = false;
                buttonGenerateScript.Enabled = false;
                buttonStop.Enabled = false;
            }
        }

        /// <summary>
        /// Event for on generator generating
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">generator configuration event arguments</param>
        private void GeneratorGenerating(object sender, GeneratorConfigurationEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<GeneratorConfigurationEventArgs>(GeneratorGenerating), new object[] { sender, e });
            }
            else
            {
                groupBoxHowToGenerate.Enabled = false;
                groupBoxScriptDetails.Enabled = false;
                buttonGenerateScript.Enabled = false;
                buttonStop.Enabled = true;
            }
        }
        
        /// <summary>
        /// Event for generator stopping
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void GeneratorStopping(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(Stopping), new object[] { sender, e });
            }
            else
            {
                groupBoxHowToGenerate.Enabled = true;
                groupBoxScriptDetails.Enabled = true;
                buttonGenerateScript.Enabled = true;
                buttonStop.Enabled = false;
            }
        }

        /// <summary>
        /// Event for clicking the generate script button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonGenerateScriptClick(object sender, EventArgs e)
        {
            // PRECONDITION 1: A script name should have been provided
            if (textBoxName.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("You have not provided a valid script name! Please type the script name before proceeding with this operation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OnGenerating(new GeneratorConfigurationEventArgs(Configuration));
        }

        /// <summary>
        /// Event for clicking the stop button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonStopClick(object sender, EventArgs e)
        {
            OnStop(e);
        }

        /// <summary>
        /// Event for clicking the extension button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonExtensionClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Event for clicking the edit default MS card button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonEditDefaultMSCardClick(object sender, EventArgs e)
        {
            CheckServerValidity();

            // PROCESS 1: Read the client-specific config file to get list of MS Cards
            XmlClientConfigurationRepository configFileReader = new XmlClientConfigurationRepository();
            ClientConfiguration configFile = configFileReader.Read(ApplicationUtility.ClientConfigurationFileName(_serverName));
            configFile.FileName = ApplicationUtility.ClientConfigurationFileName(_serverName);

            // PROCESS 2: Load the MS Card Selector form to let the user pick a new default card
            MSCardSelectionForm form = new MSCardSelectionForm(configFile);
            form.ShowDialog();

            // PROCESS 3: Reflect changes made to the selection at UI and config file
            if (form.HasCardSelectionChanged)
            {
                textBoxDefaultMSCard.Text = form.NameOfSelectedCard;
                configFile.GeneratorConfiguration.DefaultMSCard = form.NameOfSelectedCard;
                configFileReader.Save(configFile);
            }
        }

        /// <summary>
        /// Event for checking the segmented check box
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void CheckBoxSegmentedCheckedChanged(object sender, EventArgs e)
        {
            // PROCESS 1: Enable "last run" transaction option only if user wants "attract-to-attract" script division
            if (checkBoxSegmented.Checked)
            {
                checkBoxLastScripts.Enabled = true;
            }
            else
            {
                checkBoxLastScripts.Checked = false;
                checkBoxLastScripts.Enabled = false;
            }

            CheckServerValidity();

            // PROCESS 2: update config file with the change
            XmlClientConfigurationRepository configFileReader = new XmlClientConfigurationRepository();
            ClientConfiguration configFile = configFileReader.Read(ApplicationUtility.ClientConfigurationFileName(_serverName));
            configFile.FileName = ApplicationUtility.ClientConfigurationFileName(_serverName);
            configFile.GeneratorConfiguration.SegmentedScripts = checkBoxSegmented.Checked;
            configFile.GeneratorConfiguration.GenerateLast = checkBoxLastScripts.Checked;
            configFileReader.Save(configFile);
        }

        /// <summary>
        /// Event for checking the last scripts check box
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void CheckBoxLastScriptsCheckedChanged(object sender, EventArgs e)
        {
            // PROCESS 1: Enable the numeric box to allow user to indicate how many last transactions he wants
            if (checkBoxLastScripts.Checked)
            {
                numericUpDownLastScripts.Enabled = true;
            }
            else
            {
                numericUpDownLastScripts.Enabled = false;
                numericUpDownLastScripts.Value = 1;
            }

            CheckServerValidity();

            // PROCESS 2: update config file with the change
            XmlClientConfigurationRepository configFileReader = new XmlClientConfigurationRepository();
            ClientConfiguration configFile = configFileReader.Read(ApplicationUtility.ClientConfigurationFileName(_serverName));
            configFile.FileName = ApplicationUtility.ClientConfigurationFileName(_serverName);
            configFile.GeneratorConfiguration.GenerateLast = checkBoxLastScripts.Checked;
            configFile.GeneratorConfiguration.LastScriptsNumber = (int)numericUpDownLastScripts.Value;
            configFileReader.Save(configFile);
        }

        /// <summary>
        /// Event for checking the show MS card editor check box
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void CheckBoxShowMSCardEditorCheckedChanged(object sender, EventArgs e)
        {
            CheckServerValidity();

            // PROCESS 1: update config file with the change
            XmlClientConfigurationRepository configFileReader = new XmlClientConfigurationRepository();
            ClientConfiguration configFile = configFileReader.Read(ApplicationUtility.ClientConfigurationFileName(_serverName));
            configFile.FileName = ApplicationUtility.ClientConfigurationFileName(_serverName);
            configFile.GeneratorConfiguration.DontShowMSCardEditor = chkBoxDontShowMSCardEditor.Checked;
            configFileReader.Save(configFile);
        }
        
        /// <summary>
        /// Event for the numeric up and down value changed for last scripts
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void NumericUpDownLastScriptsValueChanged(object sender, EventArgs e)
        {
            // PRECONDITION 1: Server name should not be empty or null
            CheckServerValidity();

            // PROCESS 1: Update config file with the change
            XmlClientConfigurationRepository configFileReader = new XmlClientConfigurationRepository();
            ClientConfiguration configFile = configFileReader.Read(ApplicationUtility.ClientConfigurationFileName(_serverName));
            configFile.FileName = ApplicationUtility.ClientConfigurationFileName(_serverName);
            configFile.GeneratorConfiguration.LastScriptsNumber = (int)numericUpDownLastScripts.Value;
            configFileReader.Save(configFile);
        }

        /// <summary>
        /// Event for the UIValidation
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void CheckBoxUIValidationCheckedChanged(object sender, EventArgs e)
        {
            CheckServerValidity();

            // PROCESS 1: update config file with the change
            XmlClientConfigurationRepository configFileReader = new XmlClientConfigurationRepository();
            ClientConfiguration configFile = configFileReader.Read(ApplicationUtility.ClientConfigurationFileName(_serverName));
            configFile.FileName = ApplicationUtility.ClientConfigurationFileName(_serverName);
            configFile.GeneratorConfiguration.UIValidation = checkBoxUIValidation.Checked;
            configFileReader.Save(configFile);
        }

        /// <summary>
        /// Checks Server Validity
        /// </summary>
        private void CheckServerValidity()
        {
            // POST CONDITION 1: Server name should not be empty or null
            if (_serverName == null || _serverName == string.Empty)
            {
                MessageBox.Show("Operation failed due to server name is null/empty.", "Generator Pane Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggingService.Error("GeneratorPane->CheckBoxLastScriptsCheckedChanged(): Saving of changes made to the config file failed due to server name is null/empty.");
                return;
            }
        }
    }
}
