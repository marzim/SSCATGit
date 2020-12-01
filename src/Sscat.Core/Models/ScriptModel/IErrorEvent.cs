// <copyright file="IErrorEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    /// <summary>
    /// Initializes a new instance of the IErrorEvent interface
    /// </summary>
    public interface IErrorEvent : IScriptEventItem
    {
        /// <summary>
        /// Gets or sets the event type
        /// </summary>
        string EventType { get; set; }

        /// <summary>
        /// Gets or sets the error notes
        /// </summary>
        string ErrorNotes { get; set; }
    }
}
