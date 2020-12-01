// <copyright file="ISscatResponseDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using System;
    using Ncr.Core;
    using Ncr.Core.Net;
    using Sscat.Core.Config;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ISscatResponseDispatcher interface
    /// </summary>
    public interface ISscatResponseDispatcher : IResponseDispatcher
    {
        /// <summary>
        /// Event handler for scripts dispatched
        /// </summary>
        event EventHandler ScriptsDispatched;

        /// <summary>
        /// Event handler for the script event result dispatched
        /// </summary>
        event EventHandler<ScriptEventEventArgs> ScriptEventResultDispatched;
        
        /// <summary>
        /// Event handler for warning event result dispatched
        /// </summary>
        event EventHandler<WarningEventArgs> ScriptWarningEventResultDispatched;

        /// <summary>
        /// Event handler for script result dispatched
        /// </summary>
        event EventHandler<ScriptEventArgs> ScriptResultDispatched;

        /// <summary>
        /// Event handler for configurations loaded dispatched
        /// </summary>
        event EventHandler ConfigLoadedDispatched;

        /// <summary>
        /// Event handler for configurations checked dispatched
        /// </summary>
        event EventHandler<ConfigFileEventArgs> ConfigCheckedDispatched;

        /// <summary>
        /// Event handler for configurations dispatched
        /// </summary>
        event EventHandler<ConfigFileEventArgs> ConfigDispatched;

        /// <summary>
        /// Event handler for stop dispatched
        /// </summary>
        event EventHandler StopDispatched;

        /// <summary>
        /// Event handler for report dispatched
        /// </summary>
        event EventHandler<ReportEventArgs> ReportDispatched;

        /// <summary>
        /// Event handler for response dispatched
        /// </summary>
        event EventHandler<NcrEventArgs> ResponseDispatched;

        /// <summary>
        /// Event handler for configurations changed dispatched
        /// </summary>
        event EventHandler ConfigurationChangedDispatched;
    }
}
