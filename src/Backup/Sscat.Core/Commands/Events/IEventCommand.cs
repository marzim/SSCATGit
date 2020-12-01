// <copyright file="IEventCommand.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Events
{
    using System;
    using Ncr.Core.Commands;
    using Ncr.Core.Models;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Interface for the event command
    /// </summary>
    public interface IEventCommand : ICommand
    {
        /// <summary>
        /// Event handler for adding the connection
        /// </summary>
        event EventHandler<PsxWrapperEventArgs> ConnectionAdding;

        /// <summary>
        /// Gets or sets the command result
        /// </summary>
        Result Result { get; set; }

        /// <summary>
        /// Actions ran prior to the event
        /// </summary>
        void PreRun();
    }
}
