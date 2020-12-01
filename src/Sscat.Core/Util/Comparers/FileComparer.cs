// <copyright file="FileComparer.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System;
    using System.IO;
    
    /// <summary>
    /// Initializes a new instance of the FileComparer class
    /// </summary>
    public static class FileComparer
    {
        /// <summary>
        /// Compares two files to see if they are the same size
        /// </summary>
        /// <param name="file1">first file</param>
        /// <param name="file2">second file</param>
        /// <returns>Returns true if the same, false otherwise</returns>
        public static bool Compare(string file1, string file2)
        {
            FileStream fs1 = new FileStream(file1, FileMode.Open);
            FileStream fs2 = new FileStream(file2, FileMode.Open);
            try
            {
                int file1Byte;
                int file2Byte;

                do
                {
                    file1Byte = fs1.ReadByte();
                    file2Byte = fs2.ReadByte();
                } 
                while ((file1Byte == file2Byte) && (file1Byte != -1));

                return (file1Byte - file2Byte) == 0;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                fs1.Flush();
                fs1.Close();
                fs2.Flush();
                fs2.Close();
            }
        }
    }
}
