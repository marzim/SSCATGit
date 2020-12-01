// <copyright file="ZipManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using ICSharpCode.SharpZipLib.Core;
    using ICSharpCode.SharpZipLib.Zip;
    
    /// <summary>
    /// Initializes a new instance of the ZipManager class
    /// </summary>
    public class ZipManager : IZipManager
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
        public virtual string Extract(string zipFileSource, string destinationFolder, string password, string fileNameToExtract, string parserName)
        {
            if (parserName == "Psx")
            {
                Extract(zipFileSource, destinationFolder, string.Empty, "psx_ScotAppU.log");
                Extract(zipFileSource, destinationFolder, string.Empty, "psx_ScotApp.log");
                if (FileHelper.Exists(Path.Combine(destinationFolder, "psx_ScotAppU.log")))
                {
                    return Path.Combine(destinationFolder, "psx_ScotAppU.log");
                }
                else
                {
                    return Path.Combine(destinationFolder, "psx_ScotApp.log");
                }
            }
            else
            {
                Extract(zipFileSource, destinationFolder, string.Empty, fileNameToExtract);
                return Path.Combine(destinationFolder, fileNameToExtract);
            }
        }

        /// <summary>
        /// Extract file
        /// </summary>
        /// <param name="zipFileSource">zip file source</param>
        /// <param name="destinationFolder">destination folder</param>
        /// <param name="password">folder password</param>
        /// <param name="fileNameToExtract">file name to extract</param>
        public virtual void Extract(string zipFileSource, string destinationFolder, string password, string fileNameToExtract)
        {
            if (Path.GetExtension(zipFileSource).Equals(".7z"))
            {
                Extract7Zip(zipFileSource, destinationFolder, fileNameToExtract);
            }
            else
            {
                ZipFile zf = null;
                try
                {
                    FileStream fs = File.OpenRead(zipFileSource);
                    zf = new ZipFile(fs);

                    // Added in case some zip file will have password, for future used.
                    if (!string.IsNullOrEmpty(password))
                    {
                        zf.Password = password; // AES encrypted entries are handled automatically
                    }

                    foreach (ZipEntry zipEntry in zf)
                    {
                        if (!zipEntry.IsFile)
                        {
                            continue; // Ignore directories
                        }

                        string entryFileName = zipEntry.Name;
                        entryFileName = Path.GetFileName(entryFileName);

                        byte[] buffer = new byte[4096]; // 4K is optimmum
                        Stream zipStream = zf.GetInputStream(zipEntry);

                        string fullZipToPath = Path.Combine(destinationFolder, entryFileName);
                        string directoryName = Path.GetDirectoryName(fullZipToPath);
                        if (directoryName.Length > 0)
                        {
                            Directory.CreateDirectory(directoryName);
                        }

                        if (Path.GetExtension(entryFileName).Equals(".7z"))
                        {
                            using (FileStream streamWriter = File.Create(fullZipToPath))
                            {
                                StreamUtils.Copy(zipStream, streamWriter, buffer);
                            }

                            string sevenZipFileSource = string.Format(@"{0}\{1}", destinationFolder, entryFileName.ToString());
                            Extract7Zip(sevenZipFileSource, destinationFolder, fileNameToExtract);
                            break;
                        }
                        else if (fileNameToExtract.Equals(entryFileName))
                        {
                            using (FileStream streamWriter = File.Create(fullZipToPath))
                            {
                                StreamUtils.Copy(zipStream, streamWriter, buffer);
                            }

                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                finally
                {
                    if (zf != null)
                    {
                        zf.IsStreamOwner = true; // Makes close also shut the underlying stream
                        zf.Close(); // Ensure we release resources
                    }
                }
            }
        }

        /// <summary>
        /// Compress folder
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <param name="sourceDirectory">source directory</param>
        public virtual void CompressFolder(string fileName, string sourceDirectory)
        {
            FastZip fastZip = new FastZip();
            bool recurse = true;
            string filter = null;
            fastZip.CreateZip(fileName, sourceDirectory, recurse, filter);
        }

        /// <summary>
        /// Extract 7 Zip file
        /// </summary>
        /// <param name="sevenZipFileSource">7 Zip file source</param>
        /// <param name="destinationFolder">destination folder</param>
        /// <param name="fileToExtract">file to extract</param>
        private void Extract7Zip(string sevenZipFileSource, string destinationFolder, string fileToExtract)
        {
            string param = string.Format(@"e {0} -o{1} {2} -r -aos", sevenZipFileSource, destinationFolder, fileToExtract);
            int exitCode = ProcessUtility.Start(SevenZipApplicationPath(), param, true);
            LoggingService.Info(string.Format("7zip unpack exit code: {0}", exitCode.ToString()));
        }

        /// <summary>
        /// Gets the 7 Zip application path
        /// </summary>
        /// <returns>Returns the 7 Zip application path</returns>
        private string SevenZipApplicationPath()
        {
            List<string> path = new List<string>();
            path.Add(@"C:\scot\bin\7za.exe");
            path.Add(string.Format(@"{0}\7-Zip\7z.exe", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)));
            path.Add(string.Format(@"{0}\7-Zip\7z.exe", Environment.GetEnvironmentVariable("ProgramFiles(x86)")));

            foreach (string p in path)
            {
                if (FileHelper.Exists(p))
                {
                    return p;
                }
            }

            throw new Application7ZipNotFoundException("The current system is unable to extract 7-Zip files, please install 7-Zip application to be able to generate SSCAT scripts from a 7-Zip diag.");
        }
    }
}