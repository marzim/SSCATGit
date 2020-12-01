//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Gui;
using Ncr.Core.Views;
using NUnit.Framework;

namespace Ncr.Core.Tests.Views
{
	[TestFixture]
	public class DialogWorkbenchLayoutTests
	{
		DialogWorkbenchLayout l;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			l = new DialogWorkbenchLayout();
		}
		
		[Test]
		public void TestShowView()
		{
			U v = new U();
			l.ShowView(v);
		}
		
		[Test]
		public void TestCloseAllWindows()
		{
            Assert.That(() => l.CloseAllWindows(),
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestCloseActiveWindow()
		{
            Assert.That(() => l.CloseActiveWindow(),
                Throws.TypeOf<NotImplementedException>());
		}
		
		class U : BaseUserControl, IView
		{
			protected override void OnViewShow(EventArgs e)
			{
				base.OnViewShow(e);
				OnViewClose(e);
			}
		}
	}
}
