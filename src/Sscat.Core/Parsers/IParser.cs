// <copyright file="IParser.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Interface for the parser
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Event handler for parse
        /// </summary>
        event EventHandler<ProgressEventArgs> Parse;

        /// <summary>
        /// Gets the name
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Gets a value indicating whether the parser is binary
        /// </summary>
        bool IsBinary { get; }

        /// <summary>
        /// Perform the parse
        /// </summary>
        /// <returns>Returns the script event parsed out</returns>
        List<IScriptEvent> PerformParse();

        /// <summary>
        /// Perform the parse
        /// </summary>
        /// <param name="reader">text reader</param>
        /// <returns>Returns the script event parsed out</returns>
        List<IScriptEvent> PerformParse(IExtendedTextReader reader);

        /// <summary>
        /// Perform the binary parse
        /// </summary>
        /// <returns>Returns the script event parsed out</returns>
        List<IScriptEvent> PerformBinaryParse();

        /// <summary>
        /// Perform the binary parse
        /// </summary>
        /// <param name="stream">File stream</param>
        /// <returns>Returns the script event parsed out</returns>
        List<IScriptEvent> PerformBinaryParse(FileStream stream);

        /// <summary>
        /// Stops the parser
        /// </summary>
        void Stop();

        /// <summary>
        /// Disposes of the parser
        /// </summary>
        void Dispose();
    }
}
