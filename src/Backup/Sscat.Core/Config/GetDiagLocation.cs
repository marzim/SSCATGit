// <copyright file="GetDiagLocation.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;
    using System.IO;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the GetDiagLocation class
    /// </summary>
    public class GetDiagLocation
    {
        /// <summary>
        /// Launch pad configuration
        /// </summary>
        private LaunchPadConfig _configuration;

        /// <summary>
        /// Initializes a new instance of the GetDiagLocation class
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="repository">launch pad configuration repository</param>
        public GetDiagLocation(string filename, ILaunchPadConfigRepository repository)
        {
            if (FileHelper.Exists(filename))
            {
                _configuration = repository.Read(filename);
            }
            else
            {
                throw new Exception(string.Format("{0} does not exist", filename));
            }
        }

        /// <summary>
        /// Gets the file name
        /// </summary>
        /// <returns>Returns the file name</returns>
        public string GetFilename()
        {
            foreach (LaunchPadConfigExecutable exec in _configuration.LaunchPadConfigExecutables)
            {
                if (exec.ExecutableName.Equals("GenerateLog"))
                {
                    return Path.Combine(exec.Path, exec.Filename).Replace("%APP_DRIVE%", @"C:");
                }
            }

            return null;
        }
    }
}
