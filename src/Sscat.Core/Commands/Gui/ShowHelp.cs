// <copyright file="ShowHelp.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Gui
{
    using Ncr.Core.Commands;

    /// <summary>
    /// Initializes a new instance of the ShowHelp class
    /// </summary>
    public class ShowHelp : AbstractCommand
    {
        /// <summary>
        /// Interface for the help class
        /// </summary>
        private IHelp _help;

        /// <summary>
        /// Initializes a new instance of the ShowHelp class
        /// </summary>
        public ShowHelp()
            : this(new ChmHelp())
        {
        }

        /// <summary>
        /// Initializes a new instance of the ShowHelp class
        /// </summary>
        /// <param name="help">help interface</param>
        public ShowHelp(IHelp help)
        {
            _help = help;
        }

        /// <summary>
        /// Displays the SSCAT help
        /// </summary>
        public override void Run()
        {
            _help.Show();
        }
    }
}
