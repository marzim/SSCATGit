// <copyright file="EncodingUtility.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Initializes a new instance of the EncodingUtility class
    /// </summary>
    public static class EncodingUtility
    {
        /// <summary>
        /// Gets the file encoding
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns>Returns the encoding</returns>
        public static Encoding GetFileEncoding(string filePath)
        {
            try
            {
                Encoding unicode = null;
                FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                if (stream.CanSeek)
                {
                    byte[] buffer = new byte[4];
                    stream.Read(buffer, 0, 4);
                    if ((((((buffer[0] == 0x20) && (buffer[1] == 0)) && ((buffer[2] == 0x20) && (buffer[3] == 0))) || (((buffer[0] != 0) && (buffer[1] == 0)) && ((buffer[2] != 0) && (buffer[3] == 0)))) || (((buffer[0] == 0xff) && (buffer[1] == 0xfe)) || ((buffer[0] == 0xfe) && (buffer[1] == 0xff)))) || ((((buffer[0] == 0xef) && (buffer[1] == 0xbb)) && (buffer[2] == 0xbf)) || (((buffer[0] == 0) && (buffer[1] == 0)) && ((buffer[2] == 0xfe) && (buffer[3] == 0xff)))))
                    {
                        unicode = Encoding.Unicode;
                    }
                    else
                    {
                        unicode = Encoding.UTF8;
                    }

                    stream.Seek(0L, SeekOrigin.Begin);
                }
                else
                {
                    unicode = Encoding.UTF8;
                }

                stream.Close();
                return unicode;
            }
            catch (ArgumentNullException e)
            {
                //// Add more exception handling here
                throw new ArgumentNullException(e.ToString());
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.ToString());
            }
            catch (NotSupportedException e)
            {
                throw new NotSupportedException(e.ToString());
            } 
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException(e.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }
    }
}
