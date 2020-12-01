// <copyright file="IParserPattern.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the IParserPattern interface
    /// </summary>
    public interface IParserPattern
    {
        /// <summary>
        /// Gets the event value
        /// </summary>
        string EventValue { get; }

        /// <summary>
        /// Adds the event
        /// </summary>
        /// <param name="line">line to check</param>
        /// <param name="match">match to check</param>
        /// <param name="reader">extended text reader</param>
        /// <param name="events">script events</param>
        /// <param name="eventValue">event value</param>
        void Add(string line, Match match, IExtendedTextReader reader, List<IScriptEvent> events, string eventValue);

        /// <summary>
        /// Checks match by the given line
        /// </summary>
        /// <param name="line">line to check</param>
        /// <returns>Returns match if found</returns>
        Match Match(string line);
    }
}
