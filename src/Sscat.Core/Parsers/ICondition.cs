// <copyright file="ICondition.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers
{
    using System.IO;
    using Ncr.Core.Util;

    /// <summary>
    /// Interface for Condition class
    /// </summary>
    public interface ICondition
    {
        /// <summary>
        /// Checks the condition
        /// </summary>
        /// <param name="filepath">file path</param>
        /// <returns>Returns true if condition is true, false otherwise</returns>
        bool Check(string filepath);
    }
}
