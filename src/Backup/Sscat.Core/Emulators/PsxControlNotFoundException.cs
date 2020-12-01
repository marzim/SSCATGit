// <copyright file="PsxControlNotFoundException.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    using System;

    /// <summary>
    /// Initializes a new instance of the PsxControlNotFoundException class
    /// </summary>
    public class PsxControlNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the PsxControlNotFoundException class
        /// </summary>
        /// <param name="param">exception parameters</param>
        public PsxControlNotFoundException(string param)
            : base(string.Format("PSX Button {0} Not Found.", param.ToString().Trim()))
        {
        }
    }
}
