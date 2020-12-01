// <copyright file="ConvertScripts.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Gui
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Xml.Serialization;
    using Ncr.Core.Commands;
    using Ncr.Core.Util;
    using Sscat.Core.Models.OldModel;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ConvertScripts class
    /// </summary>
    public class ConvertScripts : AbstractCommand
    {
        /// <summary>
        /// Initializes a new instance of the ConvertScripts class
        /// </summary>
        public ConvertScripts()
        {
        }

        /// <summary>
        /// Add files in the list based on the search pattern filter
        /// </summary>
        public override void Run()
        {
            try
            {
                List<string> fileNames = GetFiles("*.xml");
                List<string> successFiles = new List<string>();
                string destinationPath = DirectoryHelper.GetCurrentDirectory() + @"\NewSSCATScripts_" + Environment.TickCount;
                foreach (string fileName in fileNames)
                {
                    try
                    {
                        string destinationFile = ConvertScript(fileName, destinationPath);
                        if (!destinationFile.Equals("invalid"))
                        {
                            successFiles.Add(Path.GetFileName(destinationFile));
                        }
                    }
                    catch (NotSupportedException ex)
                    {
                        ShowAndLogError(ex);
                    }
                }

                if (fileNames.Count == 0)
                {
                    ShowAndLogInfo(string.Format("No xml files were found in current directory {0}", DirectoryHelper.GetCurrentDirectory()));
                }
                else if (successFiles.Count == 0)
                {
                    DirectoryHelper.DeleteDirectory(destinationPath);
                    ShowAndLogInfo(string.Format("No files were converted out of {0} xml files found in the current directory {1}.", fileNames.Count, DirectoryHelper.GetCurrentDirectory()));
                }
                else
                {
                    foreach (string file in successFiles)
                    {
                        ShowAndLogInfo(file);
                    }

                    Console.WriteLine();
                    ShowAndLogInfo(string.Format("Converted {0} Scripts out of {1} xml files in the current directory {2}", successFiles.Count, fileNames.Count, DirectoryHelper.GetCurrentDirectory()));
                    ShowAndLogInfo(string.Format("Files can be found in {0}", destinationPath));
                }
            }
            catch (Exception ex)
            {
                ShowAndLogError(ex);
            }
        }

        /// <summary>
        /// Converts Old Scripts to New Script
        /// </summary>
        /// <param name="_fileName">name of script file</param>
        /// <param name="_destinationPath">path name of the new scripts</param>
        /// <returns>the filename of the converted script</returns>
        private string ConvertScript(string _fileName, string _destinationPath)
        {
            string destinationFile = Path.Combine(_destinationPath, Path.GetFileName(_fileName));

            if (!File.Exists(_fileName))
            {
                throw new FileNotFoundException(_fileName, "File cannot be found");
            }

            if (!Directory.Exists(_destinationPath))
            {
                Directory.CreateDirectory(_destinationPath);
            }

            int i = 0;
            try
            {
                FingerScript oldScript = GetFingerScript(_fileName);
                SSCATScript newScript = InitializeSscatScript(oldScript);

                ShowAndLogInfo(string.Format("Converting Script: {0}", Path.GetFileName(_fileName)));
                foreach (FingerScriptEvent evt in oldScript.FingerScriptEvents)
                {
                    SSCATScriptEvent scriptEvent = GetScriptEventItem(evt.Item, evt.Time, evt.Type);
                    newScript.ScriptEvents[i] = scriptEvent;
                    i++;
                }

                newScript.Serialize(destinationFile);
                ShowAndLogInfo(string.Format("Script Converted: {0}", Path.GetFileName(_fileName)));

                return destinationFile;
            }
            catch (Exception ex)
            {
                ShowAndLogError(ex);
            }

            return "invalid";
        }

        /// <summary>
        /// Initializes SSCAT Scripts with script details from the old finger script
        /// </summary>
        /// <param name="fingerScript">finger script</param>
        /// <returns>an initialized SSCAT Script</returns>
        private SSCATScript InitializeSscatScript(FingerScript fingerScript)
        {
            SSCATScript newScript = new SSCATScript();
            newScript.SscatVersion = fingerScript.FingerBuild;
            newScript.Name = fingerScript.ScriptName;
            newScript.Description = fingerScript.ScriptDescription;
            newScript.SscoVersion = fingerScript.FLBuild;
            newScript.DateTime = fingerScript.DateTime;
            newScript.DateTimeConverted = "Date-Time Converted: " + System.DateTime.Now.ToString();
            newScript.SscatVersionConverted = GetVersion();
            newScript.FileName = fingerScript.FileName;
            newScript.ScriptEvents = new SSCATScriptEvent[fingerScript.FingerScriptEvents.Length];

            return newScript;
        }

        /// <summary>
        /// Deserializes the script file into a FingerScript object
        /// </summary>
        /// <param name="fileName">file name of the script</param>
        /// <returns>finger script</returns>
        private FingerScript GetFingerScript(string fileName)
        {
            try
            {
                FingerScript fingerScript = new FingerScript();
                XmlSerializer serializer = new XmlSerializer(typeof(FingerScript));
                fingerScript = (FingerScript)serializer.Deserialize(new StreamReader(fileName));
                return fingerScript;
            }
            catch (Exception ex)
            {
                throw new InvalidDataException(string.Format("Invalid FingerScript File {0}", Path.GetFileName(fileName)), ex);
            }
        }

        /// <summary>
        /// Converts a Finger Script Event Item into a DeviceEvent, UIAutoTestEvent or PSXEvent
        /// </summary>
        /// <param name="eventItem">event Item</param>
        /// <param name="eventTime">event Time</param>
        /// <param name="eventType">event Type</param>
        /// <returns>sscat script event</returns>
        private SSCATScriptEvent GetScriptEventItem(object eventItem, int eventTime, string eventType)
        {
            SSCATScriptEvent scriptevent = new SSCATScriptEvent();
            scriptevent.Time = eventTime;

            if (eventItem is FingerDeviceEvent)
            {
                FingerDeviceEvent fingerDevice = eventItem as FingerDeviceEvent;
                DeviceEvent deviceEvent = new DeviceEvent(fingerDevice.Id, fingerDevice.Value);
                scriptevent.SequenceID = fingerDevice.SeqId;
                scriptevent.Item = deviceEvent;
            }
#if NET40
            else if (eventItem is FingerUIAutoTestEvent)
            {
                FingerUIAutoTestEvent fingerUIAutoTest = eventItem as FingerUIAutoTestEvent;
                UIAutoTestEvent uiAutoTestEvent = new UIAutoTestEvent(
                    fingerUIAutoTest.EventType,
                    fingerUIAutoTest.ControlName,
                    fingerUIAutoTest.ButtonName,
                    fingerUIAutoTest.Index,
                    fingerUIAutoTest.ButtonData,
                    fingerUIAutoTest.ContextName,
                    fingerUIAutoTest.ValidLogin);
                scriptevent.SequenceID = fingerUIAutoTest.SeqId;
                scriptevent.Item = uiAutoTestEvent;
            }
#endif
            else if (eventItem is FingerPsxEvent)
            {
                FingerPsxEvent fingerPsx = eventItem as FingerPsxEvent;
                PsxEvent psxEvent = new PsxEvent(
                    fingerPsx.Context,
                    fingerPsx.Control,
                    fingerPsx.Event,
                    fingerPsx.Param,
                    fingerPsx.RemoteConnection);
                scriptevent.SequenceID = fingerPsx.SeqId;
                scriptevent.Item = psxEvent;
            }
            else
            {
                throw new NotSupportedException(eventType + ". This event item is not yet supported.");
            }

            return scriptevent;
        }

        /// <summary>
        /// Gets a list of file name string from a directory
        /// </summary>
        /// <param name="_pattern">file pattern</param>
        /// <returns>a list of file name string</returns>
        private List<string> GetFiles(string _pattern)
        {
            List<string> files = new List<string>();
            files.AddRange(DirectoryHelper.GetFiles(DirectoryHelper.GetCurrentDirectory(), _pattern));
            return files;
        }

        /// <summary>
        /// Get's the current version of SSCAT
        /// </summary>
        /// <returns>current version of SSCAT</returns>
        private string GetVersion()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            return string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
        }

        /// <summary>
        /// Show and Log Info Message
        /// </summary>
        /// <param name="message">message to show and log</param>
        private void ShowAndLogInfo(string message)
        {
            MessageService.ShowInfo(message);
            LoggingService.Info(message);
        }

        /// <summary>
        /// Show and Log Error Message
        /// </summary>
        /// <param name="ex">Exception to show and log</param>
        private void ShowAndLogError(Exception ex)
        {
            MessageService.ShowError(ex.Message);
            LoggingService.Error(ex.ToString());
        }
    }
}
