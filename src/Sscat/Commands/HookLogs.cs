// <copyright file="HookLogs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Commands
{
    using System;
    using System.Collections;
    using System.IO;
    using Ncr.Core.Commands;
    using Ncr.Core.Util;
    using Sscat.Core.Config;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Parsers;
    using Sscat.Core.Repositories;

    /// <summary>
    /// Initializes a new instance of the HookLogs class
    /// </summary>
    public class HookLogs : AbstractCommand
    {
        /// <summary>
        /// Arguments for Hook Logs
        /// </summary>
        private string[] _args;

        /// <summary>
        /// Parsers for Hook Logs
        /// </summary>
        private Hashtable _parsers = null;

        /// <summary>
        /// Interface for Lane Configuration Repository
        /// </summary>
        private ILaneConfigurationRepository _repository;

        /// <summary>
        /// Initializes a new instance of the HookLogs class
        /// </summary>
        /// <param name="args">hook log arguments</param>
        /// <param name="repository">interface for lane configuration repository</param>
        public HookLogs(string[] args, ILaneConfigurationRepository repository)
        {
            _args = args;
            _repository = repository;
        }

        /// <summary>
        /// Adds parsers for the hook logs from the lane configuration file
        /// </summary>
        public override void Run()
        {
            try
            {
                _parsers = new Hashtable();

                LaneConfiguration config = _repository.Read(Path.Combine(ApplicationUtility.ConfigDirectory, "LaneConfiguration.xml"));
                foreach (LaneParser p in config.Parsers.Parsers)
                {
                    _parsers.Add(p.Name, p.Instantiate());
                }

                Hashtable logs = GetLogs(_args);
                foreach (string key in logs.Keys)
                {
                    IScotLogHook h = new ScotLogHook(key, _parsers[logs[key]] as IParser);
                    h.EventsChanged += new EventHandler<ScotLogHookEventArgs>(HookEventsChanged);
                }

                do
                {
                }
                while (!Console.ReadLine().Equals("exit"));
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                MessageService.ShowError(ex.Message);
            }
            finally
            {
                MessageService.ShowInfo("Bye!");
            }
        }

        /// <summary>
        /// Event handler for HooksEventsChanged
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">scot log hook event arguments</param>
        private void HookEventsChanged(object sender, ScotLogHookEventArgs e)
        {
            foreach (SSCATScriptEvent v in e.Events)
            {
                Console.WriteLine("{0} {1}", DateTimeUtility.Now(), v.ToRepresentation());
            }
        }

        /// <summary>
        /// Retrieves the log files based on the file name and parser
        /// </summary>
        /// <param name="args">hook log arguments</param>
        /// <returns>Returns the log files found in the current directory</returns>
        private Hashtable GetLogs(string[] args)
        {
            Hashtable logs = new Hashtable();
            for (int i = 1; i < args.Length; i++)
            {
                string[] fileAndParser = args[i].Split(':');
                int fileIndex = Convert.ToInt32(fileAndParser[0]);
                string parser = fileAndParser[1];
                string filename = DirectoryHelper.GetFiles(DirectoryHelper.GetCurrentDirectory(), "*.log")[fileIndex];
                logs.Add(filename, parser);
            }

            return logs;
        }
    }
}
