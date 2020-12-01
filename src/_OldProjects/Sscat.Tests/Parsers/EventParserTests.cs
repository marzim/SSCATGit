//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//		<owner name="Apple Leo Chiong" email="ac185120@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Config;
using Sscat.Core.Emulators;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Core.Services;
using Sscat.Core.Util;
using Sscat.Tests.Config;
using Sscat.Tests.Models;

namespace Sscat.Tests.Parsers
{
	[TestFixture]
	public class EventParserTests
	{
		EventParser p;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			p = new EventParser();
			p.Parse += new EventHandler<ProgressEventArgs>(ParserParse);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			p.Parse -= new EventHandler<ProgressEventArgs>(ParserParse);
		}
		
		[Test]
		public void TestStop()
		{
			p.Stop();
		}
		
		[Test]
		public void TestPerformParseOnStopped()
		{
			p.Stop();
			p.PerformParse(new ExtendedStringReader(@"..."));
		}
		
		[Test]
		public void TestPerformParseOnStoppedInParsing()
		{
			EventParserStub s = new EventParserStub();
			s.AddPattern(new ParserPattern("", null));
			s.PerformParse(new ExtendedStringReader(@"..."));
		}

		void ParserParse(object sender, ProgressEventArgs e)
		{
		}
		
//		[Test]
//		public void TestPsx()
//		{
//			ExtendedStringReader l = new ExtendedStringReader(@"PSX_ScotAppU:03/21 09:17:13       502,913 0908> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Startup, EventName:ChangeContext, Param:, Consumed:0, TimeFired:502913)
//PSX_ScotAppU:03/21 09:17:36       526,527 0908> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:OutOfService2, EventName:ChangeContext, Param:, Consumed:0, TimeFired:526527)");
//			p.AddPattern(new ParserPattern(ParserPattern.Psx, new PsxEventAdder()));
//			Assert.AreEqual(2, p.PerformParse(l).Count);
//		}
//		
//		[Test]
//		public void TestSM()
//		{
//			ExtendedStringReader l = new ExtendedStringReader(@"SM: 07/12 10:17:11    85,258,645 0A80> m_wLastWeight:  0
//SM: 08/17 16:33:27    10,390,660 0A80> Sending message:  Zero Wt
//SM: 08/17 16:33:27    10,390,660 0F2C> lCurrentTotalWeight=0");
//			p.AddPattern(new ParserPattern(ParserPattern.BagScale, new DeviceEventAdder(Constants.DeviceType.BagScale)));
//			Assert.AreEqual(3, p.PerformParse(l).Count);
//		}
//		
//		[Test]
//		public void TestTrace()
//		{
//			ExtendedStringReader l = new ExtendedStringReader(@"1932) 07/04 15:29:12;0315091568 0B88> SM-SMdmBase@5921 Scale weight = 0
//2115) 02/12 13:27:20;0025917577 15F4> SM-SMStateBase@3234 +isBarcodeValidOperatorPassword  <A048500008621~048500008621~101>
//2116) 02/12 13:27:20;0025917577 15F4> SM-SMStateBase@3495 -isBarcodeValidOperatorPassword  <0>
//5560) 04/18 14:25:25;0001287571 0934> SM-SMStateBase@3235 +isBarcodeValidOperatorPassword  <830324006460
//~830324006460~101>
//5561) 04/18 14:25:25;0001287571 0934> SM-SMStateBase@3248 co.nOperationsOperatorLoginBarcodeType = 1
//5562) 04/18 14:25:25;0001287571 0934> SM-SMStateBase@3259 csBarcodeScanType = 'F'
//5563) 04/18 14:25:25;0001287571 0934> SM-SMStateBase@3280 csTemp = 101
//5564) 04/18 14:25:25;0001287571 0934> SM-SMStateBase@3401 csItemCodeNoType = 30324006460
//~830324006460~101
//5565) 04/18 14:25:25;0001287571 0934> SM-SMStateBase@3508 -isBarcodeValidOperatorPassword  <0>
//2487) 02/12 13:27:23;0025920832 15F4> -CReport@1739 -CReporting::LogItemDetails <ItemSold Time= ""2011-02-12T18:27:23.459"" ID=""1"" Code=""A048500008621"" Description=""Grapefruit Juice"" Department=""123"" ExtPrice=""129"" UnitPrice=""129"" PriceRqd=""0"" QtySold=""1"" DealQty=""0"" QtyRqd=""0"" QtyConfirmed=""0"" QtyLimitExceeded=""0"" WgtRqd=""0"" WgtSold=""0"" Coupon=""0"" TareRqd=""0"" NotFound=""0"" NotForSale=""0"" VisVerify=""0"" Restricted=""0"" RestrictedAge=""0"" Void=""0"" Linked=""0"" CrateAnswer=""2"" SecurityBaggingRqd=""-1"" SecuritySubChkRqd=""-1"" SecurityTag=""0"" ZeroWeight=""0"" PickList=""0""/>
//2256) 04/23 13:28:22;0004591301 0558> DM-DMX@191  DMX:PostDmEventToApplication MSR-0 DM_DATA length(157)
//5003) 04/23 13:31:16;0004764981 0E98> -RCMgri@250  bstrInParms: type[text]=normal-item;description[text]=[SummaryX]$0.01 inserted
//2202) 04/10 13:43:51;0517330582 0EAC> SM-SMdmBase@366  Parse DM evt 103, dev 12, code 19, length 0
//2941) 04/10 13:44:12;0517351572 SM-SMtb@4385, 4, TBGetTotalDetails--TotalDetail: lTaxDue:28; lTotal:317; lDiscount:0; szErrDescription:(null); lFoodStampDue:0
//2844) 05/28 16:14:33;0005143666 SM-SMdmBase@1653 DM Coupon Sensor detected coupon slip");
//			p.AddPattern(new ParserPattern(ParserPattern.Scale, new DeviceEventAdder(Constants.DeviceType.Scale)));
//			p.AddPattern(new ParserPattern(ParserPattern.Scanner, new ScannerDeviceEventAdder()));
//			p.AddPattern(new ParserPattern(ParserPattern.Scanner3207, new Scanner3207DeviceEventAdder()));
//			p.AddPattern(new ParserPattern(ParserPattern.DeviceError, new DeviceEventAdder(Constants.DeviceType.DeviceError)));
//			p.AddPattern(new ParserPattern(ParserPattern.ReceiptItem, new ReceiptItemDeviceEventAdder()));
//			p.AddPattern(new ParserPattern(ParserPattern.Msr, new MsrDeviceEventAdder()));
//			p.AddPattern(new ParserPattern(ParserPattern.SignatureCapture, new DeviceEventAdder(Constants.DeviceType.SignatureCapture)));
//			p.AddPattern(new ParserPattern(ParserPattern.PinPad, new PinPadDeviceEventAdder()));
//			p.AddPattern(new ParserPattern(ParserPattern.PinPadCancel, new PinPadCancelDeviceEventAdder()));
//			p.AddPattern(new ParserPattern(ParserPattern.CouponSlip, new CouponSlipDeviceEventAdder()));
//			p.AddPattern(new ParserPattern(ParserPattern.AmountAndTaxDue, new AmountAndTaxDueDeviceEventAdder()));
//			Assert.AreEqual(8, p.PerformParse(l).Count);
//		}
//		
//		[Test]
//		public void TestParserMigration()
//		{
//			Generator g = new Generator();
//			g.Configuration = GeneratorConfiguration.Deserialize(@"C:\SSCAT\Config\ScriptGeneratorConfiguration.xml");
//			
//			SscatLane lane = new SscatLane();
//
//			LaneService service = new LaneService(lane, new ScriptRepositoryStub(), new ConfigFileRepositoryStub(), new ConfigFilesRepositoryStub(), new PlayerConfigurationRepositoryStub(), new GeneratorConfigurationRepositoryStub(), new ReportRepositoryStub());
//			g.Parsers = service.CreateParsers();
//			IScript[] scripts = g.Generate("test", "", "4.5", "3.0", true, @"C:\SSCAT\Scripts");
//			
//			LaneService2 service2 = new LaneService2(lane, new ScriptRepositoryStub(), new ConfigFileRepositoryStub(), new ConfigFilesRepositoryStub(), new PlayerConfigurationRepositoryStub(), new GeneratorConfigurationRepositoryStub(), new ReportRepositoryStub());
//			g.Parsers = service2.CreateParsers();
//			IScript[] scripts2 = g.Generate("test", "", "4.5", "3.0", true, @"C:\SSCAT\Scripts");
//			
//			Assert.AreEqual(scripts.Length, scripts2.Length);
//		}
	}
	
	public class EventParserStub : EventParser
	{
		public override List<IParserPattern> Patterns {
			get {
				Stop();
				return base.Patterns;
			}
		}
	}
}
