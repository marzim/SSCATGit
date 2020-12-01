// <copyright file="ReportResponseDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using Ncr.Core.Net;
    using Sscat.Core.Models.Report;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Repositories;

    /// <summary>
    /// Initializes a new instance of the ReportResponseDispatcher class
    /// </summary>
    public class ReportResponseDispatcher : SscatResponseDispatcher
    {
        /// <summary>
        /// Interface for Report data access object
        /// </summary>
        private IReportRepository _reportDao;

        /// <summary>
        /// Initializes a new instance of the ReportResponseDispatcher class
        /// </summary>
        /// <param name="reportRepository">report repository</param>
        public ReportResponseDispatcher(IReportRepository reportRepository)
            : base(SscatResponse.PLAYBACK)
        {
            _reportDao = reportRepository;
        }

        /// <summary>
        /// Dispatch response
        /// </summary>
        /// <param name="response">response to dispatch</param>
        public override void Dispatch(Response response)
        {
            Report report = response.Content as Report;
            string text = @"type='text/xsl' href='C:\SSCAT\Config\SSCATPlayback.xsl'";
            _reportDao.Save(report, text);
            OnReportDispatched(null);
        }
    }
}
