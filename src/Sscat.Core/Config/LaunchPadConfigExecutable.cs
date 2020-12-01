// <copyright file="LaunchPadConfigExecutable.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the LaunchPadConfigExecutable class
    /// </summary>
    public class LaunchPadConfigExecutable
    {
        /// <summary>
        /// Executable name
        /// </summary>
        private string _executableName;

        /// <summary>
        /// Window title
        /// </summary>
        private string _windowTitle;

        /// <summary>
        /// Executable path
        /// </summary>
        private string _path;

        /// <summary>
        /// File name
        /// </summary>
        private string _filename;

        /// <summary>
        /// The arguments
        /// </summary>
        private string _arguments;

        /// <summary>
        /// Minimize start
        /// </summary>
        private string _minimizeStart;

        /// <summary>
        /// Gets or sets the executable name
        /// </summary>
        [XmlAttribute("ExecutableName")]
        public string ExecutableName
        {
            get { return _executableName; }
            set { _executableName = value; }
        }

        /// <summary>
        /// Gets or sets the window title
        /// </summary>
        [XmlAttribute("WindowTitle")]
        public string WindowTitle
        {
            get { return _windowTitle; }
            set { _windowTitle = value; }
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
        /// Gets or sets the file name
        /// </summary>
        [XmlAttribute("Filename")]
        public string Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }

        /// <summary>
        /// Gets or sets the arguments
        /// </summary>
        [XmlAttribute("Arguments")]
        public string Arguments
        {
            get { return _arguments; }
            set { _arguments = value; }
        }

        /// <summary>
        /// Gets or sets the minimize start
        /// </summary>
        [XmlAttribute("MinimizeStart")]
        public string MinimizeStart
        {
            get { return _minimizeStart; }
            set { _minimizeStart = value; }
        }
    }
}
