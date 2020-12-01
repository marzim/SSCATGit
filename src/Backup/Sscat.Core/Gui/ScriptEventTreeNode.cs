// <copyright file="ScriptEventTreeNode.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System.Windows.Forms;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ScriptEventTreeNode class
    /// </summary>
    public class ScriptEventTreeNode : TreeNode
    {
        /// <summary>
        /// Interface for the script event
        /// </summary>
        private IScriptEvent _scriptEvent;

        /// <summary>
        /// Initializes a new instance of the ScriptEventTreeNode class 
        /// </summary>
        /// <param name="scriptEvent">script event</param>
        public ScriptEventTreeNode(IScriptEvent scriptEvent)
            : this(scriptEvent, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ScriptEventTreeNode class 
        /// </summary>
        /// <param name="scriptEvent">script event</param>
        /// <param name="imageIndex">image index</param>
        public ScriptEventTreeNode(IScriptEvent scriptEvent, int imageIndex)
        {
            Event = scriptEvent;
            ImageIndex = this.SelectedImageIndex = imageIndex;
        }

        /// <summary>
        /// Sets the script event
        /// </summary>
        public IScriptEvent Event
        {
            set
            {
                _scriptEvent = value;
                Text = _scriptEvent.ToString();
            }
        }
    }
}
