//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Models;
using Sscat.Core.Util;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class TriColorLightFactoryTests
	{
		[SetUp]
		public void Setup()
		{
		}
		
		[Test]
		public void TestGetString()
		{
		}
		
		[Test]
		public void TestGetState()
		{
			Assert.AreEqual("Off", TriColorLightFactory.GetState(Constants.TriColorLightState.OFF));
			Assert.AreEqual("On", TriColorLightFactory.GetState(Constants.TriColorLightState.ON));
			Assert.AreEqual("blinking a Quarter Hertz", TriColorLightFactory.GetState(Constants.TriColorLightState.BLINK_QUARTER_HERTZ));
			Assert.AreEqual("blinking Half Hertz", TriColorLightFactory.GetState(Constants.TriColorLightState.BLINK_HALF_HERTZ));
			Assert.AreEqual("blinking 1 Hertz", TriColorLightFactory.GetState(Constants.TriColorLightState.BLINK_1_HERTZ));
			Assert.AreEqual("blinking 2 Hertz", TriColorLightFactory.GetState(Constants.TriColorLightState.BLINK_2_HERTZ));
			Assert.AreEqual("blinking 4 Hertz", TriColorLightFactory.GetState(Constants.TriColorLightState.BLINK_4_HERTZ));
		}
		
		[Test]
		public void TestGetStateWithException()
		{
			Assert.That(() => TriColorLightFactory.GetState(10),
                Throws.TypeOf<NotSupportedException>());
		}
		
		[Test]
		public void TestGetColor()
		{
			Assert.AreEqual("Green", TriColorLightFactory.GetColor(Constants.TriColorLight.GREEN));
			Assert.AreEqual("Yellow", TriColorLightFactory.GetColor(Constants.TriColorLight.YELLOW));
			Assert.AreEqual("Red", TriColorLightFactory.GetColor(Constants.TriColorLight.RED));
		}
		
		[Test]
		public void TestGetColorWithException()
		{
			Assert.That(() => TriColorLightFactory.GetColor(4),
                Throws.TypeOf<NotSupportedException>());
		}
	}
}
