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
	public class BaseFormTests
	{
		BaseForm f;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			f = new BaseForm();
			f.ViewShow += new EventHandler(FViewShow);
			f.ViewClose += new EventHandler(FViewClose);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			f.TitleChanged -= new EventHandler(FTitleChanged);
			f.ViewShow -= new EventHandler(FViewShow);
			f.ViewClose -= new EventHandler(FViewClose);
			f.Dispose();
		}
		
		[Test]
		public void TestShow()
		{
			f.ShowView();
		}
		
		[Test]
		public void TestClose()
		{
			f.CloseView();
		}
		
		[Test]
		public void TestTitleChange()
		{
			f = new BaseForm();
			f.TitleChanged += new EventHandler(FTitleChanged);
			f.SetTitle("Base Form");
		}

		void FViewClose(object sender, EventArgs e)
		{
		}

		void FViewShow(object sender, EventArgs e)
		{
		}

		void FTitleChanged(object sender, EventArgs e)
		{
			Assert.AreEqual(f.GetTitle(), "Base Form");
		}
	}
}
