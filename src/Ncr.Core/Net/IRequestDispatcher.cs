// <copyright file="IRequestDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System;

    /// <summary>
    /// Initializes a new instance of the IRequestDispatcher interface
    /// </summary>
    public interface IRequestDispatcher
    {
        /// <summary>
        /// Event handler for dispatched
        /// </summary>
        event EventHandler<ResponseEventArgs> Dispatched;

        /// <summary>
        /// Event handler for dispatching
        /// </summary>
        event EventHandler<NcrEventArgs> Dispatching;

        /// <summary>
        /// Gets the request dispatcher name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Dispatch the request
        /// </summary>
        /// <param name="request">request to dispatch</param>
        void Dispatch(Request request);
    }
}
