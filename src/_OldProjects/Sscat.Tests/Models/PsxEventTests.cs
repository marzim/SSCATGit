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
	public class PsxEventTests
	{
		PsxEvent p;
		PsxEvent pe;
		PsxEvent rap;
		PsxEvent k;
		
		[SetUp]
		public void Setup()
		{
			pe = new PsxEvent();
			
			p = new PsxEvent("1", "Attract", "Display", "ChangeContext", "", "", 0);
			rap = new PsxEvent("1", "", "", "ConnectRemote", "RAP.ssco-4xsm-15", "HandheldRAP=0;operation[text]=sign-on-auto;UserId[text]=1;", 0);
			k = new PsxEvent("1", "EnterPrice", "NumericKeyPad1", "KeyDown", "13", "", 0);
		}
		
		[Test]
		public void TestValues()
		{
			Assert.AreEqual("Psx", p.Type);
			Assert.AreEqual(0, p.SeqId);
			Assert.AreEqual(false, p.IsForgivable);
		}
		
		[Test]
		public void TestToString()
		{
			Assert.AreEqual("Context: Attract, Control: Display, Event: ChangeContext, Param: ", p.ToString());
		}
		
		[Test]
		public void TestToEventItem()
		{
			Assert.That(() => p.ToEventItem(),
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestExempted()
		{
			Assert.IsFalse(p.IsExempted);
		}
		
//		[Test]
//		public void TestGetEventDetail()
//		{
//			Assert.AreEqual("ChangeContext; Display; Attract;", p.GetEventDetail());
//			Assert.AreEqual("; ; ConnectRemote; RAP.ssco-4xsm-15; HandheldRAP=0;operation[text]=sign-on-auto;UserId[text]=1;", rap.GetEventDetail());
//		}
//		
		[Test]
		public void TestIsValidKey()
		{
			Assert.IsFalse(p.IsValidKeyDown());
			Assert.IsTrue(k.IsValidKeyDown());
		}
		
		[Test]
		public void TestCreateEvent()
		{
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(ScriptEvent), p.CreateEvent());
		}
		
		[Test]
		public void TestIsSimilarEventMethodForTwoSimilarEvents()
		{
			Assert.AreEqual(true, p.IsSimilarEventItemWith(p));
		}
		
		[Test]
		public void TestIsSimilarEventMethodForNullValues()
		{
			Assert.AreEqual(false, p.IsSimilarEventItemWith(null));
		}
		
		[Test]
		public void TestIsSimilarEventMethodForTwoNotSimilarEvents()
		{
			Assert.AreEqual(false, p.IsSimilarEventItemWith(k));
		}
	}
	
	public class PsxEventStub : AbstractPsxEvent<PsxEventStub>
	{
		public override string Type {
			get { return "Qwerty"; }
		}
		
		public override IScriptEvent CreateEvent()
		{
			throw new NotImplementedException();
		}
		
		public override IScriptEvent CreateEvent(int time, bool enabled)
		{
			throw new NotImplementedException();
		}
		
		public override IScriptEventItem ToEventItem()
		{
			throw new NotImplementedException();
		}
	}
}
