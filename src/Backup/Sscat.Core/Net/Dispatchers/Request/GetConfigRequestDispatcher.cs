// <copyright file="GetConfigRequestDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using System;
    using Ncr.Core;
    using Ncr.Core.Net;
    using Sscat.Core.Config;
    using Sscat.Core.Repositories;

    /// <summary>
    /// Initializes a new instance of the GetConfigRequestDispatcher class
    /// </summary>
    public class GetConfigRequestDispatcher : SscatRequestDispatcher
    {
        /// <summary>
        /// Configuration file repository
        /// </summary>
        private IConfigFileRepository _configFileRepository;

        /// <summary>
        /// Initializes a new instance of the GetConfigRequestDispatcher class
        /// </summary>
        /// <param name="configFileRepository">configuration file repository</param>
        public GetConfigRequestDispatcher(IConfigFileRepository configFileRepository)
            : base(SscatRequest.GET_CONFIG)
        {
            _configFileRepository = configFileRepository;
        }

        /// <summary>
        /// Dispatch request
        /// </summary>
        /// <param name="request">request to dispatch</param>
        public override void Dispatch(Request request)
        {
            try
            {
                _configFileRepository.Accessing += new EventHandler<NcrEventArgs>(RepositoryAccessing);
                ConfigFiles config = request.Content as ConfigFiles;
                foreach (ConfigFile f in config.Files)
                {
                    _configFileRepository.Read(f);
                }

                OnDispatched(request.CreateResponse(SscatResponse.CONFIGS, config));
            }
            catch
            {
                throw;
            }
            finally
            {
                _configFileRepository.Accessing -= new EventHandler<NcrEventArgs>(RepositoryAccessing);
            }
        }

        /// <summary>
        /// Event for accessing repository
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void RepositoryAccessing(object sender, NcrEventArgs e)
        {
            OnDispatching(e);
        }
    }
}
