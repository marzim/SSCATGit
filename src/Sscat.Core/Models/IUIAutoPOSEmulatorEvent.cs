// <copyright file="IUIAutoPOSEmulatorEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    /// <summary>
    /// Interface for the auto POS emulator events
    /// </summary>
    public interface IUIAutoPOSEmulatorEvent : IScriptEventItem
    {
        /// <summary>
        /// Gets or sets the event type
        /// </summary>
        string EventType { get; set; }

        /// <summary>
        /// Gets or sets the control name
        /// </summary>
        string ControlName { get; set; }

        /// <summary>
        /// Gets or sets the button name
        /// </summary>
        string ButtonName { get; set; }

        /// <summary>
        /// Gets or sets the context name
        /// </summary>
        string ContextName { get; set; }
    }
}
