// <copyright file="ConfigFiles.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Ncr.Core.Net;

    /// <summary>
    /// Initializes a new instance of the ConfigFiles class
    /// </summary>
    [XmlRoot("Files"), Serializable()]
    public class ConfigFiles : BaseModel<ConfigFiles>, IContent
    {
        /// <summary>
        /// Configuration files
        /// </summary>
        private ConfigFile[] _files;

        /// <summary>
        /// Configuration file name
        /// </summary>
        private string _name;

        /// <summary>
        /// Source directory
        /// </summary>
        private string _sourceDirectory;

        /// <summary>
        /// Destination directory
        /// </summary>
        private string _destinationDirectory;

        /// <summary>
        /// Index for repetition
        /// </summary>
        private int _repetitionIndex;

        /// <summary>
        /// True if there are no config files
        /// </summary>
        private bool _none;

        /// <summary>
        /// Initializes a new instance of the ConfigFiles class
        /// </summary>
        public ConfigFiles()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ConfigFiles class
        /// </summary>
        /// <param name="destinationDirectory">destination directory</param>
        public ConfigFiles(string destinationDirectory)
        {
            DestinationDirectory = destinationDirectory;
        }

        /// <summary>
        /// Initializes a new instance of the ConfigFiles class
        /// </summary>
        /// <param name="file">configuration file</param>
        public ConfigFiles(ConfigFile file)
        {
            AddFile(file);
        }

        /// <summary>
        /// Gets or sets the config file name
        /// </summary>
        [XmlAttribute("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether there are config files or not
        /// </summary>
        [XmlAttribute("None")]
        public bool None
        {
            get { return _none; }
            set { _none = value; }
        }

        /// <summary>
        /// Gets or sets the destination directory
        /// </summary>
        [XmlAttribute("Destination")]
        public string DestinationDirectory
        {
            get { return _destinationDirectory; }
            set { _destinationDirectory = value; }
        }

        /// <summary>
        /// Gets or sets the source directory
        /// </summary>
        [XmlAttribute("Source")]
        public string SourceDirectory
        {
            get { return _sourceDirectory; }
            set { _sourceDirectory = value; }
        }

        /// <summary>
        /// Gets or sets the repetition index
        /// </summary>
        [XmlIgnoreAttribute]
        public int RepetitionIndex
        {
            get { return _repetitionIndex; }
            set { _repetitionIndex = value; }
        }

        /// <summary>
        /// Gets or sets the configuration files
        /// </summary>
        [XmlElement("File")]
        public ConfigFile[] Files
        {
            get
            {
                if (_files == null)
                {
                    return new ConfigFile[0];
                }

                return _files;
            }

            set
            {
                _files = value;
            }
        }

        /// <summary>
        /// Adds a configuration file
        /// </summary>
        /// <param name="file">configuration file</param>
        public void AddFile(ConfigFile file)
        {
            List<ConfigFile> f = new List<ConfigFile>(Files);
            f.Add(file);
            _files = new ConfigFile[f.Count];
            f.CopyTo(_files);
        }

        /// <summary>
        /// Clears the configuration files
        /// </summary>
        public void Clear()
        {
            _files = new ConfigFile[0];
        }

        /// <summary>
        /// Disposes the configuration files
        /// </summary>
        public override void Dispose()
        {
            Clear();
        }

        /// <summary>
        /// Removes a specified configuration file
        /// </summary>
        /// <param name="file">configuration file</param>
        public void RemoveFile(ConfigFile file)
        {
            List<ConfigFile> f = new List<ConfigFile>(Files);
            f.Remove(file);
            _files = new ConfigFile[f.Count];
            f.CopyTo(_files);
        }
    }
}