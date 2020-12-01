// <copyright file="IUIValidationEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    /// <summary>
    /// Initializes a new instance of the IDeviceEvent interface
    /// </summary>
    public interface IUIValidationEvent : IScriptEventItem
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
        /// Gets or sets the control type
        /// </summary>
        string ControlType { get; set; }

        /// <summary>
        /// Gets or sets the property
        /// </summary>
        string Property { get; set; }

        /// <summary>
        /// Gets or sets the property value
        /// </summary>
        string PropertyValue { get; set; }
    }
}
