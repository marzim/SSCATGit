//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class UpdateWLDBScriptPaneTests
	{
		UpdateWldbScriptPane pane;
		
		[SetUp]
		public void Setup()
		{
		}
		
		[Test]
		public void TestContructor()
		{
			pane = new UpdateWldbScriptPane();
		}
	}
}
