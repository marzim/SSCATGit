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
	public class DiagsStatusFormTests
	{
		DiagsStatusForm f;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			f = new DiagsStatusForm();
		}
		
		[Test]
		public void TestButton1Value()
		{
//			Assert.IsNotNull(f.TextBox1);
			Assert.IsNotNull(f.Button1);
		}
		
		[Test]
		public void TestAppendText()
		{
			f.AppendText("test...");
		}
	}
}
