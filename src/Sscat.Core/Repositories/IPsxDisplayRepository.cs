// <copyright file="IPsxDisplayRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories
{
    using Sscat.Core.Models.PsxDisplay;

    /// <summary>
    /// Initializes a new instance of the IPsxDisplayRepository interface
    /// </summary>
    public interface IPsxDisplayRepository : IRepository
    {
        /// <summary>
        /// Loads the context
        /// </summary>
        /// <param name="context">context name</param>
        /// <returns>Returns the PSX display</returns>
        PsxDisplay Load(string context);

        /// <summary>
        /// Reads the file
        /// </summary>
        /// <param name="file">file to read</param>
        /// <returns>Returns the PSX display</returns>
        PsxDisplay Read(string file);
    }
}
