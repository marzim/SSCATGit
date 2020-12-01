//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using NUnit.Framework;

namespace Ncr.Core.Tests.Emulators
{
	[TestFixture]
	public class EmulatorEventArgsTests
	{
		[Test]
		public void TestMessage()
		{
			EmulatorEventArgs e = new EmulatorEventArgs("test");
			Assert.AreEqual("test", e.Message);
		}
		
		[Test]
		public void TestEmulator()
		{
			EmulatorEventArgs e = new EmulatorEventArgs(new BagScale());
			Assert.IsInstanceOf(typeof(BagScale), e.Emulator);
		}
	}
}
