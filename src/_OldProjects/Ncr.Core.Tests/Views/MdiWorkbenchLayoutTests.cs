//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Windows.Forms;
using Ncr.Core.Gui;
using Ncr.Core.Views;
using NUnit.Framework;

namespace Ncr.Core.Tests.Views
{
	[TestFixture]
	public class MdiWorkbenchLayoutTests
	{
		MdiWorkbenchLayout l;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			l = new MdiWorkbenchLayout();
			l.Workbench = new WorkbenchStub();
			l.ShowView(new BaseUserControl());
		}
		
		[Test]
		public void TestCloseActiveWindow()
		{
			l.CloseActiveWindow();
		}
		
		[Test]
		public void TestCloseAllWindows()
		{
			l.CloseAllWindows();
		}
	}
}
