// <copyright file="IResponseDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System;

    /// <summary>
    /// Initializes a new instance of the IResponseDispatcher interface
    /// </summary>
    public interface IResponseDispatcher
    {
        /// <summary>
        /// Event handler for dispatching
        /// </summary>
        event EventHandler<NcrEventArgs> Dispatching;

        /// <summary>
        /// Event handler for error dispatched
        /// </summary>
        event EventHandler ErrorDispatched;

        /// <summary>
        /// Gets the response dispatcher name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Dispatch the response
        /// </summary>
        /// <param name="response">response to dispatch</param>
        void Dispatch(Response response);
    }
}
