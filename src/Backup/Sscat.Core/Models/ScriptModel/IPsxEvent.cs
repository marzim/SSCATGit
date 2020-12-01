// <copyright file="IPsxEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Ncr.Core.Util;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the IPsxEvent interface
    /// </summary>
    public interface IPsxEvent : IScriptEventItem
    {
        /// <summary>
        /// Gets or sets the event ID
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets the context name
        /// </summary>
        string Context { get; set; }

        /// <summary>
        /// Gets or sets the control name
        /// </summary>
        string Control { get; set; }

        /// <summary>
        /// Gets or sets the event name
        /// </summary>
        string Event { get; set; }

        /// <summary>
        /// Gets or sets the remote connection name
        /// </summary>
        string RemoteConnection { get; set; }

        /// <summary>
        /// Gets or sets the event parameters
        /// </summary>
        string Param { get; set; }

        /// <summary>
        /// Gets a value indicating whether it is an exempted launch pad psx event
        /// </summary>
        bool ExemptedLaunchPadPsxEvent { get; }

        /// <summary>
        /// Gets a value indicating whether it has a RAP connection
        /// </summary>
        bool HasRapConnection { get; }

        /// <summary>
        /// Absolute connection name
        /// </summary>
        /// <returns>Returns the connection name</returns>
        string AbsoluteConnectionName();
    }
}
