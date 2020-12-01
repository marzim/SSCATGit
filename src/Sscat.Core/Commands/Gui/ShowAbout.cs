// <copyright file="ShowAbout.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Gui
{
    using Ncr.Core.Commands;
    using Ncr.Core.Views;
    using Sscat.Core.Gui;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ShowAbout class
    /// </summary>
    public class ShowAbout : AbstractCommand
    {
        /// <summary>
        /// Interface for the about view
        /// </summary>
        private IAboutView _view;

        /// <summary>
        /// Initializes a new instance of the ShowAbout class
        /// </summary>
        public ShowAbout()
            : this(new AboutForm())
        {
        }

        /// <summary>
        /// Initializes a new instance of the ShowAbout class
        /// </summary>
        /// <param name="view">about view</param>
        public ShowAbout(IAboutView view)
        {
            _view = view;
        }

        /// <summary>
        /// Runs the about view dialog
        /// </summary>
        public override void Run()
        {
            WorkbenchSingleton.ShowDialog(_view);
        }
    }
}
