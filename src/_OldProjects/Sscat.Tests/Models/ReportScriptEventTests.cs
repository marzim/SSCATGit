//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Models;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class ReportScriptEventTests
	{
		[Test]
		public void TestValues()
		{
			ReportScriptEvent e = new ReportScriptEvent(new ScriptEvent(new DeviceEvent()));
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(ReportDeviceEvent), e.Item);
			Assert.AreEqual("Device", e.Type);
			Assert.AreEqual("None", e.Result);
			Assert.IsEmpty(e.ScreenshotLink);
		}
		
		[Test]
		public void TestPsxEvent()
		{
			ReportScriptEvent e = new ReportScriptEvent(new ScriptEvent(new PsxEvent()));
		}
		
		[Test]
		public void TestWldbEvent()
		{
			ReportScriptEvent e = new ReportScriptEvent(new ScriptEvent(new WldbEvent()));
		}
		
		[Test]
		public void TestNotSupportedEventItem()
		{
            ReportScriptEvent e;
			Assert.That(() => e = new ReportScriptEvent(new ScriptEvent()),
                Throws.TypeOf<NullReferenceException>());
		}
	}
}
