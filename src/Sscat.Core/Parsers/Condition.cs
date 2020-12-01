// <copyright file="Condition.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers
{
    /// <summary>
    /// Initializes a new instance of the Condition class
    /// </summary>
    public abstract class Condition : ICondition
    {
        /// <summary>
        /// Checks the condition
        /// </summary>
        /// <param name="filepath">file path</param>
        /// <returns>Returns true if condition is true, false otherwise</returns>
        public abstract bool Check(string filepath);
    }
}
