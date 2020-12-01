//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Gui;
using Ncr.Core.Views;
using NUnit.Framework;

namespace Ncr.Core.Tests.Views
{
	[TestFixture]
	public class DialogWindowTests
	{
		DialogWindow w;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			w = new DialogWindow(new BaseUserControl());
		}
		
		[Test]
		public void TestClose()
		{
			BaseUserControl v = new BaseUserControl();
			w = new DialogWindow(v);
			v.CloseView();
		}
		
		[Test]
		public void TestViewValue()
		{
			Assert.IsNotNull(w.View);
		}
	}
}
