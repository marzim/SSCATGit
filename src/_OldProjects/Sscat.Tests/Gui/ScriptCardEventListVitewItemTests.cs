//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
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
	public class ScriptCardEventListViewItemTests
	{
		ScriptEvent e;
		ScriptCardEventListViewItem l;
		ListView v;
		
		[SetUp]
		public void Setup()
		{
			e = new ScriptEvent(new WldbEvent());
			l = new ScriptCardEventListViewItem(e);
			
			v = new ListView();
			v.Items.Add(l);
		}
		
		[Test]
		public void TestEvent()
		{
			Assert.IsNotNull(l.Event);
		}
		
		[Test]
		public void TestAddPsxEvent()
		{
			ScriptCardEventListViewItem l = new ScriptCardEventListViewItem(new ScriptEvent(new PsxEvent("1", "Attract", "", "ChangeContext", "", "", 0)));
		}
		
		[Test]
		public void TestAddDeviceEvent()
		{
			ScriptCardEventListViewItem l = new ScriptCardEventListViewItem(new ScriptEvent(new DeviceEvent()));
		}
		
		[Test]
		public void TestAddWldbEvent()
		{
			ScriptCardEventListViewItem l = new ScriptCardEventListViewItem(new ScriptEvent(new WldbEvent()));
		}
		
		[Test]
		public void TestAddEventWithNullResult()
		{
			e.Result = null;
			l = new ScriptCardEventListViewItem(e);
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
