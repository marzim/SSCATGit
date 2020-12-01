// <copyright file="IOConfigFileRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories.IO
{
    using System;
    using System.IO;
    using System.Text;
    using Ncr.Core.Util;
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the IOConfigFileRepository class
    /// </summary>
    public class IOConfigFileRepository : BaseRepository, IConfigFileRepository
    {
        /// <summary>
        /// Initializes a new instance of the IOConfigFileRepository class
        /// </summary>
        public IOConfigFileRepository()
        {
        }

        /// <summary>
        /// Event handler for load on server
        /// </summary>
        public event EventHandler<ConfigFileEventArgs> LoadOnServer;

        /// <summary>
        /// Event handler for check on server
        /// </summary>
        public event EventHandler<ConfigFileEventArgs> CheckOnServer;

        /// <summary>
        /// Read the configuration file
        /// </summary>
        /// <param name="file">configuration file</param>
        public virtual void Read(ConfigFile file)
        {
            Read(file.Source, file);
        }

        /// <summary>
        /// Copies the file from source to destination and deletes the original
        /// </summary>
        /// <param name="source">source of file</param>
        /// <param name="dest">destination of file</param>
        public virtual void Rename(string source, string dest)
        {
            OnAccessing(string.Format("Copying {0} to {1}", source, dest));
            FileHelper.Copy(source, dest);
            OnAccessing(string.Format("Deleting {0}", source));
            FileHelper.Delete(source);
        }

        /// <summary>
        /// Checks if source is a core configuration file
        /// </summary>
        /// <param name="source">file source</param>
        /// <returns>Returns true if extension matches any expected, false otherwise</returns>
        public virtual bool CoreConfig(string source)
        {
            string sourceExtension = FileHelper.GetExtension(source);
            return sourceExtension == ".dat" || sourceExtension == ".xml" || sourceExtension == ".ini" || sourceExtension == ".config" || sourceExtension == ".txt";
        }

        /// <summary>
        /// Checks if the file differs
        /// </summary>
        /// <param name="file">file to check</param>
        /// <param name="source">file source</param>
        /// <param name="destination">file destination</param>
        /// <returns>Returns true if different, false otherwise</returns>
        public bool Differs(ConfigFile file, string source, string destination)
        {
            file.Source = (file.Path == null || file.Path.Equals(string.Empty)) ? file.Source : file.Path;
            file.Destination = (file.Path == null || file.Path.Equals(string.Empty)) ? destination : file.Path;
            
            if (file.HasHost())
            {
                OnCheckOnServer(new ConfigFileEventArgs(file));
                if (file.DifferentFromScotConfig)
                {
                    return true;
                }
            }
            else
            {
                file.Source = (file.Path == null || file.Path.Equals(string.Empty)) ? file.Source : file.Path;
                string scotFile = Path.Combine(file.Destination, file.Name);
                
                if (Exists(scotFile) && !file.Exists)
                {
                    if (!CoreConfig(scotFile))
                    {
                        return true;
                    }
                }
                else if (Exists(scotFile) && file.Exists)
                {
                    ConfigFile f = Read(scotFile);
                    if (!f.Content.Equals(file.Content))
                    {
                        return true;
                    }
                }
                else if (!Exists(scotFile) && file.Exists)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Loads the configuration file
        /// </summary>
        /// <param name="file">configuration file</param>
        /// <param name="source">file source</param>
        /// <param name="destination">file destination</param>
        public void Load(ConfigFile file, string source, string destination)
        {
            file.Source = source;
            file.Destination = (file.Path == null || file.Path.Equals(string.Empty)) ? destination : file.Path;
            if (file.HasHost())
            {
                if (Differs(file, source, destination))
                {
                    OnLoadOnServer(new ConfigFileEventArgs(file));
                }
                else
                {
                    OnAccessing(string.Format("{0} is identical at {1}", file.Name, file.Host));
                }
            }
            else
            {
                string scotFile = Path.Combine(file.Destination, file.Name);

                if (Exists(scotFile) && !file.Exists)
                {
                    if (!CoreConfig(scotFile))
                    {
                        Rename(scotFile, scotFile + ".sscat");
                        OnAccessing(string.Format("{0} exists in SCOT but not in configuration. File is renamed to {0}.sscat", file.Name));
                    }
                    else
                    {
                        OnAccessing(string.Format("{0} file was not renamed because it is a core configuration file.", file.Name));
                    }
                }
                else if (Exists(scotFile) && file.Exists)
                {
                    ConfigFile f = Read(scotFile);
                    if (!f.Content.Equals(file.Content))
                    {
                        Rename(scotFile, scotFile + ".sscat");
                        Create(file);
                        OnAccessing(string.Format("{0} is overridden", file.Name));
                    }
                    else
                    {
                        OnAccessing(string.Format("{0} is identical", file.Name));
                    }
                }
                else if (!Exists(scotFile) && file.Exists)
                {
                    Create(file);
                    OnAccessing(string.Format("{0} is added", file.Name));
                }
            }
        }

        /// <summary>
        /// Checks if file exists
        /// </summary>
        /// <param name="file">file to check</param>
        /// <returns>Returns true if exist, false otherwise</returns>
        public virtual bool Exists(string file)
        {
            return FileHelper.Exists(file);
        }

        /// <summary>
        /// Read the configuration file
        /// </summary>
        /// <param name="name">name of the file</param>
        /// <param name="file">configuration file</param>
        public virtual void Read(string name, ConfigFile file)
        {
            string filename = Path.Combine(name, file.Name);
            
            try
            {
                OnAccessing(string.Format("Saving Configuration in {0}", filename));
                
                if (file.Name.Equals("PickListDB.db"))
                {
                    OnAccessing(string.Format("Killing SSBCommunicator"));
                    ProcessUtility.Kill("SSBCommunicator");
                    ThreadHelper.Sleep(300);
                }

                using (StreamReader reader = new StreamReader(filename, Encoding.Default))
                {
                    file.Exists = true;
                    file.Content = reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                file.Exists = false;
                file.Content = string.Empty;
                OnAccessing(string.Format("{0} not found", filename));
            }
        }

        /// <summary>
        /// Read the configuration file
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the configuration file</returns>
        public virtual ConfigFile Read(string filename)
        {
            ConfigFile file = new ConfigFile(Path.GetFileName(filename));
            Read(Path.GetDirectoryName(filename), file);
            return file;
        }

        /// <summary>
        /// Create configuration file
        /// </summary>
        /// <param name="file">configuration file</param>
        public virtual void Create(ConfigFile file)
        {
            file.Source = (file.Path == null || file.Path.Equals(string.Empty)) ? file.Source : file.Path;

            if (file.Exists)
            {
                if (!Directory.Exists(file.Destination))
                {
                    Directory.CreateDirectory(file.Destination);
                }

                string filename = Path.Combine(file.Destination, file.Name);

                if (file.Host != null && file.Host != string.Empty)
                {
                    OnAccessing(string.Format("{0} @ {1}", filename, file.Host));
                }
                else
                {
                    OnAccessing(filename);
                }

                using (FileStream fs = new FileStream(filename, FileMode.CreateNew))
                {
                    using (StreamWriter writer = new StreamWriter(fs, Encoding.Default))
                    {
                        writer.Write(file.Content);
                    }
                }
            }
            else
            {
                if (file.Host != null && file.Host != string.Empty)
                {
                    OnAccessing(string.Format("{0} @ {1} does not exist. Skip copying.", Path.Combine(file.Destination, file.Name), file.Host));
                }
                else
                {
                    OnAccessing(string.Format("{0} does not exist. Skip copying.", Path.Combine(file.Destination, file.Name)));
                }
            }
        }

        /// <summary>
        /// Event for on check on server
        /// </summary>
        /// <param name="e">configuration file event arguments</param>
        protected virtual void OnCheckOnServer(ConfigFileEventArgs e)
        {
            if (CheckOnServer != null)
            {
                CheckOnServer(this, e);
            }
        }

        /// <summary>
        /// Event for on load on server
        /// </summary>
        /// <param name="e">configuration file event arguments</param>
        protected virtual void OnLoadOnServer(ConfigFileEventArgs e)
        {
            if (LoadOnServer != null)
            {
                LoadOnServer(this, e);
            }
        }
    }
}
