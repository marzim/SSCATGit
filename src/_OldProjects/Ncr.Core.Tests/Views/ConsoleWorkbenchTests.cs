//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Windows.Forms;
using Ncr.Core.Views;
using NUnit.Framework;

namespace Ncr.Core.Tests.Views
{
	[TestFixture]
	public class ConsoleWorkbenchTests
	{
		ConsoleWorkbench w;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			w = new ConsoleWorkbench();
			w.MainMenu = null;
			w.ToolBar = null;
			w.StatusBar = null;
			w.WorkbenchLayout = null;
			w.SettingsSave += new EventHandler<WorkbenchSettingsEventArgs>(WorkbenchSettingsSave);
		}

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            w.SettingsSave -= new EventHandler<WorkbenchSettingsEventArgs>(WorkbenchSettingsSave);
        }
		
		[Test]
		public void TestShowView()
		{
			w.ShowView(new BaseConsoleView());
		}
		
		[Test]
		public void TestSaveSettings()
		{
			w.SaveSettings(new WorkbenchSettings());
		}
		
		[Test]
		public void TestCloseActiveWindow()
		{
            Assert.That(() => w.CloseActiveWindow(),
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestCloseAllWindows()
		{
            Assert.That(() => w.CloseAllWindows(),
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestWorkbenchLayoutValue()
		{
			Assert.IsNull(w.WorkbenchLayout);
		}

        [Test]
        public void TestSettingsValue()
        {
            Assert.IsNotNull(w.Settings);
            //			Assert.AreEqual(DialogResult.OK, w.ShowDialogView(null));
        }

		void WorkbenchSettingsSave(object sender, WorkbenchSettingsEventArgs e)
		{
		}
	}
}
