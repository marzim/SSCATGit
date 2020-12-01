//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Windows.Forms;
using Ncr.Core.Gui;
using Ncr.Core.Tests.Plugins;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Gui
{
	[TestFixture]
	public class NToolStripButtonTests
	{
		NToolStripButton b;
		CommandStub c;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			FileHelper.Attach(new FileManagerStub());
			ImageHelper.Attach(new ImageManagerStub());
			
			c = new CommandStub();
			b = new NToolStripButton("Title", c, @"C:\Projects\finger\trunk\doc\images\test.png", ToolStripItemDisplayStyle.ImageAndText);
		}
		
		[Test]
		public void TestClick()
		{
			c.Running += delegate(object sender, NcrEventArgs e) { 
				Assert.AreEqual("hello world", e.Message);
			};
			b.PerformClick();
		}
		
		[Test]
		public void TestTextEqualsTitle()
		{
			Assert.AreEqual("Title", b.Text);
        }

        [Test]
        public void TestOwnerCEqualsB()
        {
            Assert.AreEqual(b, c.Owner);
        }

        [Test]
        public void TestDisplayStyle()
        {
            Assert.AreEqual(ToolStripItemDisplayStyle.ImageAndText, b.DisplayStyle);
        }
	}
}
