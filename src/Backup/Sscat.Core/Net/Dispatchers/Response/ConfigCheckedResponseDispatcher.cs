// <copyright file="ConfigCheckedResponseDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using Ncr.Core.Net;
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the ConfigCheckedResponseDispatcher class
    /// </summary>
    public class ConfigCheckedResponseDispatcher : SscatResponseDispatcher
    {
        /// <summary>
        /// Initializes a new instance of the ConfigCheckedResponseDispatcher class
        /// </summary>
        public ConfigCheckedResponseDispatcher()
            : base(SscatResponse.CONFIG_CHECKED)
        {
        }

        /// <summary>
        /// Dispatch response
        /// </summary>
        /// <param name="response">response to dispatch</param>
        public override void Dispatch(Response response)
        {
            ConfigFile file = response.Content as ConfigFile;
            OnConfigCheckedDispatched(new ConfigFileEventArgs(file));
        }
    }
}
