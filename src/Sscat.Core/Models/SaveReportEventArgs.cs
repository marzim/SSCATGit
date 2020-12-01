// <copyright file="SaveReportEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;

    /// <summary>
    /// Initializes a new instance of the SaveReportEventArgs class
    /// </summary>
    public class SaveReportEventArgs : EventArgs
    {
        /// <summary>
        /// Save report information
        /// </summary>
        private SaveReport _saveReportInfo;

        /// <summary>
        /// Initializes a new instance of the SaveReportEventArgs class
        /// </summary>
        /// <param name="saveReportInfo">save report information</param>
        public SaveReportEventArgs(SaveReport saveReportInfo)
        {
            SaveReportInfo = saveReportInfo;
        }

        /// <summary>
        /// Gets or sets the save report information
        /// </summary>
        public SaveReport SaveReportInfo
        {
            get { return _saveReportInfo; }
            set { _saveReportInfo = value; }
        }
    }
}
