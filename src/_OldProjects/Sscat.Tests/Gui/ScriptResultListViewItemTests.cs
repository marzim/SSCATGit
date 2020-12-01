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
	public class ScriptResultListViewItemTests
	{
		ScriptFile s;
		ScriptResultListViewItem l;
		ListView v;
		Form f;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			s = new ScriptFile(@"C:\Projects\finger\trunk\tests\test.xml");
			l = new ScriptResultListViewItem(s);
			v = new ListView();
			v.Items.Add(l);
			f = new Form();
			f.Controls.Add(v);
		}
		
		[Test]
		public void TestNullParent()
		{
			ScriptResultListViewItem l = new ScriptResultListViewItem(new ScriptFile(@"C:\Projects\finger\trunk\tests\test.xml"));
			Assert.IsNull(l.Parent);
		}
		
		[Test]
		public void TestNotNullParent()
		{
			Assert.IsNotNull(l.Parent);
		}
		
		[Test]
		public void TestPassedResultChanged()
		{
			s.Result = new Result(ResultType.Passed, "Passed");
		}
		
		[Test]
		public void TestNoneResultChanged()
		{
			s.Result = new Result(ResultType.None, "");
		}
	}
}
