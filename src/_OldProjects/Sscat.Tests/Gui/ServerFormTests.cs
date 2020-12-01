//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Gui;
using Ncr.Core.Net;
using Ncr.Core.Plugins;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using Ncr.Core.Views;
using NUnit.Framework;
using Sscat.Server.Gui;
using Sscat.Tests.Emulators;
using Sscat.Tests.Net;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class ServerFormTests
	{
		ServerForm f;
		SscatServerStub s;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApplicationUtility.Attach(new ApplicationManagerStub());
			
			f = new ServerForm();
			s = new SscatServerStub(new XmlRequestParser(), new SscatLaneStub(), new EasyServerEngine(30000, "SSCAT Server", new XmlRequestParser()));
			f.Server = s;
			
			f.WorkbenchLayout = new MdiWorkbenchLayout();
			f.Settings = new WorkbenchSettings();
			
			Plugin p = Plugin.Load(new StringReader(@"<Plugin/>"));
			f.MainMenu = p.CreateMenu();
			f.ToolBar = p.CreateToolBar();
			f.StatusBar = p.CreateStatusBar();
			
			f.ServerStart += new EventHandler(FormServerStart);
			f.ServerStop += new EventHandler(FormServerStop);
			f.SettingsSave += new EventHandler<WorkbenchSettingsEventArgs>(FormSettingsSave);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			f.ServerStart -= new EventHandler(FormServerStart);
			f.ServerStop -= new EventHandler(FormServerStop);
			f.SettingsSave -= new EventHandler<WorkbenchSettingsEventArgs>(FormSettingsSave);
		}
		
		[Test]
		public void TestServerStop()
		{
			s.Stop();
		}
		
		[Test]
		public void TestServerListen()
		{
			s.Listen();
		}
		
		[Test]
		public void TestShowView()
		{
            try
            {
                f.ShowView(new BaseUserControl());
            }
            catch (ArgumentException)
            {
                Assert.That(() => f.ShowView(new BaseUserControl()),
                    Throws.TypeOf<ArgumentException>());
            }
		}
		
		[Test]
		public void TestClose()
		{
			f.Show();
			f.Close();
		}
		
		[Test]
		public void TestSaveSettings()
		{
			f.SaveSettings(new WorkbenchSettings());
		}
		
		[Test]
		public void TestClearLogs()
		{
			f.ClearLogs();
		}
		
		[Test]
		public void TestValues()
		{
			Assert.IsNotNull(f.Server);
			Assert.IsNotNull(f.Settings);
			Assert.IsNotNull(f.WorkbenchLayout);
		}

		void FormSettingsSave(object sender, WorkbenchSettingsEventArgs e)
		{
		}

		void FormServerStop(object sender, EventArgs e)
		{
		}

		void FormServerStart(object sender, EventArgs e)
		{
		}
	}
}
