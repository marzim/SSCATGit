// <copyright file="ErrorResponseDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using Ncr.Core.Net;

    /// <summary>
    /// Initializes a new instance of the ErrorResponseDispatcher class
    /// </summary>
    public class ErrorResponseDispatcher : SscatResponseDispatcher
    {
        /// <summary>
        /// Initializes a new instance of the ErrorResponseDispatcher class
        /// </summary>
        public ErrorResponseDispatcher()
            : base(SscatResponse.ERROR)
        {
        }

        /// <summary>
        /// Dispatch response
        /// </summary>
        /// <param name="response">response to dispatch</param>
        public override void Dispatch(Response response)
        {
            OnDispatching((response.Content as MessageContent).Message);
            OnErrorDispatched(null);
        }
    }
}
