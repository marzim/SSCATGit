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
	public class BaseLaunchPadLauncherTests
	{
		BaseLaunchPadLauncher l;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ProcessUtility.Attach(new ProcessManagerStub());
			RegistryHelper.Attach(new RegistryManagerStub());
			
			l = new BaseLaunchPadLauncher();
			l.Application = new Lane();
		}
		
		[Test]
		public void TestApplicationValue()
		{
			Assert.IsNotNull(l.Application);
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
