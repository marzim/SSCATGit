// <copyright file="IDeviceEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    /// <summary>
    /// Initializes a new instance of the IDeviceEvent interface
    /// </summary>
    public interface IDeviceEvent : IScriptEventItem
    {
        /// <summary>
        /// Gets or sets the script event ID
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets the script event value
        /// </summary>
        string Value { get; set; }
    }
}
