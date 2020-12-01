// <copyright file="ScriptComparer.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System.Collections.Generic;
    using Sscat.Core.Models.ScriptModel;
    
    /// <summary>
    /// Initializes a new instance of the ScriptComparer class
    /// </summary>
    public class ScriptComparer : IComparer<IScript>
    {
        /// <summary>
        /// Compares two script names
        /// </summary>
        /// <param name="x">script one</param>
        /// <param name="y">script two</param>
        /// <returns>Return a numeric comparer result between the two script names</returns>
        public int Compare(IScript x, IScript y)
        {
            return new NumericComparer().Compare(x.FileName, y.FileName);
        }
    }
}
