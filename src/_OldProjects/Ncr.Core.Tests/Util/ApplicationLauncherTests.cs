using System;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class ApplicationLauncherTests
	{
		ApplicationLauncher appLauncher = new ApplicationLauncher();
		
		[Test]
		public void TestRunApplication()
		{
            // Get the working directory so that it will work running in local machine or in build machine
            string debugDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] trunkDir = debugDir.Split(new[] { "src" }, StringSplitOptions.None);

//			IApplicationLauncher appLauncher = new ApplicationLauncher();
			//appLauncher.RunApplication("E7Lane-Oye1", @"C:\Documents and settings\scot.E56Lane\desktop\helloworld.bat");
            appLauncher.RunApplication("localhost", System.IO.Path.Combine(trunkDir[0], @"scripts\Artifacts\TestProcessManager.bat"));
//			appLauncher.RunApplication("E7Lane-Oye", @"C:\helloworld1.bat");
            
		}
		
//		[Test]
//		public void TestPreRun()
//		{
//			appLauncher.PreRun("E7Lane-Oye1", @"C:\Documents and settings\scot.E56Lane\desktop\helloworld.bat");
//		}
	}
}
