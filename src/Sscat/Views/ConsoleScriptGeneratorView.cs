// <copyright file="ConsoleScriptGeneratorView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Views
{
    using System;
    using Ncr.Core.Views;
    using Sscat.Core.Config;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ConsoleScriptGeneratorView class
    /// </summary>
    public class ConsoleScriptGeneratorView : BaseConsoleView, IScriptGeneratorView
    {
        /// <summary>
        /// Generator configuration
        /// </summary>
        private GeneratorConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the ConsoleScriptGeneratorView class
        /// </summary>
        /// <param name="name">script name</param>
        /// <param name="description">script description</param>
        /// <param name="diagpath">path for diag files</param>
        /// <param name="segmented">whether or not script is segmented</param>
        /// <param name="scriptOutputDirectory">the output directory for the script</param>
        /// <param name="generateLast">whether or not to generate the last script</param>
        /// <param name="lastScriptsNumber">the last scripts number</param>
        public ConsoleScriptGeneratorView(string name, string description, string diagpath, bool segmented, string scriptOutputDirectory, bool generateLast, int lastScriptsNumber)
        {
            GeneratorConfiguration gc = new GeneratorConfiguration();
            gc.ScriptName = name;
            gc.ScriptDescription = description;
            gc.DiagPath = diagpath;
            gc.SegmentedScripts = segmented;
            gc.ScriptOutputDirectory = scriptOutputDirectory;
            gc.ScotConfigOutputDirectory = @"C:\sscat\scotconfig"; // TODO: Is this really needed?
            gc.GenerateLast = generateLast;
            gc.LastScriptsNumber = lastScriptsNumber;
            this.Configuration = gc;
        }

        /// <summary>
        /// Event handler for generating scripts
        /// </summary>
        public event EventHandler<GeneratorConfigurationEventArgs> Generate;

        /// <summary>
        /// Event handler for stopping scripts
        /// </summary>
        public event EventHandler Stopping;

        /// <summary>
        /// Event handler for when scripts stop
        /// </summary>
        public event EventHandler Stop;

        /// <summary>
        /// Gets or sets the generator configuration
        /// </summary>
        public GeneratorConfiguration Configuration
        {
            get { return _config; }
            set { _config = value; }
        }

        /// <summary>
        /// Show the view
        /// </summary>
        public override void ShowView()
        {
            base.ShowView();
            PerformGenerate();
        }

        /// <summary>
        /// Perform the script generation
        /// </summary>
        public void PerformGenerate()
        {
            OnGenerating(new GeneratorConfigurationEventArgs(Configuration));
        }

        /// <summary>
        /// Perform a script stop
        /// </summary>
        public void PerformStop()
        {
            OnStop(null);
        }

        /// <summary>
        /// Perform the script stopping
        /// </summary>
        public void PerformStopping()
        {
            OnStopping(null);
        }

        /// <summary>
        /// Perform a script disable
        /// </summary>
        public void PerformDisable()
        {
        }

        /// <summary>
        /// Perform the script generating
        /// </summary>
        public void PerformGenerating()
        {
            OnGenerating(new GeneratorConfigurationEventArgs(_config));
        }

        /// <summary>
        /// Event for when script is stopped
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnStop(EventArgs e)
        {
            if (Stop != null)
            {
                Stop(this, e);
            }
        }

        /// <summary>
        /// Event for script generating
        /// </summary>
        /// <param name="e">generator configuration event arguments</param>
        protected virtual void OnGenerating(GeneratorConfigurationEventArgs e)
        {
            if (Generate != null)
            {
                Generate(this, e);
            }
        }

        /// <summary>
        /// Event for script stopping
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnStopping(EventArgs e)
        {
            if (Stopping != null)
            {
                Stopping(this, e);
            }
        }
    }
}
