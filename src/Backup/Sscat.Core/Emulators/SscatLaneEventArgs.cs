// <copyright file="SscatLaneEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    using System;
    using System.Collections.Generic;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the SscatLaneEventArgs class
    /// </summary>
    public class SscatLaneEventArgs : EventArgs
    {
        /// <summary>
        /// Script files
        /// </summary>
        private List<ScriptFile> _scriptFiles = new List<ScriptFile>();

        /// <summary>
        /// Repeat amount
        /// </summary>
        private int _repeat;

        /// <summary>
        /// Custom Report file name
        /// </summary>
        private string _customReportFileName;
        
        /// <summary>
        /// Initializes a new instance of the SscatLaneEventArgs class 
        /// </summary>
        /// <param name="scriptFiles">script files</param>
        /// <param name="repeat">repeat amount</param>
        /// <param name="customReportFileName">custom report file name</param>
        public SscatLaneEventArgs(List<ScriptFile> scriptFiles, int repeat, string customReportFileName)
        {
            ScriptFiles = scriptFiles;
            Repeat = repeat;
            CustomReportFileName = customReportFileName;
        }

        /// <summary>
        /// Initializes a new instance of the SscatLaneEventArgs class 
        /// </summary>
        /// <param name="scriptFiles">script files</param>
        /// <param name="repeat">repeat amount</param>
        public SscatLaneEventArgs(List<ScriptFile> scriptFiles, int repeat)
        {
            ScriptFiles = scriptFiles;
            Repeat = repeat;
        }

        /// <summary>
        /// Initializes a new instance of the SscatLaneEventArgs class 
        /// </summary>
        /// <param name="scriptFiles">script files</param>
        public SscatLaneEventArgs(List<ScriptFile> scriptFiles)
            : this(scriptFiles, 1)
        {
        }

        /// <summary>
        /// Gets or sets the custom report file name
        /// </summary>
        public string CustomReportFileName
        {
            get { return _customReportFileName; }
            set { _customReportFileName = value; }
        }

        /// <summary>
        /// Gets or sets the repeat amount
        /// </summary>
        public int Repeat
        {
            get { return _repeat; }
            set { _repeat = value; }
        }

        /// <summary>
        /// Gets or sets the script files
        /// </summary>
        public List<ScriptFile> ScriptFiles
        {
            get { return _scriptFiles; }
            set { _scriptFiles = value; }
        }
    }
}
