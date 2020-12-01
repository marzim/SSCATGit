// <copyright file="ReportPlaybackUtility.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ReportPlaybackUtility class
    /// </summary>
    public class ReportPlaybackUtility
    {
        /// <summary>
        /// Writer lock
        /// </summary>
        private readonly object writerLock = new object();
        
        /// <summary>
        /// Initializes a new instance of the ReportPlaybackUtility class
        /// </summary>
        public ReportPlaybackUtility()
        {
        }

        /// <summary>
        /// Get the latest report playback file
        /// </summary>
        /// <param name="directoryInfo">Directory information</param>
        /// <returns>Returns the file information</returns>
        public FileInfo GetLatestReportPlaybackFile(DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null || !directoryInfo.Exists)
            {
                // to be handled
                return null; 
            }

            FileInfo[] files = directoryInfo.GetFiles("*.csv");
            DateTime lastWrite = DateTime.MinValue;
            FileInfo lastWritenFile = null;

            foreach (FileInfo file in files)
            {
                if (file.LastWriteTime > lastWrite)
                {
                    lastWrite = file.LastWriteTime;
                    lastWritenFile = file;
                }
            }

            return lastWritenFile;
        }

        /// <summary>
        /// Get cached files
        /// </summary>
        /// <param name="directoryInfo">directory information</param>
        /// <returns>Returns cached files</returns>
        public IList<string> GetCacheFiles(DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null || !directoryInfo.Exists)
            {
                return null; // to be handled
            }

            List<string> cacheFiles = new List<string>();
            FileInfo[] files = directoryInfo.GetFiles("*.*");
            foreach (FileInfo file in files)
            {
                cacheFiles.Add(file.FullName);
            }

            return cacheFiles;
        }

        /// <summary>
        /// Gets the script event report file name
        /// </summary>
        /// <param name="cacheScriptFileName">cache script file name</param>
        /// <param name="reportsTempDirectory">report temporary directory</param>
        /// <returns>Returns the report file name</returns>
        public string GetScriptEventReportFileName(string cacheScriptFileName, DirectoryInfo reportsTempDirectory)
        {
            string[] scriptEventReportFileName = cacheScriptFileName.Split('\\');
            return string.Format(@"{0}\{1}.csv", reportsTempDirectory, scriptEventReportFileName[scriptEventReportFileName.Length - 1]);
        }

        /// <summary>
        /// Write on report playback file
        /// </summary>
        /// <param name="file">file to write in</param>
        /// <param name="message">message to write to file</param>
        public void WriteOnReportPlaybackFile(string file, string message)
        {
            lock (writerLock)
            {
                using (StreamWriter streamWriter = new StreamWriter(file, true))
                {
                    streamWriter.WriteLine(message);
                }
            }
        }

        /// <summary>
        /// Write on report playback file
        /// </summary>
        /// <param name="file">file to write in</param>
        /// <param name="data">data to write</param>
        public void WriteOnReportPlaybackFile(string file, ArrayList data)
        {
            lock (writerLock)
            {
                using (StreamWriter streamWriter = new StreamWriter(file))
                {
                    foreach (string dataLine in data)
                    {
                        streamWriter.WriteLine(dataLine);
                    }
                }
            }
        }

        /// <summary>
        /// Update report playback summary
        /// </summary>
        /// <param name="file">report file</param>
        /// <param name="result">report result</param>
        public void UpdateReportPlaybackSummary(string file, ResultType result)
        {
            string passed = "Total Passed:";
            string failed = "Total Failed:";

            if (result == ResultType.Passed)
            {
                EditFile(file, passed);
            }
            else if (result == ResultType.Failed || result == ResultType.Exception)
            {
                EditFile(file, failed);
            }
        }

        /// <summary>
        /// Edit file
        /// </summary>
        /// <param name="file">file to edit</param>
        /// <param name="result">result to check</param>
        private void EditFile(string file, string result)
        {
            try
            {
                ArrayList newFile = new ArrayList();
                string temp = string.Empty;
                ArrayList reportFileByLine = IOHelper.ReadAllLines(file);
                foreach (string line in reportFileByLine)
                {
                    if (line.StartsWith("Total Scripts:"))
                    {
                        string tempStringTotalScripts = line.Split(':')[1];
                        int tempIntTotalScripts = int.Parse(tempStringTotalScripts);
                        tempIntTotalScripts++;
                        temp = line.Replace(tempStringTotalScripts, tempIntTotalScripts.ToString());
                        newFile.Add(temp);
                        continue;
                    }

                    if (line.StartsWith(result))
                    {
                        string tempStringTotalResult = line.Split(':')[1];
                        int tempIntTotalResult = int.Parse(tempStringTotalResult);
                        tempIntTotalResult++;
                        temp = line.Replace(tempStringTotalResult, tempIntTotalResult.ToString());
                        newFile.Add(temp);
                        continue;
                    }

                    newFile.Add(line);
                }

                WriteOnReportPlaybackFile(file, newFile);
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
            }
        }
    }
}
