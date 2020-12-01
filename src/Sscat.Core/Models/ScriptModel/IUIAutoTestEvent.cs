// <copyright file="IUIAutoTestEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    /// <summary>
    /// Interface for the UI auto test events
    /// </summary>
    public interface IUIAutoTestEvent : IScriptEventItem
    {
        /// <summary>
        /// Gets or sets the event type
        /// </summary>
        string EventType { get; set; }

        /// <summary>
        /// Gets or sets the context name
        /// </summary>
        string ContextName { get; set; }

        /// <summary>
        /// Gets or sets the control name
        /// </summary>
        string ControlName { get; set; }

        /// <summary>
        /// Gets or sets the button name
        /// </summary>
        string ButtonName { get; set; }
        
        /// <summary>
        /// Gets or sets the button data
        /// </summary>
        string ButtonData { get; set; }

        /// <summary>
        /// Gets or sets the index
        /// </summary>
        string Index { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the script event is a valid login
        /// </summary>
        string ValidLogin { get; set; }
    }
}
