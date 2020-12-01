// <copyright file="IScript.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using Ncr.Core.Models;
    using Ncr.Core.Net;

    /// <summary>
    /// Initializes a new instance of the IScript interface
    /// </summary>
    public interface IScript : IBaseModel, IContent
    {
        /// <summary>
        /// Event handler for the result changed
        /// </summary>
        event EventHandler<ResultEventArgs> ResultChanged;

        /// <summary>
        /// Gets a value indicating whether or not the script has device events
        /// </summary>
        bool HasDeviceEvents { get; }

        /// <summary>
        /// Gets a value indicating whether or not the script is a round trip
        /// </summary>
        bool IsRoundTrip { get; }

        /// <summary>
        /// Gets or sets the script name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the file name
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// Gets or sets the script description
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the date time
        /// </summary>
        string DateTime { get; set; }

        /// <summary>
        /// Gets or sets the version
        /// </summary>
        string Version { get; set; }

        /// <summary>
        /// Gets or sets the SSCAT version
        /// </summary>
        string SscatVersion { get; set; }

        /// <summary>
        /// Gets or sets the SSCO version
        /// </summary>
        string SscoVersion { get; set; }

        /// <summary>
        /// Gets or sets the script index
        /// </summary>
        int Index { get; set; }

        /// <summary>
        /// Gets or sets the script result
        /// </summary>
        Result Result { get; set; }

        /// <summary>
        /// Gets or sets script events
        /// </summary>
        ScriptEvents Events { get; set; }

        /// <summary>
        /// Clear the event results
        /// </summary>
        void ClearResults();

        /// <summary>
        /// Revise all MS cards
        /// </summary>
        /// <param name="nameOfMSCardToUse">name of the MS cards to use</param>
        /// <returns>Returns true if successfully revised, false otherwise</returns>
        bool ReviseAllMSCardsUsedTo(string nameOfMSCardToUse);
    }
}
