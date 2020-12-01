// <copyright file="IScriptEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using Ncr.Core.Models;
    using Ncr.Core.Net;
    
    /// <summary>
    /// Interface for the script event class
    /// </summary>
    public interface IScriptEvent : IBaseModel, IContent
    {
        /// <summary>
        /// Event handler for result changed
        /// </summary>
        event EventHandler<ResultEventArgs> ResultChanged;

        /// <summary>
        /// Gets the event type
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets or sets the screenshot link
        /// </summary>
        string ScreenshotLink { get; set; }

        /// <summary>
        /// Gets or sets the script event time
        /// </summary>
        long Time { get; set; }

        /// <summary>
        /// Gets or sets the script event item
        /// </summary>
        object Item { get; set; }

        /// <summary>
        /// Gets or sets the script index
        /// </summary>
        int ScriptIndex { get; set; }

        /// <summary>
        /// Gets or sets the index
        /// </summary>
        int Index { get; set; }

        /// <summary>
        /// Gets or sets the event's sequence id
        /// </summary>
        int SequenceID { get; set; }

        /// <summary>
        /// Gets or sets the script event result
        /// </summary>
        Result Result { get; set; }

        /// <summary>
        /// Gets or sets the new item value
        /// </summary>
        string NewItemValue { get; set; }

        /// <summary>
        /// Gets or sets the script file name
        /// </summary>
        string ScriptFileName { get; set; }

        /// <summary>
        /// Creates the script event item
        /// </summary>
        /// <returns>Returns the script event</returns>
        IScriptEvent ToEvent();
    }
}
