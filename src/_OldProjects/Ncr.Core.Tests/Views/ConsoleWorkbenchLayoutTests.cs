//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Windows.Forms;
using Ncr.Core.Gui;
using Ncr.Core.Views;
using NUnit.Framework;

namespace Ncr.Core.Tests.Views
{
	[TestFixture]
	public class ConsoleWorkbenchLayoutTests
	{
		ConsoleWorkbenchLayout l;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			l = new ConsoleWorkbenchLayout();
		}
		
		[Test]
		public void TestCloseActiveWindow()
		{
            Assert.That(() => l.CloseActiveWindow(),
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestCloseAllWindows()
		{
            Assert.That(() => l.CloseAllWindows(),
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestShowDialogView()
		{
			Assert.AreEqual(DialogResult.OK, l.ShowDialogView(null));
		}
		
		[Test]
		public void TestShowView()
		{
			l.ShowView(new BaseUserControl());
		}
	}
}
