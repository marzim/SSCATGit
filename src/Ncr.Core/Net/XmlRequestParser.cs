// <copyright file="XmlRequestParser.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System.IO;

    /// <summary>
    /// Initializes a new instance of the XmlRequestParser class
    /// </summary>
    public class XmlRequestParser : IRequestParser
    {
        /// <summary>
        /// Parse the request
        /// </summary>
        /// <param name="request">request to parse</param>
        /// <returns>Returns parsed request</returns>
        public Request Parse(string request)
        {
            return Request.Deserialize(new StringReader(request));
        }
    }
}
