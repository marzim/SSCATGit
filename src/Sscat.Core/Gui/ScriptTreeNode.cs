// <copyright file="ScriptTreeNode.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System.Windows.Forms;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ScriptTreeNode class
    /// </summary>
    public class ScriptTreeNode : TreeNode
    {
        /// <summary>
        /// Interface for the script
        /// </summary>
        private IScript _script;

        /// <summary>
        /// Initializes a new instance of the ScriptTreeNode class
        /// </summary>
        /// <param name="script">the script</param>
        public ScriptTreeNode(IScript script)
            : this(script, 0, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ScriptTreeNode class
        /// </summary>
        /// <param name="script">the script</param>
        /// <param name="imageIndex">image index</param>
        /// <param name="selectedImageIndex">selected image index</param>
        public ScriptTreeNode(IScript script, int imageIndex, int selectedImageIndex)
        {
            ImageIndex = imageIndex;
            SelectedImageIndex = selectedImageIndex;
            Script = script;
        }

        /// <summary>
        /// Sets the script
        /// </summary>
        public IScript Script
        {
            set
            {
                _script = value;
                Text = _script.FileName;
                Nodes.Clear();
                foreach (IScriptEvent e in (_script as SSCATScript).ScriptEvents)
                {
                    Nodes.Add(new ScriptEventTreeNode(e));
                }
            }
        }
    }
}
