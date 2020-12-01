// <copyright file="BackCommands.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the BackCommands class
    /// </summary>
    public class BackCommands
    {
        /// <summary>
        /// Back commands
        /// </summary>
        private BackCommand[] _commands;

        /// <summary>
        /// Gets or sets the back commands
        /// </summary>
        [XmlElement("Command")]
        public BackCommand[] Commands
        {
            get
            {
                if (_commands == null)
                {
                    _commands = new BackCommand[0];
                }

                return _commands;
            }

            set
            {
                _commands = value;
            }
        }
    }
}
