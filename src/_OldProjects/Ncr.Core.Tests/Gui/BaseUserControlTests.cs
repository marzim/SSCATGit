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
	public class BaseUserControlTests
	{
		BaseUserControl c;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			c = new BaseUserControl();
			c.TitleChanged += new EventHandler(ControlTitleChanged);
			c.ViewShow += new EventHandler(ControlViewShow);
			c.ViewClose += new EventHandler(ControlViewClose);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			c.TitleChanged -= new EventHandler(ControlTitleChanged);
			c.ViewShow -= new EventHandler(ControlViewShow);
			c.ViewClose -= new EventHandler(ControlViewClose);
		}
		
		[Test]
		public void TestClose()
		{
			c.CloseView();
		}
		
		[Test]
		public void TestShow()
		{
			c.ShowView();
		}
		
		[Test]
		public void TestXDispose()
		{
			c.Dispose();
		}		
		
		[Test]
		public void TestGetTitleTextValue()
		{
			c.SetTitle("Title");
			Assert.AreEqual("Title", c.Text);
		}

        [Test]
        public void TestGetTitleValue()
        {
            Assert.AreEqual(c.Text, c.GetTitle());
        }

		void ControlTitleChanged(object sender, EventArgs e)
		{
		}

		void ControlViewClose(object sender, EventArgs e)
		{
		}

		void ControlViewShow(object sender, EventArgs e)
		{
		}
	}
}
