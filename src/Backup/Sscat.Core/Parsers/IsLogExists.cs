// <copyright file="IsLogExists.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers
{
    using Ncr.Core.Util;
    
    /// <summary>
    /// Initializes a new instance of the IsLogExists class
    /// </summary>
    public class IsLogExists : Condition
    {
        /// <summary>
        /// Checks if the file path exists
        /// </summary>
        /// <param name="filepath">file path</param>
        /// <returns>Returns true if exists, false otherwise</returns>
        public override bool Check(string filepath)
        {
            return FileHelper.Exists(filepath);
        }
    }
}
