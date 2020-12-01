// <copyright file="IApplicationLauncherEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    /// <summary>
    /// Interface for the application launcher event
    /// </summary>
    public interface IApplicationLauncherEvent : IScriptEventItem
    {
        /// <summary>
        /// Gets or sets the script file name
        /// </summary>
        string ScriptFileName { get; set; }

        /// <summary>
        /// Gets or sets the host name
        /// </summary>
        string Host { get; set; }

        /// <summary>
        /// Gets or sets the application path
        /// </summary>
        string ApplicationPath { get; set; }
    }
}
