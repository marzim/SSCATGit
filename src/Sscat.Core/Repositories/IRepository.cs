// <copyright file="IRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories
{
    using System;
    using Ncr.Core;

    /// <summary>
    /// Initializes a new instance of the IRepository interface
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Event handler for accessing repository
        /// </summary>
        event EventHandler<NcrEventArgs> Accessing;
    }
}
