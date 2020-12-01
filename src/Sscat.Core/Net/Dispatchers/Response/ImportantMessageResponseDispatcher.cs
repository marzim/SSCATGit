// <copyright file="ImportantMessageResponseDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using Ncr.Core.Net;

    /// <summary>
    /// Initializes a new instance of the ImportantMessageResponseDispatcher class
    /// </summary>
    public class ImportantMessageResponseDispatcher : SscatResponseDispatcher
    {
        /// <summary>
        /// Initializes a new instance of the ImportantMessageResponseDispatcher class
        /// </summary>
        public ImportantMessageResponseDispatcher()
            : base(SscatResponse.IMPT_MESSAGE)
        {
        }

        /// <summary>
        /// Dispatch response
        /// </summary>
        /// <param name="response">response to dispatch</param>
        public override void Dispatch(Response response)
        {
            OnDispatching((response.Content as MessageContent).Message);
        }
    }
}
