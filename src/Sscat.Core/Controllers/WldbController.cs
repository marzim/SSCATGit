// <copyright file="WldbController.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Controllers
{
    using System;
    using Ncr.Core.Controllers;
    using Ncr.Core.Util;
    using Ncr.Core.Views;
    using Sscat.Core.Gui;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the WldbController class
    /// </summary>
    public class WldbController : AbstractController, IWldbController
    {
        /// <summary>
        /// Interface for the weight learning database manager view
        /// </summary>
        private IWldbManagerView _managerView;

        /// <summary>
        /// Interface for the SSCAT security manager
        /// </summary>
        private ISscatSecurityManager _securityManager;

        /// <summary>
        /// Loading form thread
        /// </summary>
        private LoadingFormThread _loadingForm;

        /// <summary>
        /// Initializes a new instance of the WldbController class
        /// </summary>
        /// <param name="securityManager">security manager</param>
        /// <param name="managerView">weight learning database manager view</param>
        public WldbController(ISscatSecurityManager securityManager, IWldbManagerView managerView)
        {
            _managerView = managerView;
            _securityManager = securityManager;

            securityManager.WldbManage += new EventHandler<WldbEventArgs>(SecurityManagerWldbManage);
            managerView.Managing += new EventHandler<WldbEventArgs>(ManagerViewManaging);
        }

        /// <summary>
        /// Finalizes an instance of the WldbController class
        /// </summary>
        ~WldbController()
        {
            _securityManager.WldbManage -= new EventHandler<WldbEventArgs>(SecurityManagerWldbManage);
            _managerView.Managing -= new EventHandler<WldbEventArgs>(ManagerViewManaging);
        }

        /// <summary>
        /// Manage view
        /// </summary>
        /// <returns>Returns manager view</returns>
        public IView Manage()
        {
            return _managerView;
        }

        /// <summary>
        /// Security manager weight learning database manage event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">wldb event arguments</param>
        private void SecurityManagerWldbManage(object sender, WldbEventArgs e)
        {
            _loadingForm.Kill();
            MessageService.ShowInfo(e.Message);
        }

        /// <summary>
        /// Manager view managing event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">wldb event arguments</param>
        private void ManagerViewManaging(object sender, WldbEventArgs e)
        {
            switch (e.Mode)
            {
                case "UpdateWLDBFiles":
                    _loadingForm = new LoadingFormThread("Update WLDB Files", "Please wait while SSCAT is updating WLDB Files.");
                    _loadingForm.Start();
                    _securityManager.UpdateWldb(e.Event);
                    break;
                case "CreateUpdateScript":
                    _loadingForm = new LoadingFormThread("Create Update WLDB Script", "Please wait while SSCAT is creating Update WLDB Scripts.");
                    _loadingForm.Start();
                    _securityManager.CreateUpdateScript(e.Event);
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
