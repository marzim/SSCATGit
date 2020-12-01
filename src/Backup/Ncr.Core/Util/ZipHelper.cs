// <copyright file="ZipHelper.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;

    /// <summary>
    /// Initializes static members of the ZipHelper class
    /// </summary>
    public static class ZipHelper
    {
        /// <summary>
        /// Zip Manager interface
        /// </summary>
        private static IZipManager manager;

        /// <summary>
        /// Initializes static members of the ZipHelper class
        /// </summary>
        static ZipHelper()
        {
            Attach(new ZipManager());
        }

        /// <summary>
        /// Attach Zip manager
        /// </summary>
        /// <param name="manager">Zip manager</param>
        public static void Attach(IZipManager manager)
        {
            ZipHelper.manager = manager;
        }

        /// <summary>
        /// Extract file
        /// </summary>
        /// <param name="zipFileSource">zip file source</param>
        /// <param name="destinationFolder">destination folder</param>
        /// <param name="password">folder password</param>
        /// <param name="fileNameToExtract">file name to extract</param>
        /// <param name="parserName">parser name</param>
        /// <returns>Returns extracted file</returns>
        public static string Extract(string zipFileSource, string destinationFolder, string password, string fileNameToExtract, string parserName)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("ZipManager");
            }

            try
            {
                return manager.Extract(zipFileSource, destinationFolder, password, fileNameToExtract, parserName);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Extract file
        /// </summary>
        /// <param name="zipFileSource">zip file source</param>
        /// <param name="destinationFolder">destination folder</param>
        /// <param name="password">folder password</param>
        /// <param name="fileNameToExtract">file name to extract</param>
        public static void Extract(string zipFileSource, string destinationFolder, string password, string fileNameToExtract)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("ZipManager");
            }

            try
            {
                manager.Extract(zipFileSource, destinationFolder, password, fileNameToExtract);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Compress folder
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <param name="sourceDirectory">source directory</param>
        public static void CompressFolder(string fileName, string sourceDirectory)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("ZipManager");
            }

            try
            {
                manager.CompressFolder(fileName, sourceDirectory);
            }
            catch
            {
                throw;
            }
        }
    }
}
