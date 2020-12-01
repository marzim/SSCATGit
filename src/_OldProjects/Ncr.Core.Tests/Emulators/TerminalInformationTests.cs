//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Emulators
{
	[TestFixture]
	public class TerminalInformationTests
	{
		TerminalInformation t;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			t = new TerminalInformation();
		}
		
		[Test]
		public void TestMethod()
		{
			Assert.AreEqual(t.Exists, ProcessUtility.HasStarted(t.ProcessName));
		}
	}
}
