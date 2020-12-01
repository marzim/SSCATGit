//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Models;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class PsxDisplayTests
	{
		PsxDisplay p;
		
		[SetUp]
		public void Setup()
		{
			p = PsxDisplay.Deserialize(new StringReader(@"<Display Version='1.0' Position='0,0,5,5' Language='0409'>
	<Includes>
		<Include File='test.xml'/>
	</Includes>
	<Controls>
		<Control Name='MinMaxFastLaneButton' Type='Button'>
			<Properties>
				<Property Name='Position'>0,0,10,10</Property>
			</Properties>
			<CustomData>
				<Data Name='PrimaryText'>MinMaxFastLaneButton</Data>
			</CustomData>
		</Control>
	</Controls>
	<Fonts>
		<Font Name='LaunchPadFont'>
			<Face>Arial</Face>
			<Size>14</Size>
			<Bold>True</Bold>
			<Italic>False</Italic>
		</Font>
	</Fonts>
	<Contexts>
		<Context Name='FastLaneContext'>
			<CustomData>
				<Data Name='LaneViewPosition'>0,0,45,45</Data>
			</CustomData>
			<Properties/>
		</Context>
	</Contexts>
</Display>"));
		}
		
		[Test]
		public void TestValues()
		{
			Assert.AreEqual(1, p.Controls.Controls.Length);
			
			PsxControl c = p.Controls.GetControl("MinMaxFastLaneButton");
			Assert.AreEqual("Button", c.Type);
			Assert.IsNull(p.Controls.GetControl("Qwerty"));
			
			PsxProperty r = c.Properties.GetProperty("Position");
			Assert.AreEqual("0,0,10,10", r.Value);
			c.Properties.SetProperty("Position", "0,0,12,12");
			Assert.AreEqual("0,0,12,12", r.Value);
			Assert.IsNull(c.Properties.GetProperty("Qwerty"));

			PsxContext o = p.Contexts.GetContext("FastLaneContext");
			Assert.AreEqual("FastLaneContext", o.Name);
			Assert.IsNotNull(o.Properties);
			Assert.IsNull(p.Contexts.GetContext("Qwerty"));
		}
	}
}
