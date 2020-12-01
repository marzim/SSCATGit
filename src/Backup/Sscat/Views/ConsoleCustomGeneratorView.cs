// <copyright file="ConsoleCustomGeneratorView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Views
{
    using System;
    using Ncr.Core.Views;
    using Sscat.Core.Config;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ConsoleCustomGeneratorView class
    /// </summary>
    public class ConsoleCustomGeneratorView : BaseConsoleView, ICustomGeneratorView
    {
        /// <summary>
        /// Event handler for the custom script generator
        /// </summary>
        public event EventHandler<GeneratorConfigurationEventArgs> CustomGenerate;

        /// <summary>
        /// Gets the output view
        /// </summary>
        public IOutputView OutputView
        {
            get
            {
                return new ConsoleOutputView();
            }
        }

        /// <summary>
        /// Writes to the output view
        /// </summary>
        /// <param name="text">text to write</param>
        public void WriteLine(string text)
        {
            OutputView.WriteLine(text);
        }

        /// <summary>
        /// Event for custom generated scripts
        /// </summary>
        /// <param name="e">generator configuration event arguments</param>
        protected virtual void OnCustomGenerate(GeneratorConfigurationEventArgs e)
        {
            if (CustomGenerate != null)
            {
                CustomGenerate(this, e);
            }
        }
    }
}
