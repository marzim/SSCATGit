// <copyright file="ErrorMessageCollection.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Initializes a new instance of the ErrorMessageCollection class
    /// </summary>
    [Serializable]
    public class ErrorMessageCollection : List<ErrorMessage>
    {
        /// <summary>
        /// Adds the message
        /// </summary>
        /// <param name="message">error message</param>
        public void Add(string message)
        {
            Add(new ErrorMessage(message));
        }

        /// <summary>
        /// Formats the error message string
        /// </summary>
        /// <returns>Returns the formatted string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (ErrorMessage msg in this)
            {
                if (sb.Length > 0)
                {
                    sb.Append(Environment.NewLine);
                }

                sb.Append(msg.ToString());
            }

            return sb.ToString();
        }
    }
}
