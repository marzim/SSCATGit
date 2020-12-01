//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Emulators
{
	[TestFixture]
	public class AbstractApplicationTests
	{
		ApplicationStub a;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ProcessUtility.Attach(new ProcessManagerStub());
			FileHelper.Attach(new FileManagerStub());
			RegistryHelper.Attach(new RegistryManagerStub());
			
			a = new ApplicationStub();
			a.LaunchPad = new LaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer());
		}
		
		[Test]
        public void TestCaptionValue()
		{
			Assert.AreEqual("Qwerty", a.Caption);
		}

        [Test]
        public void TestLaunchPadValue()
        {
            Assert.IsNotNull(a.LaunchPad);

        }

        [Test]
        public void TestHasStartedValue()
        {
            Assert.IsFalse(a.HasStarted);
        }

        [Test]
        public void TestExistsValue()
        {
            Assert.IsTrue(a.Exists);
        }
		
		[Test]
		public void TestStart()
		{
			a.Start();
		}
		
		[Test]
		public void TestStop()
		{
			a.Kill();
		}
		
		[Test]
		public void TestForceStop()
		{
			a.ForceKill();
		}
	}
}
