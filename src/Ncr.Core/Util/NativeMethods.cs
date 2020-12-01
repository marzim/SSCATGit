// <copyright file="NativeMethods.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Initializes static members of the Native methods class
    /// </summary>
    public static class NativeMethods
    {
        /// <summary>
        /// Retrieves the names of all sections in an initialization file.
        /// </summary>
        /// <param name="lpszReturnBuffer">A pointer to a buffer that receives the section names associated with the named file.</param>
        /// <param name="nSize">The size of the buffer pointed to by the ReturnBuffer parameter, in characters.</param>
        /// <param name="lpFileName">The name of the initialization file.</param>
        /// <returns>The return value specifies the number of characters copied to the specified buffer, not including the terminating null character.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetPrivateProfileSectionNames(IntPtr lpszReturnBuffer, uint nSize, string lpFileName);

        /// <summary>
        /// Retrieves a string from the specified section in an initialization file.
        /// </summary>
        /// <param name="lpAppName">The name of the section containing the key name.</param>
        /// <param name="lpKeyName">The name of the key whose associated string is to be retrieved.</param>
        /// <param name="lpDefault">A default string.</param>
        /// <param name="lpReturnedString">A pointer to the buffer that receives the retrieved string.</param>
        /// <param name="nSize">The size of the buffer pointed to by the ReturnedString parameter, in characters.</param>
        /// <param name="lpFileName">The name of the initialization file. </param>
        /// <returns>The return value is the number of characters copied to the buffer, not including the terminating null character.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        /// <summary>
        /// Retrieves a string from the specified section in an initialization file.
        /// </summary>
        /// <param name="lpAppName">The name of the section containing the key name.</param>
        /// <param name="lpKeyName">The name of the key whose associated string is to be retrieved.</param>
        /// <param name="lpDefault">A default string.</param>
        /// <param name="lpReturnedString">A pointer to the buffer that receives the retrieved string.</param>
        /// <param name="nSize">The size of the buffer pointed to by the ReturnedString parameter, in characters.</param>
        /// <param name="lpFileName">The name of the initialization file. </param>
        /// <returns>The return value is the number of characters copied to the buffer, not including the terminating null character.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, [In, Out] char[] lpReturnedString, int nSize, string lpFileName);

        /// <summary>
        /// Retrieves a string from the specified section in an initialization file.
        /// </summary>
        /// <param name="lpAppName">The name of the section containing the key name.</param>
        /// <param name="lpKeyName">The name of the key whose associated string is to be retrieved.</param>
        /// <param name="lpDefault">A default string.</param>
        /// <param name="lpReturnedString">A pointer to the buffer that receives the retrieved string.</param>
        /// <param name="nSize">The size of the buffer pointed to by the ReturnedString parameter, in characters.</param>
        /// <param name="lpFileName">The name of the initialization file. </param>
        /// <returns>The return value is the number of characters copied to the buffer, not including the terminating null character.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, IntPtr lpReturnedString, uint nSize, string lpFileName);

        /// <summary>
        /// Retrieves an integer associated with a key in the specified section of an initialization file.
        /// </summary>
        /// <param name="lpAppName">The name of the section in the initialization file.</param>
        /// <param name="lpKeyName">The name of the key whose value is to be retrieved.</param>
        /// <param name="lpDefault">The default value to return if the key name cannot be found in the initialization file.</param>
        /// <param name="lpFileName">The name of the initialization file.</param>
        /// <returns>The return value is the integer equivalent of the string following the specified key name in the specified initialization file. 
        /// If the key is not found, the return value is the specified default value.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetPrivateProfileInt(string lpAppName, string lpKeyName, int lpDefault, string lpFileName);

        /// <summary>
        /// Retrieves all the keys and values for the specified section of an initialization file.
        /// </summary>
        /// <param name="lpAppName">The name of the section in the initialization file.</param>
        /// <param name="lpReturnedString">A pointer to a buffer that receives the key name and value pairs associated with the named section.</param>
        /// <param name="nSize">The size of the buffer pointed to by the lpReturnedString parameter, in characters.</param>
        /// <param name="lpFileName">The name of the initialization file.</param>
        /// <returns>The return value specifies the number of characters copied to the buffer, not including the terminating null character.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetPrivateProfileSection(string lpAppName, IntPtr lpReturnedString, uint nSize, string lpFileName);

        /// <summary>
        /// Retrieves a string from the specified section in an initialization file.
        /// </summary>
        /// <param name="lpAppName">The name of the section containing the key name.</param>
        /// <param name="lpKeyName">The name of the key whose associated string is to be retrieved.</param>
        /// <param name="lpValue">The Value of the string to write</param>
        /// <param name="lpFileName">The name of the initialization file. </param>
        /// <returns>The return value is the number of characters copied to the buffer, not including the terminating null character.</returns>
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern long WritePrivateProfileString(string lpAppName, string lpKeyName, string lpValue, string lpFileName);
    }
}
