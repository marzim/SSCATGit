// <copyright file="CheckConfigRequestDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using System;
    using System.IO;
    using Ncr.Core.Net;
    using Ncr.Core.Util;
    using Sscat.Core.Config;
    using Sscat.Core.Repositories;
    
    /// <summary>
    /// Initializes a new instance of the CheckConfigRequestDispatcher class
    /// </summary>
    public class CheckConfigRequestDispatcher : SscatRequestDispatcher
    {
        /// <summary>
        /// Configuration file repository
        /// </summary>
        private IConfigFileRepository _configFileRepository;

        /// <summary>
        /// Initializes a new instance of the CheckConfigRequestDispatcher class
        /// </summary>
        /// <param name="configFileRepository">configuration file repository</param>
        public CheckConfigRequestDispatcher(IConfigFileRepository configFileRepository)
            : base(SscatRequest.CHECK_CONFIG)
        {
            _configFileRepository = configFileRepository;
        }

        /// <summary>
        /// Dispatches the configuration file
        /// </summary>
        /// <param name="request">dispatch request</param>
        public override void Dispatch(Request request)
        {
            try
            {
                OnDispatching("Checking config file");
                ConfigFile file = request.Content as ConfigFile;
                file.Destination = (file.Path == null || file.Path.Length == 0) ? file.Destination : file.Path;
                string scotFile = Path.Combine(file.Destination, file.Name);
                if (_configFileRepository.Exists(scotFile) && !file.Exists)
                {
                    file.DifferentFromScotConfig = true;
                }
                else if (_configFileRepository.Exists(scotFile) && file.Exists)
                {
                    ConfigFile f = _configFileRepository.Read(scotFile);
                    if (!f.Content.Equals(file.Content))
                    {
                        file.DifferentFromScotConfig = true;
                    }
                    else
                    {
                        file.DifferentFromScotConfig = false;
                    }
                }
                else if (!_configFileRepository.Exists(scotFile) && file.Exists)
                {
                    file.DifferentFromScotConfig = true;
                }
                else
                {
                    file.DifferentFromScotConfig = false;
                }

                OnDispatching(file.DifferentFromScotConfig ? "Config differs" : "Config is the same");
                OnDispatched(request.CreateResponse(SscatResponse.CONFIG_CHECKED, file));
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                OnDispatching(ex.Message);
            }
        }
    }
}