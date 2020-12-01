//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Util;
using Sscat.Tests.Config;

namespace Sscat.Tests.Util
{
	[TestFixture]
	public class WindowAppHelperTest
	{
		WindowAppManager wam;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			wam = new WindowAppManager(new LaunchPadConfigRepositoryStub());
			
			WindowAppHelper.Attach(new WindowAppManagerStub());
			DirectoryHelper.Attach(new DirectoryManagerStub());
//			ThreadHelper.Attach(new ThreadManager());
			ThreadHelper.Attach(new ThreadManagerStub());
			FileHelper.Create(@"c:\test.txt", "asdfghjkl");
			
			WindowAppHelper.DiagnosticsInProcess += new EventHandler<SscatEventArgs>(WindowAppHelperDoingSomething);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			FileHelper.Delete("c:\test.txt");
			WindowAppHelper.DiagnosticsInProcess -= new EventHandler<SscatEventArgs>(WindowAppHelperDoingSomething);
		}
		
		[Test]
		public void TestCheckDiagnosticFile()
		{
			WindowAppHelper.Attach(new WindowAppManagerStub());
			WindowAppHelper.CheckDiagnosticFile(100, 100);
			WindowAppHelper.Attach(null);
			Assert.That(() => WindowAppHelper.CheckDiagnosticFile(100, 100),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestCheckDiagnosticFileOnException()
		{
			WindowAppHelper.Attach(new W());
			Assert.That(() => WindowAppHelper.CheckDiagnosticFile(100, 100),
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestGetText()
		{
			WindowAppHelper.Attach(new WindowAppManagerStub());
			WindowAppHelper.GetText("myfile");
			WindowAppHelper.Attach(null);
			Assert.That(() => WindowAppHelper.GetText("myfile"),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestGetTextOnException()
		{
			WindowAppHelper.Attach(new W());
			Assert.That(() => WindowAppHelper.GetText("myfile"),
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestAutoPushDiagFiles()
		{
			WindowAppHelper.Attach(new WindowAppManagerStub());
			WindowAppHelper.AutoPushDiagFiles();
			WindowAppHelper.Attach(null);
			Assert.That(() => WindowAppHelper.AutoPushDiagFiles(),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestAutoPushDiagFilesOnException()
		{
			WindowAppHelper.Attach(new W());
			Assert.That(() => WindowAppHelper.AutoPushDiagFiles(),
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestEnterOk()
		{
			WindowAppHelper.Attach(new WindowAppManagerStub());
			WindowAppHelper.GetDiagnosticFilesResults();
			WindowAppHelper.Attach(null);
			Assert.That(() => WindowAppHelper.GetDiagnosticFilesResults(),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestEnterOkOnException()
		{
			WindowAppHelper.Attach(new W());
			Assert.That(() => WindowAppHelper.GetDiagnosticFilesResults(),
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestWriteFile()
		{
			WindowAppHelper.Attach(new WindowAppManagerStub());
			WindowAppHelper.WriteFile("c:\test.txt", "c:\test.txt", "");
			WindowAppHelper.Attach(null);
			Assert.That(() => WindowAppHelper.WriteFile("c:\test.txt", "c:\test.txt", ""),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestWriteFileOnException()
		{
			WindowAppHelper.Attach(new W());
			Assert.That(() => WindowAppHelper.WriteFile("c:\test.txt", "c:\test.txt", ""),
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestGetLastWrittenFileOnException()
		{
			WindowAppHelper.Attach(new WindowAppManagerStub());
			WindowAppHelper.GetLastWrittenFile("c:\temp", "*.zip");
			WindowAppHelper.Attach(null);
			Assert.That(() => WindowAppHelper.GetLastWrittenFile("c:\temp", "*.zip"),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestGetLastWrittenFile()
		{
			WindowAppHelper.Attach(new W());
			Assert.That(() => WindowAppHelper.GetLastWrittenFile("c:\temp", "*.zip"),
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestWindowAppExit()
		{
			WindowAppHelper.Attach(new WindowAppManagerStub());
			WindowAppHelper.WindowAppExit("c:\test.txt");
			WindowAppHelper.Attach(null);
			Assert.That(() => WindowAppHelper.WindowAppExit("c:\test.txt"),
                Throws.TypeOf<ArgumentNullException>());
		}

		[Test]
		public void TestWindowAppExitOnException()
		{
			WindowAppHelper.Attach(new W());
			Assert.That(() => WindowAppHelper.WindowAppExit("c:\test.txt"),
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestManager_CheckDiagnosticFile()
		{
			ApiHelper.Attach(new ApiManagerStub(0, new IntPtr(666), new IntPtr(666), new IntPtr(666)));
			FileHelper.Attach(new FileManagerStub());
			wam.CheckDiagnosticFile(100, 100);
			ApiHelper.Attach(new ApiManagerStub(0, new IntPtr(666), IntPtr.Zero, new IntPtr(666)));
			Assert.That(() => wam.CheckDiagnosticFile(100, 100),
                Throws.TypeOf<Exception>());
		}
		
		[Test]
		public void TestManager_GetText()
		{
			wam.GetText(@"c:\test.txt");
			Assert.That(() => wam.GetText(@"c:\test2.txt"),
                Throws.TypeOf<System.IO.FileNotFoundException>());
		}
		
		[Test]
		[Ignore("This doesn't end. Please check!")]
		public void TestManager_WindowAppExit()
		{
			ApiHelper.Attach(new ApiManagerStub(0, new IntPtr(666), new IntPtr(666), IntPtr.Zero));
			wam.WindowAppExit("myfile");
		}
		
		[Test]
		[Ignore("There's an issue with de-serialize on GetDiagLocation.")]
		public void TestManager_AutoPushDiagFiles()
		{
			ApiHelper.Attach(new ApiManagerStub(0, new IntPtr(666), new IntPtr(666), new IntPtr(666)));
			ProcessUtility.Attach(new ProcessManagerStub());
			wam.AutoPushDiagFiles();
		}
		
		[Test]
		public void TestManager_EnterOk()
		{
			ApiHelper.Attach(new ApiManagerStub(0, new IntPtr(666), new IntPtr(666), new IntPtr(666)));
			wam.GetDiagnosticFilesResults();
			ApiHelper.Attach(new ApiManagerStub(0, new IntPtr(666), IntPtr.Zero, new IntPtr(666)));
			Assert.That(() => wam.GetDiagnosticFilesResults(),
                Throws.TypeOf<Exception>());
		}
		
		[Test]
		public void TestManager_EnterOk1()
		{
			ApiHelper.Attach(new ApiManagerStub(0, new IntPtr(666), new IntPtr(666), IntPtr.Zero));
			Assert.That(() => wam.GetDiagnosticFilesResults(),
                Throws.TypeOf<Exception>());
		}

		[Test]
		public void TestManager_GetLastWrittenFile()
		{
			wam.GetLastWrittenFile("", "");
		}
		
		[Test]
		public void TestManager_WriteFile()
		{
			Assert.That(() => wam.WriteFile("c:\test.txt", "c:\test.txt", ""),
                Throws.TypeOf<ArgumentException>());
		}
		
		void WindowAppHelperDoingSomething(object sender, SscatEventArgs e)
		{
		}
		
		class W : WindowAppManagerStub
		{
			public override void GetDiagnosticFilesResults()
			{
				throw new NotImplementedException();
			}
			
			public override void AutoPushDiagFiles()
			{
				throw new NotImplementedException();
			}
			
			public override string GetText(string filename)
			{
				throw new NotImplementedException();
			}
			
			public override void WindowAppExit(string windowTitle)
			{
				throw new NotImplementedException();
			}
			
			public override string CheckDiagnosticFile(int time, int timeout)
			{
				throw new NotImplementedException();
			}
			
			public override void WriteFile(string writeFile, string readFile, string message)
			{
				throw new NotImplementedException();
			}
			
			public override string GetLastWrittenFile(string path, string pattern)
			{
				throw new NotImplementedException();
			}
		}
	}
}
