// <copyright file="ReceiptItemException.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    using System;

    /// <summary>
    /// Initializes a new instance of the ReceiptItemException class
    /// </summary>
    public class ReceiptItemException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the ReceiptItemException class
        /// </summary>
        /// <param name="error">error message</param>
        public ReceiptItemException(string error)
            : base(string.Format("Receipt Item Exception: {0}", error))
        {
        }
    }
}
