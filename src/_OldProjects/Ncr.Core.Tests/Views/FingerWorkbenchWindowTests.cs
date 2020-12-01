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
	public class FingerWorkbenchWindowTests
	{
		FingerWorkbenchWindow w;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			w = new FingerWorkbenchWindow(new BaseUserControl());
		}
		
		[Test]
		public void TestClose()
		{
			w.CloseWindow();
		}
		
		[Test]
		public void TestViewValue()
		{
			Assert.IsInstanceOf(typeof(BaseUserControl), w.View);
		}
		
		[Test]
		public void TestShow()
		{
			new W(new BaseUserControl()).ShowDialog();
		}
		
		class W : FingerWorkbenchWindow
		{
			public W(IView view) : base(view)
			{
			}
			
			protected override void OnShown(EventArgs e)
			{
				base.OnShown(e);
				Close();
			}
		}
	}
}
