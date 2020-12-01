// <copyright file="WldbEventCommand.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Events.Wldb
{
    using Sscat.Core.Emulators;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the WldbEventCommand class
    /// </summary>
    public class WldbEventCommand : AbstractEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the WldbEventCommand class
        /// </summary>
        /// <param name="item">weight learning database event</param>
        /// <param name="lane">sscat lane</param>
        public WldbEventCommand(IWldbEvent item, SscatLane lane)
        {
            ScriptEventItem = item;
            Lane = lane;
        }

        /// <summary>
        /// Gets the weight learning database event
        /// </summary>
        public IWldbEvent Item
        {
            get { return Item as IWldbEvent; }
        }

        /// <summary>
        /// Runs prior to the weight learning database event
        /// </summary>
        public override void PreRun()
        {
            if (Lane.Configuration.PlayerConfiguration.OverrideSecurityServer)
            {
                Item.Host = Lane.Configuration.PlayerConfiguration.SecurityServer;
            }
        }
    }
}
