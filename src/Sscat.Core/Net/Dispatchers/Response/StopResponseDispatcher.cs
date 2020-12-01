// <copyright file="StopResponseDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net.Dispatchers.Response
{
    using Ncr.Core.Net;
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the StopResponseDispatcher class
    /// </summary>
    public class StopResponseDispatcher : SscatResponseDispatcher
    {
        /// <summary>
        /// Initializes a new instance of the StopResponseDispatcher class
        /// </summary>
        public StopResponseDispatcher()
            : base(SscatResponse.STOPPED)
        {
        }

        /// <summary>
        /// Dispatch response
        /// </summary>
        /// <param name="response">response to dispatch</param>
        public override void Dispatch(Response response)
        {
            OnStopDispatched(null);
        }
    }
}
