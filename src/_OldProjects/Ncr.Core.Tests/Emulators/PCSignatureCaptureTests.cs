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
	public class PCSignatureCaptureTests
	{
		PCSignatureCapture p;

		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			p = new PCSignatureCapture();
		}
		
		[Test]
		public void TestMethod()
		{
			p.Sign(5000);
		}
	}
}
