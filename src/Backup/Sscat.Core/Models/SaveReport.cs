// <copyright file="SaveReport.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System.IO;
    using Ncr.Core.Models;

    /// <summary>
    /// Initializes a new instance of the SaveReport class
    /// </summary>
    public class SaveReport : BaseModel<SaveReport>
    {
        /// <summary>
        /// Report file name
        /// </summary>
        private string _reportFilename;

        /// <summary>
        /// Report output directory
        /// </summary>
        private string _reportOutputDirectory;

        /// <summary>
        /// Initializes a new instance of the SaveReport class
        /// </summary>
        public SaveReport()
        {
        }

        /// <summary>
        /// Gets or sets the report file name
        /// </summary>
        public string ReportFilename
        {
            get { return _reportFilename; }
            set { _reportFilename = value; }
        }

        /// <summary>
        /// Gets or sets the report output directory
        /// </summary>
        public string ReportOutputDirectory
        {
            get { return _reportOutputDirectory; }
            set { _reportOutputDirectory = value; }
        }

        /// <summary>
        /// Validates the report file name and whether or not the file already exists
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            AddErrorIf("Report file name contains invalid character(s).", _reportFilename.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0);
            AddErrorIf("Report file name already exists in Report Output Directory", File.Exists(Path.Combine(_reportOutputDirectory, string.Format("{0}.zip", _reportFilename))));
        }
    }
}
