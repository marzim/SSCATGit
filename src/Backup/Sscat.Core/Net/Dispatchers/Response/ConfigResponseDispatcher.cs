// <copyright file="ConfigResponseDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using Ncr.Core;
    using Ncr.Core.Net;
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the ConfigResponseDispatcher class
    /// </summary>
    public class ConfigResponseDispatcher : SscatResponseDispatcher
    {
        /// <summary>
        /// Initializes a new instance of the ConfigResponseDispatcher class
        /// </summary>
        public ConfigResponseDispatcher()
            : base(SscatResponse.CONFIGS)
        {
        }

        /// <summary>
        /// Dispatch response
        /// </summary>
        /// <param name="response">response to dispatch</param>
        public override void Dispatch(Response response)
        {
            ConfigFiles c = response.Content as ConfigFiles;
            foreach (ConfigFile file in c.Files)
            {
                OnConfigDispatched(new ConfigFileEventArgs(file));
                OnDispatching(new NcrEventArgs(file.Name));
            }
        }
    }
}
