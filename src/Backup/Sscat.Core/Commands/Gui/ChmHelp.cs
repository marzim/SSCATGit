// <copyright file="ChmHelp.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Gui
{
    using System.IO;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ChmHelp class
    /// </summary>
    public class ChmHelp : IHelp
    {
        /// <summary>
        /// Displays the SSCAT help
        /// </summary>
        public void Show()
        {
            ProcessUtility.Start(Path.Combine(ApplicationUtility.DocsDirectory, "SSCAT Help.chm"));
        }
    }
}
