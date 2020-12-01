// <copyright file="ConfigFile.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Ncr.Core.Net;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ConfigFile class
    /// </summary>
    [XmlRoot("File"), Serializable()]
    public class ConfigFile : BaseSerializable<ConfigFile>, IContent
    {
        /// <summary>
        /// Configuration file name
        /// </summary>
        private string _name;

        /// <summary>
        /// Configuration file content
        /// </summary>
        private string _content;

        /// <summary>
        /// Configuration file host
        /// </summary>
        private string _host;

        /// <summary>
        /// Configuration file source
        /// </summary>
        private string _source;

        /// <summary>
        ///  Whether configuration file exists or not
        /// </summary>
        private bool _exists;

        /// <summary>
        /// Configuration file destination
        /// </summary>
        private string _destination;

        /// <summary>
        /// Configuration file path
        /// </summary>
        private string _path;

        /// <summary>
        /// Configuration file port number
        /// </summary>
        private int _port;

        /// <summary>
        /// Whether or not configuration file differs from the one in SCOT configuration
        /// </summary>
        private bool _differentFromScotConfig;

        /// <summary>
        /// Initializes a new instance of the ConfigFile class
        /// </summary>
        public ConfigFile()
            : this(string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ConfigFile class
        /// </summary>
        /// <param name="name">configuration file</param>
        public ConfigFile(string name)
            : this(name, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ConfigFile class
        /// </summary>
        /// <param name="name">configuration file</param>
        /// <param name="host">configuration host</param>
        public ConfigFile(string name, string host)
        {
            Name = name;
            Host = host;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the configuration differs from the SCOT version
        /// </summary>
        [XmlAttribute("DifferentFromScotConfig")]
        public bool DifferentFromScotConfig
        {
            get { return _differentFromScotConfig; }
            set { _differentFromScotConfig = value; }
        }

        /// <summary>
        /// Gets or sets the port number
        /// </summary>
        [XmlAttribute("Port")]
        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        /// <summary>
        /// Gets or sets the destination
        /// </summary>
        [XmlAttribute("Destination")]
        public string Destination
        {
            get { return _destination; }
            set { _destination = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the file exists
        /// </summary>
        [XmlAttribute("Exists")]
        public bool Exists
        {
            get { return _exists; }
            set { _exists = value; }
        }

        /// <summary>
        /// Gets or sets the source
        /// </summary>
        [XmlAttribute("Source")]
        public string Source
        {
            get { return _source; }
            set { _source = value; }
        }

        /// <summary>
        /// Gets or sets the host
        /// </summary>
        [XmlAttribute("Host")]
        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }

        /// <summary>
        /// Gets or sets the path
        /// </summary>
        [XmlAttribute("Path")]
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        /// <summary>
        /// Gets or sets the file content
        /// </summary>
        [XmlTextAttribute]
        public string Content
        {
            get
            {
                if (_content == null)
                {
                    _content = string.Empty;
                }

                return _content;
            }

            set
            {
                _content = value;
            }
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
        /// Checks whether config has a host
        /// </summary>
        /// <returns>Returns true if it has a host, false otherwise</returns>
        public bool HasHost()
        {
            return DnsHelper.HasHost(Host);
        }
    }
}
