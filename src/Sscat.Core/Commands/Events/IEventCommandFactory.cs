// <copyright file="IEventCommandFactory.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using Sscat.Core.Commands.Events;

    /// <summary>
    /// Interface for the event command factory
    /// </summary>
    public interface IEventCommandFactory
    {
        /// <summary>
        /// Creates the device event command
        /// </summary>
        /// <returns>Returns event command</returns>
        IEventCommand CreateCommand();
    }
}
