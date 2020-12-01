// <copyright file="ScriptEventResponseDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using Ncr.Core.Net;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ScriptEventResponseDispatcher class
    /// </summary>
    public class ScriptEventResponseDispatcher : SscatResponseDispatcher
    {
        /// <summary>
        /// Initializes a new instance of the ScriptEventResponseDispatcher class
        /// </summary>
        public ScriptEventResponseDispatcher()
            : base(SscatResponse.EVENT_RESULT)
        {
        }

        /// <summary>
        /// Dispatch response
        /// </summary>
        /// <param name="response">response to dispatch</param>
        public override void Dispatch(Response response)
        {
            IScriptEvent scriptEvent = response.Content as IScriptEvent;
            OnDispatching(scriptEvent.Result.ToRepresentation());
            OnScriptEventResultDispatched(new ScriptEventEventArgs(scriptEvent));
        }
    }
}
