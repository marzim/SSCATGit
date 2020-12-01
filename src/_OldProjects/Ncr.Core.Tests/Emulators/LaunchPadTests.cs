//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Drawing;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Emulators
{
	[TestFixture]
	public class LaunchPadTests
	{
		LaunchPad pad;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			ProcessUtility.Attach(new ProcessManagerStub(true, false, "SMAttract"));
			FileHelper.Attach(new FileManagerStub());
			RegistryHelper.Attach(new RegistryManagerStub());
			DirectoryHelper.Attach(new DirectoryManagerStub());
			
			pad = new LaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer());
			pad.Started += new EventHandler(PadStarted);
		}
		
		[OneTimeTearDown]
		public void Teardown()
		{
			pad.Started -= new EventHandler(PadStarted);
		}
		
		[Test]
        public void TestApplicationValue()
		{
			Assert.IsNotNull(pad.Application);
		}

        [Test]
        public void TestFileNameValue()
        {
            Assert.AreEqual(@"C:\scot\bin\LaunchPadNet.exe", pad.FileName);
        }

        [Test]
        public void TestHasApplicationValue()
        {
            Assert.IsTrue(pad.HasApplication);
        }
		
		[Test]
		public void TestClick()
		{
			pad.ClickAt(new Point(100, 100));
		}
		
		[Test]
		public void TestStart()
		{
			pad.Start();
		}
		
		[Test]
		public void TestKill()
		{
			pad.Kill();
		}

		void PadStarted(object sender, EventArgs e)
		{
		}
	}
}
