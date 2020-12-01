// <copyright file="DeleteScotLogs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Gui
{
    using System;
    using System.Windows.Forms;
    using Ncr.Core.Commands;
    using Ncr.Core.Emulators;
    using Ncr.Core.Util;
    using Sscat.Core.Emulators;
    using Sscat.Core.Gui;

    /// <summary>
    /// Initializes a new instance of the DeleteScotLogs class
    /// </summary>
    public class DeleteScotLogs : AbstractCommand
    {
        /// <summary>
        /// SSCAT lane
        /// </summary>
        private SscatLane _lane;

        /// <summary>
        /// Initializes a new instance of the DeleteScotLogs class
        /// </summary>
        public DeleteScotLogs()
            : this(SscatContext.Lane)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DeleteScotLogs class
        /// </summary>
        /// <param name="lane">sscat lane</param>
        public DeleteScotLogs(SscatLane lane)
        {
            _lane = lane;
        }

        /// <summary>
        /// Gets a value indicating whether the lane can run
        /// </summary>
        public override bool CanRun
        {
            get { return _lane.Exists; }
        }

        /// <summary>
        /// Deletes the SCOT logs and reboots SSCO if user wants it to
        /// </summary>
        public override void Run()
        {
            _lane.LaunchPad = new SscatLaunchPad(new DefaultLaunchPadLauncher(), ApplicationFactory.GetApplication(_lane, new Rap()), new StoreServer());
            LoadingFormThread loadingForm = new LoadingFormThread("Delete Scot Logs", "Please wait while SSCAT is deleting SCOT Logs.");
            try
            {
                if (_lane.HasStarted)
                {
                    DialogResult diagResult = MessageService.ShowYesNoCancel("SSCAT will terminate SSCO before deleting SCOT logs. Would you like to re-launch the SSCO after deleting SCOT logs?");
                    loadingForm.Start();
                    switch (diagResult)
                    {
                        case DialogResult.Yes:
                            _lane.ForceKill();
                            ThreadHelper.Sleep(1000);
                            _lane.DeleteLogs();
                            ThreadHelper.Sleep(1000);
                            loadingForm.Kill();
                            _lane.Start();
                            break;
                        case DialogResult.No:
                            _lane.ForceKill();
                            ThreadHelper.Sleep(1000);
                            _lane.DeleteLogs();
                            ThreadHelper.Sleep(1000);
                            loadingForm.Kill();
                            MessageService.ShowInfo("SCOT logs deleted.");
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                }
                else
                {
                    loadingForm.Start();
                    _lane.ForceKill();
                    ThreadHelper.Sleep(100);
                    _lane.DeleteLogs();
                    loadingForm.Kill();
                    MessageService.ShowInfo("SCOT logs deleted.");
                }
            }
            catch (Exception ex)
            {
                loadingForm.Kill();
                LoggingService.Error(ex.ToString());
                MessageService.ShowError(ex.Message);
            }
            finally
            {
                loadingForm.Kill();
            }
        }
    }
}