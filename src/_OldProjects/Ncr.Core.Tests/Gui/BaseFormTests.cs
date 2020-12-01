//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Gui;
using NUnit.Framework;

namespace Ncr.Core.Tests.Gui
{
	[TestFixture]
	public class BaseFormTests
	{
		BaseForm f;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			f = new BaseForm();
			f.TitleChanged += new EventHandler(FormTitleChanged);
			f.ViewShow += new EventHandler(FormViewShow);
			f.ViewClose += new EventHandler(FormViewClose);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			f.TitleChanged -= new EventHandler(FormTitleChanged);
			f.ViewShow -= new EventHandler(FormViewShow);
			f.ViewClose -= new EventHandler(FormViewClose);
		}
		
		[Test]
		public void TestGetTitleTextValue()
		{
			f.SetTitle("Title");
			Assert.AreEqual("Title", f.Text);
		}

        [Test]
        public void TestGetTitleValue()
        {
            Assert.AreEqual(f.Text, f.GetTitle());
        }
		
		[Test]
		public void TestClose()
		{
			f.CloseView();
		}
		
		[Test]
		public void TestShow()
		{
			f.ShowView();
		}
		
		[Test]
		public void TestDispose()
		{
			new F().X();
		}

		void FormTitleChanged(object sender, EventArgs e)
		{
		}

		void FormViewClose(object sender, EventArgs e)
		{
		}

		void FormViewShow(object sender, EventArgs e)
		{
		}
		
		class F : BaseForm
		{
			public void X()
			{
				Dispose(true);
			}
		}
	}
}
