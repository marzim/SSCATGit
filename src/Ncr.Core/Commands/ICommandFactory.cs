// <copyright file="ICommandFactory.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Commands
{
    /// <summary>
    /// Initializes a new instance of the AbstractCommand class
    /// </summary>
    public interface ICommandFactory
    {
        /// <summary>
        /// Create the command
        /// </summary>
        /// <param name="command">command to create</param>
        /// <returns>Returns the created command</returns>
        ICommand CreateCommand(string command);
    }
}
