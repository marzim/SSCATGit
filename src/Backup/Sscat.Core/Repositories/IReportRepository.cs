// <copyright file="IReportRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories
{
    using Sscat.Core.Models.Report;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the IReportRepository interface
    /// </summary>
    public interface IReportRepository : IRepository
    {
        /// <summary>
        /// Saves the report
        /// </summary>
        /// <param name="report">report to save</param>
        void Save(Report report);

        /// <summary>
        /// Save report with given text
        /// </summary>
        /// <param name="report">report to save</param>
        /// <param name="text">text to save</param>
        void Save(Report report, string text);

        /// <summary>
        /// Reads the file and returns the report
        /// </summary>
        /// <param name="file">file to read</param>
        /// <returns>Returns the report</returns>
        Report Read(string file);
    }
}
