// <copyright file="Application7ZipNotFoundException.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;

    /// <summary>
    /// Initializes a new instance of the Application7ZipNotFoundException class
    /// </summary>
    public class Application7ZipNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the Application7ZipNotFoundException class
        /// </summary>
        /// <param name="message">exception message</param>
        public Application7ZipNotFoundException(string message)
            : base(message)
        {
        }
    }
}
