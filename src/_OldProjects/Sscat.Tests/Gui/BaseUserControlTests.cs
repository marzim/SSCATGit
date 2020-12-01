//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Gui;
using NUnit.Framework;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class BaseUserControlTests
	{
		BaseUserControl u;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			u = new BaseUserControl();
			u.ViewShow += new EventHandler(UViewShow);
			u.ViewClose += new EventHandler(UViewClose);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			u.TitleChanged -= new EventHandler(UTitleChanged);
			u.ViewShow -= new EventHandler(UViewShow);
			u.ViewClose -= new EventHandler(UViewClose);
			u.Dispose();
		}
		
		[Test]
		public void TestShow()
		{
			u.ShowView();
		}
		
		[Test]
		public void TestClose()
		{
			u.CloseView();
		}
		
		[Test]
		public void TestTitleChange()
		{
			u.TitleChanged += new EventHandler(UTitleChanged);
			u.SetTitle("Base UserControl");
		}

		void UViewClose(object sender, EventArgs e)
		{
		}

		void UViewShow(object sender, EventArgs e)
		{
		}

		void UTitleChanged(object sender, EventArgs e)
		{
			Assert.AreEqual(u.GetTitle(), "Base UserControl");
		}
	}
}
