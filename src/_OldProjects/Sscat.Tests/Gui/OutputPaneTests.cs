//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class OutputPaneTests
	{
		OutputPane p;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			p = new OutputPane();
            //p.Closed += new EventHandler(PaneClosed);
		}
		
		//[TearDown]
        //TODO: Either remove or fix empty TearDown
		public void Teardown()
		{
            //p.Closed -= new EventHandler(PaneClosed);
		}
		
		[Test]
		public void TestWriteLine()
		{
			p.WriteLine("test");
		}
		
		[Test]
		public void TestShowDialog()
		{
		    Assert.That(() => p.ShowDialog(),
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestClear()
		{
			p.Clear();
		}
		
		[Test]
		public void TestWordWrap()
		{
			p.WordWrap = true;
		}
		
		[Test]
		public void TestRichTextBoxChanged()
		{
			p.RichTextBoxTextChanged(new object(), new EventArgs());
		}

		void PaneClosed(object sender, EventArgs e)
		{
		}
	}
}
