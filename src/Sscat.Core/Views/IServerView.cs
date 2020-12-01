// <copyright file="IServerView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Views
{
    using System;
    using Ncr.Core.Net;
    using Ncr.Core.Views;

    /// <summary>
    /// Initializes a new instance of the IServerView interface
    /// </summary>
    public interface IServerView : IView
    {
        /// <summary>
        /// Gets or sets the server
        /// </summary>
        IServer Server { get; set; }

        /// <summary>
        /// Clears the logs
        /// </summary>
        [Obsolete]
        void ClearLogs();
    }
}
