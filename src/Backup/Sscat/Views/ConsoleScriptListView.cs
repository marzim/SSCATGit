// <copyright file="ConsoleScriptListView.cs" company="NCR">
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
    /// Initializes a new instance of the ConsoleScriptListView class.
    /// </summary>
    public class ConsoleScriptListView : BaseConsoleView, IScriptListView
    {
        /// <summary>
        /// List of the scripts
        /// </summary>
        private List<IScript> _scripts;

        /// <summary>
        /// List of the script files
        /// </summary>
        private List<ScriptFile> _files;

        /// <summary>
        /// Initializes a new instance of the ConsoleScriptListView class.
        /// </summary>
        public ConsoleScriptListView()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ConsoleScriptListView class.
        /// </summary>
        /// <param name="files">script files</param>
        public ConsoleScriptListView(List<ScriptFile> files)
        {
            _files = files;
        }

        /// <summary>
        /// Event handler for the scripts list
        /// </summary>
        public event EventHandler<SscatLaneEventArgs> ScriptsList;

        /// <summary>
        /// Gets or sets the scripts
        /// </summary>
        public List<IScript> Scripts
        {
            get
            {
                return _scripts;
            }

            set
            {
                _scripts = value;
                foreach (IScript s in _scripts)
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Showing {0}", s.FileName);
                    foreach (IScriptEvent e in s.Events.Events)
                    {
                        Console.WriteLine("{0}: {1}", e.Time, e.ToRepresentation());
                    }
                }
            }
        }

        /// <summary>
        /// Event on the scripts list. 
        /// </summary>
        /// <param name="e">sscat lane event arguments</param>
        protected virtual void OnScriptsList(SscatLaneEventArgs e)
        {
            if (ScriptsList != null)
            {
                ScriptsList(this, e);
            }
        }

        /// <summary>
        /// Event on the view show
        /// </summary>
        /// <param name="e">event arguments</param>
        protected override void OnViewShow(EventArgs e)
        {
            base.OnViewShow(e);
            OnScriptsList(new SscatLaneEventArgs(_files));
        }
    }
}
