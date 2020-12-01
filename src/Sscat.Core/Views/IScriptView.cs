// <copyright file="IScriptView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Views
{
    using System;
    using Ncr.Core.Views;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the IScriptView interface
    /// </summary>
    public interface IScriptView : IView
    {
        /// <summary>
        /// Event handler for script save
        /// </summary>
        event EventHandler<ScriptEventArgs> ScriptSave;

        /// <summary>
        /// Gets or sets the script
        /// </summary>
        IScript Script { get; set; }

        /// <summary>
        /// Save the script
        /// </summary>
        void Save();
    }
}
