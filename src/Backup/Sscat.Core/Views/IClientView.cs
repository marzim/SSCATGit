// <copyright file="IClientView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Views
{
    using System;
    using Ncr.Core.Views;
    using Sscat.Core.Config;
    using Sscat.Core.Emulators;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Net;

    /// <summary>
    /// Initializes a new instance of the IClientView interface
    /// </summary>
    public interface IClientView : IView
    {
        /// <summary>
        /// Event handler for script play
        /// </summary>
        event EventHandler<SscatLaneEventArgs> Play;

        /// <summary>
        /// Event handler for script stop
        /// </summary>
        event EventHandler Stop;

        /// <summary>
        /// Event handler for script generate
        /// </summary>
        event EventHandler<GeneratorConfigurationEventArgs> Generate;

        /// <summary>
        /// Event handler for configuration save
        /// </summary>
        event EventHandler<ClientConfigurationEventArgs> ConfigurationSave;

        /// <summary>
        /// Event handler for configuration restore
        /// </summary>
        event EventHandler ConfigurationRestore;

        /// <summary>
        /// Gets or sets the SSCAT client
        /// </summary>
        SscatClient Client { get; set; }

        /// <summary>
        /// Gets the output view
        /// </summary>
        IOutputView OutputView { get; }

        /// <summary>
        /// Clears the results
        /// </summary>
        void ClearResults();

        /// <summary>
        /// Performs the script stopping
        /// </summary>
        void PerformStopping();

        /// <summary>
        /// Performs the script playing
        /// </summary>
        void PerformPlaying();

        /// <summary>
        /// Performs the script generate
        /// </summary>
        void PerformGenerate();

        /// <summary>
        /// Performs the script generating 
        /// </summary>
        void PerformGenerating();

        /// <summary>
        /// Performs the disable
        /// </summary>
        void PerformDisable();

        /// <summary>
        /// Writes the given text
        /// </summary>
        /// <param name="text">text to write</param>
        void WriteLine(string text);

        /// <summary>
        /// Updates the result
        /// </summary>
        /// <param name="e">script event</param>
        void UpdateResult(IScriptEvent e);

        /// <summary>
        /// Update the warning events
        /// </summary>
        /// <param name="e">warning event</param>
        void UpdateWarning(IWarningEvent e);

        /// <summary>
        /// Updates the result
        /// </summary>
        /// <param name="s">script to update</param>
        void UpdateResult(IScript s);

        /// <summary>
        /// Update view on connection timeout
        /// </summary>
        /// <param name="error">error for timeout</param>
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
        /// Selects the given script
        /// </summary>
        /// <param name="script">script to select</param>
        void SelectScript(ScriptFile script);
    }
}
