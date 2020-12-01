// <copyright file="IZipManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    /// <summary>
    /// Initializes a new instance of the IZipManager interface
    /// </summary>
    public interface IZipManager
    {
        /// <summary>
        /// Extract file
        /// </summary>
        /// <param name="zipFileSource">zip file source</param>
        /// <param name="destinationFolder">destination folder</param>
        /// <param name="password">folder password</param>
        /// <param name="fileNameToExtract">file name to extract</param>
        /// <param name="parserName">parser name</param>
        /// <returns>Returns extracted file</returns>
        string Extract(string zipFileSource, string destinationFolder, string password, string fileNameToExtract, string parserName);

        /// <summary>
        /// Extract file
        /// </summary>
        /// <param name="zipFileSource">zip file source</param>
        /// <param name="destinationFolder">destination folder</param>
        /// <param name="password">folder password</param>
        /// <param name="fileNameToExtract">file name to extract</param>
        void Extract(string zipFileSource, string destinationFolder, string password, string fileNameToExtract);

        /// <summary>
        /// Compress folder
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <param name="sourceDirectory">source directory</param>
        void CompressFolder(string fileName, string sourceDirectory);
    }
}
