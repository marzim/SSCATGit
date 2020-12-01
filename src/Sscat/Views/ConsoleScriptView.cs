// <copyright file="ConsoleScriptView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Views
{
    using System;
    using System.Collections.Generic;
    using Ncr.Core.Views;
    using Sscat.Core.Emulators;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ConsoleScriptView class.
    /// </summary>
    public class ConsoleScriptView : BaseConsoleView, IScriptView
    {
        /// <summary>
        /// The script
        /// </summary>
        private IScript _script;

        /// <summary>
        /// Event handler for saving the script
        /// </summary>
        public event EventHandler<ScriptEventArgs> ScriptSave;

        /// <summary>
        /// Gets or sets the script
        /// </summary>
        public IScript Script
        {
            get
            {
                return _script;
            }

            set
            {
                _script = value;
                Console.WriteLine("Name: {0}", _script.Name); // TODO: Console?
                Console.WriteLine("Description: {0}", _script.Description);
            }
        }

        /// <summary>
        /// Saves the script
        /// </summary>
        public void Save()
        {
            OnScriptSave(new ScriptEventArgs(Script));
        }

        /// <summary>
        /// Event for saving the script
        /// </summary>
        /// <param name="e">script event arguments</param>
        protected virtual void OnScriptSave(ScriptEventArgs e)
        {
            if (ScriptSave != null)
            {
                ScriptSave(this, e);
            }
        }
    }
}
