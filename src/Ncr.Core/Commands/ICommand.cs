// <copyright file="ICommand.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Commands
{
    using System;
    using Ncr.Core.Models;

    /// <summary>
    /// Initializes a new instance of the ICommand interface
    /// </summary>
    public interface ICommand : IBaseModel
    {
        /// <summary>
        /// Event handler for running
        /// </summary>
        event EventHandler<NcrEventArgs> Running;

        /// <summary>
        /// Gets or sets the command owner
        /// </summary>
        object Owner { get; set; }

        /// <summary>
        /// Gets a value indicating whether or not the command can run
        /// </summary>
        bool CanRun { get; }

        /// <summary>
        /// Gets a value indicating whether the command can be checked
        /// </summary>
        bool Checked { get; }

        /// <summary>
        /// Run the command
        /// </summary>
        void Run();
    }
}
