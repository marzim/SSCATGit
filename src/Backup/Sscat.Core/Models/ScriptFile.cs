// <copyright file="ScriptFile.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using System.IO;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ScriptFile class
    /// </summary>
    public class ScriptFile
    {
        /// <summary>
        /// Script file
        /// </summary>
        private string _fileName;

        /// <summary>
        /// Script result
        /// </summary>
        private Result _result;

        /// <summary>
        /// Script index
        /// </summary>
        private int _index;

        /// <summary>
        /// Repetition index
        /// </summary>
        private int _repetitionIndex;

        /// <summary>
        /// Initializes a new instance of the ScriptFile class
        /// </summary>
        /// <param name="file">script file</param>
        public ScriptFile(string file)
        {
            File = file;
        }

        /// <summary>
        /// Event handler for result changed event
        /// </summary>
        public event EventHandler<ResultEventArgs> ResultChanged;

        /// <summary>
        /// Gets a value indicating whether or not the cached file exists
        /// </summary>
        public bool HasCacheFile
        {
            get { return FileHelper.Exists(CacheFile); }
        }

        /// <summary>
        /// Gets the cached file
        /// </summary>
        public string CacheFile
        {
            get { return Path.Combine(ApplicationUtility.CacheDirectory, string.Format("playback-{0}-{1}-{2}", _repetitionIndex, _index, Path.GetFileNameWithoutExtension(_fileName))); }
        }

        /// <summary>
        /// Gets or sets the index
        /// </summary>
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        /// <summary>
        /// Gets or sets the repetition index
        /// </summary>
        public int RepetitionIndex
        {
            get { return _repetitionIndex; }
            set { _repetitionIndex = value; }
        }

        /// <summary>
        /// Gets or sets the file name
        /// </summary>
        public string File
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>
        /// Gets or sets the script result
        /// </summary>
        public Result Result
        {
            get
            {
                return _result;
            }

            set
            {
                _result = value;
                OnResultChanged(new ResultEventArgs(_result));
            }
        }

        /// <summary>
        /// Deletes the cached file
        /// </summary>
        public void ClearCache()
        {
            FileHelper.Delete(CacheFile);
        }

        /// <summary>
        /// Event for when the result is changed
        /// </summary>
        /// <param name="e">result event arguments</param>
        protected virtual void OnResultChanged(ResultEventArgs e)
        {
            if (ResultChanged != null)
            {
                ResultChanged(this, e);
            }
        }
    }
}
