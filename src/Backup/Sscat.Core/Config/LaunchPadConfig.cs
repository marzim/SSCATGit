// <copyright file="LaunchPadConfig.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System.Xml.Serialization;
    using Ncr.Core.Models;

    /// <summary>
    /// Initializes a new instance of the LaunchPadConfig class
    /// </summary>
    [XmlRoot("root")]
    public class LaunchPadConfig : BaseModel<LaunchPadConfig>
    {
        /// <summary>
        /// Launch pad configuration executable files
        /// </summary>
        private LaunchPadConfigExecutable[] _launchPadConfigExecutables;

        /// <summary>
        /// Gets or sets the launch pad configuration executable files
        /// </summary>
        [XmlElement("Executable")]
        public LaunchPadConfigExecutable[] LaunchPadConfigExecutables
        {
            get { return _launchPadConfigExecutables; }
            set { _launchPadConfigExecutables = value; }
        }
    }    
}
