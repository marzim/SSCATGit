// <copyright file="IUIValidationEvents.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    /// <summary>
    /// Initializes a new instance of the IUIValidationEvents interface
    /// </summary>
    public interface IUIValidationEvents : IScriptEventItem
    {
        /// <summary>
        /// Gets or sets the script event ID
        /// </summary>
        UIValidationEvent[] UIValidationEvnts { get; set; }
    }
}
