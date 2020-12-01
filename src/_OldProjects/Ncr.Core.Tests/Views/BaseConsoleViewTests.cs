//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Views;
using NUnit.Framework;

namespace Ncr.Core.Tests.Views
{
	[TestFixture]
	public class BaseConsoleViewTests
	{
		BaseConsoleView v;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			v = new BaseConsoleView();
			v.TitleChanged += new EventHandler(ViewTitleChanged);
			v.ViewClose += new EventHandler(ViewViewClose);
			v.ViewShow += new EventHandler(ViewViewShow);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			v.TitleChanged -= new EventHandler(ViewTitleChanged);
			v.ViewClose -= new EventHandler(ViewViewClose);
			v.ViewShow -= new EventHandler(ViewViewShow);
		}
		
		[Test]
		public void TestTitleChange()
		{
			v.SetTitle("Test");
		}
		
		[Test]
		public void TestClose()
		{
			v.CloseView();
		}
		
		[Test]
		public void TestShow()
		{
			v.ShowView();
		}

		void ViewTitleChanged(object sender, EventArgs e)
		{
			Assert.AreEqual("Test", v.GetTitle());
		}

		void ViewViewClose(object sender, EventArgs e)
		{
		}

		void ViewViewShow(object sender, EventArgs e)
		{
		}
	}
}
