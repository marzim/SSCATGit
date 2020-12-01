// <copyright file="LaneConfiguration.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Ncr.Core.Util;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.PsxDisplay;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Parsers;

    /// <summary>
    /// Initializes a new instance of the LaneConfiguration class
    /// </summary>
    [XmlRoot("Configuration")]
    public class LaneConfiguration : BaseModel<LaneConfiguration>
    {
        /// <summary>
        /// Lane configuration file name
        /// </summary>
        private string _fileName;

        /// <summary>
        /// Player configuration
        /// </summary>
        private PlayerConfiguration _playerConfig;

        /// <summary>
        /// Generator configuration
        /// </summary>
        private GeneratorConfiguration _generatorConfig;

        /// <summary>
        /// Configuration files
        /// </summary>
        private ConfigFiles _files;

        /// <summary>
        /// Lane parsers
        /// </summary>
        private LaneParsers _parsers;

        /// <summary>
        /// Lane hooks
        /// </summary>
        private LaneHooks _hooks;

        /// <summary>
        /// Back commands
        /// </summary>
        private BackCommands _backCommands;

        /// <summary>
        /// NXTUI Back commands
        /// </summary>
        private BackCommands _nxtuiBackCommands;

        /// <summary>
        /// PSX Display
        /// </summary>
        private PsxDisplay _display;

        /// <summary>
        /// Initializes a new instance of the LaneConfiguration class
        /// </summary>
        public LaneConfiguration()
            : this(string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the LaneConfiguration class
        /// </summary>
        /// <param name="file">configuration file</param>
        public LaneConfiguration(string file)
        {
            FileName = file;
        }

        /// <summary>
        /// Gets or sets the PSX display
        /// </summary>
        [XmlElement("Display")]
        public PsxDisplay Display
        {
            get { return _display; }
            set { _display = value; }
        }

        /// <summary>
        /// Gets or sets the ngui back commands
        /// </summary>
        [XmlElement("NXTUIBackCommands")]
        public BackCommands NXTUIBackCommands
        {
            get
            {
                if (_nxtuiBackCommands == null)
                {
                    _nxtuiBackCommands = new BackCommands();
                }

                return _nxtuiBackCommands;
            }

            set
            {
                _nxtuiBackCommands = value;
            }
        }

        /// <summary>
        /// Gets or sets the back commands
        /// </summary>
        [XmlElement("BackCommands")]
        public BackCommands BackCommands
        {
            get
            {
                if (_backCommands == null)
                {
                    _backCommands = new BackCommands();
                }

                return _backCommands;
            }

            set
            {
                _backCommands = value;
            }
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
        /// Gets or sets the generator configuration
        /// </summary>
        [XmlElement("Generator")]
        public GeneratorConfiguration GeneratorConfiguration
        {
            get { return _generatorConfig; }
            set { _generatorConfig = value; }
        }

        /// <summary>
        /// Gets or sets the player configuration
        /// </summary>
        [XmlElement("Player")]
        public PlayerConfiguration PlayerConfiguration
        {
            get { return _playerConfig; }
            set { _playerConfig = value; }
        }

        /// <summary>
        /// Gets or sets the file name
        /// </summary>
        [XmlIgnoreAttribute]
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>
        /// Gets or sets the lane parsers
        /// </summary>
        [XmlElement("Parsers")]
        public LaneParsers Parsers
        {
            get { return _parsers; }
            set { _parsers = value; }
        }

        /// <summary>
        /// Gets or sets the lane hooks
        /// </summary>
        [XmlElement("Hooks")]
        public LaneHooks Hooks
        {
            get { return _hooks; }
            set { _hooks = value; }
        }

        /// <summary>
        /// Creates back commands
        /// </summary>
        /// <returns>Returns commands</returns>
        public IDictionary<string, LaneCommand> CreateBackCommands()
        {
            IDictionary<string, LaneCommand> commands = new Dictionary<string, LaneCommand>();
            foreach (BackCommand cmd in BackCommands.Commands)
            {
                if (cmd.HasAction)
                {
                    commands.Add(cmd.Context, cmd.InstantiateAction());
                }
                else
                {
                    commands.Add(cmd.Context, new LaneClickCommand(cmd.Control, cmd.Param));
                }
            }

            return commands;
        }

#if NET40
        /// <summary>
        /// Creates ngui back commands
        /// </summary>
        /// <returns>Returns commands</returns>
        public IDictionary<string, LaneCommand> NXTUICreateBackCommands()
        {
            IDictionary<string, LaneCommand> commands = new Dictionary<string, LaneCommand>();
            foreach (BackCommand cmd in NXTUIBackCommands.Commands)
            {
                if (cmd.HasAction)
                {
                    commands.Add(cmd.Context, cmd.InstantiateAction());
                }
                else
                {
                    commands.Add(cmd.Context, new NXTUIClickCommand(cmd.Control, cmd.Context, cmd.Param));
                }
            }

            return commands;
        }
#endif

        /// <summary>
        /// Gets the parsers
        /// </summary>
        /// <param name="isGenerateFromDiag">if it's script generation from a diag</param>
        /// <returns>Returns the parser</returns>
        public List<IParser> GetParsers(bool isGenerateFromDiag)
        {
            string sourcefile = string.Empty;
            string destination = string.Empty;
            string dumpProductVersion = string.Empty;

            if (isGenerateFromDiag)
            {
                ExtractFilesFromDiag(ref sourcefile, ref destination, ref dumpProductVersion);
            }

            List<IParser> pp = new List<IParser>();
            foreach (LaneParser parser in Parsers.Parsers)
            {
                IExtendedTextReader reader;

                if (isGenerateFromDiag)
                {
                    string file = parser.File;
                    if (IsParserFileValid(sourcefile, destination, dumpProductVersion, ref file, parser.Name))
                    {
                        parser.File = file;
                        LoggingService.Info(parser.File);
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (parser.HasCondition && !parser.InstantiateCondition(@"c:\scot\logs\").Check(parser.GetFileName()))
                {
                    continue;
                }

                if (parser.IsBinary)
                {
                    pp.Add(parser.InstantiateBinary(new FileStream(parser.File, FileMode.Open)));
                }
                else
                {
                    if (parser.HasFile)
                    {
                        reader = new ExtendedStreamReader(new FileStream(parser.GetFileName(isGenerateFromDiag), FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                    }
                    else
                    {
                        reader = new ExtendedStringReader(parser.Text);
                    }

                    pp.Add(parser.Instantiate(reader));
                }
            }

            return pp;
        }

        /// <summary>
        /// Gets the hooks
        /// </summary>
        /// <returns>Returns the hooks</returns>
        public Dictionary<string, IScotLogHook> GetHooks()
        {
            Dictionary<string, IScotLogHook> hh = new Dictionary<string, IScotLogHook>();
            foreach (LaneHook hook in Hooks.Hooks)
            {
                LoggingService.Info(string.Format("Getting Hooks {0} in {1}. HasFile? {2}", hook.Name, hook.File, hook.HasFile.ToString()));
                if (hook.HasFile)
                {
                    if (FileHelper.Exists(hook.GetFileName()))
                    {
                        hh.Add(hook.Name, new ScotLogHook(hook.GetFileName(), _parsers.GetParser(hook.Parser).Instantiate()));
                    }
                    else
                    {
                        LoggingService.Info(string.Format("{0} does not exist.", hook.GetFileName()));
                    }
                }
                else
                {
                    hh.Add(hook.Name, new ScotLogHook(new TextWatcher(hook.Text), _parsers.GetParser(hook.Parser).Instantiate()));
                }
            }

            return hh;
        }

        /// <summary>
        /// Extract Files From Diag
        /// </summary>
        /// <param name="sourcefile">the source file</param>
        /// <param name="destination">the destination file</param>
        /// <param name="dumpProductVersion">the dump product version</param>
        private void ExtractFilesFromDiag(ref string sourcefile, ref string destination, ref string dumpProductVersion)
        {
            if (!FileHelper.Exists(_generatorConfig.DiagPath))
            {
                throw new FileNotFoundException(string.Format("File {0} not found", _generatorConfig.DiagPath));
            }

            sourcefile = _generatorConfig.DiagPath;
            destination = string.Format(@"{0}\GenerateFromDiag_{1}", ApplicationUtility.DiagsDirectory, DateTime.Now.ToString("MMdd-hhmmss"));
            _files.SourceDirectory = destination;
                        
            LoggingService.Info("Extracting NCR Regristry dump");
            ZipHelper.Extract(sourcefile, destination, string.Empty, "NCRRegDump.txt");
            string ncrRegDumpFile = string.Format(@"{0}\NCRRegDump.txt", destination);
            LoggingService.Info("Extracted NCR Registry dump location: {0}", ncrRegDumpFile);

            FileHelper.SetDumpProductVersion(ncrRegDumpFile);
            dumpProductVersion = FileHelper.GetDumpProductVersion();
            LoggingService.Info("Diag file Product Version: {0}", dumpProductVersion);
            
            if ((dumpProductVersion == "6.0.1") || (dumpProductVersion == "6.0.2"))
            {
                throw new Exception("ADK 6.0.1 and ADK 6.0.2 is not supported by SSCAT. This is due to NGUI logs that are needed for automation are not available on those versions.");
            }

            foreach (ConfigFile f in Files.Files)
            {
                ZipHelper.Extract(sourcefile, destination, string.Empty, Path.GetFileName(f.Name));
            }
        }

        /// <summary>
        /// Check if Parser File is Valid
        /// </summary>
        /// <param name="sourcefile">the source file</param>
        /// <param name="destination">the destination file</param>
        /// <param name="dumpProductVersion">the dump product version</param>
        /// <param name="parserFile">parser's FileName</param>
        /// <param name="parserName">parser's Name</param>
        /// <returns>returns true if Parser File is valid</returns>
        private bool IsParserFileValid(string sourcefile, string destination, string dumpProductVersion, ref string parserFile, string parserName)
        {
            string s = Path.Combine(destination, Path.GetFileName(parserFile));
            string file = ZipHelper.Extract(sourcefile, destination, string.Empty, Path.GetFileName(s), parserName);

            if (SSCOHelper.IsNGUI(dumpProductVersion) && (parserName == "Psx"))
            {
                // TODO: Improved to support ADK 6.0.3 higher
                LoggingService.Info("Diag file is ADK 6.0.3, will not parse PSX events");
                return false;
            }

            if (FileHelper.Exists(file))
            {
                parserFile = file;
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
