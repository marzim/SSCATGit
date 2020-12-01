// <copyright file="XmlReportRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories.Xml
{
    using System.IO;
    using Ncr.Core.Util;
    using Sscat.Core.Models.Report;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the XmlReportRepository class
    /// </summary>
    public class XmlReportRepository : BaseXmlRepository<Report>, IReportRepository
    {
        /// <summary>
        /// Save the report
        /// </summary>
        /// <param name="report">report to save</param>
        public void Save(Report report)
        {
            DirectoryHelper.CreateDirectory(Path.GetDirectoryName(report.FileName));
            OnAccessing(string.Format("Saving report to {0}...", report.FileName));
            Serialize(report.FileName, report);
        }

        /// <summary>
        /// Save the report
        /// </summary>
        /// <param name="report">report to save</param>
        /// <param name="text">text to save to report</param>
        public void Save(Report report, string text)
        {
            DirectoryHelper.CreateDirectory(Path.GetDirectoryName(report.FileName));
            OnAccessing(string.Format("Saving report to {0}...", report.FileName));
            Serialize(report.FileName, text, report);
        }

        /// <summary>
        /// Read the file
        /// </summary>
        /// <param name="file">file to read</param>
        /// <returns>Returns the report</returns>
        public Report Read(string file)
        {
            return Deserialize(file);
        }
    }
}
