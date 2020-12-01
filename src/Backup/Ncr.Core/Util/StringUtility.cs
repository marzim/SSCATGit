// <copyright file="StringUtility.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Initializes static members of the StringUtility class
    /// </summary>
    public static class StringUtility
    {
        /// <summary>
        /// Truncate text
        /// </summary>
        /// <param name="text">text to truncate</param>
        /// <param name="count">text length</param>
        /// <returns>Returns truncated text</returns>
        public static string Truncate(string text, int count)
        {
            return text.Substring(0, count) + "...";
        }

        /// <summary>
        /// Replace text
        /// </summary>
        /// <param name="text">text to do replacement in</param>
        /// <param name="oldValue">old value</param>
        /// <param name="newValue">new value</param>
        /// <returns>Returns new text after replacements</returns>
        public static string Replace(string text, string oldValue, string newValue)
        {
            return text.Replace(oldValue, newValue);
        }

        /// <summary>
        /// Checks if text contains certain pattern
        /// </summary>
        /// <param name="text">text to check</param>
        /// <param name="findtext">text pattern to find</param>
        /// <returns>Returns true if pattern is found, false otherwise</returns>
        public static bool Contains(string text, string findtext)
        {
            if (!text.Equals(string.Empty))
            {
                Match m = Regex.Match(text, findtext, RegexOptions.IgnoreCase);
                if (m.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Converts text to pascal case
        /// </summary>
        /// <param name="str">text to convert</param>
        /// <returns>Returns converted text</returns>
        public static string ToPascalCase(string str)
        {
            return ToWords(str).Replace(" ", string.Empty);
        }

        /// <summary>
        /// Converts text to camel case
        /// </summary>
        /// <param name="str">text to convert</param>
        /// <returns>Returns converted text</returns>
        public static string ToCamelCase(string str)
        {
            char[] ch = ToWords(str).Replace(" ", string.Empty).ToCharArray();
            ch[0] = char.ToLower(ch[0]);
            return new string(ch);
        }

        /// <summary>
        /// Converts text after splitting up by spaces
        /// </summary>
        /// <param name="str">text to convert</param>
        /// <returns>Returns converted text</returns>
        public static string ToWords(string str)
        {
            string[] ss = str.Split(new char[] { ' ' });
            string finalString = string.Empty;
            int i = 0;
            foreach (string s in ss)
            {
                char[] ch = s.Trim().ToCharArray();
                ch[0] = char.ToUpper(ch[0]);
                finalString += new string(ch);
                finalString += (i++ < str.Length - 1) ? " " : string.Empty;
            }

            return finalString;
        }
    }
}
