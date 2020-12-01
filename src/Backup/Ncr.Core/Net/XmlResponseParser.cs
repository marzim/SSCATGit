// <copyright file="XmlResponseParser.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System.IO;

    /// <summary>
    /// Initializes a new instance of the XmlResponseParser class
    /// </summary>
    public class XmlResponseParser : IResponseParser
    {
        /// <summary>
        /// Parse the response
        /// </summary>
        /// <param name="response">response to parse</param>
        /// <returns>Returns parsed response</returns>
        public Response Parse(string response)
        {
            return Response.Deserialize(new StringReader(response));
        }

        /// <summary>
        /// Parse the response
        /// </summary>
        /// <param name="response">response to parse</param>
        /// <returns>Returns parsed response</returns>
        public Response Parse(object response)
        {
            return Response.Deserialize(new StringReader((string)response));
        }
    }
}
