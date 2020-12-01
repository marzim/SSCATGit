//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Net;
using Ncr.Core.Plugins;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using Ncr.Core.Views;
using NUnit.Framework;
using Sscat.Core.Net;
using Sscat.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class MainFormTests
	{
		MainForm f;
		SscatClient c;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApplicationUtility.Attach(new ApplicationManagerStub());
			DnsHelper.Attach(new DnsManagerStub());
			
			f = new MainForm();
			f.Settings = WorkbenchSettings.Deserialize(new StringReader(@"<Settings Location='10,10' Size='100,100'/>"));
			f.WorkbenchLayout = new SdiWorkbenchLayout();
			
			Plugin p = Plugin.Load(new StringReader(@"<Plugin/>"));
			f.MainMenu = p.CreateMenu();
			f.ToolBar = p.CreateToolBar();
			f.StatusBar = p.CreateStatusBar();
			f.SettingsSave += new EventHandler<WorkbenchSettingsEventArgs>(FormSettingsSave);
			
			c = new SscatClient("localhost", 30000, new XmlResponseParser(), new EasyClientEngine());
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			f.SettingsSave -= new EventHandler<WorkbenchSettingsEventArgs>(FormSettingsSave);
		}
		
//		[Test]
//		public void TestSaveSettings()
//		{
//			f.SaveSettings(new WorkbenchSettings());
//		}
//		
		[Test]
		public void TestAddClient()
		{
			f.Clients.Add(c.Server, c);
		}
		
		[Test]
		public void TestSettingsValue()
		{
			Assert.IsNotNull(f.Settings);
        }

        [Test]
        public void TestWorkbenchLayoutValue()
        {
			Assert.IsNotNull(f.WorkbenchLayout);
		}
		
		[Test]
		public void TestShowView()
		{
			f.ShowView(new GeneratorPane());
		}
		
		[Test]
		public void TestCloseAllWindows()
		{
			f.CloseAllWindows();
		}
		
		[Test]
		public void TestCloseActiveWindow()
		{
			f.CloseActiveWindow();
		}
		
		[Test]
		public void TestClose()
		{
			f.Close();
		}

		void FormSettingsSave(object sender, WorkbenchSettingsEventArgs e)
		{
		}
	}
}
