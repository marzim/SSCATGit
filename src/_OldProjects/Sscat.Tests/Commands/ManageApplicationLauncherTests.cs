//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Commands;

namespace Sscat.Tests.Commands
{
	[TestFixture]
	public class ManageApplicationLauncherTests
	{
		ManageApplicationLauncher command;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			command = new ManageApplicationLauncher();
		}

		[Test]
		public void TestRun()

		{
			Assert.That(() => command.Run(),
                Throws.TypeOf<Exception>());
		}			
	}
}
