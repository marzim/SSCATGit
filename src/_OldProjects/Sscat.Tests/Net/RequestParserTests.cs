//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Net;
using NUnit.Framework;
using Sscat.Core.Models;
using Sscat.Core.Net;
using Sscat.Core.Util;

namespace Sscat.Tests.Net
{
	[TestFixture]
	public class RequestParserTests
	{
//		IRequestParser finger;
//		IRequestParser parser;
//		
		[SetUp]
		public void Setup()
		{
//			finger = new FingerRequestParser();
//			parser = new SimpleRequestParser();
		}
		
		[Test]
		public void TestMethod()
		{
		}
		
//		[Test]
//		public void TestFingerRequestParser()
//		{
//			Request r = finger.Parse(@"GetButtonState|BagScale\Emulator|3|30000");
//			Assert.AreEqual("BagScale", r.Command);
//			Assert.AreEqual("GetButtonState", r.Action);
//			
//			r = finger.Parse(@"SelectIndex|Scale\Emulator|0|1|30000");
//			Assert.AreEqual("Scale", r.Command);
//			Assert.AreEqual("SelectIndex", r.Action);
//			
//			r = finger.Parse(@"SetText|Scale\Emulator|3|30000");
//			Assert.AreEqual("Scale", r.Command);
//			Assert.AreEqual("SetText", r.Action);
//			
//			r = finger.Parse(@"ClickButton|Scale\Emulator|3|30000");
//			Assert.AreEqual("Scale", r.Command);
//			Assert.AreEqual("ClickButton", r.Action);
//			
//			r = finger.Parse(@"ClickPSXButton|920|729");
//			Assert.AreEqual("Psx", r.Command);
//			Assert.AreEqual("Click", r.Action);
//			
//			r = finger.Parse(@"ClickPSXButton|318|234");
//			Assert.AreEqual("Psx", r.Command);
//			Assert.AreEqual("Click", r.Action);
//			
//			r = finger.Parse(@"ClickPSXButton|669|506");
//			Assert.AreEqual("Psx", r.Command);
//			Assert.AreEqual("Click", r.Action);
//			
//			r = finger.Parse(@"ClickPSXButton|871|337");
//			Assert.AreEqual("Psx", r.Command);
//			Assert.AreEqual("Click", r.Action);
//			
//			r = finger.Parse(@"ClickPSXButton|871|145");
//			Assert.AreEqual("Psx", r.Command);
//			Assert.AreEqual("Click", r.Action);
//			
//			r = finger.Parse(@"ClickPSXButton|871|721");
//			Assert.AreEqual("Psx", r.Command);
//			Assert.AreEqual("Click", r.Action);
//		}
		
//		[Test]
//		public void TestRequestParser()
//		{
//			Request r = parser.Parse("BagScale.Weigh(400, 5000)");
//			Assert.AreEqual("BagScale", r.Command);
//			Assert.AreEqual("Weigh", r.Action);
//			Assert.AreEqual(2, r.Parameters.Count);
//			
//			r = parser.Parse("CashAcceptor.Escrow(5, 5000)");
//			Assert.AreEqual("CashAcceptor", r.Command);
//			Assert.AreEqual("Escrow", r.Action);
//			Assert.AreEqual(2, r.Parameters.Count);
//			
//			r = parser.Parse("CoinAcceptor.Insert(5, 5000)");
//			Assert.AreEqual("CoinAcceptor", r.Command);
//			Assert.AreEqual("Insert", r.Action);
//			Assert.AreEqual(2, r.Parameters.Count);
//			
//			r = parser.Parse("Scale.Weigh(650, 5000)");
//			Assert.AreEqual("Scale", r.Command);
//			Assert.AreEqual("Weigh", r.Action);
//			Assert.AreEqual(2, r.Parameters.Count);
//			
//			r = parser.Parse(@"Wldb.Update(g2lane-ian, C:\Finger\tools\pstools\clean WLDB\WLDB.mdb, C:\Finger\tools\pstools\clean SAconfig\SACONFIG.mdb)");
//			Assert.AreEqual("Wldb", r.Command);
//			Assert.AreEqual("Update", r.Action);
//			Assert.AreEqual(3, r.Parameters.Count);
//			
//			r = parser.Parse(@"Wldb.Backup(g2lane-ian, C:\Finger\tools\pstools\clean WLDB\WLDB.mdb, C:\Finger\tools\pstools\clean SAconfig\SACONFIG.mdb)");
//			Assert.AreEqual("Wldb", r.Command);
//			Assert.AreEqual("Backup", r.Action);
//			Assert.AreEqual(3, r.Parameters.Count);
//			Assert.AreEqual("g2lane-ian", r.Parameters[0].ToString());
//			Assert.AreEqual(@"C:\Finger\tools\pstools\clean WLDB\WLDB.mdb", r.Parameters[1].ToString());
//			Assert.AreEqual(@"C:\Finger\tools\pstools\clean SAconfig\SACONFIG.mdb", r.Parameters[2].ToString());
//			
//			r = parser.Parse("Psx.ChangeContext(Attract, Display, , , )");
//			Assert.AreEqual("Psx", r.Command);
//			Assert.AreEqual("ChangeContext", r.Action);
//			Assert.AreEqual(5, r.Parameters.Count);
//		}
	}
}
