// <copyright file="LaneException.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Emulators
{
    using System;

    /// <summary>
    /// Initializes a new instance of the LaneException class
    /// </summary>
    [Serializable]
    public class LaneException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the LaneException class
        /// </summary>
        /// <param name="message">exception message</param>
        public LaneException(string message)
            : base(message)
        {
        }
    }
}
