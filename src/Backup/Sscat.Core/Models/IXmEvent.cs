// <copyright file="IXmEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    /// <summary>
    /// Interface for Cash management events
    /// </summary>
    public interface IXmEvent : IScriptEventItem
    {
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets the values
        /// </summary>
        string[] Values { get; set; }

        /// <summary>
        /// Gets or sets the value count
        /// </summary>
        int ValueCount { get; set; }
    }
}
