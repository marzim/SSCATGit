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
	public class FingerWorkbenchLayoutTests
	{
		FingerWorkbenchLayout l;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			l = new FingerWorkbenchLayout();
		}
		
		[Test]
		public void TestShowForm()
		{
			l.ShowView(new F());
		}
		
		[Test]
		public void TestShowUserControl()
		{
			l.ShowView(new U());
		}
		
		[Test]
		public void TestCloseActiveWindow()
		{
            Assert.That(() => l.CloseActiveWindow(),
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestCloseAllWindows()
		{
            Assert.That(() => l.CloseAllWindows(),
                Throws.TypeOf<NotImplementedException>());
		}
		
		class F : BaseForm
		{
			protected override void OnShown(EventArgs e)
			{
				base.OnShown(e);
				Close();
			}
		}
		
		class U : BaseUserControl
		{
			protected override void OnViewShow(EventArgs e)
			{
				base.OnViewShow(e);
				OnViewClose(e);
			}
		}
	}
}
