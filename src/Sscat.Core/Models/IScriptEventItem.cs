// <copyright file="IScriptEventItem.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using Ncr.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Interface for the script event item
    /// </summary>
    public interface IScriptEventItem : IBaseModel, ISequential, IStimulus
    {
        /// <summary>
        /// Gets the type of event
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets or sets a value indicating whether or not script event is forgivable
        /// </summary>
        bool IsForgivable { get; set; }

        /// <summary>
        /// Gets a value indicating whether or not script event is exempted
        /// </summary>
        bool IsExempted { get; }

        /// <summary>
        /// Checks if the event item given is same type as script event
        /// </summary>
        /// <param name="eventItemToCompareWith">event item to compare with</param>
        /// <returns>Returns true if event item type is the same, false otherwise</returns>
        bool IsSimilarEventItemWith(IScriptEventItem eventItemToCompareWith);

        /// <summary>
        /// Creates the script event
        /// </summary>
        /// <returns>Returns the script event</returns>
        IScriptEvent CreateEvent();

        /// <summary>
        /// Creates the script event
        /// </summary>
        /// <param name="time">time of the event</param>
        /// <param name="enabled">whether or not it is enabled</param>
        /// <returns>Returns the script event</returns>
        IScriptEvent CreateEvent(long time, bool enabled);

        /// <summary>
        /// Creates the script event
        /// </summary>
        /// <param name="time">time of the event</param>
        /// <param name="dateTime">date and time</param>
        /// <param name="enabled">whether or not it is enabled</param>
        /// <returns>Returns the script event</returns>
        IScriptEvent CreateEvent(long time, DateTime dateTime, bool enabled);

        /// <summary>
        /// Creates the script event item
        /// </summary>
        /// <returns>Returns the script event</returns>
        IScriptEventItem ToEventItem();
    }
}
