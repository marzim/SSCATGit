//	<file>
//		<license></license>
//		<owner name="Apple Leo Chiong" email="Apple_Leo_Derilo.Chiong@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Models;
using Sscat.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class ApplicationLauncherPaneTests
	{
		ApplicationLauncherPane alp;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			alp = new ApplicationLauncherPane();
			alp.Creating += new EventHandler<ApplicationLauncherEventArgs>(PaneCreating);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			alp.Creating -= new EventHandler<ApplicationLauncherEventArgs>(PaneCreating);
		}
		
		[Test]
		public void TestCreate()
		{
			alp.Create();
		}
		
		[Test]
		public void TestApplicationLauncherValue()
		{
			Assert.IsNotNull(alp.ApplicationLauncher);
		}
		
		void PaneCreating(object sender, ApplicationLauncherEventArgs e)
		{
		}
	}
}
