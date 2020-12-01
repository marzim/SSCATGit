// <copyright file="IScotLogHook.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Log
{
    using System;
    using System.Collections.Generic;
    using Ncr.Core.Util;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the IScotLogHook interface
    /// </summary>
    public interface IScotLogHook : ILogHook
    {
        /// <summary>
        /// Event handler for events changed
        /// </summary>
        event EventHandler<ScotLogHookEventArgs> EventsChanged;
        
        /// <summary>
        /// Event handler for checking
        /// </summary>
        event EventHandler<SscatEventArgs> Checking;
        
        /// <summary>
        /// Event handler for warning found
        /// </summary>
        event EventHandler<WarningEventArgs> WarningEventFound;

        /// <summary>
        /// Gets the script events
        /// </summary>
        List<IScriptEvent> Events { get; }

        /// <summary>
        /// Gets the warning events
        /// </summary>
        List<IWarningEvent> WarningEvents { get; }

        /// <summary>
        /// Checks the script event
        /// </summary>
        /// <param name="scriptEvent">script event</param>
        /// <param name="timeout">timeout amount</param>
        /// <returns>Returns the result</returns>
        Result Check(IScriptEvent scriptEvent, int timeout);

        /// <summary>
        /// Checks if script exists
        /// </summary>
        /// <param name="scriptEvent">script event</param>
        /// <param name="lastSimilarEvent">last similar event</param>
        /// <param name="timeout">timeout amount</param>
        /// <returns>Returns true if exists, false otherwise</returns>
        bool Exists(IScriptEvent scriptEvent, out IScriptEvent lastSimilarEvent, int timeout);

        /// <summary>
        /// Clears Warning Events
        /// </summary>
        void ClearWarningEvents();
        
        /// <summary>
        /// Compares the receipt items
        /// </summary>
        /// <param name="scriptEvent">script event</param>
        /// <param name="e">event arguments</param>
        /// <returns>Returns true if found, false otherwise</returns>
        bool CompareReceiptItem(string scriptEvent, string e);

        /// <summary>
        /// Stops the hook
        /// </summary>
        void Stop();
    }
}
