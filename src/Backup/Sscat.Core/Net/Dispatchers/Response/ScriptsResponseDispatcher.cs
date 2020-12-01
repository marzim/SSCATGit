// <copyright file="ScriptsResponseDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using System;
    using System.Collections.Generic;
    using Ncr.Core;
    using Ncr.Core.Net;
    using Ncr.Core.Util;
    using Sscat.Core.Config;
    using Sscat.Core.Gui;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Repositories;
    using Sscat.Core.Repositories.Xml;

    /// <summary>
    /// Initializes a new instance of the ScriptsResponseDispatcher class
    /// </summary>
    public class ScriptsResponseDispatcher : SscatResponseDispatcher
    {
        /// <summary>
        /// Configuration file repository
        /// </summary>
        private IConfigFileRepository _configFileRepository;

        /// <summary>
        /// Script repository
        /// </summary>
        private IScriptRepository _scriptRepository;

        /// <summary>
        /// The server
        /// </summary>
        private string _server;

        /// <summary>
        /// Initializes a new instance of the ScriptsResponseDispatcher class
        /// </summary>
        /// <param name="configFileRepository">configuration file repository</param>
        /// <param name="scriptRepository">script repository</param>
        /// <param name="server">the server</param>
        public ScriptsResponseDispatcher(IConfigFileRepository configFileRepository, IScriptRepository scriptRepository, string server)
            : base(SscatResponse.SCRIPTS)
        {
            _configFileRepository = configFileRepository;
            _scriptRepository = scriptRepository;
            _server = server;
        }

        /// <summary>
        /// Dispatch response
        /// </summary>
        /// <param name="response">response to dispatch</param>
        public override void Dispatch(Response response)
        {
            try
            {
                _scriptRepository.Accessing += new EventHandler<NcrEventArgs>(ScriptDaoAccessing);
                GeneratorConfiguration config = response.Content as GeneratorConfiguration;
                foreach (ConfigFile file in config.Files.Files)
                {
                    _configFileRepository.Create(file);
                }

                if (CardEventEditor.ContainsMSCard(config.Scripts.Scripts) &&
                    config.DontShowMSCardEditor == false)
                {
                    ShowMSRForm(config.Scripts.Scripts, _server);
                }
                else if (CardEventEditor.ContainsMSCard(config.Scripts.Scripts) == false &&
                         config.DontShowMSCardEditor == false)
                {
                    OnDispatching("No MS Card(s) was/were found on the script(s)! " +
                                  "The MS Card Editor will not be shown.");
                }

                foreach (SSCATScript script in config.Scripts.Scripts)
                {
                    _scriptRepository.Save(script);
                }

                // Sending message to Client that response has arrived preventing Client to timeout in CardEventEditor form.
                OnScriptsDispatched(null);
                OnDispatching("Script generation done.");
            }
            catch
            {
                throw;
            }
            finally
            {
                _scriptRepository.Accessing -= new EventHandler<NcrEventArgs>(ScriptDaoAccessing);
            }
        }

        /// <summary>
        /// SHow the MSR form
        /// </summary>
        /// <param name="scripts">sscat scripts</param>
        /// <param name="server">the server</param>
        private void ShowMSRForm(SSCATScript[] scripts, string server)
        {
            CardEventEditor form = new CardEventEditor();
            try
            {
                form.Running += new EventHandler<NcrEventArgs>(CardEventEditorRunning);
                form.ConfigurationChanged += new EventHandler(MSRConfigurationChanged);
                form.AddScriptsToScriptListView(new List<IScript>(scripts));
                form.AddConfig(new XmlClientConfigurationRepository().Read(ApplicationUtility.ClientConfigurationFileName(server)));

                if (!form.IsDisposed)
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                throw;
            }
            finally
            {
                form.Running -= new EventHandler<NcrEventArgs>(CardEventEditorRunning);
                form.ConfigurationChanged -= new EventHandler(MSRConfigurationChanged);
                form.Dispose();
            }
        }

        /// <summary>
        /// Event for Card event editor running
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void CardEventEditorRunning(object sender, NcrEventArgs e)
        {
            OnResponseDispatched(e);
        }

        /// <summary>
        /// Event for MSR configuration changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void MSRConfigurationChanged(object sender, EventArgs e)
        {
            OnConfigurationChangedDispatched(e);
        }

        /// <summary>
        /// Event for Script data access object accessing 
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ScriptDaoAccessing(object sender, NcrEventArgs e)
        {
            OnDispatching(e.Message);
        }
    }
}
