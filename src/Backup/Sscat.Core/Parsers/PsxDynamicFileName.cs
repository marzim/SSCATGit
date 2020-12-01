// <copyright file="PsxDynamicFileName.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers
{
    using System.IO;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the PsxDynamicFileName class
    /// </summary>
    public class PsxDynamicFileName : IDynamicFileName
    {
        /// <summary>
        /// PSX Dynamic file directory
        /// </summary>
        private string _directory;

        /// <summary>
        /// Gets a value indicating whether the file has a directory
        /// </summary>
        public bool HasDirectory
        {
            get { return _directory != null && _directory != string.Empty; }
        }

        /// <summary>
        /// Gets or sets the directory
        /// </summary>
        public string Directory
        {
            get { return _directory; }
            set { _directory = value; }
        }

        /// <summary>
        /// Gets the file name
        /// </summary>
        public string FileName
        {
            get
            {
                if (HasDirectory)
                {
                    if (FileHelper.Exists(Path.Combine(_directory, @"psx_ScotAppU.log")))
                    {
                        return Path.Combine(_directory, @"psx_ScotAppU.log");
                    }
                    else
                    {
                        return Path.Combine(_directory, @"psx_ScotApp.log");
                    }
                }

                return SscatContext.Lane.GetPsxLogFile();
            }
        }
    }
}
