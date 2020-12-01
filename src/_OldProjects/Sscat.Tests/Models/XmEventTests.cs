//	<file>
//		<license></license>
//		<owner name="Apple Leo Chiong" email="Apple_Leo_Derilo.Chiong@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Models;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class XmEventTests
	{
		XmEvent countChanges;
		XmEvent printData;
		XmEvent notValid;
		
		[SetUp]
		public void Setup()
		{
			countChanges = new XmEvent("XmCountChanges", 2, new string[] {"1:15,5:3,25:2,100:1;100:6,200:0,500:2,1000:1,2000:0,5000:0,10000:0", "1:110,5:100,10:100,25:100;100:3000,500:1500,1000:750" });
			printData = new XmEvent("XmPrintData", 3, new string[] {"ReportLine1", "ReportLine2", "ReportLine3" });
			notValid = new XmEvent("NotValid", 1, new string[] {"NotValid" });
		}
		
		[Test]
		public void TestValues()
		{
			Assert.AreEqual("Xm", countChanges.Type);
			Assert.AreEqual("XmCountChanges", countChanges.Id);
			Assert.AreEqual(2, countChanges.ValueCount);
			Assert.AreEqual("1:15,5:3,25:2,100:1;100:6,200:0,500:2,1000:1,2000:0,5000:0,10000:0", countChanges.Values[0]);
			Assert.AreEqual("1:110,5:100,10:100,25:100;100:3000,500:1500,1000:750", countChanges.Values[1]);
			
			countChanges.SeqId = 0;
			Assert.AreEqual(0, countChanges.SeqId);
			
			Assert.AreEqual(true, countChanges.IsForgivable);
			Assert.AreEqual(false, countChanges.IsExempted);
			Assert.AreEqual(false, countChanges.IsStimulus);
			
			countChanges.IsForgivable = false;
			Assert.AreEqual(false, countChanges.IsForgivable);
		}
		
		[Test]
		public void TestCreateEvent()
		{
			Assert.IsNotNull(countChanges.CreateEvent());
		}
		
		[Test]
		public void TestToEventItem()
		{
			Assert.IsNotNull(countChanges.ToEventItem());
		}
		
		[Test]
		public void TestToString()
		{
			Assert.AreEqual("Checking XmCountChanges", countChanges.ToString());
		}
		
		[Test]
		public void TestToRepresentation()
		{
			Assert.AreEqual("Checking Cash Management Print Data Report", printData.ToRepresentation());
			Assert.AreEqual("Checking Cash Management count after changes", countChanges.ToRepresentation());
			Assert.AreEqual("Checking NotValid", notValid.ToRepresentation());
		}
		
		[Test]
		public void TestIsSimilarEventItemWithSimilarEvent()
		{
			Assert.AreEqual(true, countChanges.IsSimilarEventItemWith(countChanges));
		}
		
		[Test]
		public void TestIsSimilarEventItemWithNull()
		{
			Assert.AreEqual(false, countChanges.IsSimilarEventItemWith(null));
		}
		
		[Test]
		public void TestIsSimilarEventItemWithNotSimilarEvent()
		{
			Assert.AreEqual(false, countChanges.IsSimilarEventItemWith(printData));
		}
	}
}
