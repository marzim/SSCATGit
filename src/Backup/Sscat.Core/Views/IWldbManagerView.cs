// <copyright file="IWldbManagerView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Views
{
    using System;
    using Ncr.Core.Views;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the IWldbManagerView interface
    /// </summary>
    public interface IWldbManagerView : IView
    {
        /// <summary>
        /// Event handler for managing
        /// </summary>
        event EventHandler<WldbEventArgs> Managing;

        /// <summary>
        /// Gets or sets the weight learning database
        /// </summary>
        IWldbEvent Wldb { get; set; }

        /// <summary>
        /// Manages the WLDB
        /// </summary>
        void Manage();
    }
}
