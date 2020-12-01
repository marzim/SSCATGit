// <copyright file="ArrayHelper.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    /// <summary>
    /// Initializes a new instance of the ConsoleCommand class
    /// </summary>
    public static class ArrayHelper
    {
        /// <summary>
        /// Gets the argument at a given index
        /// </summary>
        /// <param name="args">arguments to check</param>
        /// <param name="index">index of the argument</param>
        /// <returns>Returns the argument at the given index</returns>
        public static string GetValue(string[] args, int index)
        {
            if (index < args.Length)
            {
                return args[index];
            }

            return string.Empty;
        }
    }
}
