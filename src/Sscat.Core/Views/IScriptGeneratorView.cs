// <copyright file="IScriptGeneratorView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Views
{
    using System;
    using Ncr.Core.Views;
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the IScriptGeneratorView interface
    /// </summary>
    public interface IScriptGeneratorView : IView
    {
        /// <summary>
        /// Event handler for generate
        /// </summary>
        event EventHandler<GeneratorConfigurationEventArgs> Generate;

        /// <summary>
        /// Event handler for stop
        /// </summary>
        event EventHandler Stop;

        /// <summary>
        /// Event handler for stopping
        /// </summary>
        event EventHandler Stopping;

        /// <summary>
        /// Gets or sets the generator configuration
        /// </summary>
        GeneratorConfiguration Configuration { get; set; }

        /// <summary>
        /// Perform the generate
        /// </summary>
        void PerformGenerate();

        /// <summary>
        /// Perform the stop
        /// </summary>
        void PerformStop();

        /// <summary>
        /// Perform the stopping
        /// </summary>
        void PerformStopping();

        /// <summary>
        /// Perform the disable
        /// </summary>
        void PerformDisable();

        /// <summary>
        /// Perform the generating
        /// </summary>
        void PerformGenerating();
    }
}
