//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Views;

namespace Sscat.Tests.Views
{
	[TestFixture]
	public class ConsoleOutputViewTests
	{
		ConsoleOutputView v;
		
		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			v = new ConsoleOutputView();
		}
		
		[Test]
		public void TestWordWrap()
		{
			Assert.That(() => v.WordWrap = false, Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestVisibleValue()
		{
			v.Visible = false;
			Assert.IsFalse(v.Visible);
		}
		
		[Test]
		public void TestWriteLine()
		{
			v.WriteLine("test...");
		}
		
		[Test]
		public void TestWrite()
		{
			v.Write("test...");
		}
		
		[Test]
		public void TestShow()
		{
			v.Show();
		}
		
		[Test]
		public void TestClear()
		{
            Assert.That(() => v.Clear(), Throws.TypeOf<NotImplementedException>()); 
		}
		
		[Test]
		public void TestShowDialog()
		{
            Assert.That(() => v.ShowDialog(), Throws.TypeOf<NotImplementedException>());
		}
	}
}
