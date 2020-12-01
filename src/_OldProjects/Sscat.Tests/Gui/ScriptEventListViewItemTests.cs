//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Windows.Forms;
using NUnit.Framework;
using Sscat.Core.Gui;
using Sscat.Core.Models;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class ScriptEventListViewItemTests
	{
		ScriptEvent e;
		ScriptEventListViewItem l;
		ListView v;
		
		[SetUp]
		public void Setup()
		{
			e = new ScriptEvent(new WldbEvent());
			l = new ScriptEventListViewItem(e);
			
			v = new ListView();
			v.Items.Add(l);
		}
		
		[Test]
		public void TestNotNullParent()
		{
			Form f = new Form();
			f.Controls.Add(v);
			Assert.IsNotNull(l.Parent);
		}
		
		[Test]
		public void TestEvent()
		{
			Assert.IsNotNull(l.Event);
		}
		
		[Test]
		public void TestNullParent()
		{
			Assert.IsNull(l.Parent);
		}
		
		[Test]
		public void TestAddPsxEvent()
		{
			ScriptEventListViewItem l = new ScriptEventListViewItem(new ScriptEvent(new PsxEvent("1", "Attract", "", "ChangeContext", "", "", 0)));
		}
		
		[Test]
		public void TestAddDeviceEvent()
		{
			ScriptEventListViewItem l = new ScriptEventListViewItem(new ScriptEvent(new DeviceEvent()));
		}
		
		[Test]
		public void TestAddWldbEvent()
		{
			ScriptEventListViewItem l = new ScriptEventListViewItem(new ScriptEvent(new WldbEvent()));
		}
		
		[Test]
		public void TestAddEventWithNullResult()
		{
			e.Result = null;
			l = new ScriptEventListViewItem(e);
		}
		
		[Test]
		public void TestPassedResultChanged()
		{
			Form f = new Form();
			f.Controls.Add(v);
			e.Result = new Result(ResultType.Passed, "Passed");
		}
		
		[Test]
		public void TestNoneResultChanged()
		{
			Form f = new Form();
			f.Controls.Add(v);
			e.Result = new Result(ResultType.None, "");
		}
	}
}
