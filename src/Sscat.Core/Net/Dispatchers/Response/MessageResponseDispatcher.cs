// <copyright file="MessageResponseDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using Ncr.Core.Net;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the MessageResponseDispatcher class
    /// </summary>
    public class MessageResponseDispatcher : SscatResponseDispatcher
    {
        /// <summary>
        /// Initializes a new instance of the MessageResponseDispatcher class
        /// </summary>
        public MessageResponseDispatcher()
            : base(SscatResponse.MESSAGE)
        {
        }

        /// <summary>
        /// Dispatch response
        /// </summary>
        /// <param name="response">response to dispatch</param>
        public override void Dispatch(Response response)
        {
            //// SSCAT-1865 Causes crash in Linux
            OnDispatching((response.Content as MessageContent).Message);
        }
    }
}
