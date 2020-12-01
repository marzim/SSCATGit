// <copyright file="IWarningEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using Ncr.Core.Net;

    /// <summary>
    /// Initializes a new instance of the IWarningEvent interface
    /// </summary>
    public interface IWarningEvent : IScriptEventItem, IContent
    {
        /// <summary>
        /// Gets or sets the event type
        /// </summary>
        string EventType { get; set; }

        /// <summary>
        /// Gets or sets the warning notes
        /// </summary>
        string WarningNotes { get; set; }
    }
}
