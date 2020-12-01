// <copyright file="ScriptResultListView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ScriptResultListView class
    /// </summary>
    public class ScriptResultListView : ListView
    {
        /// <summary>
        /// Script files
        /// </summary>
        private List<ScriptFile> _scriptFiles = new List<ScriptFile>();

        /// <summary>
        /// Initializes a new instance of the ScriptResultListView class
        /// </summary>
        public ScriptResultListView()
        {
            ScriptAdded += new EventHandler<ScriptEventArgs>(ViewScriptAdded);
            SelectedIndexChanged += new EventHandler(ViewSelectedIndexChanged);
            ScriptsChanged += new EventHandler(ViewScriptsChanged);
        }

        /// <summary>
        /// Finalizes an instance of the ScriptResultListView class
        /// </summary>
        ~ScriptResultListView()
        {
            ScriptAdded -= new EventHandler<ScriptEventArgs>(ViewScriptAdded);
            SelectedIndexChanged -= new EventHandler(ViewSelectedIndexChanged);
            ScriptsChanged -= new EventHandler(ViewScriptsChanged);
        }

        /// <summary>
        /// Event handler for the selected script changed
        /// </summary>
        public event EventHandler<ScriptEventArgs> SelectedScriptChanged;

        /// <summary>
        /// Event handler for scripts changed
        /// </summary>
        public event EventHandler ScriptsChanged;

        /// <summary>
        /// Event handler for the script added
        /// </summary>
        public event EventHandler<ScriptEventArgs> ScriptAdded;

        /// <summary>
        /// Gets the script files
        /// </summary>
        public List<ScriptFile> Scripts
        {
            get { return _scriptFiles; }
        }

        /// <summary>
        /// Gets the selected script
        /// </summary>
        public ScriptFile SelectedScript
        {
            get
            {
                if (SelectedItems.Count > 0)
                {
                    return _scriptFiles[SelectedItems[0].Index];
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the selected scripts
        /// </summary>
        public IList<ScriptFile> SelectedScripts
        {
            get
            {
                IList<ScriptFile> selectedScripts = new List<ScriptFile>();
                if (SelectedItems.Count > 0)
                {
                    foreach (ListViewItem li in SelectedItems)
                    {
                        selectedScripts.Add(_scriptFiles[li.Index]);
                    }
                }

                return selectedScripts;
            }
        }

        /// <summary>
        /// Removes the selected scripts
        /// </summary>
        public void RemoveSelectedScripts()
        {
            if (SelectedScripts.Count > 0)
            {
                foreach (ScriptFile f in SelectedScripts)
                {
                    _scriptFiles.Remove(f);
                }

                OnScriptsChanged(null);
            }
        }

        /// <summary>
        /// Removes a single selected script
        /// </summary>
        public void RemoveSelectedScript()
        {
            if (SelectedScript != null)
            {
                _scriptFiles.RemoveAt(SelectedItems[0].Index);
                OnScriptsChanged(null);
            }
        }

        /// <summary>
        /// Clears the scripts
        /// </summary>
        public void ClearScripts()
        {
            _scriptFiles = new List<ScriptFile>();
            Items.Clear();
            OnScriptsChanged(null);
        }

        /// <summary>
        /// Clears the results
        /// </summary>
        public void ClearResults()
        {
            foreach (ScriptFile s in Scripts)
            {
                s.Result = new Result(ResultType.None, string.Empty);
            }
        }

        /// <summary>
        /// Adds a script files
        /// </summary>
        /// <param name="files">files to add</param>
        public void AddScript(string[] files)
        {
            List<string> ss = new List<string>();
            foreach (string file in files)
            {
                ss.Add(file);
            }

            ss.Sort(new FileNameComparer());
            AddScript(ss);
        }

        /// <summary>
        /// Add scripts
        /// </summary>
        /// <param name="scripts">scripts to add</param>
        public void AddScript(List<string> scripts)
        {
            foreach (string script in scripts)
            {
                AddScript(script);
            }
        }

        /// <summary>
        /// Add scripts
        /// </summary>
        /// <param name="scripts">scripts to add</param>
        public void AddScript(List<IScript> scripts)
        {
            foreach (IScript script in scripts)
            {
                AddScript(script.FileName);
            }
        }

        /// <summary>
        /// Add script
        /// </summary>
        /// <param name="script">script to add</param>
        public void AddScript(string script)
        {
            ScriptFile file = new ScriptFile(script);
            _scriptFiles.Add(file);
            OnScriptAdded(new ScriptEventArgs(file));
        }

        /// <summary>
        /// Event for on scripts changed
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnScriptsChanged(EventArgs e)
        {
            if (ScriptsChanged != null)
            {
                ScriptsChanged(this, e);
            }
        }

        /// <summary>
        /// Event for on selected script changed
        /// </summary>
        /// <param name="e">script event arguments</param>
        protected virtual void OnSelectedScriptChanged(ScriptEventArgs e)
        {
            if (SelectedScriptChanged != null)
            {
                SelectedScriptChanged(this, e);
            }
        }

        /// <summary>
        /// Event for on script added
        /// </summary>
        /// <param name="e">script event arguments</param>
        protected virtual void OnScriptAdded(ScriptEventArgs e)
        {
            if (ScriptAdded != null)
            {
                ScriptAdded(this, e);
            }
        }

        /// <summary>
        /// Event for view scripts changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ViewScriptsChanged(object sender, EventArgs e)
        {
            Items.Clear();
            foreach (ScriptFile script in _scriptFiles)
            {
                AddToListView(script);
            }
        }

        /// <summary>
        /// Add script to list view
        /// </summary>
        /// <param name="script">script to add</param>
        private void AddToListView(ScriptFile script)
        {
            ScriptResultListViewItem li = Items.Add(new ScriptResultListViewItem(script)) as ScriptResultListViewItem;
            li.Text = (li.Index + 1).ToString();
            script.Index = li.Index;
        }

        /// <summary>
        /// Event for view selected index changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ViewSelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedScript != null)
            {
                OnSelectedScriptChanged(new ScriptEventArgs(SelectedScript));
            }
        }

        /// <summary>
        /// Event for view script added
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">script event arguments</param>
        private void ViewScriptAdded(object sender, ScriptEventArgs e)
        {
            AddToListView(e.ScriptFile);
        }
    }
}
