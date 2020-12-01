// <copyright file="ILaneConfigurationRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories
{
    using Ncr.Core.Plugins;
    using Ncr.Core.Util;
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the ILaneConfigurationRepository interface
    /// </summary>
    public interface ILaneConfigurationRepository : IRepository
    {
        /// <summary>
        /// Save lane configuration
        /// </summary>
        /// <param name="config">lane configuration to save</param>
        void Save(LaneConfiguration config);

        /// <summary>
        /// Read the file
        /// </summary>
        /// <param name="file">file to read</param>
        /// <returns>Return the lane configuration</returns>
        LaneConfiguration Read(string file);
    }
}
