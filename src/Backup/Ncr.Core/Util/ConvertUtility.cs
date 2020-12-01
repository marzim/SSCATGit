// <copyright file="ConvertUtility.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Util
{
    using System;

    /// <summary>
    /// Initializes a new instance of the ConvertUtility class
    /// </summary>
    public static class ConvertUtility
    {
        /// <summary>
        /// Convert object into an integer
        /// </summary>
        /// <param name="val">object value</param>
        /// <returns>Returns the integer</returns>
        public static int ToInt32(object val)
        {
            return ToInt32(val, false);
        }

        /// <summary>
        /// Convert object into an integer
        /// </summary>
        /// <param name="val">object value</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>Returns the integer</returns>
        public static int ToInt32(object val, int defaultValue)
        {
            try
            {
                return Convert.ToInt32(val);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Convert object into long
        /// </summary>
        /// <param name="val">object value</param>
        /// <returns>Returns the long value</returns>
        public static long ToInt64(object val)
        {
            return Convert.ToInt64(val);
        }

        /// <summary>
        /// Returns the minimum value
        /// </summary>
        /// <param name="val">value to check</param>
        /// <param name="minimum">minimum value</param>
        /// <returns>Returns the minimum between value and given minimum value</returns>
        public static int Min(int val, int minimum)
        {
            return val > minimum ? minimum : val;
        }

        /// <summary>
        /// Convert object into an integer
        /// </summary>
        /// <param name="val">object value</param>
        /// <param name="throwOnException">whether or not to throw on exception</param>
        /// <returns>Returns the integer</returns>
        public static int ToInt32(object val, bool throwOnException)
        {
            try
            {
                return Convert.ToInt32(val);
            }
            catch
            {
                if (throwOnException)
                {
                    throw;
                }

                return 0;
            }
        }

        /// <summary>
        /// Checks if the value is a valid integer
        /// </summary>
        /// <param name="val">value to check</param>
        /// <returns>Returns true if a value integer</returns>
        public static bool ValidInteger(object val)
        {
            try
            {
                int dummy = Convert.ToInt32(val);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
