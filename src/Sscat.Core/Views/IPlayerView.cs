// <copyright file="IPlayerView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Views
{
    using System;
    using System.Collections.Generic;
    using Ncr.Core.Views;
    using Sscat.Core.Emulators;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the IPlayerView interface
    /// </summary>
    public interface IPlayerView : IView
    {
        /// <summary>
        /// Event handler for play
        /// </summary>
        event EventHandler<SscatLaneEventArgs> Play;

        /// <summary>
        /// Event handler for stopping
        /// </summary>
        event EventHandler Stopping;

        /// <summary>
        /// Event handler for stop
        /// </summary>
        event EventHandler Stop;

        /// <summary>
        /// Gets the script files
        /// </summary>
        List<ScriptFile> ScriptFiles { get; }

        /// <summary>
        /// Clears the results
        /// </summary>
        void ClearResults();

        /// <summary>
        /// Perform the playing
        /// </summary>
        void PerformPlaying();

        /// <summary>
        /// Perform play
        /// </summary>
        void PerformPlay();

        /// <summary>
        /// Perform the stopping
        /// </summary>
        void PerformStopping();

        /// <summary>
        /// Perform disable
        /// </summary>
        void PerformDisable();

        /// <summary>
        /// Update event result
        /// </summary>
        /// <param name="e">script event</param>
        void UpdateEventResult(IScriptEvent e);

        /// <summary>
        /// Update warning event result
        /// </summary>
        /// <param name="e">warning event</param>
        void UpdateWarningEventResult(IWarningEvent e);

        /// <summary>
        /// Update script result
        /// </summary>
        /// <param name="s">script to update</param>
        void UpdateScriptResult(IScript s);

        /// <summary>
        /// Update view on connection timeout
        /// </summary>
        /// <param name="error">timeout error</param>
        void UpdateViewOnConnectionTimeout(string error);

        /// <summary>
        /// Initiate cache
        /// </summary>
        /// <param name="e">script event arguments</param>
        void InitiateCache(ScriptEventArgs e);

        /// <summary>
        /// Clears the view
        /// </summary>
        void ClearView();

        /// <summary>
        /// Adds the scripts
        /// </summary>
        /// <param name="scripts">scripts to add</param>
        void AddScript(List<string> scripts);

        /// <summary>
        /// Perform the stop
        /// </summary>
        void PerformStop();

        /// <summary>
        /// Select given script
        /// </summary>
        /// <param name="script">script to select</param>
        void SelectScript(ScriptFile script);
    }
}
