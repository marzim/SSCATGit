// <copyright file="IOConfigFilesRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories.IO
{
    using System;
    using System.IO;
    using System.Net.Sockets;
    using Ncr.Core;
    using Ncr.Core.Emulators;
    using Ncr.Core.Util;
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the IOConfigFilesRepository class
    /// </summary>
    public class IOConfigFilesRepository : BaseRepository, IConfigFilesRepository
    {
        /// <summary>
        /// Checks whether or not repository has stopped
        /// </summary>
        private volatile bool _hasStopped;

        /// <summary>
        /// Initializes a new instance of the IOConfigFilesRepository class
        /// </summary>
        public IOConfigFilesRepository()
        {
        }

        /// <summary>
        /// Event handler for check configuration on server
        /// </summary>
        public event EventHandler<ConfigFileEventArgs> CheckConfigOnServer;

        /// <summary>
        /// Event handler for load configuration on server
        /// </summary>
        public event EventHandler<ConfigFileEventArgs> LoadConfigOnServer;

        /// <summary>
        /// Event handler for copy configuration on server
        /// </summary>
        public event EventHandler<ConfigFileEventArgs> CopyConfigOnServer;

        /// <summary>
        /// Read the configuration file
        /// </summary>
        /// <param name="name">configuration directory</param>
        /// <param name="config">configuration files</param>
        public virtual void Read(string name, ConfigFiles config)
        {
            string dir = name; // FIXME: Why not Path.Combine(config.DestinationDirectory, name)?
            if (DirectoryHelper.Exists(dir))
            {
                config.None = false;
                foreach (ConfigFile file in config.Files)
                {
                    CreateConfigFileRepository().Read(name, file);
                }
            }
            else
            {
                config.None = true;
            }
        }

        /// <summary>
        /// Stop the repository
        /// </summary>
        public void Stop()
        {
            _hasStopped = true;
        }

        /// <summary>
        /// Get the configuration files
        /// </summary>
        /// <param name="files">configuration files</param>
        /// <param name="configName">configuration name</param>
        public virtual void Get(ConfigFiles files, string configName)
        {
            _hasStopped = false;
            IConfigFileRepository r = CreateConfigFileRepository();
            string configDir = Path.Combine(files.DestinationDirectory, configName);
            foreach (ConfigFile file in files.Files)
            {
                if (_hasStopped)
                {
                    break;
                }

                SetPAPLASetting(file.Name, file.Path);

                file.Source = ((file.Path == null) || file.Path.Equals(string.Empty)) ? files.SourceDirectory : file.Path;
                file.Destination = Path.Combine(files.DestinationDirectory, configName);
                try
                {
                    r.Accessing += new EventHandler<NcrEventArgs>(ConfigFileRepositoryAccessing);
                    if (file.HasHost())
                    {
                        OnCopyConfigOnServer(new ConfigFileEventArgs(file));
                    }
                    else
                    {
                        r.Read(file);
                    }
                }
                catch (SocketException ex)
                {
                    OnAccessing(ex.Message);
                }
                finally
                {
                    r.Accessing -= new EventHandler<NcrEventArgs>(ConfigFileRepositoryAccessing);
                }
            }
        }

        /// <summary>
        /// Create configuration file repository
        /// </summary>
        /// <returns>Returns a new configuration file repository</returns>
        public virtual IConfigFileRepository CreateConfigFileRepository()
        {
            return new IOConfigFileRepository();
        }

        /// <summary>
        /// Checks if file differs from SCOT configuration
        /// </summary>
        /// <param name="files">configuration files</param>
        /// <returns>Returns true if different, false otherwise</returns>
        public bool DiffersFromScotConfig(ConfigFiles files)
        {
            IConfigFileRepository r = CreateConfigFileRepository();
            foreach (ConfigFile file in files.Files)
            {
                try
                {
                    r.Accessing += new EventHandler<NcrEventArgs>(ConfigFileRepositoryAccessing);
                    r.CheckOnServer += new EventHandler<ConfigFileEventArgs>(FileCheckOnServer);
                    if (r.Differs(file, files.SourceDirectory, files.DestinationDirectory))
                    {
                        return true;
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    r.Accessing -= new EventHandler<NcrEventArgs>(ConfigFileRepositoryAccessing);
                    r.CheckOnServer -= new EventHandler<ConfigFileEventArgs>(FileCheckOnServer);
                }
            }

            return false;
        }

        /// <summary>
        /// Load configuration files
        /// </summary>
        /// <param name="files">configuration files</param>
        public void Load(ConfigFiles files)
        {
            IConfigFileRepository r = CreateConfigFileRepository();
            foreach (ConfigFile file in files.Files)
            {
                try
                {
                    r.Accessing += new EventHandler<NcrEventArgs>(ConfigFileRepositoryAccessing);
                    r.LoadOnServer += new EventHandler<ConfigFileEventArgs>(FileLoadOnServer);
                    r.CheckOnServer += new EventHandler<ConfigFileEventArgs>(FileCheckOnServer);
                    r.Load(file, files.SourceDirectory, files.DestinationDirectory);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    r.Accessing -= new EventHandler<NcrEventArgs>(ConfigFileRepositoryAccessing);
                    r.CheckOnServer -= new EventHandler<ConfigFileEventArgs>(FileCheckOnServer);
                    r.LoadOnServer -= new EventHandler<ConfigFileEventArgs>(FileLoadOnServer);
                }
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
        /// Event for on load configuration on server
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
        /// Event for on check configuration on server
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
        /// Event for configuration file repository accessing
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ConfigFileRepositoryAccessing(object sender, NcrEventArgs e)
        {
            OnAccessing(e);
        }

        /// <summary>
        /// Event for configuration file check on server
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">configuration file event arguments</param>
        private void FileCheckOnServer(object sender, ConfigFileEventArgs e)
        {
            OnCheckConfigOnServer(e);
        }

        /// <summary>
        /// Event for configuration file load on server
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">configuration file event arguments</param>
        private void FileLoadOnServer(object sender, ConfigFileEventArgs e)
        {
            OnLoadConfigOnServer(e);
        }

        /// <summary>
        /// Sets PAPLA Setting
        /// </summary>
        /// <param name="file">file name</param>
        /// <param name="path">file path</param>
        private void SetPAPLASetting(string file, string path)
        {
            if (file.Equals("PAPLASettings.ini", StringComparison.OrdinalIgnoreCase))
            {
                SSBSimulator ssb = new SSBSimulator();
                ssb.SetPAPLASetting(Path.Combine(path, file));
            }
        }
    }
}
