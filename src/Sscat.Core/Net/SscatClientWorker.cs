// <copyright file="SscatClientWorker.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using JadBenAutho.EasySocket;
    using Ncr.Core.Net;
    using Ncr.Core.Util;
    using Sscat.Core.Config;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
   
    /// <summary>
    /// Initializes a new instance of the SscatClientWorker class
    /// </summary>
    public class SscatClientWorker
    {
        /// <summary>
        /// Whether or not the client has stopped
        /// </summary>
        private volatile bool _hasStopped;

        /// <summary>
        /// SSCAT client
        /// </summary>
        private SscatClient _client;

        /// <summary>
        /// Script files
        /// </summary>
        private IList<ScriptFile> _scriptFiles;

        /// <summary>
        /// Generator configuration
        /// </summary>
        private GeneratorConfiguration _generatorConfig;

        /// <summary>
        /// Initializes a new instance of the SscatClientWorker class
        /// </summary>
        /// <param name="client">sscat client</param>
        public SscatClientWorker(SscatClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Sets the generator configuration
        /// </summary>
        public GeneratorConfiguration GeneratorConfiguration
        {
            set { _generatorConfig = value; }
        }

        /// <summary>
        /// Sets the script files
        /// </summary>
        public IList<ScriptFile> ScriptFiles
        {
            set { _scriptFiles = value; }
        }

        /// <summary>
        /// Generate the scripts
        /// </summary>
        public void Generate()
        {
            try
            {
                _client.StartLogger();
                _hasStopped = false;
                _generatorConfig.Files.SourceDirectory = @"C:\scot\config";
                _generatorConfig.Files.DestinationDirectory = _generatorConfig.ScriptOutputDirectory;
                _client.SendRequest(new Request(SscatRequest.GENERATE_SCRIPTS, _generatorConfig));

                while (!_client.HasStopped)
                {
                    if (_hasStopped)
                    {
                        break;
                    }

                    ThreadHelper.Sleep(200);
                }

                if (_client.HasTimedOut)
                {
                    _client.PerformConnectionTimeOut();
                }
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                MessageService.ShowError(ex.Message);
                _client.PerformStopping();
            }
            finally
            {
                _client.StopLogger();
            }
        }

        /// <summary>
        /// Stop the client worker
        /// </summary>
        public void Stop()
        {
            _hasStopped = true;
        }

        /// <summary>
        /// Play the scripts
        /// </summary>
        public void Play()
        {
            try
            {
                _client.StartLogger();

                // For creating the Report Playback Summary
                ReportPlayback reportPlayback = new ReportPlayback();
                reportPlayback.CreateReportPlaybackFormat(string.Format(@"C:\SSCAT\Reports\ReportPlayback-{0}.csv", DateTime.Now.ToString("yyyyMMdd-HHmmss")));

                _hasStopped = false;
                _client.PerformPlaying();
                PlayerConfiguration config = _client.Configuration.PlayerConfiguration;
                config.ConfigFiles.SourceDirectory = @"C:\SSCAT\ScotConfig";
                config.ConfigFiles.DestinationDirectory = @"C:\scot\config";

                if (config.PlaybackRepetition == 0)
                {
                    for (;;)
                    {
                        if (_hasStopped)
                        {
                            break;
                        }

                        PlayConfiguration(config);
                    }
                }
                else
                {
                    for (int i = 0; i < config.PlaybackRepetition; i++)
                    {
                        if (_hasStopped)
                        {
                            break;
                        }

                        _client.ClearView();
                        config.ConfigFiles.RepetitionIndex = i + 1;
                        PlayConfiguration(config);
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                ScriptFile filePath = _scriptFiles.FirstOrDefault();
                string[] lineNumber = Regex.Split(ex.Message, @"\D+");
                string message = string.Format("Error Message: {0}Syntax error found in {3} at line {1} & column {2}{0}{0}Troubleshooting Tips: {0}In SSCAT Client, go to PlayerPane and remove {4} in Script List View{0}Go to {3} and modify  at line {1} & column {2}{0}Correct XML syntax error{0}{0}", Environment.NewLine, lineNumber[1], lineNumber[2], filePath.File, Path.GetFileNameWithoutExtension(filePath.File));
                LoggingService.Error(message);
                MessageService.ShowError(message);
                _client.PerformStopping();
            }
            catch (EasySocketException ex)
            {
                LoggingService.Error("Connection to SSCAT Server is lost! Please restart SSCAT Client and make sure that SSCAT Server is running properly. " + ex.ToString());
                MessageService.ShowErrorOnTop("Connection to SSCAT Server is lost! Please restart SSCAT Client and make sure that SSCAT Server is running properly.");
                _client.PerformStopping();
            }
            catch (IOException ex)
            {
                LoggingService.Error(ex.ToString());
                MessageService.ShowErrorOnTop("Unable to send data to the transport connection! An established connection was unexpectedly aborted in the host/server machine. Please restart SSCAT Client and make sure that SSCAT Server is running properly.");
                _client.PerformStopping();
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                MessageService.ShowErrorOnTop(ex.Message);
                _client.PerformStopping();
            }
            finally
            {
                _client.StopLogger();
            }
        }

        /// <summary>
        /// Setup the player configuration
        /// </summary>
        /// <param name="config">player configuration</param>
        private void PlayConfiguration(PlayerConfiguration config)
        {
            foreach (ScriptFile script in _scriptFiles)
            {
                if (_hasStopped)
                {
                    break;
                }

                script.RepetitionIndex = config.ConfigFiles.RepetitionIndex;
                _client.InitiateCache(script);
                _client.PreparePlayerConfiguration(script);
                _client.SendRequest(new Request(SscatRequest.PLAY_SCRIPT, config));
                config.Dispose();

                while (!_client.HasReportDispatched)
                {
                    if (_hasStopped)
                    {
                        break;
                    }

                    ThreadHelper.Sleep(200);
                }

                if (_client.HasTimedOut)
                {
                    _client.PerformConnectionTimeOut();
                    break;
                }

                if (_client.HasStopped)
                {
                    break;
                }
            }
        }
    }
}
