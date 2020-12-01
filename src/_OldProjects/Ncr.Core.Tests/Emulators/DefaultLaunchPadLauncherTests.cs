//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Emulators
{
	[TestFixture]
	public class DefaultLaunchPadLauncherTests
	{
		DefaultLaunchPadLauncher l;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ProcessUtility.Attach(new ProcessManagerStub(true, false, "SMAttract"));
			FileHelper.Attach(new FileManagerStub());
			RegistryHelper.Attach(new RegistryManagerStub());
			
			l = new DefaultLaunchPadLauncher();
			LaunchPad pad = new LaunchPad(l, new Lane(), new StoreServer());
		}
		
		[Test]
		public void TestApplicationValue()
		{
			Assert.IsNotNull(l.Application);
		}

        [Test]
        public void TestLaunchPadValue()
        {
            Assert.IsNotNull(l.LaunchPad);
        }
		
		[Test]
		public void TestStart()
		{
			l.Start();
		}
		
		[Test]
		public void TestKill()
		{
			l.Kill();
		}
	}
}
