// <copyright file="ConsolePlayerView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Views
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Ncr.Core.Views;
    using Sscat.Core.Commands.Gui;
    using Sscat.Core.Emulators;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ConsolePlayerView class
    /// </summary>
    public class ConsolePlayerView : BaseConsoleView, IPlayerView
    {
        /// <summary>
        /// Script files
        /// </summary>
        private List<ScriptFile> _scriptFiles = new List<ScriptFile>();

        /// <summary>
        /// Number of times to repeat the script
        /// </summary>
        private int _repeat;

        /// <summary>
        /// User given report file name
        /// </summary>
        private string _reportFileName;

        /// <summary>
        /// Initializes a new instance of the ConsolePlayerView class
        /// </summary>
        public ConsolePlayerView()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ConsolePlayerView class
        /// </summary>
        /// <param name="scriptFiles">script files</param>
        /// <param name="repeat">number of times to repeat</param>
        public ConsolePlayerView(List<ScriptFile> scriptFiles, int repeat)
        {
            _scriptFiles = scriptFiles;
            _repeat = repeat;
            _reportFileName = string.Empty;
        }
        
        /// <summary>
        /// Initializes a new instance of the ConsolePlayerView class
        /// </summary>
        /// <param name="scriptFiles">script files</param>
        /// <param name="repeat">number of times to repeat</param>
        /// <param name="reportFileName">report file name</param>
        public ConsolePlayerView(List<ScriptFile> scriptFiles, int repeat, string reportFileName)
        {
            _scriptFiles = scriptFiles;
            _repeat = repeat;
            _reportFileName = reportFileName;
        }

        /// <summary>
        /// Event handler for play command
        /// </summary>
        public event EventHandler<SscatLaneEventArgs> Play;

        /// <summary>
        /// Event handler for the stopping command
        /// </summary>
        public event EventHandler Stopping;

        /// <summary>
        /// Event handler for the stop command
        /// </summary>
        public event EventHandler Stop;

        /// <summary>
        /// Gets the script files
        /// </summary>
        public List<ScriptFile> ScriptFiles
        {
            get { return _scriptFiles; }
        }

        /// <summary>
        /// Clears the results
        /// </summary>
        public void ClearResults()
        {
        }

        /// <summary>
        /// Clears the view
        /// </summary>
        public void ClearView()
        {
        }

        /// <summary>
        /// Runs the scripts
        /// </summary>
        public void PerformPlay()
        {
            OnPlay(new SscatLaneEventArgs(ScriptFiles, _repeat, _reportFileName));
        }

        /// <summary>
        /// Perform playing
        /// </summary>
        public void PerformPlaying()
        {
        }

        /// <summary>
        /// Performs the stop
        /// </summary>
        public void PerformStop()
        {
            OnStop(null);
        }

        /// <summary>
        /// Performs the disable
        /// </summary>
        public void PerformDisable()
        {
        }

        /// <summary>
        /// Performs the stopping event
        /// </summary>
        public void PerformStopping()
        {
            OnStopping(null);
        }

        /// <summary>
        /// Updates the event result
        /// </summary>
        /// <param name="e">script event arguments</param>
        public void UpdateEventResult(IScriptEvent e)
        {
        }

        /// <summary>
        /// Update the warning event result
        /// </summary>
        /// <param name="e">warning event</param>
        public void UpdateWarningEventResult(IWarningEvent e)
        {
        }

        /// <summary>
        /// Updates the script result
        /// </summary>
        /// <param name="s">the script</param>
        public void UpdateScriptResult(IScript s)
        {
        }

        /// <summary>
        /// Updates the view when there is a connection timeout
        /// </summary>
        /// <param name="error">the error</param>
        public void UpdateViewOnConnectionTimeout(string error)
        {
        }

        /// <summary>
        /// Initiates the cache
        /// </summary>
        /// <param name="e">script event arguments</param>
        public void InitiateCache(ScriptEventArgs e)
        {
        }

        /// <summary>
        /// Adds a script to the script files
        /// </summary>
        /// <param name="scripts">scripts to be added</param>
        public void AddScript(List<string> scripts)
        {
            foreach (string s in scripts)
            {
                ScriptFiles.Add(new ScriptFile(s));
            }
        }

        /// <summary>
        /// Select a specific script
        /// </summary>
        /// <param name="script">script to be selected</param>
        public void SelectScript(ScriptFile script)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event on stop
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnStop(EventArgs e)
        {
            if (Stop != null)
            {
                Stop(this, e);
            }
        }

        /// <summary>
        /// Event on play
        /// </summary>
        /// <param name="e">sscat lane event arguments</param>
        protected virtual void OnPlay(SscatLaneEventArgs e)
        {
            if (Play != null)
            {
                Play(this, e);
            }
        }

        /// <summary>
        /// Event on stopping
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnStopping(EventArgs e)
        {
            if (Stopping != null)
            {
                Stopping(this, e);
            }
        }

        /// <summary>
        /// Event on show view
        /// </summary>
        /// <param name="e">event arguments</param>
        protected override void OnViewShow(EventArgs e)
        {
            base.OnViewShow(e);
            PerformPlay();
        }
    }
}
