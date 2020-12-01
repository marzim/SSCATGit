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
	public class ScriptEventFormatterTests
	{
		[Test]
		public void TestDeviceEvent()
		{
			ScriptEventFormatter f = new ScriptEventFormatter(new ScriptEvent(new DeviceEvent("BagScale", "500")));
			Assert.AreEqual("BagScale(500)", f.ToString());
		}
		
		[Test]
		public void TestPsxEvent()
		{
			ScriptEventFormatter f = new ScriptEventFormatter(new ScriptEvent(new PsxEvent("1", "Attract", "Display", "ChangeContext", "", "", 0)));
			Assert.AreEqual("Psx.ChangeContext(Attract, Display,  )", f.ToString());
		}
	}
}
