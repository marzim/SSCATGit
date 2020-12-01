// <copyright file="IResponseParser.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    /// <summary>
    /// Initializes a new instance of the IResponseParser interface
    /// </summary>
    public interface IResponseParser
    {
        /// <summary>
        /// Parse the response
        /// </summary>
        /// <param name="response">response to parse</param>
        /// <returns>Returns parsed response</returns>
        Response Parse(string response);

        /// <summary>
        /// Parse the response
        /// </summary>
        /// <param name="response">response to parse</param>
        /// <returns>Returns parsed response</returns>
        Response Parse(object response);
    }
}
