// <copyright file="CommandBuilder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Commands
{
    using Ncr.Core.Commands;

    /// <summary>
    /// Initializes a new instance of the CommandBuilder class
    /// </summary>
    public static class CommandBuilder
    {
        /// <summary>
        /// Interface for command factory
        /// </summary>
        private static ICommandFactory _commandFactory;

        /// <summary>
        /// Gets or sets the command factory
        /// </summary>
        public static ICommandFactory CommandFactory
        {
            get
            {
                return _commandFactory;
            }

            set
            {
                CommandBuilder._commandFactory = value;
            }
        }
    }
}
