// <copyright file="ReportPlayback.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;

    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ReportPlayback class
    /// </summary>
    public class ReportPlayback
    {
        /// <summary>
        /// Report directory information
        /// </summary>
        private DirectoryInfo _reportDirectory = new DirectoryInfo(@"C:\sscat\reports");

        /// <summary>
        /// Report playback utility
        /// </summary>
        private ReportPlaybackUtility _reportUtility = new ReportPlaybackUtility();

        /// <summary>
        /// Cached script
        /// </summary>
        private SSCATScript _cacheScript;

        /// <summary>
        /// Initializes a new instance of the ReportPlayback class
        /// </summary>
        public ReportPlayback()
        {
        }

        /// <summary>
        /// Gets the file name
        /// </summary>
        public FileInfo FileName
        {
            get { return _reportUtility.GetLatestReportPlaybackFile(_reportDirectory); }
        }

        /// <summary>
        /// Gets the report playback file
        /// </summary>
        public string ReportPlaybackFile
        {
            get { return string.Format(@"C:\sscat\reports\{0}", FileName.Name); }
        }

        /// <summary>
        /// Updates the report playback
        /// </summary>
        /// <param name="script">script to update with</param>
        public void UpdateReportPlayback(IScript script)
        {
            _reportUtility.WriteOnReportPlaybackFile(ReportPlaybackFile, AppendReportPlaybackData(script));
            _reportUtility.UpdateReportPlaybackSummary(ReportPlaybackFile, script.Result.Type);
        }

        /// <summary>
        /// Create compressed report files
        /// </summary>
        /// <param name="saveReportInfo">save report information</param>
        /// <param name="cacheDirectory">cached directory information</param>
        public void CreateCompressReportFiles(SaveReport saveReportInfo, DirectoryInfo cacheDirectory)
        {
            IList<string> cacheFiles = new List<string>();

            DirectoryInfo reportsTempDirectory = new DirectoryInfo(string.Format(@"{0}\sscattemp", saveReportInfo.ReportOutputDirectory));
            if (reportsTempDirectory.Exists)
            {
                DirectoryHelper.DeleteDirectory(reportsTempDirectory.ToString());
            }

            DirectoryHelper.CreateDirectory(reportsTempDirectory.ToString());

            foreach (string f in _reportUtility.GetCacheFiles(cacheDirectory))
            {
                _cacheScript = SSCATScript.Deserialize(f);
                CreateScriptEventReport(_cacheScript, reportsTempDirectory);
            }

            CompressReports(saveReportInfo.ReportFilename, saveReportInfo.ReportOutputDirectory);
        }

        /// <summary>
        /// Create report playback format
        /// </summary>
        /// <param name="reportPlaybackFile">report playback file</param>
        public void CreateReportPlaybackFormat(string reportPlaybackFile)
        {
            ArrayList reportFormat = new ArrayList();
            reportFormat.Add("Report Playback Summary");
            reportFormat.Add(string.Format("SSCAT Version: " + ApplicationUtility.ProductVersion));
            reportFormat.Add(string.Empty);
            reportFormat.Add("Total Scripts:0");
            reportFormat.Add("Total Passed:0");
            reportFormat.Add("Total Failed:0");
            reportFormat.Add(string.Empty);
            reportFormat.Add("Script#,ScriptName,Duration,Result,Notes,ScreenshotPath,DiagnosticPath,RepetitionIndex");
            _reportUtility.WriteOnReportPlaybackFile(reportPlaybackFile, reportFormat);
        }

        /// <summary>
        /// Create script event report
        /// </summary>
        /// <param name="cacheScript">cached script</param>
        /// <param name="reportsTempDirectory">reports temporary directory information</param>
        public void CreateScriptEventReport(SSCATScript cacheScript, DirectoryInfo reportsTempDirectory)
        {
            ArrayList scriptEventReport = new ArrayList();
            scriptEventReport.Add("Script Results");
            scriptEventReport.Add(string.Format("SSCAT Version: {0}", ApplicationUtility.ProductVersion));
            scriptEventReport.Add(string.Empty);
            scriptEventReport.Add(string.Format("Script Name,{0}", cacheScript.Name));
            scriptEventReport.Add(string.Format("Script Description,{0}", cacheScript.Description));
            scriptEventReport.Add(string.Format("Duration,{0}", cacheScript.Result.Duration.ToString()));
            scriptEventReport.Add(string.Format("Result,{0}", cacheScript.Result.Type.ToString()));
            scriptEventReport.Add(string.Format("Notes,{0}", Regex.Replace(cacheScript.Result.Notes, @"\t|\n|\r", "; ")));
            scriptEventReport.Add(string.Format("# of Warnings,{0}", cacheScript.Result.NumberOfWarnings.ToString()));
            scriptEventReport.Add(string.Format("Screenshot Path,{0}", cacheScript.Result.ScreenshotPath));
            scriptEventReport.Add(string.Format("Diagnostic Path,{0}", cacheScript.Result.DiagnosticPath));
            scriptEventReport.Add(string.Format("Script Index,{0}", cacheScript.Index.ToString()));
            scriptEventReport.Add(string.Format("Repetition Index,{0}", cacheScript.Result.RepetitionIndex.ToString()));
            scriptEventReport.Add(string.Empty);
            scriptEventReport.Add("#,Event Time,Event Details,General Result,Expected Result,Actual Result,Screenshot Link");
            foreach (IScriptEvent evnt in cacheScript.ScriptEvents)
            {
                IScriptEventItem item = evnt.Item as IScriptEventItem;
                scriptEventReport.Add(string.Format("{0},{1},{2},{3},{4},{5},{6}", evnt.SequenceID.ToString(), evnt.Time.ToString(), item.ToRepresentation(), evnt.Result.Type.ToString(), evnt.Result.ExpectedResult, evnt.Result.ActualResult, evnt.ScreenshotLink));
            }

            string scriptEventReportFileName = _reportUtility.GetScriptEventReportFileName(cacheScript.FileName, reportsTempDirectory);
            _reportUtility.WriteOnReportPlaybackFile(scriptEventReportFileName, scriptEventReport);
        }

        /// <summary>
        /// Compress reports
        /// </summary>
        /// <param name="reportFilename">report file name</param>
        /// <param name="reportOutputDirectory">report output directory</param>
        public void CompressReports(string reportFilename, string reportOutputDirectory)
        {
            string fileName = string.Format(@"{0}\{1}.zip", reportOutputDirectory, reportFilename);
            string sourceDirectory = string.Format(@"{0}\sscattemp", reportOutputDirectory);

            FileHelper.Copy(ReportPlaybackFile, string.Format(@"{0}\{1}", sourceDirectory, FileName));
            ZipHelper.CompressFolder(fileName, sourceDirectory);
            DirectoryHelper.DeleteDirectory(sourceDirectory);
        }

        /// <summary>
        /// Append report playback data
        /// </summary>
        /// <param name="script">script to append</param>
        /// <returns>Returns formatted script with appended script data</returns>
        private string AppendReportPlaybackData(IScript script)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", script.Index, script.Name, script.Result.Duration, script.Result.Type.ToString(), Regex.Replace(script.Result.Notes, @"\t|\n|\r", "; "), script.Result.ScreenshotPath, script.Result.DiagnosticPath, script.Result.RepetitionIndex);
        }
    }
}
