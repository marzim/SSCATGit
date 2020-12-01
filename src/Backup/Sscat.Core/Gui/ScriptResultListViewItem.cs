// <copyright file="ScriptResultListViewItem.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using Ncr.Core.ExtensionMethods;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ScriptResultListViewItem class
    /// </summary>
    public class ScriptResultListViewItem : ListViewItem
    {
        /// <summary>
        /// Script file
        /// </summary>
        private ScriptFile _scriptFile;

        /// <summary>
        /// Initializes a new instance of the ScriptResultListViewItem class
        /// </summary>
        /// <param name="script">script file</param>
        public ScriptResultListViewItem(ScriptFile script)
        {
            _scriptFile = script;

            SubItems.Add(Path.GetFileName(script.File));
            SubItems.Add(string.Empty);
            SubItems.Add(string.Empty);
            SubItems.Add(string.Empty);
            SubItems.Add(string.Empty);
            SubItems.Add(string.Empty);
            SubItems.Add(string.Empty);
            script.ResultChanged += new EventHandler<ResultEventArgs>(ScriptResultChanged);
        }

        /// <summary>
        /// Finalizes an instance of the ScriptResultListViewItem class
        /// </summary>
        ~ScriptResultListViewItem()
        {
            _scriptFile.ResultChanged -= new EventHandler<ResultEventArgs>(ScriptResultChanged);
        }

        /// <summary>
        /// Gets the parent control
        /// </summary>
        public Control Parent
        {
            get
            {
                if (ListView != null)
                {
                    if (ListView.Parent != null)
                    {
                        return ListView.Parent;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// Event for script result changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">result event arguments</param>
        private void ScriptResultChanged(object sender, ResultEventArgs e)
        {
            if (Parent != null)
            {
                if (Parent.InvokeRequired)
                {
                    Parent.Invoke(new EventHandler<ResultEventArgs>(ScriptResultChanged), new object[] { sender, e });
                }
                else
                {
                    if (e.Result.Type == ResultType.None)
                    {
#if NET40
                        SubItems[2].Text = e.Result.Duration.MillisecondsToSeconds();
#else
                        SubItems[2].Text = e.Result.Duration.ToString();
#endif
                        SubItems[3].Text = string.Empty;
                        SubItems[4].Text = string.Empty;
                        SubItems[5].Text = string.Empty;
                        SubItems[6].Text = e.Result.ScreenshotPath;
                        SubItems[7].Text = e.Result.DiagnosticPath;                        
                    }
                    else
                    {
#if NET40
                        SubItems[2].Text = e.Result.Duration.MillisecondsToSeconds();
#else
                        SubItems[2].Text = e.Result.Duration.ToString();
#endif
                        SubItems[3].Text = e.Result.Type.ToString();
                        SubItems[4].Text = e.Result.Notes;
                        SubItems[5].Text = e.Result.NumberOfWarnings.ToString();
                        SubItems[6].Text = e.Result.ScreenshotPath;
                        SubItems[7].Text = e.Result.DiagnosticPath;                        
                        if (ListView != null)
                        {
                            ListView.SelectedItems.Clear();
                            ListView.EnsureVisible(this.Index);
                            this.Selected = true;
                        }
                    }
                }
            }
        }
    }
}
