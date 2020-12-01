//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using System.Windows.Forms;
using NUnit.Framework;
using Sscat.Core.Gui;
using Sscat.Core.Models;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class CardEventListViewItemTests
	{
		CardEventListViewItem l;
		ListView v;
		Form f;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			//ScriptEvent s = new ScriptEvent(new DeviceEvent("MSR","WalmartMCXShoppingCard"));
			DeviceEvent d = new DeviceEvent("MSR", "WalmartMCXShoppingCard", 23);
			ScriptEvent s = new ScriptEvent(d);
			l = new CardEventListViewItem(s);
			v = new ListView();
			v.Items.Add(l);
			f = new Form();
			f.Controls.Add(v);
		}
		
		[Test]
		public void TestEventRepresentationValue()
		{
			Assert.AreEqual("Swiping MSR with value of WalmartMCXShoppingCard", l.Event.ToRepresentation());
		}

        [Test]
        public void TestSubItemTextIndexZeroValue()
        {
            Assert.AreEqual("23", l.SubItems[0].Text);

        }

        [Test]
        public void TestSubItemTextIndexOneValue()
        {
            Assert.AreEqual("WalmartMCXShoppingCard", l.SubItems[1].Text);
        }
	}
}
