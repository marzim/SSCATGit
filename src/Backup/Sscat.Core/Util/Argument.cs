// <copyright file="Argument.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System.Collections.Generic;

    /// <summary>
    /// Initializes a new instance of the Argument class
    /// </summary>
    public class Argument
    {
        /// <summary>
        /// Argument name
        /// </summary>
        private string _name;

        /// <summary>
        /// Help message
        /// </summary>
        private string _help;

        /// <summary>
        /// Initializes a new instance of the Argument class
        /// </summary>
        /// <param name="name">argument name</param>
        /// <param name="help">help message</param>
        public Argument(string name, string help)
        {
            Name = name;
            Help = help;
        }

        /// <summary>
        /// Sets the help message
        /// </summary>
        public string Help
        {
            set { _help = value; }
        }

        /// <summary>
        /// Sets the name
        /// </summary>
        public string Name
        {
            set { _name = value; }
        }
    }
}
