// <copyright file="LaunchSsco.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Gui
{
    using System;
    using Ncr.Core.Commands;
    using Ncr.Core.Emulators;
    using Ncr.Core.Util;
    using Sscat.Core.Emulators;
    using Sscat.Core.Gui;

    /// <summary>
    /// Initializes a new instance of the LaunchSsco class
    /// </summary>
    public class LaunchSsco : AbstractCommand
    {
        /// <summary>
        /// SSCAT lane
        /// </summary>
        private SscatLane _lane;
        
        /// <summary>
        /// Interface for the message view form
        /// </summary>
        private IMessageView _form;

        /// <summary>
        /// Initializes a new instance of the LaunchSsco class
        /// </summary>
        public LaunchSsco()
            : this(SscatContext.Lane, new MessageForm())
        {
        }

        /// <summary>
        /// Initializes a new instance of the LaunchSsco class
        /// </summary>
        /// <param name="lane">sscat lane</param>
        /// <param name="form">message view form</param>
        public LaunchSsco(SscatLane lane, IMessageView form)
        {
            _lane = lane;
            _form = form;
        }

        /// <summary>
        /// Gets a value indicating whether the lane exists
        /// </summary>
        public override bool CanRun
        {
            get { return _lane.Exists; }
        }

        /// <summary>
        /// Starts up SSCO if it is not already started
        /// </summary>
        public override void Run()
        {
            ISscatLaunchPad pad = new SscatLaunchPad(new DefaultLaunchPadLauncher(), ApplicationFactory.GetApplication(_lane, new Rap()), new StoreServer());
            try
            {
                _lane.CheckForStoreLogin = false;
                if (_lane.HasStarted)
                {
                    MessageService.ShowInfo("SSCO Application has already started");
                }
                else
                {
                    ThreadHelper.Start(pad.Start);
                }
            }
            catch (ObjectDisposedException ex)
            {
                LoggingService.Error(ex.ToString());
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                MessageService.ShowInfo(ex.Message);
            }
        }
    }
}
