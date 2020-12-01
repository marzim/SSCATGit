// <copyright file="ScriptEventFormatter.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ScriptEventFormatter class
    /// </summary>
    public class ScriptEventFormatter
    {
        /// <summary>
        /// Interface for the script event
        /// </summary>
        private IScriptEvent _scriptEvent;

        /// <summary>
        /// Initializes a new instance of the ScriptEventFormatter class
        /// </summary>
        /// <param name="scriptEvent">script event</param>
        public ScriptEventFormatter(IScriptEvent scriptEvent)
        {
            _scriptEvent = scriptEvent;
        }

        /// <summary>
        /// Formats the script event item string
        /// </summary>
        /// <returns>Returns the formatted string</returns>
        public override string ToString()
        {
            return _scriptEvent.Item is IPsxEvent ? GetPsxString() : GetDeviceString();
        }

        /// <summary>
        /// Gets the device string
        /// </summary>
        /// <returns>Returns the formatted string with the device event information</returns>
        private string GetDeviceString()
        {
            IDeviceEvent item = _scriptEvent.Item as IDeviceEvent;
            return string.Format("{0}({1})", item.Id, item.Value);
        }

        /// <summary>
        /// Gets the PSX string
        /// </summary>
        /// <returns>Returns the formatted string with the PSX event information</returns>
        private string GetPsxString()
        {
            IPsxEvent item = _scriptEvent.Item as IPsxEvent;
            return string.Format("Psx.{0}({1}, {2}, {3} {4})", item.Event, item.Context, item.Control, item.Param, item.RemoteConnection);
        }
    }
}
