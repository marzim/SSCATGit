// <copyright file="XmEventCommand.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the XmEventCommand class
    /// </summary>
    public class XmEventCommand : AbstractEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the XmEventCommand class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">cash management event item</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public XmEventCommand(IScotLogHook hook, IXmEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Gets the cash management event item
        /// </summary>
        public IXmEvent Item
        {
            get { return ScriptEventItem as IXmEvent; }
        }
    }
}
