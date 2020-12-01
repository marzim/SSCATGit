// <copyright file="IScriptListView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Views
{
    using System;
    using System.Collections.Generic;
    using Ncr.Core.Views;
    using Sscat.Core.Emulators;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the IScriptListView interface
    /// </summary>
    public interface IScriptListView : IView
    {
        /// <summary>
        /// Event handler for scripts list
        /// </summary>
        event EventHandler<SscatLaneEventArgs> ScriptsList;

        /// <summary>
        /// Gets or sets the scripts
        /// </summary>
        List<IScript> Scripts { get; set; }
    }
}
