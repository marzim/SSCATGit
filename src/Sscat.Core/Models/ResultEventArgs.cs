// <copyright file="ResultEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;

    /// <summary>
    /// Initializes a new instance of the ResultEventArgs class
    /// </summary>
    public class ResultEventArgs : EventArgs
    {
        /// <summary>
        /// Event result
        /// </summary>
        private Result _result;
        
        /// <summary>
        /// Initializes a new instance of the ResultEventArgs class
        /// </summary>
        /// <param name="result">event result</param>
        public ResultEventArgs(Result result)
        {
            Result = result;
        }

        /// <summary>
        /// Gets or sets the result
        /// </summary>
        public Result Result
        {
            get { return _result; }
            set { _result = value; }
        }
    }
}
