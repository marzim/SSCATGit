//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Models;
using Sscat.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class ScriptPaneTests
	{
		ScriptPane p;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			p = new ScriptPane();
			p.Script = FingerScript.Deserialize(new StringReader(@"<FingerScript/>"));
			p.ScriptSave += new EventHandler<ScriptEventArgs>(PaneScriptSave);
		}
		
		[TearDown]
		public void Teardown()
		{
			p.ScriptSave -= new EventHandler<ScriptEventArgs>(PaneScriptSave);
		}
		
		[Test]
		public void TestSave()
		{
			p.Save();
		}
		
		[Test]
		public void TestValues()
		{
			Assert.IsNotNull(p.Script);
		}

		void PaneScriptSave(object sender, ScriptEventArgs e)
		{
		}
	}
}
