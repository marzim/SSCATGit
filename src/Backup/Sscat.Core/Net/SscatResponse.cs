// <copyright file="SscatResponse.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using Ncr.Core.Net;

    /// <summary>
    /// Initializes a new instance of the SscatResponse class
    /// </summary>
    public class SscatResponse : Response
    {
        /// <summary>
        /// SSCAT scripts
        /// </summary>
        public const string SCRIPTS = "SCRIPTS";

        /// <summary>
        /// Event result
        /// </summary>
        public const string EVENT_RESULT = "EVENT_RESULT";
        
        /// <summary>
        /// Warning Event result
        /// </summary>
        public const string WARNING_EVENT_RESULT = "WARNING_EVENT_RESULT";

        /// <summary>
        /// Script configurations
        /// </summary>
        public const string CONFIGS = "CONFIGS";

        /// <summary>
        /// Script configuration
        /// </summary>
        public const string CONFIG = "CONFIG";

        /// <summary>
        /// Script message
        /// </summary>
        public const string MESSAGE = "MESSAGE";

        /// <summary>
        /// Script error
        /// </summary>
        public const string ERROR = "ERROR";

        /// <summary>
        /// Script result
        /// </summary>
        public const string SCRIPT_RESULT = "SCRIPT_RESULT";

        /// <summary>
        /// Playback report
        /// </summary>
        public const string PLAYBACK = "PLAYBACK";

        /// <summary>
        /// Player stopped
        /// </summary>
        public const string PLAYER_STOPPED = "PLAYER_STOPPED";

        /// <summary>
        /// Configuration loaded
        /// </summary>
        public const string CONFIG_LOADED = "CONFIG_LOADED";

        /// <summary>
        /// Configuration stopped
        /// </summary>
        public const string CONFIG_CHECKED = "CONFIG_CHECKED";

        /// <summary>
        /// SSCAT stopped
        /// </summary>
        public const string STOPPED = "STOPPED";
    }
}
