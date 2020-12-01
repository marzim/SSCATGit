// <copyright file="ArgumentParser.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System.Collections.Generic;

    /// <summary>
    /// Initializes a new instance of the ArgumentParser class
    /// </summary>
    public class ArgumentParser
    {
        /// <summary>
        /// List of arguments
        /// </summary>
        private IList<Argument> _arguments = new List<Argument>();

        /// <summary>
        /// Description for argument parser
        /// </summary>
        private string _description;

        /// <summary>
        /// Initializes a new instance of the ArgumentParser class
        /// </summary>
        public ArgumentParser()
        {
        }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Adds the argument
        /// </summary>
        /// <param name="argument">argument to add</param>
        /// <param name="help">help message</param>
        public void AddArgument(string argument, string help)
        {
            _arguments.Add(new Argument(argument, help));
        }

        /// <summary>
        /// Parses through each argument
        /// </summary>
        /// <param name="args">list of arguments</param>
        public void ParseArguments(string[] args)
        {
            foreach (string arg in args)
            {
            }
        }
    }
}
