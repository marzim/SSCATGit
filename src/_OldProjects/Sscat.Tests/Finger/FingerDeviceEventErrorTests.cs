//	<file>
//		<license></license>
//		<owner name="Apple Leo Chiong" email="Apple_Leo_Derilo.Chiong@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Finger;

namespace Sscat.Tests.Finger
{
	[TestFixture]
	public class FingerDeviceEventErrorTests
	{
		FingerDeviceEventError e;
		
		[Test]
		public void TestErrorType()
		{
			e = new FingerDeviceEventError();
			e.Error = "DeviceError";
			Assert.AreEqual("DeviceError", e.Error);
		}
	}
}
