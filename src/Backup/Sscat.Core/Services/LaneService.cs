// <copyright file="LaneService.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Services
{
    using System;
    using System.Collections.Generic;
    using Ncr.Core;
    using Ncr.Core.Models;
    using Ncr.Core.Util;
    using Sscat.Core.Config;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.PsxDisplay;
    using Sscat.Core.Models.Report;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Parsers;
    using Sscat.Core.Repositories;

    /// <summary>
    /// Initializes a new instance of the LaneService class
    /// </summary>
    public class LaneService
    {
        /// <summary>
        /// SSCAT lane
        /// </summary>
        private SscatLane _lane;

        /// <summary>
        /// Interface for the script repository
        /// </summary>
        private IScriptRepository _scriptRepository;

        /// <summary>
        /// Interface for the configuration file repository
        /// </summary>
        private IConfigFileRepository _configFileRepository;

        /// <summary>
        /// Interface for the configuration files repository
        /// </summary>
        private IConfigFilesRepository _configFilesRepository;

        /// <summary>
        /// Interface for the player configuration repository
        /// </summary>
        private IPlayerConfigurationRepository _playerConfigRepository;

        /// <summary>
        /// Interface for the generator configuration repository
        /// </summary>
        private IGeneratorConfigurationRepository _generatorConfigRepository;

        /// <summary>
        /// Interface for the report repository
        /// </summary>
        private IReportRepository _reportRepository;

        /// <summary>
        /// Interface for the lane configuration repository
        /// </summary>
        private ILaneConfigurationRepository _laneConfigRepository;

        /// <summary>
        /// Interface for the PSX display repository
        /// </summary>
        private IPsxDisplayRepository _psxDisplayRepository;
        
        /// <summary>
        /// SSCAT logger
        /// </summary>
        private CpuAndMemoryLogger _sscatLogger;

        /// <summary>
        /// SCOT logger
        /// </summary>
        private CpuAndMemoryLogger _scotLogger;

        /// <summary>
        /// Initializes a new instance of the LaneService class
        /// </summary>
        /// <param name="lane">sscat lane</param>
        /// <param name="scriptRepository">script repository</param>
        /// <param name="configFileRepository">configuration file repository</param>
        /// <param name="configFilesRepository">configuration files repository</param>
        /// <param name="playerConfigRepository">player configuration repository</param>
        /// <param name="generatorConfigRepository">generator configuration repository</param>
        /// <param name="laneConfigRepository">lane configuration repository</param>
        /// <param name="reportRepository">report repository</param>
        /// <param name="psxDisplayRepository">PSX display repository</param>
        /// <param name="sscatLogger">SSCAT logger</param>
        /// <param name="scotLogger">SCOT logger</param>
        public LaneService(SscatLane lane, IScriptRepository scriptRepository, IConfigFileRepository configFileRepository, IConfigFilesRepository configFilesRepository, IPlayerConfigurationRepository playerConfigRepository, IGeneratorConfigurationRepository generatorConfigRepository, ILaneConfigurationRepository laneConfigRepository, IReportRepository reportRepository, IPsxDisplayRepository psxDisplayRepository, CpuAndMemoryLogger sscatLogger, CpuAndMemoryLogger scotLogger)
        {
            Lane = lane;
            _scriptRepository = scriptRepository;
            _configFileRepository = configFileRepository;
            _configFilesRepository = configFilesRepository;
            _playerConfigRepository = playerConfigRepository;
            _generatorConfigRepository = generatorConfigRepository;
            _laneConfigRepository = laneConfigRepository;
            _reportRepository = reportRepository;
            _psxDisplayRepository = psxDisplayRepository;

            _sscatLogger = sscatLogger;
            _scotLogger = scotLogger;

            scriptRepository.Accessing += new EventHandler<NcrEventArgs>(RepositoryAccessing);
            reportRepository.Accessing += new EventHandler<NcrEventArgs>(RepositoryAccessing);
        }

        /// <summary>
        /// Finalizes an instance of the LaneService class
        /// </summary>
        ~LaneService()
        {
            _scriptRepository.Accessing -= new EventHandler<NcrEventArgs>(RepositoryAccessing);
            _reportRepository.Accessing -= new EventHandler<NcrEventArgs>(RepositoryAccessing);
        }

        /// <summary>
        /// Event handler for servicing
        /// </summary>
        public event EventHandler<NcrEventArgs> Servicing;

        /// <summary>
        /// Event handler for checking the configuration on the server
        /// </summary>
        public event EventHandler<ConfigFileEventArgs> CheckConfigOnServer;

        /// <summary>
        /// Event handler for loading the configuration on the server
        /// </summary>
        public event EventHandler<ConfigFileEventArgs> LoadConfigOnServer;

        /// <summary>
        /// Event handler for copying the configuration on the server
        /// </summary>
        public event EventHandler<ConfigFileEventArgs> CopyConfigOnServer;

        /// <summary>
        /// Gets or sets the SSCAT lane
        /// </summary>
        protected SscatLane Lane
        {
            get { return _lane; }
            set { _lane = value; }
        }

        /// <summary>
        /// Starts the SCOT logger
        /// </summary>
        public void StartScotLogger()
        {
            if (_scotLogger != null)
            {
                ThreadHelper.Start(_scotLogger.Start);
            }
        }

        /// <summary>
        /// Stops the SCOT logger
        /// </summary>
        public void StopScotLogger()
        {
            if (_scotLogger != null)
            {
                _scotLogger.Stop();
            }
        }

        /// <summary>
        /// Stars the SSCAT logger
        /// </summary>
        public void StartLogger()
        {
            if (_sscatLogger != null)
            {
                ThreadHelper.Start(_sscatLogger.Start);
            }
        }

        /// <summary>
        /// Stops the SSCAT logger
        /// </summary>
        public void StopLogger()
        {
            if (_sscatLogger != null)
            {
                _sscatLogger.Stop();
            }
        }

        /// <summary>
        /// Saves the report
        /// </summary>
        /// <param name="report">report to save</param>
        /// <param name="text">text to save</param>
        public void SaveReport(Report report, string text)
        {
            _reportRepository.Save(report, text);
        }

        /// <summary>
        /// Saves the report
        /// </summary>
        /// <param name="report">report to save</param>
        public void SaveReport(Report report)
        {
            _reportRepository.Save(report);
        }

        /// <summary>
        /// Reads the file
        /// </summary>
        /// <param name="filename">file to read</param>
        /// <returns>Returns the PSX display</returns>
        public PsxDisplay ReadPsxDisplay(string filename)
        {
            return _psxDisplayRepository.Read(filename);
        }

        /// <summary>
        /// Read the file
        /// </summary>
        /// <param name="filename">file to read</param>
        /// <returns>Return the lane configuration</returns>
        public LaneConfiguration ReadLaneConfiguration(string filename)
        {
            LaneConfiguration config = _laneConfigRepository.Read(filename);
            return config;
        }

        /// <summary>
        /// Read the file
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the player configuration</returns>
        public PlayerConfiguration ReadPlayerConfiguration(string filename)
        {
            return _playerConfigRepository.Read(filename);
        }

        /// <summary>
        /// Read the file
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the generator configuration</returns>
        public GeneratorConfiguration ReadGeneratorConfiguration(string filename)
        {
            return _generatorConfigRepository.Read(filename);
        }

        /// <summary>
        /// Creates the PSX wrapper
        /// </summary>
        /// <param name="host">host name</param>
        /// <param name="service">service name</param>
        /// <param name="name">psx wrapper name</param>
        /// <param name="timeout">timeout amount</param>
        /// <returns>Returns the psx wrapper</returns>
        public virtual IPsx CreatePsx(string host, string service, string name, int timeout)
        {
            return new PsxWrapper(host, service, name, timeout);
        }

        /// <summary>
        /// Read the configuration file
        /// </summary>
        /// <param name="configFile">configuration file</param>
        public void ReadConfigFile(ConfigFile configFile)
        {
            _configFileRepository.Read(configFile);
        }

        /// <summary>
        /// Read the configuration files
        /// </summary>
        /// <param name="name">directory name</param>
        /// <param name="configFiles">configuration files</param>
        public void ReadConfigFiles(string name, ConfigFiles configFiles)
        {
            _configFilesRepository.Read(name, configFiles);
        }

        /// <summary>
        /// Create SCOT log hooks
        /// </summary>
        /// <returns>Returns the hooks</returns>
        public virtual Dictionary<string, IScotLogHook> CreateHooks()
        {
            return Lane.Configuration.GetHooks();
        }

        /// <summary>
        /// Creates the parsers
        /// </summary>
        /// <returns>Returns the parsers</returns>
        public virtual List<IParser> CreateParsers()
        {
            if (Lane.Configuration.GeneratorConfiguration.DiagPath == null || Lane.Configuration.GeneratorConfiguration.DiagPath.Equals(string.Empty))
            {
                return Lane.Configuration.GetParsers(false);
            }
            else
            {
                Lane.Configuration.Files.SourceDirectory = _lane.Configuration.GeneratorConfiguration.DiagPath;
                return Lane.Configuration.GetParsers(true);
            }
        }

        /// <summary>
        /// Get scripts
        /// </summary>
        /// <param name="args">script arguments</param>
        /// <returns>Returns the script file</returns>
        public List<ScriptFile> GetScripts(string[] args)
        {
            int numberOfArguments = 2;
            return GetScripts(args, numberOfArguments);
        }

        /// <summary>
        /// Get scripts
        /// </summary>
        /// <param name="args">script arguments</param>
        /// <param name="length">length of arguments</param>
        /// <returns>Returns the script files</returns>
        public List<ScriptFile> GetScripts(string[] args, int length)
        {
            return _scriptRepository.GetScripts(args, length);
        }

        /// <summary>
        /// Reads the file and creates a script
        /// </summary>
        /// <param name="filename">file to read</param>
        /// <returns>Returns the script</returns>
        public IScript ReadScript(string filename)
        {
            return _scriptRepository.Read(filename);
        }

        /// <summary>
        /// Saves the scripts
        /// </summary>
        /// <param name="scripts">scripts to save</param>
        public void SaveScripts(IScript[] scripts)
        {
            _scriptRepository.Save(scripts);
        }

        /// <summary>
        /// Save configuration files
        /// </summary>
        /// <param name="files">files to save</param>
        public void SaveConfigFiles(ConfigFile[] files)
        {
            foreach (ConfigFile file in files)
            {
                _configFileRepository.Create(file);
            }
        }

        /// <summary>
        /// Get configuration
        /// </summary>
        /// <param name="files">configuration files</param>
        /// <param name="configName">configuration name</param>
        public void GetConfiguration(ConfigFiles files, string configName)
        {
            try
            {
                _configFilesRepository.Accessing += new EventHandler<NcrEventArgs>(RepositoryAccessing);
                _configFilesRepository.CopyConfigOnServer += new EventHandler<ConfigFileEventArgs>(ConfigFilesRepositoryCopyConfigOnServer);
                _configFilesRepository.Get(files, configName);
            }
            catch
            {
                throw;
            }
            finally
            {
                _configFilesRepository.Accessing -= new EventHandler<NcrEventArgs>(RepositoryAccessing);
                _configFilesRepository.CopyConfigOnServer -= new EventHandler<ConfigFileEventArgs>(ConfigFilesRepositoryCopyConfigOnServer);
            }
        }

        /// <summary>
        /// Load configuration
        /// </summary>
        /// <param name="files">configuration files</param>
        /// <param name="forceStop">whether or not a force stop is requested</param>
        public void LoadConfiguration(ConfigFiles files, bool forceStop)
        {
            try
            {
                _configFilesRepository.Accessing += new EventHandler<NcrEventArgs>(RepositoryAccessing);
                _configFilesRepository.CheckConfigOnServer += new EventHandler<ConfigFileEventArgs>(PlayerLaneCheckConfigOnServer);
                _configFilesRepository.LoadConfigOnServer += new EventHandler<ConfigFileEventArgs>(PlayerLaneLoadConfigOnServer);

                if (!files.None)
                {
                    if (forceStop)
                    {
                        Lane.ForceKill();
                        if (_configFilesRepository.DiffersFromScotConfig(files))
                        {
                            _configFilesRepository.Load(files);
                            Lane.Start(true);
                        }
                        else
                        {
                            Lane.Start();
                        }
                    }
                    else
                    {
                        if (_configFilesRepository.DiffersFromScotConfig(files))
                        {
                            Lane.ForceKill();
                            _configFilesRepository.Load(files);
                            Lane.Start();
                        }
                    }
                }
                else
                {
                    if (forceStop)
                    {
                        Lane.ForceKill();
                        Lane.Start();
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                _configFilesRepository.Accessing -= new EventHandler<NcrEventArgs>(RepositoryAccessing);
                _configFilesRepository.CheckConfigOnServer -= new EventHandler<ConfigFileEventArgs>(PlayerLaneCheckConfigOnServer);
                _configFilesRepository.LoadConfigOnServer -= new EventHandler<ConfigFileEventArgs>(PlayerLaneLoadConfigOnServer);
            }
        }

        /// <summary>
        /// Event for on copy configuration on server
        /// </summary>
        /// <param name="e">configuration file event arguments</param>
        protected virtual void OnCopyConfigOnServer(ConfigFileEventArgs e)
        {
            if (CopyConfigOnServer != null)
            {
                CopyConfigOnServer(this, e);
            }
        }

        /// <summary>
        /// Event on servicing
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnServicing(NcrEventArgs e)
        {
            if (Servicing != null)
            {
                Servicing(this, e);
            }
        }

        /// <summary>
        /// Event for on loading configuration on server
        /// </summary>
        /// <param name="e">configuration file event arguments</param>
        protected virtual void OnLoadConfigOnServer(ConfigFileEventArgs e)
        {
            if (LoadConfigOnServer != null)
            {
                LoadConfigOnServer(this, e);
            }
        }

        /// <summary>
        /// Event for on checking configuration on server
        /// </summary>
        /// <param name="e">configuration file event arguments</param>
        protected virtual void OnCheckConfigOnServer(ConfigFileEventArgs e)
        {
            if (CheckConfigOnServer != null)
            {
                CheckConfigOnServer(this, e);
            }
        }

        /// <summary>
        /// Event on configuration files repository copying configuration on server
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">configuration file event arguments</param>
        private void ConfigFilesRepositoryCopyConfigOnServer(object sender, ConfigFileEventArgs e)
        {
            OnCopyConfigOnServer(e);
        }

        /// <summary>
        /// Event on player lane checking configuration server 
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">configuration file event arguments</param>
        private void PlayerLaneCheckConfigOnServer(object sender, ConfigFileEventArgs e)
        {
            OnCheckConfigOnServer(e);
        }

        /// <summary>
        /// Event on player lane loading configuration server
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">configuration file event arguments</param>
        private void PlayerLaneLoadConfigOnServer(object sender, ConfigFileEventArgs e)
        {
            OnLoadConfigOnServer(e);
        }

        /// <summary>
        /// Event on repository accessing
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void RepositoryAccessing(object sender, NcrEventArgs e)
        {
            OnServicing(e);
        }
    }
}
