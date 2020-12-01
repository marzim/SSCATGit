// <copyright file="PluginControl.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Plugins
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Commands;

    /// <summary>
    /// Initializes a new instance of the PluginControl class
    /// </summary>
    public class PluginControl
    {
        /// <summary>
        /// Plugin control command
        /// </summary>
        private string _command;

        /// <summary>
        /// Gets or sets the command
        /// </summary>
        [XmlAttribute("Command")]
        public virtual string Command
        {
            get { return _command; }
            set { _command = value; }
        }

        /// <summary>
        /// Creates a command
        /// </summary>
        /// <returns>Returns the command created</returns>
        protected ICommand CreateCommand()
        {
            if (Command != null && !Command.Equals(string.Empty))
            {
                Type t = Type.GetType(Command);
                if (t != null)
                {
                    return Activator.CreateInstance(t) as ICommand;
                }
            }

            return null;
        }
    }
}
