// <copyright file="CustomGeneratorPane.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Gui
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using Ncr.Core.Gui;
    using Ncr.Core.Util;
    using Sscat.Core.Config;
    using Sscat.Core.Repositories.Xml;
    using Sscat.Core.Util;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the CustomGeneratorPane class
    /// </summary>
    public partial class CustomGeneratorPane : BaseUserControl, ICustomGeneratorView
    {
        /// <summary>
        /// Generator configuration
        /// </summary>
        private GeneratorConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the CustomGeneratorPane class
        /// </summary>
        public CustomGeneratorPane()
        {
            InitializeComponent();
            SetTitle("Custom Script Generator");
            _config = new GeneratorConfiguration();
            _config.ScriptOutputDirectory = @"c:\sscat\scripts";

            // Display current default MS Card
            XmlLaneConfigurationRepository configFileReader = new XmlLaneConfigurationRepository();
            LaneConfiguration configFile = configFileReader.Read(ApplicationUtility.LaneConfigurationFileName);

            if (configFile.GeneratorConfiguration.DefaultMSCard == null ||
                configFile.GeneratorConfiguration.DefaultMSCard.Trim().Equals(string.Empty))
            {
                this.textBoxDefaultMSCard.Text = Constants.MSCard.NAME_OF_DEFAULT_MS_CARD;
            }
            else
            {
                this.textBoxDefaultMSCard.Text = configFile.GeneratorConfiguration.DefaultMSCard.Trim();
            }

            // Display previous setting for showing of Default MS Card Editor Window
            if (configFile.GeneratorConfiguration.DontShowMSCardEditor == false)
            {
                this.chkBoxDontShowMSCardEditor.Checked = false;
            }
            else
            {
                this.chkBoxDontShowMSCardEditor.Checked = true;
            }

            // Display previous setting of attract-to-attract testing and last run scripts
            checkBoxSegmented.Checked = configFile.GeneratorConfiguration.SegmentedScripts;
            checkBoxLastScripts.Checked = configFile.GeneratorConfiguration.GenerateLast;
            numericUpDownLastScripts.Value = (configFile.GeneratorConfiguration.LastScriptsNumber == 0) ?
                                             1 :
                                             Convert.ToDecimal(configFile.GeneratorConfiguration.LastScriptsNumber);
        }

        /// <summary>
        /// Delegate for set configuration event handler
        /// </summary>
        /// <param name="config">generator configuration</param>
        private delegate void SetConfigurationEventHandler(GeneratorConfiguration config);

        /// <summary>
        /// Event handler for custom generate
        /// </summary>
        public event EventHandler<GeneratorConfigurationEventArgs> CustomGenerate;

        /// <summary>
        /// Gets or sets the generator configuration
        /// </summary>
        public GeneratorConfiguration Configuration
        {
            get
            {
                _config.ScriptName = textBoxScriptName.Text;
                _config.ScriptDescription = textBoxScriptDescription.Text;
                _config.DiagPath = textBoxDiagPath.Text;
                _config.SegmentedScripts = checkBoxSegmented.Checked;
                _config.GenerateLast = checkBoxLastScripts.Checked;
                _config.LastScriptsNumber = Convert.ToInt32(numericUpDownLastScripts.Value);
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
        /// Gets the output view
        /// </summary>
        public IOutputView OutputView
        {
            get { return outputPane1; }
        }

        /// <summary>
        /// Writes the text to the output view
        /// </summary>
        /// <param name="text">text to write</param>
        public void WriteLine(string text)
        {
            OutputView.WriteLine(text);
        }

        /// <summary>
        /// Event for on custom generating
        /// </summary>
        /// <param name="e">generator configuration event arguments</param>
        protected virtual void OnCustomGenerating(GeneratorConfigurationEventArgs e)
        {
            if (CustomGenerate != null)
            {
                CustomGenerate(this, e);
            }
        }

        /// <summary>
        /// Set configuration
        /// </summary>
        /// <param name="config">generator configuration</param>
        private void SetConfiguration(GeneratorConfiguration config)
        {
            if (InvokeRequired)
            {
                Invoke(new SetConfigurationEventHandler(SetConfiguration), new object[] { config });
            }
            else
            {
                textBoxScriptName.Text = config.ScriptName;
                textBoxScriptDescription.Text = config.ScriptDescription;
                textBoxDiagPath.Text = config.DiagPath;
                checkBoxSegmented.Checked = config.SegmentedScripts;
                checkBoxLastScripts.Checked = config.GenerateLast;
                numericUpDownLastScripts.Value = config.LastScriptsNumber;
                chkBoxDontShowMSCardEditor.Checked = config.DontShowMSCardEditor;
                textBoxDefaultMSCard.Text = config.DefaultMSCard;
            }
        }

        /// <summary>
        /// Event for click generate button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonGenerateClick(object sender, EventArgs e)
        {
            // PRECONDITION 1: A script name should have been provided
            if (textBoxScriptName.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("You have not provided a valid script name! Please type the script name before proceeding with this operation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // PRECONDITION 2: The location of the diagnostic file 
            // should have been provided
            if (textBoxDiagPath.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("You have not provided a valid location for the diagnostic file! Please indicate where the diag is located before proceeding with this operation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // PROCESS 1: Generation will start so disable the generate
            // script & close button
            buttonGenerateScript.Enabled = false;
            buttonClose.Enabled = false;
            grpBoxCustomGenerateSettings.Enabled = false;
            grpBoxScriptAndDiagDetails.Enabled = false;

            // PROCESS 2: Raise event to start generating the scripts
            try
            {
                OnCustomGenerating(new GeneratorConfigurationEventArgs(Configuration));
            }
            catch (FileNotFoundException ex)
            {
                this.WriteLine(string.Format("File {0} not found in {1}", Path.GetFileNameWithoutExtension(ex.FileName), this.textBoxDiagPath.Text));
                MessageBox.Show(string.Format("File {0} not found in {1}", Path.GetFileNameWithoutExtension(ex.FileName), this.textBoxDiagPath.Text), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                this.WriteLine(string.Format("{0}: {1}", DateTimeUtility.Now(), ex.Message));
                LoggingService.Error(ex.ToString());
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                buttonGenerateScript.Enabled = true;
                buttonClose.Enabled = true;
                grpBoxCustomGenerateSettings.Enabled = true;
                grpBoxScriptAndDiagDetails.Enabled = true;
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
        /// Event for clicking the browse diagnostics button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void BrowseDiagClick(object sender, EventArgs e)
        {
            AssignFileToTextBox(textBoxDiagPath);
        }

        /// <summary>
        /// Assign file to text box
        /// </summary>
        /// <param name="textBox">text box</param>
        private void AssignFileToTextBox(TextBox textBox)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Event for clicking the edit default MS card button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonEditDefaultMSCardClick(object sender, EventArgs e)
        {
            // PROCESS 1: Read the local config file to get list of MS Cards
            XmlLaneConfigurationRepository configFileReader = new XmlLaneConfigurationRepository();
            LaneConfiguration configFile = configFileReader.Read(ApplicationUtility.LaneConfigurationFileName);
            configFile.FileName = ApplicationUtility.LaneConfigurationFileName;

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
            // PROCESS 1: Enable "last run" transaction option 
            // only if user wants "attract-to-attract" script division
            if (checkBoxSegmented.Checked)
            {
                checkBoxLastScripts.Enabled = true;
            }
            else
            {
                checkBoxLastScripts.Checked = false;
                checkBoxLastScripts.Enabled = false;
            }

            // PROCESS 2: update config file with the change
            XmlLaneConfigurationRepository configFileReader = new XmlLaneConfigurationRepository();
            LaneConfiguration configFile = configFileReader.Read(ApplicationUtility.LaneConfigurationFileName);
            configFile.FileName = ApplicationUtility.LaneConfigurationFileName;
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
            // PROCESS 1: Enable the numeric box to allow user to 
            // indicate how many last transactions he wants
            if (checkBoxLastScripts.Checked)
            {
                numericUpDownLastScripts.Enabled = true;
            }
            else
            {
                numericUpDownLastScripts.Enabled = false;
                numericUpDownLastScripts.Value = 1;
            }

            // PROCESS 2: Update config file with the change
            XmlLaneConfigurationRepository configFileReader = new XmlLaneConfigurationRepository();
            LaneConfiguration configFile = configFileReader.Read(ApplicationUtility.LaneConfigurationFileName);
            configFile.FileName = ApplicationUtility.LaneConfigurationFileName;
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
            // PROCESS 1: update config file with the change
            XmlLaneConfigurationRepository configFileReader = new XmlLaneConfigurationRepository();
            LaneConfiguration configFile = configFileReader.Read(ApplicationUtility.LaneConfigurationFileName);
            configFile.FileName = ApplicationUtility.LaneConfigurationFileName;
            configFile.GeneratorConfiguration.DontShowMSCardEditor = chkBoxDontShowMSCardEditor.Checked;
            configFileReader.Save(configFile);
        }

        /// <summary>
        /// Event for changing the numeric up and down for last scripts
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void NumericUpDownLastScriptsValueChanged(object sender, EventArgs e)
        {
            // PROCESS 1: Update config file with the change
            XmlLaneConfigurationRepository configFileReader = new XmlLaneConfigurationRepository();
            LaneConfiguration configFile = configFileReader.Read(ApplicationUtility.LaneConfigurationFileName);
            configFile.FileName = ApplicationUtility.LaneConfigurationFileName;
            configFile.GeneratorConfiguration.LastScriptsNumber = (int)numericUpDownLastScripts.Value;
            configFileReader.Save(configFile);
        }
    }
}
