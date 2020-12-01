// <copyright file="ISscatRequestDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using System;
    using Ncr.Core.Models;
    using Ncr.Core.Net;

    /// <summary>
    /// Initializes a new instance of the ISscatRequestDispatcher interface
    /// </summary>
    public interface ISscatRequestDispatcher : IRequestDispatcher
    {
        /// <summary>
        /// Event handler for connection adding
        /// </summary>
        event EventHandler<PsxWrapperEventArgs> ConnectionAdding;

        /// <summary>
        /// Event handler for log hook initialize
        /// </summary>
        event EventHandler LogHookInitialize;

        /// <summary>
        /// Event handler for parser initialize
        /// </summary>
        event EventHandler ParserInitialize;

        /// <summary>
        /// Event handler for client initialize
        /// </summary>
        event EventHandler ClientInitialize;

        /// <summary>
        /// Event handler for logger start
        /// </summary>
        event EventHandler LoggerStart;

        /// <summary>
        /// Event handler for logger stop
        /// </summary>
        event EventHandler LoggerStop;

        /// <summary>
        /// Gets or sets the SSCAT server
        /// </summary>
        SscatServer Server { get; set; }
    }
}
