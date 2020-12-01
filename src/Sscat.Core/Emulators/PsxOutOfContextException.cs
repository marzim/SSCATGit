// <copyright file="PsxOutOfContextException.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    using System;

    /// <summary>
    /// Initializes a new instance of the PsxOutOfContextException class
    /// </summary>
    public class PsxOutOfContextException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the PsxOutOfContextException class 
        /// </summary>
        /// <param name="context">error context</param>
        /// <param name="seqId">sequence ID</param>
        public PsxOutOfContextException(string context, int seqId) :
            base(string.Format("Psx Out of Context Error on {0} at sequence #{1}", context, seqId))
        {
        }
    }
}
