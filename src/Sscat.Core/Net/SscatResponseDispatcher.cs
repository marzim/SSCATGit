// <copyright file="SscatResponseDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using System;
    using Ncr.Core;
    using Ncr.Core.Net;
    using Sscat.Core.Config;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the SscatResponseDispatcher class
    /// </summary>
    public abstract class SscatResponseDispatcher : ResponseDispatcher, ISscatResponseDispatcher
    {
        /// <summary>
        /// Initializes a new instance of the SscatResponseDispatcher class
        /// </summary>
        /// <param name="name">dispatcher name</param>
        public SscatResponseDispatcher(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Event handler for script event result dispatched
        /// </summary>
        public event EventHandler<ScriptEventEventArgs> ScriptEventResultDispatched;
        
        /// <summary>
        /// Event handler for warning event result dispatched
        /// </summary>
        public event EventHandler<WarningEventArgs> ScriptWarningEventResultDispatched;

        /// <summary>
        /// Event handler for script result dispatched
        /// </summary>
        public event EventHandler<ScriptEventArgs> ScriptResultDispatched;

        /// <summary>
        /// Event handler for scripts dispatched
        /// </summary>
        public event EventHandler ScriptsDispatched;

        /// <summary>
        /// Event handler for configuration loaded dispatched
        /// </summary>
        public event EventHandler ConfigLoadedDispatched;

        /// <summary>
        /// Event handler for configuration checked dispatched
        /// </summary>
        public event EventHandler<ConfigFileEventArgs> ConfigCheckedDispatched;

        /// <summary>
        /// Event handler for configuration dispatched
        /// </summary>
        public event EventHandler<ConfigFileEventArgs> ConfigDispatched;

        /// <summary>
        /// Event handler for report dispatched
        /// </summary>
        public event EventHandler<ReportEventArgs> ReportDispatched;

        /// <summary>
        /// Event handler for stop dispatched
        /// </summary>
        public event EventHandler StopDispatched;

        /// <summary>
        /// Event handler for response dispatched
        /// </summary>
        public event EventHandler<NcrEventArgs> ResponseDispatched;

        /// <summary>
        /// Event handler for configurations changed dispatched
        /// </summary>
        public event EventHandler ConfigurationChangedDispatched;

        /// <summary>
        /// Event for on configuration changed dispatched
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnConfigurationChangedDispatched(EventArgs e)
        {
            if (ConfigurationChangedDispatched != null)
            {
                ConfigurationChangedDispatched(this, e);
            }
        }

        /// <summary>
        /// Event for on stopped dispatched
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnStopDispatched(EventArgs e)
        {
            if (StopDispatched != null)
            {
                StopDispatched(this, e);
            }
        }

        /// <summary>
        /// Event for on response dispatched
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnResponseDispatched(NcrEventArgs e)
        {
            if (ResponseDispatched != null)
            {
                ResponseDispatched(this, e);
            }
        }

        /// <summary>
        /// Event for on configuration checked dispatched
        /// </summary>
        /// <param name="e">configuration file event arguments</param>
        protected virtual void OnConfigCheckedDispatched(ConfigFileEventArgs e)
        {
            if (ConfigCheckedDispatched != null)
            {
                ConfigCheckedDispatched(this, e);
            }
        }

        /// <summary>
        /// Event for on report dispatched
        /// </summary>
        /// <param name="e">report event arguments</param>
        protected virtual void OnReportDispatched(ReportEventArgs e)
        {
            if (ReportDispatched != null)
            {
                ReportDispatched(this, e);
            }
        }

        /// <summary>
        /// Event for on configuration dispatched
        /// </summary>
        /// <param name="e">configuration file event arguments</param>
        protected virtual void OnConfigDispatched(ConfigFileEventArgs e)
        {
            if (ConfigDispatched != null)
            {
                ConfigDispatched(this, e);
            }
        }

        /// <summary>
        /// Event for on configuration loaded dispatched
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnConfigLoadedDispatched(EventArgs e)
        {
            if (ConfigLoadedDispatched != null)
            {
                ConfigLoadedDispatched(this, e);
            }
        }

        /// <summary>
        /// Event for on scripts dispatched
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnScriptsDispatched(EventArgs e)
        {
            if (ScriptsDispatched != null)
            {
                ScriptsDispatched(this, e);
            }
        }

        /// <summary>
        /// Event for on script result dispatched
        /// </summary>
        /// <param name="e">script event arguments</param>
        protected virtual void OnScriptResultDispatched(ScriptEventArgs e)
        {
            if (ScriptResultDispatched != null)
            {
                ScriptResultDispatched(this, e);
            }
        }

        /// <summary>
        /// Event for on script event result dispatched
        /// </summary>
        /// <param name="e">script event arguments</param>
        protected virtual void OnScriptEventResultDispatched(ScriptEventEventArgs e)
        {
            if (ScriptEventResultDispatched != null)
            {
                ScriptEventResultDispatched(this, e);
            }
        }
        
        /// <summary>
        /// Event for on warning event result dispatched
        /// </summary>
        /// <param name="e">warning event arguments</param>
        protected virtual void OnScriptWarningEventResultDispatched(WarningEventArgs e)
        {
            if (ScriptWarningEventResultDispatched != null)
            {
                ScriptWarningEventResultDispatched(this, e);
            }
        }
    }
}
