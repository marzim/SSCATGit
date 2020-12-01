//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using System.Windows.Forms;
using Ncr.Core.Gui;
using Ncr.Core.Plugins;
using Ncr.Core.Views;
using NUnit.Framework;

namespace Ncr.Core.Tests.Views
{
	[TestFixture]
	public class WorkbenchSingletonTests
	{
		[SetUp]
		public void Setup()
		{
			WorkbenchSingleton.Attach(new WorkbenchStub(), new SdiWorkbenchLayout());
		}
		
		[Test]
		public void TestValues()
		{
			Assert.IsNotNull(WorkbenchSingleton.MainForm);
		}
		
		[Test]
		public void TestWithPlugin()
		{
			WorkbenchSingleton.Attach(new WorkbenchStub(), new SdiWorkbenchLayout(), Plugin.Deserialize(new StringReader(@"<Plugin/>")));
		}
		
		[Test]
		public void TestShowDialog()
		{
			WorkbenchSingleton.ShowDialog(new Form1());
		}
		
		[Test]
		public void TestCloseAllWindows()
		{
			WorkbenchSingleton.CloseAllWindows();
		}
		
		[Test]
		public void TestCloseAllWindowsOnNullWorkbench()
		{
			WorkbenchSingleton.Attach(null);
            Assert.That(() => WorkbenchSingleton.CloseAllWindows(),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestCloseAllWindowsOnNullWorkbenchLayout()
		{
			WorkbenchSingleton.Attach(new WorkbenchStub());
            Assert.That(() => WorkbenchSingleton.CloseAllWindows(),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestCloseActiveWindow()
		{
			WorkbenchSingleton.CloseActiveWindow();
		}
		
		[Test]
		public void TestCloseActiveWindowOnNullWorkbench()
		{
			WorkbenchSingleton.Attach(null);
            Assert.That(() => WorkbenchSingleton.CloseActiveWindow(),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestCloseActiveWindowOnNullWorkbenchLayout()
		{
			WorkbenchSingleton.Attach(new WorkbenchStub());
            Assert.That(() => WorkbenchSingleton.CloseActiveWindow(),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestShowView()
		{
			WorkbenchSingleton.ShowView(new BaseUserControl());
		}
		
		[Test]
		public void TestShowViewOnNullWorkbench()
		{
			WorkbenchSingleton.Attach(null);
            Assert.That(() => WorkbenchSingleton.ShowView(new BaseUserControl()),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestNullMainForm()
		{
			WorkbenchSingleton.Attach(null);
            try {
                Form f = WorkbenchSingleton.MainForm;
            } catch (ArgumentNullException ex) {
                Assert.AreEqual("Workbench", ex.ParamName);
            }
		}
	}
}
