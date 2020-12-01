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
	public class SdiWorkbenchWindowTests
	{
		SdiWorkbenchWindow w;
		BaseUserControl c;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			c = new BaseUserControl();
			w = new SdiWorkbenchWindow(c);
			w.WindowClosing += new EventHandler(WindowWindowClosing);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			w.WindowClosing -= new EventHandler(WindowWindowClosing);
		}
		
		[Test]
		public void TestSetTitle()
		{
			c.TitleChanged += delegate { 
				Assert.AreEqual(c.Text, c.GetTitle());
			};
			c.SetTitle("test");
		}
		
		[Test]
		public void TestCloseView()
		{
			c.CloseView();
		}

		void WindowWindowClosing(object sender, EventArgs e)
		{
		}
	}
}
