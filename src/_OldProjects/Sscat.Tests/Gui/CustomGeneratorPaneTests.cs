//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Emulators;
using Sscat.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class CustomGeneratorPaneTests
	{
		CustomGeneratorPane pane;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApplicationUtility.Attach(new ApplicationManager());
		}
		
		[Test]
		public void TestContructor()
		{
			Assert.That(() => pane = new CustomGeneratorPane(),
                Throws.TypeOf<System.IO.DirectoryNotFoundException>());
		}
		
		[Test]
		public void TestMethod()
		{
			Assert.That(() => pane.WriteLine("test"),
                Throws.TypeOf<NullReferenceException>());
		}
	}
}
