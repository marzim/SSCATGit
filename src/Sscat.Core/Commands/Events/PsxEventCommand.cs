// <copyright file="PsxEventCommand.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System;
    using Ncr.Core.Util;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the PsxEventCommand class
    /// </summary>
    public class PsxEventCommand : AbstractEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the PsxEventCommand class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">script event item</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public PsxEventCommand(IScotLogHook hook, IPsxEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Gets the psx event item
        /// </summary>
        public IPsxEvent Item
        {
            get { return ScriptEventItem as IPsxEvent; }
        }

        /// <summary>
        /// Checks the rap connection prior to the psx event command being ran
        /// </summary>
        public override void PreRun()
        {
            try
            {
                if (Lane.Configuration.PlayerConfiguration.OverrideRapName && Item.HasRapConnection)
                {
                    Item.RemoteConnection = "RAP." + DnsHelper.GetIPAddress(Lane.Configuration.PlayerConfiguration.RapName);
                }
                else if (Item.HasRapConnection)
                {
                    Item.RemoteConnection = "RAP." + DnsHelper.GetIPAddress(Item.AbsoluteConnectionName());
                }
            }
           catch (NullReferenceException e)
            {
                throw new NullReferenceException(string.Format("Make sure values are not empty. {0}", e.Message));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
