//	<file>
//		<license></license>
//		<owner name="Apple Leo Chiong" email="Apple_Leo_Derilo.Chiong@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Controllers;
using Sscat.Core.Models;
using Sscat.Core.Util;
using Sscat.Gui;
using Sscat.Tests.Util;

namespace Sscat.Tests.Controllers
{
	[TestFixture]
	public class ApplicationLauncherControllerTests
	{
		ApplicationLauncherController controller;
		ISscatApplicationLauncher applicationLauncher;
		ApplicationLauncherPane view;

        [OneTimeSetUp]
        public void OneTimeSetUp()
		{
			MessageService.Attach(new NoMessageProvider());
			
			applicationLauncher = new ApplicationLauncherStub();
			view = new ApplicationLauncherPane();
			controller = new ApplicationLauncherController(applicationLauncher, view);
		}
		
		[Test]
		public void TestCreate()
		{
			Assert.IsInstanceOf(typeof(ApplicationLauncherPane), controller.Create());
		}
		
		[Test]
		public void TestLaunchApplication()
		{
			applicationLauncher.LaunchApplication(new ApplicationLauncherEvent());
		}
		
		[Test]
		public void TestViewApplicationManager()
		{
			view.Create();
		}
	}
}
