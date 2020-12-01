// <copyright file="IRequestParser.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    /// <summary>
    /// Initializes a new instance of the IRequestParser interface
    /// </summary>
    public interface IRequestParser
    {
        /// <summary>
        /// Parse the request
        /// </summary>
        /// <param name="request">request to parse</param>
        /// <returns>Returns parsed request</returns>
        Request Parse(string request);
    }
}
