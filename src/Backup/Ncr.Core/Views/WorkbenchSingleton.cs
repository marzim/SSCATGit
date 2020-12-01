// <copyright file="WorkbenchSingleton.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Views
{
    using System;
    using System.Windows.Forms;
    using Ncr.Core.Plugins;

    /// <summary>
    /// Initializes a new instance of the SdiWorkbenchLayout class
    /// </summary>
    public static class WorkbenchSingleton
    {
        /// <summary>
        /// Workbench interface
        /// </summary>
        private static IWorkbench _workbench;

        /// <summary>
        /// Gets the workbench
        /// </summary>
        public static IWorkbench Workbench
        {
            get { return _workbench; }
        }

        /// <summary>
        /// Gets the main form
        /// </summary>
        public static Form MainForm
        {
            get
            {
                Form form = _workbench as Form;
                if (form == null)
                {
                    throw new ArgumentNullException("Workbench");
                }

                return form;
            }
        }

        /// <summary>
        /// Attach the workbench
        /// </summary>
        /// <param name="workbench">workbench to attach</param>
        public static void Attach(IWorkbench workbench)
        {
            Attach(workbench, null);
        }

        /// <summary>
        /// Attach the workbench
        /// </summary>
        /// <param name="workbench">workbench to attach</param>
        /// <param name="layout">workbench layout</param>
        public static void Attach(IWorkbench workbench, IWorkbenchLayout layout)
        {
            Attach(workbench, layout, null);
        }

        /// <summary>
        /// Attach the workbench
        /// </summary>
        /// <param name="workbench">workbench to attach</param>
        /// <param name="layout">workbench layout</param>
        /// <param name="plugin">plugin to attach</param>
        public static void Attach(IWorkbench workbench, IWorkbenchLayout layout, Plugin plugin)
        {
            if (layout != null)
            {
                workbench.WorkbenchLayout = layout;
            }

            if (plugin != null)
            {
                workbench.StatusBar = plugin.CreateStatusBar();
                workbench.ToolBar = plugin.CreateToolBar();
                workbench.MainMenu = plugin.CreateMenu();
            }

            WorkbenchSingleton._workbench = workbench;
        }

        /// <summary>
        /// Show view
        /// </summary>
        /// <param name="view">view interface</param>
        public static void ShowView(IView view)
        {
            if (_workbench == null)
            {
                throw new ArgumentNullException("Workbench");
            }

            _workbench.ShowView(view);
        }

        /// <summary>
        /// Show dialog
        /// </summary>
        /// <param name="window">window interface</param>
        /// <returns>Returns the dialog result</returns>
        public static DialogResult ShowDialog(IWin32Window window)
        {
            return _workbench.WorkbenchLayout.ShowDialogView(window);
        }

        /// <summary>
        /// Closes all windows
        /// </summary>
        public static void CloseAllWindows()
        {
            if (_workbench == null)
            {
                throw new ArgumentNullException("Workbench");
            }
            else if (_workbench.WorkbenchLayout == null)
            {
                throw new ArgumentNullException("WorkbenchLayout");
            }

            _workbench.WorkbenchLayout.CloseAllWindows();
        }

        /// <summary>
        /// Closes active window
        /// </summary>
        public static void CloseActiveWindow()
        {
            if (_workbench == null)
            {
                throw new ArgumentNullException("Workbench");
            }
            else if (_workbench.WorkbenchLayout == null)
            {
                throw new ArgumentNullException("WorkbenchLayout");
            }

            _workbench.WorkbenchLayout.CloseActiveWindow();
        }
    }
}
