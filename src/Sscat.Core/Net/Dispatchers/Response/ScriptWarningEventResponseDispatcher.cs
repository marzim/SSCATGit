// <copyright file="ScriptWarningEventResponseDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using Ncr.Core.Net;
    using Ncr.Core.Util;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ScriptWarningEventResponseDispatcher class
    /// </summary>
    public class ScriptWarningEventResponseDispatcher : SscatResponseDispatcher
    {
        /// <summary>
        /// Initializes a new instance of the ScriptWarningEventResponseDispatcher class
        /// </summary>
        public ScriptWarningEventResponseDispatcher()
            : base(SscatResponse.WARNING_EVENT_RESULT)
        {
        }

        /// <summary>
        /// Dispatch response
        /// </summary>
        /// <param name="response">response to dispatch</param>
        public override void Dispatch(Response response)
        {
            IWarningEvent warningEvent = response.Content as IWarningEvent;
            OnScriptWarningEventResultDispatched(new WarningEventArgs(warningEvent));
        }
    }
}
