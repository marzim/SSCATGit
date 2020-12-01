// <copyright file="ConfigLoadedResponseDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using Ncr.Core.Net;

    /// <summary>
    /// Initializes a new instance of the ConfigLoadedResponseDispatcher class
    /// </summary>
    public class ConfigLoadedResponseDispatcher : SscatResponseDispatcher
    {
        /// <summary>
        /// Initializes a new instance of the ConfigLoadedResponseDispatcher class
        /// </summary>
        public ConfigLoadedResponseDispatcher()
            : base(SscatResponse.CONFIG_LOADED)
        {
        }

        /// <summary>
        /// Dispatch response
        /// </summary>
        /// <param name="response">response to dispatch</param>
        public override void Dispatch(Response response)
        {
            OnConfigLoadedDispatched(null);
        }
    }
}
