// <copyright file="ScriptPane.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Gui
{
    using System;
    using Ncr.Core.Gui;
    using Sscat.Core.Gui;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ScriptPane class
    /// </summary>
    public partial class ScriptPane : BaseUserControl, IScriptView
    {
        /// <summary>
        /// Interface for the script
        /// </summary>
        private IScript _script;

        /// <summary>
        /// Initializes a new instance of the ScriptPane class
        /// </summary>
        public ScriptPane()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for script save
        /// </summary>
        public event EventHandler<ScriptEventArgs> ScriptSave;

        /// <summary>
        /// Gets or sets the script
        /// </summary>
        public IScript Script
        {
            get
            {
                return _script;
            }

            set
            {
                _script = value;
                SetTitle(_script.FileName);
                treeView1.Nodes.Add(new ScriptTreeNode(_script));
            }
        }

        /// <summary>
        /// Click the save button
        /// </summary>
        public void Save()
        {
            ToolStripButton1Click(this, null);
        }

        /// <summary>
        /// Event for on script save
        /// </summary>
        /// <param name="e">script event arguments</param>
        protected virtual void OnScriptSave(ScriptEventArgs e)
        {
            if (ScriptSave != null)
            {
                ScriptSave(this, e);
            }
        }

        /// <summary>
        /// Event for clicking the save button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ToolStripButton1Click(object sender, EventArgs e)
        {
            OnScriptSave(new ScriptEventArgs(_script));
        }
    }
}
