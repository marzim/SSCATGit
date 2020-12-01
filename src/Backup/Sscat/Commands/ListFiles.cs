// <copyright file="ListFiles.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Commands
{
    using System.Collections.Generic;
    using System.IO;
    using Ncr.Core.Commands;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ListFiles class
    /// </summary>
    public class ListFiles : AbstractCommand
    {
        /// <summary>
        /// Search pattern filters for the list files
        /// </summary>
        private string[] _filters;

        /// <summary>
        /// Initializes a new instance of the ListFiles class
        /// </summary>
        /// <param name="filters">search pattern filters for the list files</param>
        public ListFiles(params string[] filters)
        {
            _filters = filters;
        }

        /// <summary>
        /// Add files in the list based on the search pattern filter
        /// </summary>
        public override void Run()
        {
            int i = 0;
            List<string> files = new List<string>();
            foreach (string filter in _filters)
            {
                files.AddRange(DirectoryHelper.GetFiles(DirectoryHelper.GetCurrentDirectory(), filter));
            }

            foreach (string file in files)
            {
                MessageService.ShowInfo(string.Format("[{0}] {1}", i++, Path.GetFileName(file)));
            }
        }
    }
}
