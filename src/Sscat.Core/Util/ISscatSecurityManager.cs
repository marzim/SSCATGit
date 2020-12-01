// <copyright file="ISscatSecurityManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System;
    using Ncr.Core.Util;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ISscatSecurityManager interface
    /// </summary>
    public interface ISscatSecurityManager : ISecurityManager
    {
        /// <summary>
        /// Event handler for WLDB manage
        /// </summary>
        event EventHandler<WldbEventArgs> WldbManage;

        /// <summary>
        /// Update the WLDB
        /// </summary>
        /// <param name="item">WLDB event item</param>
        void UpdateWldb(IWldbEvent item);

        /// <summary>
        /// Create the update script
        /// </summary>
        /// <param name="item">WLDB event item</param>
        void CreateUpdateScript(IWldbEvent item);
    }
}
