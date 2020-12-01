//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using System.Windows.Forms;
using Ncr.Core.Commands;
using Ncr.Core.Plugins;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Plugins
{
	public class DummyCommand : AbstractCommand
	{
		public override void Run()
		{
		}
	}
	
	[TestFixture]
	public class PluginTests
	{
		Plugin plugin;
		Plugin emptyPlugin;
		Plugin smallPlugin;
		Plugin fromFile;
		string filename = @"C:\Projects\finger\trunk\tests\plugin.xml";
		
		[SetUp]
		public void Setup()
		{
			plugin = Plugin.Load(new StringReader(@"<Plugin Name='' Description='' Author='John Doe'>
	            <MainMenu>
		            <Menu Text='File'>
			            <Menu Text='Exit' Command='Ncr.Core.Tests.Plugins.DummyCommand, Sscat.Tests' Image='C:\Projects\finger\trunk\docs\images\cross.png' Shortcut='D, Control'/>
		            </Menu>
		            <Menu Text='View'>
			            <Menu Text='SubMenu'>
				            <Menu Text='Yet another sub menu'/>
				            <Menu Text='-'/>
				            <Menu Text='After a separator' Command='Ncr.Core.Tests.Plugins.DummyCommand, Ncr.Core.Tests'/>
			            </Menu>
		            </Menu>
		            <Menu Text='Tools'/>
		            <Menu Text='?'/>
	            </MainMenu>
	            <ToolBar>
		            <ToolBarButton Text='New' Command='Ncr.Core.Tests.Plugins.DummyCommand2, Ncr.Core.Tests' Image='C:\Projects\finger\trunk\docs\images\new.png' Style=''/>
		            <ToolBarButton Text='Help'/>
	            </ToolBar>
	            <StatusBar>
		            <StatusBarLabel Text='Ready'/>
	            </StatusBar>
            </Plugin>"));
			emptyPlugin = Plugin.Load(new StringReader(@"<Plugin/>"));
			smallPlugin = Plugin.Load(new StringReader(@"<Plugin>
	            <MainMenu/>
	            <ToolBar/>
	            <StatusBar/>
            </Plugin>"));
			FileHelper.Attach(new FileManager());
			FileHelper.Create(filename, new Plugin().Serialize());
			fromFile = Plugin.Load(filename);
		}
		
		[Test]
		public void TestClick()
		{
			ToolStripItem i = plugin.MainMenu.Menus[0].Menus[0].Create();
			i.PerformClick();
			i = plugin.ToolBar.Buttons[0].Create();
			i.PerformClick();
		}
		
		[Test]
		public void TestNameValue()
		{
			Assert.AreEqual("", plugin.Name);
		}

        [Test]
        public void TestDescriptionValue()
        {
            Assert.AreEqual("", plugin.Description);
        }

        [Test]
        public void TestAuthorValue()
        {
            Assert.AreEqual("John Doe", plugin.Author);
        }

        [Test]
        public void TestHasMenusValue()
        {
            Assert.IsTrue(plugin.MainMenu.HasMenus);
        }

        [Test]
        public void TestMainMenusLengthValue()
        {
            Assert.AreEqual(4, plugin.MainMenu.Menus.Length);
        }

        [Test]
        public void TestMenuTextValue()
        {        
			PluginMenu m = plugin.MainMenu.Menus[0];
			Assert.AreEqual("File", m.Text);
        }

        [Test]
        public void TestToolbarButtonsLengthValue()
        {
			Assert.AreEqual(2, plugin.ToolBar.Buttons.Length);
        }

        [Test]
        public void TestToolbarButtonsValue()
        {
            PluginToolBarButton b = plugin.ToolBar.Buttons[0];
            Assert.AreEqual("New", b.Text);
        }

        [Test]
        public void TestStatusBarLabelsLengthValue()
        {
            Assert.AreEqual(1, plugin.StatusBar.Labels.Length);
        }

        [Test]
        public void TestStatusBarLabelsValue()
        {
            PluginStatusBarLabel l = plugin.StatusBar.Labels[0];
            Assert.AreEqual("Ready", l.Text);
        }
		
		[Test]
		public void TestCreation()
		{
			MenuStrip m = plugin.CreateMenu();
			Assert.AreEqual(4, m.Items.Count);
			ToolStrip t = plugin.CreateToolBar() as ToolStrip;
			Assert.AreEqual(2, t.Items.Count);
			StatusStrip s = plugin.CreateStatusBar() as StatusStrip;
			Assert.AreEqual(1, s.Items.Count);
		}
		
		[Test]
		public void TestEmptyPlugin()
		{
			Assert.IsNull(emptyPlugin.CreateMenu());
			Assert.IsNull(emptyPlugin.CreateToolBar());
			Assert.IsNull(emptyPlugin.CreateStatusBar());
		}
		
		[Test]
		public void TestSmallPlugin()
		{
			Assert.AreEqual(0, smallPlugin.MainMenu.Menus.Length);
			Assert.AreEqual(0, smallPlugin.ToolBar.Buttons.Length);
			Assert.AreEqual(0, smallPlugin.StatusBar.Labels.Length);
		}
	}
}
