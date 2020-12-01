// <copyright file="IUtilityEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    /// <summary>
    /// Interface for the utility events
    /// </summary>
    public interface IUtilityEvent : IScriptEventItem
    {
        /// <summary>
        /// Gets or sets the event type
        /// </summary>
        string EventType { get; set; }

        /// <summary>
        /// Gets or sets the context name
        /// </summary>
        string Value { get; set; }
    }
}
