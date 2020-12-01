// <copyright file="UpdateWldbRequestDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using Ncr.Core.Net;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the UpdateWldbRequestDispatcher class
    /// </summary>
    public class UpdateWldbRequestDispatcher : SscatRequestDispatcher
    {
        /// <summary>
        /// Initializes a new instance of the UpdateWldbRequestDispatcher class
        /// </summary>
        public UpdateWldbRequestDispatcher()
            : base(SscatRequest.UPDATE_WLDB)
        {
        }

        /// <summary>
        /// Dispatch request
        /// </summary>
        /// <param name="request">request to dispatch</param>
        public override void Dispatch(Request request)
        {
            OnDispatched(request.CreateResponse(SscatResponse.EVENT_RESULT, new Result(ResultType.Passed, "OK")));
        }
    }
}
