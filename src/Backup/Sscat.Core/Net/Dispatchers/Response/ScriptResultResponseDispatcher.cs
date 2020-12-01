// <copyright file="ScriptResultResponseDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using Ncr.Core.Net;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ScriptResultResponseDispatcher class
    /// </summary>
    public class ScriptResultResponseDispatcher : SscatResponseDispatcher
    {
        /// <summary>
        /// Initializes a new instance of the ScriptResultResponseDispatcher class
        /// </summary>
        public ScriptResultResponseDispatcher()
            : base(SscatResponse.SCRIPT_RESULT)
        {
        }

        /// <summary>
        /// Dispatch response
        /// </summary>
        /// <param name="response">response to dispatch</param>
        public override void Dispatch(Response response)
        {
            SSCATScript s = response.Content as SSCATScript;
            OnScriptResultDispatched(new ScriptEventArgs(s));

            if (s.Result.Notes.Equals("SSCO Not found"))
            {
                OnDispatching("Playback stopped due to SSCO not found. Please manually start the SSCO.");
                return;
            }

            ReportPlayback reportPlayback = new ReportPlayback();
            reportPlayback.UpdateReportPlayback(s);
            OnDispatching(string.Format("Saving playback summary report to {0}", reportPlayback.ReportPlaybackFile));
        }
    }
}
