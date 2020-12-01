// <copyright file="LoadConfigRequestDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using System;
    using System.IO;
    using Ncr.Core;
    using Ncr.Core.Emulators;
    using Ncr.Core.Net;
    using Ncr.Core.Util;
    using Sscat.Core.Config;
    using Sscat.Core.Emulators;
    using Sscat.Core.Repositories;

    /// <summary>
    /// Initializes a new instance of the LoadConfigRequestDispatcher class
    /// </summary>
    public class LoadConfigRequestDispatcher : SscatRequestDispatcher
    {
        /// <summary>
        /// Interface for Configuration file repository
        /// </summary>
        private IConfigFileRepository _configFileRepository;

        /// <summary>
        /// Interface for SSCAT launch pad
        /// </summary>
        private ISscatLaunchPad _launchPad;

        /// <summary>
        /// Initializes a new instance of the LoadConfigRequestDispatcher class
        /// </summary>
        /// <param name="configFileRepository">configuration file repository</param>
        /// <param name="launchPad">sscat launch pad</param>
        public LoadConfigRequestDispatcher(IConfigFileRepository configFileRepository, ISscatLaunchPad launchPad)
            : base(SscatRequest.LOAD_CONFIG)
        {
            _configFileRepository = configFileRepository;
            _launchPad = launchPad;
        }

        /// <summary>
        /// Dispatch request
        /// </summary>
        /// <param name="request">request to dispatch</param>
        public override void Dispatch(Request request)
        {
            try
            {
                _configFileRepository.Accessing += new EventHandler<NcrEventArgs>(ConfigFileDaoAccessing);
                _launchPad.Emulating += new EventHandler<EmulatorEventArgs>(LaunchPadEmulating);
                ConfigFile file = request.Content as ConfigFile;
                string path = Path.Combine(file.Destination, file.Name);
                _launchPad.Kill();
                if (_configFileRepository.Exists(path))
                {
                    OnDispatching(string.Format("{0} exists. Renaming...", path));
                    _configFileRepository.Rename(path, path + ".sscat");
                    _configFileRepository.Create(file);
                }
                else
                {
                    OnDispatching(string.Format("{0} does not exist", path));
                    _configFileRepository.Create(file);
                }

                _launchPad.Start();
                OnDispatched(request.CreateResponse(SscatResponse.CONFIG_LOADED, string.Empty));
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                OnDispatching(ex.Message);
            }
            finally
            {
                _configFileRepository.Accessing -= new EventHandler<NcrEventArgs>(ConfigFileDaoAccessing);
                _launchPad.Emulating -= new EventHandler<EmulatorEventArgs>(LaunchPadEmulating);
            }
        }

        /// <summary>
        /// Event for launch pad emulating
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">emulator event arguments</param>
        private void LaunchPadEmulating(object sender, EmulatorEventArgs e)
        {
            OnDispatching(e.Message);
        }

        /// <summary>
        /// EVent for configuration file accessing
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ConfigFileDaoAccessing(object sender, NcrEventArgs e)
        {
            OnDispatching(e.Message);
        }
    }
}
