// <copyright file="PluginMainMenu.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Plugins
{
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using Ncr.Core.Gui;

    /// <summary>
    /// Initializes a new instance of the PluginMainMenu class
    /// </summary>
    public class PluginMainMenu
    {
        /// <summary>
        /// Plugin menus
        /// </summary>
        private PluginMenu[] _menus;

        /// <summary>
        /// Gets a value indicating whether or not the plugin has menus
        /// </summary>
        [XmlIgnore]
        public bool HasMenus
        {
            get { return Menus.Length > 0; }
        }

        /// <summary>
        /// Gets or sets the plugin menus
        /// </summary>
        [XmlElement("Menu")]
        public PluginMenu[] Menus
        {
            get
            {
                if (_menus == null)
                {
                    return new PluginMenu[0];
                }

                return _menus;
            }

            set
            {
                _menus = value;
            }
        }

        /// <summary>
        /// Create the menu strip
        /// </summary>
        /// <returns>Returns the menu strip</returns>
        public MenuStrip Create()
        {
            MenuStrip main = new MenuStrip();
            foreach (PluginMenu menu in Menus)
            {
                ToolStripItem item = menu.Create();
                if (menu.HasMenus)
                {
                    AddItem(item, menu.Menus);
                }

                main.Items.Add(item);
            }

            return main;
        }

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="item">tool strip item</param>
        /// <param name="menus">plugin menus</param>
        private void AddItem(ToolStripItem item, PluginMenu[] menus)
        {
            foreach (PluginMenu menu in menus)
            {
                ToolStripItem subItem = menu.Create();
                if (menu.HasMenus)
                {
                    AddItem(subItem, menu.Menus);
                }

                if (subItem is NToolStripMenuItem)
                {
                    (item as ToolStripMenuItem).DropDownItems.Add(subItem);
                }

                (item as ToolStripMenuItem).DropDownItems.Add(subItem);
            }
        }
    }
}
