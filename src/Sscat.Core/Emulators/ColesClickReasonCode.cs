// <copyright file="ColesClickReasonCode.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    using System;
    using Ncr.Core.Emulators;
    using Ncr.Core.Util;
    using Sscat.Core.Commands.Events.UIAutoTest;

    /// <summary>
    /// Initializes a new instance of the ColesClickReasonCode class
    /// </summary>
    public class ColesClickReasonCode : LaneCommand
    {
        /// <summary>
        /// Runs the lane login
        /// </summary>
        public override void Run()
        {
            try
            {
                LoggingService.Info(string.Format("[SmartExit] Clicking ListButton Control='ContainerCmdList', Button='CmdListItemConfirm', Index=1, Context='SmDataEntryWithCmdList'"));
                NextGenUITestClient.Instance.ClickListButton("ContainerCmdList", "CmdListItemConfirm", "1", "SmDataEntryWithCmdList");
                ThreadHelper.Sleep(200);
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
            }
        }
    }
}
