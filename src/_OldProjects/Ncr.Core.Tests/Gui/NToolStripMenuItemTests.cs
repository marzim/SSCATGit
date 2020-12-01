//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Windows.Forms;
using Ncr.Core.Commands;
using Ncr.Core.Gui;
using Ncr.Core.Tests.Plugins;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Gui
{
	[TestFixture]
	public class NToolStripMenuItemTests
	{
		NToolStripMenuItem i;
		ICommand c;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			FileHelper.Attach(new FileManagerStub());
			ImageHelper.Attach(new ImageManagerStub());
			
			c = new CommandStub();
			i = new NToolStripMenuItem("File", c, @"C:\Projects\finger\trunk\doc\images\test.png", "D, Control");
		}
		
		[Test]
		public void TestOwnerValue()
		{
			Assert.AreEqual(i, c.Owner);
		}

        [Test]
        public void TestKeysValue()
        {
            Assert.AreEqual(Keys.D, Keys.D);
        }

        [Test]
        public void TestShortcutKeysValue()
        {
			Assert.AreEqual(i.ShortcutKeys, Keys.Control | Keys.D);

        }
		
		[Test]
		public void TestClick()
		{
			c.Running += delegate(object sender, NcrEventArgs e) { 
				Assert.AreEqual("hello world", e.Message);
			};
			i.PerformClick();
		}
		
		[Test]
		public void TestDropDown()
		{
			c.Running += delegate(object sender, NcrEventArgs e) { 
				Assert.AreEqual("hello world", e.Message);
			};			
			i.ShowDropDown();
		}
	}
}
