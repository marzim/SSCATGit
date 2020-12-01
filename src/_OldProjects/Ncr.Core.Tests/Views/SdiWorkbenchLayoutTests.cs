//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Windows.Forms;
using Ncr.Core.Gui;
using Ncr.Core.Views;
using NUnit.Framework;
using Rhino.Mocks;

namespace Ncr.Core.Tests.Views
{
	[TestFixture]
	public class SdiWorkbenchLayoutTests
	{
		SdiWorkbenchLayout l;
		BaseUserControl v;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			l = new SdiWorkbenchLayout();
			v = new BaseUserControl();
			l.ShowView(v);
		}
		
		[Test]
		public void TestTitleChange()
		{
			v.TitleChanged += delegate(object sender, EventArgs e) { 
				Assert.AreEqual("test", v.GetTitle());
			};
			v.SetTitle("test");
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
