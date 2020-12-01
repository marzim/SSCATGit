// <copyright file="InvalidUserLoginException.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    using System;

    /// <summary>
    /// Initializes a new instance of the InvalidUserLoginException class
    /// </summary>
    public class InvalidUserLoginException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the InvalidUserLoginException class
        /// </summary>
        public InvalidUserLoginException()
            : base("Incorrect operator number and password. Please check Smart Exit Option")
        {
        }
    }
}
