// <copyright file="DeviceEventCommand.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using Sscat.Core.Config;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the DeviceEventCommand class
    /// </summary>
    public class DeviceEventCommand : AbstractEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the DeviceEventCommand class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event item</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public DeviceEventCommand(IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Gets the device event item
        /// </summary>
        public IDeviceEvent Item
        {
            get
            {
                return ScriptEventItem as IDeviceEvent;
            }
        }

        /// <summary>
        /// Prior to the event, runs checking for MSR configuration
        /// </summary>
        public override void PreRun()
        {
            if (Item.Id.Equals("MSR"))
            {
                foreach (MSRCard card in Lane.Configuration.PlayerConfiguration.WalmartCards.Cards)
                {
                    if (card.Name.Equals(Item.Value))
                    {
                        Item.Value = string.Concat(card.Track1, "~", card.Track2, "~", card.Track3);
                        break;
                    }
                }

                if (!Item.Value.Contains("~"))
                {
                    MSRCard card = Lane.Configuration.PlayerConfiguration.WalmartCards.Cards[0];
                    Item.Value = string.Concat(card.Track1, "~", card.Track2, "~", card.Track3);
                }
            }
        }
    }
}
