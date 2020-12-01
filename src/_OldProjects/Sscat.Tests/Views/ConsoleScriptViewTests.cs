//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Models;
using Sscat.Views;

namespace Sscat.Tests.Views
{
	[TestFixture]
	public class ConsoleScriptViewTests
	{
		ConsoleScriptView v;
		
		[OneTimeSetUp]
		public void Setup()
		{
			v = new ConsoleScriptView();
			v.Script = new Script();
			v.ScriptSave += new EventHandler<ScriptEventArgs>(ViewScriptSave);
		}
		
		[OneTimeTearDown]
		public void Teardown()
		{
			v.ScriptSave -= new EventHandler<ScriptEventArgs>(ViewScriptSave);
		}
		
		[Test]
		public void TestScriptValue()
		{
			Assert.IsNotNull(v.Script);
		}
		
		[Test]
		public void TestSave()
		{
			v.Save();
		}

		void ViewScriptSave(object sender, ScriptEventArgs e)
		{
		}
	}
}
