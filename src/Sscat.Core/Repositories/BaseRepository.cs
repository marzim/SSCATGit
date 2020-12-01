// <copyright file="BaseRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories
{
    using System;
    using Ncr.Core;

    /// <summary>
    /// Initializes a new instance of the BaseRepository class
    /// </summary>
    public class BaseRepository : IRepository
    {
        /// <summary>
        /// Event handler for accessing repository
        /// </summary>
        public event EventHandler<NcrEventArgs> Accessing;

        /// <summary>
        /// Accesses repository with a given message
        /// </summary>
        /// <param name="message">message to send</param>
        protected virtual void OnAccessing(string message)
        {
            OnAccessing(new NcrEventArgs(message));
        }

        /// <summary>
        /// Event for on accessing repository
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnAccessing(NcrEventArgs e)
        {
            if (Accessing != null)
            {
                Accessing(this, e);
            }
        }
    }
}
