// <copyright file="ICustomGeneratorView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Views
{
    using System;
    using Ncr.Core.Views;
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the ICustomGeneratorView interface
    /// </summary>
    public interface ICustomGeneratorView : IView
    {
        /// <summary>
        /// Event handler for custom generate
        /// </summary>
        event EventHandler<GeneratorConfigurationEventArgs> CustomGenerate;

        /// <summary>
        /// Gets the output view
        /// </summary>
        IOutputView OutputView { get; }

        /// <summary>
        /// Writes the given text
        /// </summary>
        /// <param name="text">text to write</param>
        void WriteLine(string text);
    }
}
