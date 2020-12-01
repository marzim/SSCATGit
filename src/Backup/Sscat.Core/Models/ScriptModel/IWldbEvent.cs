// <copyright file="IWldbEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    /// <summary>
    /// Interface for weight learning database events
    /// </summary>
    public interface IWldbEvent : IScriptEventItem
    {
        /// <summary>
        /// Gets or sets the action
        /// </summary>
        string Action { get; set; }

        /// <summary>
        /// Gets or sets the host
        /// </summary>
        string Host { get; set; }

        /// <summary>
        /// Gets or sets the WLDB file
        /// </summary>
        string WldbFile { get; set; }

        /// <summary>
        /// Gets or sets the security agent  config file
        /// </summary>
        string SAConfigFile { get; set; }

        /// <summary>
        /// Gets or sets the script file name
        /// </summary>
        string ScriptFileName { get; set; }

        /// <summary>
        /// Gets or sets the user name
        /// </summary>
        string User { get; set; }

        /// <summary>
        /// Gets or sets the password
        /// </summary>
        string Password { get; set; }
    }
}
