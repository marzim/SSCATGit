//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Models;
using Sscat.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class WldbManagerPaneTests
	{
		WldbManagerPane p;
		
		[SetUp]
		public void Setup()
		{
			p = new WldbManagerPane();
			p.Managing += new EventHandler<WldbEventArgs>(PaneManaging);
		}
		
		[TearDown]
		public void Teardown()
		{
			p.Managing -= new EventHandler<WldbEventArgs>(PaneManaging);
		}
		
		[Test]
		public void TestManage()
		{
			p.Manage();
		}
		
		[Test]
		public void TestValues()
		{
			Assert.IsNotNull(p.Wldb);
		}

		void PaneManaging(object sender, WldbEventArgs e)
		{
		}
	}
}
