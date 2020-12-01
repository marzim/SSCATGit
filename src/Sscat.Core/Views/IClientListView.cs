// <copyright file="IClientListView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Views
{
    using System.Collections;
    using Ncr.Core.Views;

    /// <summary>
    /// Initializes a new instance of the IClientListView interface
    /// </summary>
    public interface IClientListView : IView
    {
        /// <summary>
        /// Gets the clients
        /// </summary>
        Hashtable Clients { get; }
    }
}
