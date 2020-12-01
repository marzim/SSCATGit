//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Models;

namespace Sscat.Tests.Finger
{
	[TestFixture]
	public class FingerLaunchPadPsxEventTests
	{
		FingerLaunchPadPsxEvent xml;
		FingerLaunchPadPsxEvent e;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			e = new FingerLaunchPadPsxEvent();
			xml = FingerLaunchPadPsxEvent.Deserialize(new StringReader(@"<PsxEventData>
            </PsxEventData>")) as FingerLaunchPadPsxEvent;
		}
		
		[Test]
		public void TestContextValue()
		{
			Assert.IsEmpty(e.Context);
		}
	}
}
