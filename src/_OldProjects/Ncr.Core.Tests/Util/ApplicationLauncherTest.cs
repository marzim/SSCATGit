//	<file>
//		<license></license>
//		<owner name="Apple Leo Chiong" email="Apple_Leo_Derilo.Chiong@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class ApplicationLauncherTest
	{
		ApplicationLauncher appLauncher;

        [OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ProcessUtility.Attach(new ProcessManagerStub(true, false, "The command completed successfully."));
			FileHelper.Attach(new FileManagerStub());
			
			appLauncher = new ApplicationLauncher();
		}

//		[Test]
//		public void TestRunApplicationReg()
//		{
//			FileHelper.Attach(new R());
//			appLauncher.RunApplication("localhost", @"C:\Test.bat");
//		}

//
		[Test]
		public void TestRunApplicationFileNotReg()
        {
            ProcessUtility.Attach(new ProcessManagerStub(true, false, "The command completed successfully."));
            // Get the working directory so that it will work running in local machine or in build machine
            string debugDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] trunkDir = debugDir.Split(new[] { "src" }, StringSplitOptions.None);

			FileHelper.Attach(new E());
			//appLauncher.RunApplication("localhost", @"C:\Projects\Finger\trunk\tools\usbanet.exe"); //usbanet.exe used as test file only
            appLauncher.RunApplication("localhost", System.IO.Path.Combine(trunkDir[0], @"tools\usbanet.exe")); //usbanet.exe used as test file only
		}

		[Test]
		public void TestCanRunOnRemote()
		{
			appLauncher.CanRunOnRemoteHost("localhost", @"C:\Test.bat");
		}
		
		[Test]
		public void TestCanRunOnRemoteFailedRemoteException()
		{
			ProcessUtility.Attach(new ProcessManagerStub(true, false, "Unable to log in into remote host"));
            Assert.That(() => appLauncher.CanRunOnRemoteHost("localhost", @"C:\Test.bat"),
                Throws.TypeOf<Exception>());
		}
		
		[Test]
		public void TestCanRunOnRemoteFileNotFound()
		{
			FileHelper.Attach(new F());
            Assert.That(() => appLauncher.CanRunOnRemoteHost("localhost", @"C:\Test.bat"),
                Throws.TypeOf<Exception>());
		}
		
		[Test]
		public void TestCanRunOnRemoteHostPingException()
		{
            Assert.That(() => appLauncher.CanRunOnRemoteHost("YouDontSeeMe", ""),
                Throws.TypeOf<Exception>());
		}
		
		class F : FileManagerStub
		{
			public override bool Exists(string path)
			{
				return false;
			}
		}
		
		class R : FileManagerStub
		{
			public override string GetExtension(string filePath)
			{
				return ".reg";
			}
			
			public override void Create(string path)
			{
				Create(@"C:\temp.bat");
			}
		}
		
		class E : FileManagerStub
		{
			public override string GetExtension(string filePath)
			{
				return ".exe";
			}
		}
	}
}