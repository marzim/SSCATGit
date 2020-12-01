// <copyright file="IDynamicFileName.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers
{
    /// <summary>
    /// Interface for Dynamic File Name
    /// </summary>
    public interface IDynamicFileName
    {
        /// <summary>
        /// Gets the file name
        /// </summary>
        string FileName { get; }

        /// <summary>
        /// Gets or sets the directory
        /// </summary>
        string Directory { get; set; }
    }
}
