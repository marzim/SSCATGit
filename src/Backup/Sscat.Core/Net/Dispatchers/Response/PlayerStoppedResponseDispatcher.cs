// <copyright file="PlayerStoppedResponseDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using Ncr.Core.Net;

    /// <summary>
    /// Initializes a new instance of the PlayerStoppedResponseDispatcher class
    /// </summary>
    public class PlayerStoppedResponseDispatcher : SscatResponseDispatcher
    {
        /// <summary>
        /// Initializes a new instance of the PlayerStoppedResponseDispatcher class
        /// </summary>
        public PlayerStoppedResponseDispatcher()
            : base(SscatResponse.PLAYER_STOPPED)
        {
        }

        /// <summary>
        /// Dispatch response
        /// </summary>
        /// <param name="response">response to dispatch</param>
        public override void Dispatch(Response response)
        {
        }
    }
}
