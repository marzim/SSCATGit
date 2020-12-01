// <copyright file="ScriptEventListViewItem.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System;
    using System.Windows.Forms;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ScriptEventListViewItem class
    /// </summary>
    [Serializable]
    public class ScriptEventListViewItem : ListViewItem
    {
        /// <summary>
        /// Interface for the script event
        /// </summary>
        private IScriptEvent _scriptEvent;

        /// <summary>
        /// Initializes a new instance of the ScriptEventListViewItem class
        /// </summary>
        /// <param name="scriptEvent">script event</param>
        public ScriptEventListViewItem(IScriptEvent scriptEvent)
        {
            Event = scriptEvent;
            scriptEvent.ResultChanged += new EventHandler<ResultEventArgs>(EventResultChanged);
        }

        /// <summary>
        /// Finalizes an instance of the ScriptEventListViewItem class
        /// </summary>
        ~ScriptEventListViewItem()
        {
            _scriptEvent.ResultChanged -= new EventHandler<ResultEventArgs>(EventResultChanged);
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
        /// Gets or sets the script event
        /// </summary>
        public virtual IScriptEvent Event
        {
            get
            {
                return _scriptEvent;
            }

            set
            {
                _scriptEvent = value;
                IScriptEventItem item = _scriptEvent.Item as IScriptEventItem;
                Text = _scriptEvent.SequenceID.ToString();
                SubItems.Add(_scriptEvent.Time.ToString());
                SubItems.Add(item.ToRepresentation());
                if (_scriptEvent.Result != null)
                {
                    SubItems.Add(_scriptEvent.Result.Type == ResultType.None ? string.Empty : _scriptEvent.Result.ToString());
                    SubItems.Add(_scriptEvent.Result.ExpectedResult);
                    SubItems.Add(_scriptEvent.Result.ActualResult);
                    SubItems.Add(_scriptEvent.Result.ScreenshotLink);
                }
                else
                {
                    SubItems.Add(string.Empty);
                    SubItems.Add(string.Empty);
                    SubItems.Add(string.Empty);
                    SubItems.Add(string.Empty);
                }
            }
        }

        /// <summary>
        /// Event for event result changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">result event arguments</param>
        private void EventResultChanged(object sender, ResultEventArgs e)
        {
            if (Parent != null)
            {
                if (Parent.InvokeRequired)
                {
                    Parent.Invoke(new ResultEventHandler(EventResultChanged), new object[] { sender, e });
                }
                else
                {
                    if (e.Result.Type == ResultType.None)
                    {
                        SubItems[3].Text = string.Empty;
                        SubItems[4].Text = string.Empty;
                        SubItems[5].Text = string.Empty;
                        SubItems[6].Text = e.Result.ScreenshotLink;
                    }
                    else
                    {
                        SubItems[3].Text = e.Result.ToString();
                        SubItems[4].Text = e.Result.ExpectedResult;
                        SubItems[5].Text = e.Result.ActualResult;
                        SubItems[6].Text = e.Result.ScreenshotLink;
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
