// <copyright file="ResourceUtility.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System.Globalization;
    using System.Reflection;
    using System.Resources;

    /// <summary>
    /// Initializes a new instance of the ResourceUtility class
    /// </summary>
    public static class ResourceUtility
    {
        /// <summary>
        /// Resource manager
        /// </summary>
        private static ResourceManager _manager;

        /// <summary>
        /// Initializes static members of the ResourceUtility class
        /// </summary>
        static ResourceUtility()
        {
            _manager = new ResourceManager("Sscat.Core.Resources", Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Get the string
        /// </summary>
        /// <param name="key">resource key</param>
        /// <returns>Returns the string from the key</returns>
        public static string GetString(string key)
        {
            return GetString(key, string.Empty);
        }

        /// <summary>
        /// Gets the string from a key and definition
        /// </summary>
        /// <param name="key">resource key</param>
        /// <param name="def">resource definition</param>
        /// <returns>Returns the string from the key, otherwise returns the definition</returns>
        public static string GetString(string key, string def)
        {
            try
            {
                return _manager.GetString(key, CultureInfo.CurrentCulture);
            }
            catch
            {
                return def;
            }
        }
    }
}
