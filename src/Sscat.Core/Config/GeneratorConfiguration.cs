// <copyright file="GeneratorConfiguration.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;
    using System.IO;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Ncr.Core.Net;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the GeneratorConfiguration class
    /// </summary>
    [XmlRoot("Configuration"), Serializable()]
    public class GeneratorConfiguration : BaseModel<GeneratorConfiguration>, IContent
    {
        /// <summary>
        /// The last script number
        /// </summary>
        private int _lastScriptsNumber;

        /// <summary>
        /// Whether or not to generate last
        /// </summary>
        private bool _generateLast;

        /// <summary>
        /// Whether or not to segment the scripts
        /// </summary>
        private bool _segmentedScripts;

        /// <summary>
        /// Whether or not UIValidation is enabled
        /// </summary>
        private bool _uiValidation;

        /// <summary>
        /// Whether or not to show the MS card editor
        /// </summary>
        private bool _dontShowMSCardEditor;

        /// <summary>
        /// Script name
        /// </summary>
        private string _scriptName;

        /// <summary>
        /// Script description
        /// </summary>
        private string _scriptDescription;
        
        /// <summary>
        /// Script output directory
        /// </summary>
        private string _scriptOutputDirectory;

        /// <summary>
        /// Logs output directory
        /// </summary>
        private string _logsOutputDirectory;

        /// <summary>
        /// Root directory
        /// </summary>
        private string _rootDirectory;

        /// <summary>
        /// SCOT configuration output directory
        /// </summary>
        private string _scotConfigOutputDirectory;

        /// <summary>
        /// Diagnostics path
        /// </summary>
        private string _diagPath;

        /// <summary>
        /// RAP name
        /// </summary>
        private string _rapName;

        /// <summary>
        /// Default MS card
        /// </summary>
        private string _defaultMSCard;

        /// <summary>
        /// SSCAT scripts
        /// </summary>
        private SSCATScripts _scripts;

        /// <summary>
        /// Configuration files
        /// </summary>
        private ConfigFiles _files;

        /// <summary>
        /// Whether or not to store mode keyboard should replace key in to automated login
        /// </summary>
        private bool _storeModeKeyboardAutomatedLogin;

        /// <summary>
        /// Initializes a new instance of the GeneratorConfiguration class
        /// </summary>
        public GeneratorConfiguration()
        {
            Files = new ConfigFiles();
        }

        /// <summary>
        /// Gets or sets the script output directory
        /// </summary>
        [XmlAttribute("ScriptOutputDirectory")]
        public string ScriptOutputDirectory
        {
            get { return _scriptOutputDirectory; }
            set { _scriptOutputDirectory = value; }
        }

        /// <summary>
        /// Gets or sets the script name
        /// </summary>
        [XmlAttribute("ScriptName")]
        public string ScriptName
        {
            get { return _scriptName; }
            set { _scriptName = value; }
        }

        /// <summary>
        /// Gets or sets the script description
        /// </summary>
        [XmlAttribute("ScriptDescription")]
        public string ScriptDescription
        {
            get { return _scriptDescription; }
            set { _scriptDescription = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to segment the scripts
        /// </summary>
        [XmlAttribute("SegmentedScripts")]
        public bool SegmentedScripts
        {
            get { return _segmentedScripts; }
            set { _segmentedScripts = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to store mode keyboard key in should be replaced with automated login
        /// </summary>
        [XmlAttribute("StoreModeKeyboardAutomatedLogin")]
        public bool StoreModeKeyboardAutomatedLogin
        {
            get { return _storeModeKeyboardAutomatedLogin; }
            set { _storeModeKeyboardAutomatedLogin = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether UIValidation events are enabled
        /// </summary>
        [XmlAttribute("UIValidation")]
        public bool UIValidation
        {
            get { return _uiValidation; }
            set { _uiValidation = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to generate last
        /// </summary>
        [XmlAttribute("GenerateLast")]
        public bool GenerateLast
        {
            get { return _generateLast; }
            set { _generateLast = value; }
        }

        /// <summary>
        /// Gets or sets the last scripts number
        /// </summary>
        [XmlAttribute("LastScriptsNumber")]
        public int LastScriptsNumber
        {
            get { return _lastScriptsNumber; }
            set { _lastScriptsNumber = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show the MS card editor
        /// </summary>
        [XmlAttribute("DontShowMSCardEditor")]
        public bool DontShowMSCardEditor
        {
            get { return _dontShowMSCardEditor; }
            set { _dontShowMSCardEditor = value; }
        }

        /// <summary>
        /// Gets or sets the default MS card
        /// </summary>
        [XmlAttribute("DefaultMSCard")]
        public string DefaultMSCard
        {
            get { return _defaultMSCard; }
            set { _defaultMSCard = value; }
        }

        /// <summary>
        /// Gets or sets the root directory
        /// </summary>
        [XmlAttribute("RootDirectory")]
        public string RootDirectory
        {
            get { return _rootDirectory; }
            set { _rootDirectory = value; }
        }

        /// <summary>
        /// Gets or sets the RAP name
        /// </summary>
        [XmlAttribute("RapName")]
        public string RapName
        {
            get { return _rapName; }
            set { _rapName = value; }
        }

        /// <summary>
        /// Gets or sets the logs output directory
        /// </summary>
        [XmlAttribute("LogsOutputDirectory")]
        public string LogsOutputDirectory
        {
            get { return _logsOutputDirectory; }
            set { _logsOutputDirectory = value; }
        }

        /// <summary>
        /// Gets or sets the SCOT configuration output directory
        /// </summary>
        [XmlAttribute("ScotConfigOutputDirectory")]
        public string ScotConfigOutputDirectory
        {
            get { return _scotConfigOutputDirectory; }
            set { _scotConfigOutputDirectory = value; }
        }

        /// <summary>
        /// Gets or sets the diagnostics path
        /// </summary>
        [XmlAttribute("DiagPath")]
        public string DiagPath
        {
            get { return _diagPath; }
            set { _diagPath = value; }
        }

        /// <summary>
        /// Gets or sets the configuration files
        /// </summary>
        [XmlElement("Files")]
        public ConfigFiles Files
        {
            get { return _files; }
            set { _files = value; }
        }

        /// <summary>
        /// Gets or sets the scripts
        /// </summary>
        [XmlElement("Scripts")]
        public SSCATScripts Scripts
        {
            get
            {
                if (_scripts == null)
                {
                    _scripts = new SSCATScripts();
                }

                return _scripts;
            }

            set
            {
                _scripts = value;
            }
        }

        /// <summary>
        /// Validates the generator configuration
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            AddErrorIf("Script name shouldn't be blank", ScriptName == null || ScriptName == string.Empty);
            AddErrorIf("Config files should not be null", Files == null);
            AddErrorIf("You've decided not to show the MS Card Editor Window so default MS Card should not be empty! Please select a value for the default MS Card to proceed with this operation.", this.DontShowMSCardEditor == true && this.DefaultMSCard.Trim().Equals(string.Empty));
            AddErrorIf(string.Format(@"{1}Script Name - {0}.xml {1}You may have used the same script name before and forgot to delete the corresponding {0} configuration folder where SSCAT saves all the important SSCO config files.{1}{1}Troubleshooting Tips : {1}Please delete/rename the folder or choose another script filename.", ScriptName, Environment.NewLine), Directory.Exists(_scriptOutputDirectory + "\\" + _scriptName));
        }
    }    
}
