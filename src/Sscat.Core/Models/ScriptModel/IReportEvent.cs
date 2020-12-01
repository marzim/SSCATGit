// <copyright file="IReportEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;

    /// <summary>
    /// Initializes a new instance of the IReportEvent interface
    /// </summary>
    public interface IReportEvent : IScriptEventItem
    {
        /// <summary>
        /// Gets or sets the event ID
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets the event value
        /// </summary>
        string Value { get; set; }

        /// <summary>
        /// Event detail
        /// </summary>
        /// <returns>Returns the event detail</returns>
        string EventDetail();
    }
}
