// <copyright file="PsxControlNotClickableException.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Sscat.Core.Emulators
{
    using System;

    /// <summary>
    /// Initializes a new instance of the PsxControlNotClickableException class
    /// </summary>
    public class PsxControlNotClickableException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the PsxControlNotClickableException class
        /// </summary>
        /// <param name="param">exception parameters</param>
        public PsxControlNotClickableException(string param)
            : base(string.Format("PSX Button {0} was not clickable.", param.ToString().ToString()))
        {
        }
    }
}
