//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Models;
using Sscat.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class ReportPaneTests
	{
		ReportPane pane;
		
		[SetUp]
		public void Setup()
		{
		}
		
		[Test]
		public void TestContructor()
		{
			pane = new ReportPane();
		}
		
		[Test]
		public void TestDispose()
		{
			Assert.IsNull(pane.Report);
			pane.Report = new Report();
			pane.Dispose();
			Assert.IsNotNull(pane.Report);
		}
	}
}
