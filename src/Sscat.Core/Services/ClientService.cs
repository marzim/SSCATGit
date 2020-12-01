// <copyright file="ClientService.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Services
{
    using System.IO;
    using Ncr.Core.Util;
    using Sscat.Core.Config;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Repositories;

    /// <summary>
    /// Initializes a new instance of the ClientService class
    /// </summary>
    public class ClientService
    {
        /// <summary>
        /// Interface for client configuration repository
        /// </summary>
        private IClientConfigurationRepository _clientConfigRepository;

        /// <summary>
        /// Interface for configuration files repository
        /// </summary>
        private IConfigFilesRepository _configFilesRepository;

        /// <summary>
        /// Interface for script repository
        /// </summary>
        private IScriptRepository _scriptRepository;

        /// <summary>
        /// Interface for configuration file repository
        /// </summary>
        private IConfigFileRepository _configFileRepository;

        /// <summary>
        /// Client CPU and memory logger
        /// </summary>
        private CpuAndMemoryLogger _logger;

        /// <summary>
        /// Initializes a new instance of the ClientService class
        /// </summary>
        /// <param name="clientConfigRepository">client configuration repository</param>
        /// <param name="configFilesRepository">configuration files repository</param>
        /// <param name="configFileRepository">configuration file repository</param>
        /// <param name="scriptRepository">script repository</param>
        /// <param name="logger">client logger</param>
        public ClientService(IClientConfigurationRepository clientConfigRepository, IConfigFilesRepository configFilesRepository, IConfigFileRepository configFileRepository, IScriptRepository scriptRepository, CpuAndMemoryLogger logger)
        {
            _clientConfigRepository = clientConfigRepository;
            _configFilesRepository = configFilesRepository;
            _configFileRepository = configFileRepository;
            _scriptRepository = scriptRepository;
            _logger = logger;
        }

        /// <summary>
        /// Starts the logger
        /// </summary>
        public virtual void StartLogger()
        {
            ThreadHelper.Start(_logger.Start);
        }

        /// <summary>
        /// Stops the logger
        /// </summary>
        public virtual void StopLogger()
        {
            _logger.Stop();
        }

        /// <summary>
        /// Creates the configuration files
        /// </summary>
        /// <param name="files">configuration files</param>
        public void CreateConfigFiles(ConfigFiles files)
        {
            foreach (ConfigFile file in files.Files)
            {
                _configFileRepository.Create(file);
            }
        }

        /// <summary>
        /// Save scripts
        /// </summary>
        /// <param name="scripts">scripts to save</param>
        public void SaveScripts(IScript[] scripts)
        {
            foreach (IScript script in scripts)
            {
                _scriptRepository.Save(script);
            }
        }

        /// <summary>
        /// Read client configuration
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the client configuration</returns>
        public ClientConfiguration ReadClientConfiguration(string filename)
        {
            return _clientConfigRepository.Read(filename);
        }

        /// <summary>
        /// Saves the client configuration
        /// </summary>
        /// <param name="config">client configuration</param>
        public void SaveClientConfiguration(ClientConfiguration config)
        {
            _clientConfigRepository.Save(config);
        }

        /// <summary>
        /// Reads the script
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the script</returns>
        public IScript ReadScript(string filename)
        {
            return _scriptRepository.Read(filename);
        }

        /// <summary>
        /// Reads the configuration files
        /// </summary>
        /// <param name="name">configuration directory</param>
        /// <param name="files">configuration files</param>
        public void ReadConfigFiles(string name, ConfigFiles files)
        {
            _configFilesRepository.Read(name, files);
        }

        /// <summary>
        /// Prepares the player configuration
        /// </summary>
        /// <param name="config">player configuration</param>
        /// <param name="script">script file</param>
        public void PreparePlayerConfiguration(PlayerConfiguration config, ScriptFile script)
        {
            config.Clear();
            SSCATScript s = _scriptRepository.Read(script.File) as SSCATScript;
            s.Index = script.Index;
            string name = Path.Combine(Path.GetDirectoryName(s.FileName), s.Name);
            _configFilesRepository.Read(name, config.ConfigFiles);
            config.ScriptConfigs.AddConfig(new ScriptConfig(s, config.ConfigFiles));
        }
    }
}
