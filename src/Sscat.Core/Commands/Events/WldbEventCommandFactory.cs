// <copyright file="WldbEventCommandFactory.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System;
    using Sscat.Core.Commands.Events;
    using Sscat.Core.Emulators;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the WldbEventCommandFactory class
    /// </summary>
    public class WldbEventCommandFactory : EventCommandFactory
    {
        /// <summary>
        /// Interface for the weight learning database event item
        /// </summary>
        private IWldbEvent _item;

        /// <summary>
        /// Initializes a new instance of the WldbEventCommandFactory class
        /// </summary>
        /// <param name="item">weight learning database event item</param>
        /// <param name="lane">sscat lane</param>
        public WldbEventCommandFactory(IWldbEvent item, SscatLane lane)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (lane == null)
            {
                throw new ArgumentNullException("lane");
            }

            _item = item;
            Lane = lane;
        }

        /// <summary>
        /// Creates the weight learning database event command
        /// </summary>
        /// <returns>Returns event command</returns>
        public override IEventCommand CreateCommand()
        {
            switch (_item.Action)
            {
                case Constants.WldbEvent.UPDATE:
                    return new UpdateWldb(_item, Lane);
                default:
                    throw new NotSupportedException(string.Format("WLDB action '{0}' not supported.", _item.Action));
            }
        }
    }
}
