// <copyright file="SscatRequest.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using Ncr.Core.Net;

    /// <summary>
    /// Initializes a new instance of the SscatRequest class
    /// </summary>
    public class SscatRequest : Request
    {
        /// <summary>
        /// Generate scripts
        /// </summary>
        public const string GENERATE_SCRIPTS = "GENERATE_SCRIPTS";

        /// <summary>
        /// Play scripts
        /// </summary>
        public const string PLAY_SCRIPT = "PLAY_SCRIPT";

        /// <summary>
        /// Get configuration
        /// </summary>
        public const string GET_CONFIG = "GET_CONFIG";

        /// <summary>
        /// Load configuration
        /// </summary>
        public const string LOAD_CONFIG = "LOAD_CONFIG";

        /// <summary>
        /// Check configuration
        /// </summary>
        public const string CHECK_CONFIG = "CHECK_CONFIG";

        /// <summary>
        /// Update the weight learning database
        /// </summary>
        public const string UPDATE_WLDB = "UPDATE_WLDB";

        /// <summary>
        /// Backup the weight learning database
        /// </summary>
        public const string BACKUP_WLDB = "BACKUP_WLDB";

        /// <summary>
        /// Stop the player
        /// </summary>
        public const string STOP_PLAYER = "STOP_PLAYER";
    }
}
