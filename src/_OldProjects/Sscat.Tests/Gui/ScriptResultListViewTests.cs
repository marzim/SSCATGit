//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Sscat.Core.Gui;
using Sscat.Core.Models;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class ScriptResultListViewTests
	{
		ScriptResultListView l;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			l = new ScriptResultListView();
			l.SelectedScriptChanged += new EventHandler<ScriptEventArgs>(LaneSelectedScriptChanged);
			l.ScriptsChanged += new EventHandler(LaneScriptsChanged);
			l.ScriptAdded += new EventHandler<ScriptEventArgs>(LaneScriptAdded);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			l.SelectedScriptChanged -= new EventHandler<ScriptEventArgs>(LaneSelectedScriptChanged);
			l.ScriptsChanged -= new EventHandler(LaneScriptsChanged);
			l.ScriptAdded -= new EventHandler<ScriptEventArgs>(LaneScriptAdded);
		}
		
		[Test]
		public void TestValues()
		{
			Assert.IsNotNull(l.Scripts);
			Assert.IsNull(l.SelectedScript);
		}
		
		[Test]
		public void TestClearScripts()
		{
			l.ClearScripts();
		}
		
		[Test]
		public void TestClearResults()
		{
			l.ClearResults();
		}
		
		[Test]
		public void TestAddScriptFiles()
		{
			l.AddScript(new string[] { @"C:\Projects\finger\trunk\tests\script.xml" });
		}
		
		[Test]
		public void TestAddScripts()
		{
			l.AddScript(new List<string>(new string[] { @"C:\Projects\finger\trunk\tests\script.xml" }));
		}
		
		[Test]
		public void TestRemoveSelectedScript()
		{
			l.RemoveSelectedScript();
		}

		void LaneScriptAdded(object sender, ScriptEventArgs e)
		{
		}

		void LaneScriptsChanged(object sender, EventArgs e)
		{
		}

		void LaneSelectedScriptChanged(object sender, ScriptEventArgs e)
		{
		}
	}
}
