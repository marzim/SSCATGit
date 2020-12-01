// <copyright file="IsClassicSCO.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers
{
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the IsClassicSCO class
    /// </summary>
    public class IsClassicSCO : Condition
    {
        /// <summary>
        /// Checks the given file path to see if it is NGUI or not
        /// </summary>
        /// <param name="filepath">file path</param>
        /// <returns>Returns true if file path is not NGUI, false otherwise</returns>
        public override bool Check(string filepath)
        {
            return !SSCOHelper.IsNGUI();
        }
    }
}
