// <copyright file="StopPlayerRequestDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using Ncr.Core.Net;

    /// <summary>
    /// Initializes a new instance of the StopPlayerRequestDispatcher class
    /// </summary>
    public class StopPlayerRequestDispatcher : SscatRequestDispatcher
    {
        /// <summary>
        /// Initializes a new instance of the StopPlayerRequestDispatcher class
        /// </summary>
        public StopPlayerRequestDispatcher()
            : base(SscatRequest.STOP_PLAYER)
        {
        }

        /// <summary>
        /// Dispatch request
        /// </summary>
        /// <param name="request">request to dispatch</param>
        public override void Dispatch(Request request)
        {
            OnDispatching("Stopping server request dispatch");
            Server.StopDispatching();
            OnDispatched(request.CreateResponse(SscatResponse.PLAYER_STOPPED, new MessageContent(string.Empty)));
        }
    }
}
