// <copyright file="UpdateWldb.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;
    using Sscat.Core.Commands.Events.Wldb;
    using Sscat.Core.Emulators;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the UpdateWldb class
    /// </summary>
    public class UpdateWldb : WldbEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the UpdateWldb class
        /// </summary>
        /// <param name="item">weight learning database event</param>
        /// <param name="lane">sscat lane</param>
        public UpdateWldb(IWldbEvent item, SscatLane lane)
            : base(item, lane)
        {
        }

        /// <summary>
        /// Runs the update weight learning database event
        /// </summary>
        public override void Run()
        {
            try
            {
                Item.Password = CryptographyHelper.Decrypt(Item.Password, Item.User);
                Lane.SecurityManager.WldbManage += new EventHandler<WldbEventArgs>(LaneSecurityManagerWldbManage);
                Lane.SecurityManager.UpdateWldb(Item);
                Result = new Result(ResultType.Passed, "OK");
            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {
                Result = new Result(ResultType.Failed, Regex.Replace(ex.Message, @"\t|\n|\r", "; "));
            }
            catch (SecurityManagerException ex)
            {
                Result = new Result(ResultType.Failed, Regex.Replace(ex.Message, @"\t|\n|\r", "; "));
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.ToString());
                throw;
            }
            finally
            {
                Lane.SecurityManager.WldbManage -= new EventHandler<WldbEventArgs>(LaneSecurityManagerWldbManage);
            }
        }

        /// <summary>
        /// Runs the lane security manager for the weight learning database
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">weight learning database event arguments</param>
        private void LaneSecurityManagerWldbManage(object sender, WldbEventArgs e)
        {
            OnRunning(e.Message);
        }
    }
}
