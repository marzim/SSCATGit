//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.ComponentModel;
using System.Diagnostics;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class ProcessManagerTests
	{
		ProcessManager m;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			m = new ProcessManager();
		}
		
		[Test]
		public void TestStartFileNameAndWait()
		{
            Assert.That(() => m.Start("qwerty.exe", true, 100),
                Throws.TypeOf<Win32Exception>());
		}
		
		[Test]
		public void TestStartFileName()
		{
            Assert.That(() => m.Start("qwerty.exe"),
                Throws.TypeOf<Win32Exception>());
		}
		
		[Test]
		public void TestStartWithProcessWindowStyle()
		{
            Assert.That(() => m.Start("qwerty.exe", "", ProcessWindowStyle.Normal, false),
                Throws.TypeOf<Win32Exception>());
		}
		
		[Test]
		public void TestStartProcessInfo()
		{
            Assert.That(() => m.Start(new ProcessStartInfo("qwerty.exe"), true),
                Throws.TypeOf<Win32Exception>());
		}
		
		[Test]
		public void TestKill()
		{
			m.Kill("qwerty.exe", false);
		}
		
		[Test]
		public void TestMethods1()
		{
            // Get the working directory so that it will work running in local machine or in build machine
            string debugDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] trunkDir = debugDir.Split(new[] { "src" }, StringSplitOptions.None);

			//string remoteHost = "\\\\153.59.104.1";
            string remoteHost = "localhost";
//			string path = "C:\\SSCAT\\Scripts\\CallMe.bat";
			//string path = "C:\\scot\\bin\\PickListEditor.exe";
            string path = System.IO.Path.Combine(trunkDir[0], @"scripts\Artifacts\TestProcessManager.bat");
			string username = "support";
			string password = "support";
			//string filename = "C:\\SSCAT\\Tools\\PsTools\\psexec.exe";
            string filename = System.IO.Path.Combine(trunkDir[0], @"Tools\\PsTools\\psexec.exe");
			string param = string.Format("{0} -i -d \"{1}\" -accepteula -u {2} {3}", remoteHost, path, username, password);
//			m.Start(param);
			Process.Start(filename, param);
		}
		
		[Test]
		public void TestMethods()
		{
            // Get the working directory so that it will work running in local machine or in build machine
            string debugDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] trunkDir = debugDir.Split(new[] { "src" }, StringSplitOptions.None);
            
			// Test WaitForExit in GetStandardOutput
            //m.GetStandardOutput(@"C:\Projects\Finger\trunk\scripts\Artifacts\TestProcessManager.bat", "1");
            m.GetStandardOutput(System.IO.Path.Combine(trunkDir[0], @"scripts\Artifacts\TestProcessManager.bat"), "1");

			// Test Start(string filename, bool waitForExit, int sleep) WaitForExit
            //m.Start(@"C:\Projects\Finger\trunk\scripts\Artifacts\TestProcessManager.bat", true, 2000);
            m.Start(System.IO.Path.Combine(trunkDir[0], @"scripts\Artifacts\TestProcessManager.bat"), true, 2000);
			
			// Test Start(ProcessStartInfo startInfo, bool waitForExit) WaitForExit
            //ProcessStartInfo startInfo = new ProcessStartInfo(@"C:\Projects\Finger\trunk\scripts\Artifacts\TestProcessManager.bat");
            ProcessStartInfo startInfo = new ProcessStartInfo(System.IO.Path.Combine(trunkDir[0], @"scripts\Artifacts\TestProcessManager.bat"));
			m.Start(startInfo, true);
			
			// Test HasStarted(string processName)
			m.Start(startInfo, false);
			Assert.IsTrue(m.HasStarted("cmd"));
			
			// Test Kill(string name, bool waitForExit)
			m.Start(startInfo, false);
			m.Kill("cmd", true);
			
			// Test GetProcessesByName(string name)
			Assert.IsNotNull(m.GetProcessesByName("system"));
		}
		
		[Test]
		public void TestGetCurrentProcess()
		{
			Assert.IsNotNull(m.GetCurrentProcess());
		}
		
		[Test]
		public void TestGetStandardOutput()
		{
            Assert.That(() => m.GetStandardOutput("qwerty.exe", ""),
                Throws.TypeOf<Win32Exception>());
		}
		
		[Test]
		public void TestCanPing()
		{
			Assert.IsTrue(m.CanPing("localhost"));
		}
		
		[Test]
		public void TestCannotPing()
		{
			Assert.IsFalse(m.CanPing("qwertyuiop"));
		}

        //TODO: Please fix this
        //[Test]
        //[Ignore("NUnit is not started with TeamCity.")]
        //public void TestHasStarted()
        //{
        //    Assert.IsTrue(m.HasStarted("nunit-console-dotnet2"));
        //}
		
		[Test]
		public void TestHasStartedIncludeMe()
		{
			Assert.IsFalse(m.HasStarted("nunit-console-dotnet2", true));
		}
	}
}
