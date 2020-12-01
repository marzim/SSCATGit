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
	public class NToolStripLabelTests
	{
		NToolStripLabel l;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			l = new NToolStripLabel("Test");
		}
		
		[Test]
		public void TestTextValue()
		{
			Assert.AreEqual("Test", l.Text);
		}
	}
}
