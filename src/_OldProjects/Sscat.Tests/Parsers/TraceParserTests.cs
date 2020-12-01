//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.IO;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Config;
using Sscat.Core.Finger;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Core.Services;
using Sscat.Tests.Config;

namespace Sscat.Tests.Parsers
{
	[TestFixture]
	public class TraceParserTests
	{
		IExtendedTextReader log;
		IParser parser;
		
		[SetUp]
		public void Setup()
		{
			log = new ExtendedStringReader(@"1932) 07/04 15:29:12;0315091568 0B88> SM-SMdmBase@5921 Scale weight = 0
5560) 04/18 14:25:25;0001287571 0934> SM-SMStateBase@3235 +isBarcodeValidOperatorPassword  <830324006460
~830324006460~101>
5565) 04/18 14:25:25;0001287571 0934> SM-SMStateBase@3508 -isBarcodeValidOperatorPassword  <0>
2115) 02/12 13:27:20;0025917577 15F4> SM-SMStateBase@3234 +isBarcodeValidOperatorPassword  <A048500008621~048500008621~101>
2116) 02/12 13:27:20;0025917577 15F4> SM-SMStateBase@3495 -isBarcodeValidOperatorPassword  <0>
2487) 02/12 13:27:23;0025920832 15F4> -CReport@1739 -CReporting::LogItemDetails <ItemSold Time= ""2011-02-12T18:27:23.459"" ID=""1"" Code=""A048500008621"" Description=""Grapefruit Juice"" Department=""123"" ExtPrice=""129"" UnitPrice=""129"" PriceRqd=""0"" QtySold=""1"" DealQty=""0"" QtyRqd=""0"" QtyConfirmed=""0"" QtyLimitExceeded=""0"" WgtRqd=""0"" WgtSold=""0"" Coupon=""0"" TareRqd=""0"" NotFound=""0"" NotForSale=""0"" VisVerify=""0"" Restricted=""0"" RestrictedAge=""0"" Void=""0"" Linked=""0"" CrateAnswer=""2"" SecurityBaggingRqd=""-1"" SecuritySubChkRqd=""-1"" SecurityTag=""0"" ZeroWeight=""0"" PickList=""0""/>
2256) 04/23 13:28:22;0004591301 0558> DM-DMX@191  DMX:PostDmEventToApplication MSR-0 DM_DATA length(157)
5003) 04/23 13:31:16;0004764981 0E98> -RCMgri@250  bstrInParms: type[text]=normal-item;description[text]=[SummaryX]$0.01 inserted
2202) 04/10 13:43:51;0517330582 0EAC> SM-SMdmBase@366  Parse DM evt 103, dev 12, code 19, length 0
4249) 06/13 19:15:07;0015770396 0EC4> SM-SMdmBase@367  Parse DM evt 0, dev 15, code 0, length 15
4250) 06/13 19:15:07;0015770396 0EC4> SM-SMdmBase@1635 -Parse
4280) 06/13 19:15:08;0015771448 0EC4> -RCMgri@250  bstrInParms: type[text]=normal-item;description[text]=[SummaryX]£10.00 inserted
4249) 06/13 19:15:07;0015770396 0EC4> SM-SMdmBase@367  Parse DM evt 0, dev 15, code 0, length 15
4250) 06/13 19:15:07;0015770396 0EC4> SM-SMdmBase@1635 -Parse
4280) 06/13 19:15:08;0015771448 0EC4> -RCMgri@250  bstrInParms: type[text]=normal-item;description[text]=[SummaryX]10&comma;00 € inserted
4249) 06/13 19:15:07;0015770396 0EC4> SM-SMdmBase@367  Parse DM evt 0, dev 15, code 0, length 15
4250) 06/13 19:15:07;0015770396 0EC4> SM-SMdmBase@1635 -Parse
4280) 06/13 19:15:08;0015771448 0EC4> -RCMgri@250  bstrInParms: type[text]=normal-item;description[text]=[SummaryX]$10&comma;00 € inserted
4249) 06/13 19:15:07;0015770396 0EC4> SM-SMdmBase@367  Parse DM evt 0, dev 15, code 0, length 15
4250) 06/13 19:15:07;0015770396 0EC4> SM-SMdmBase@1635 -Parse
4280) 06/13 19:15:08;0015771448 0EC4> -RCMgri@250  bstrInParms: type[text]=normal-item;description[text]=[SummaryX]10&comma;00 € įdėta
4249) 06/13 19:15:07;0015770396 0EC4> SM-SMdmBase@367  Parse DM evt 0, dev 15, code 0, length 15
4250) 06/13 19:15:07;0015770396 0EC4> SM-SMdmBase@1635 -Parse
4280) 06/13 19:15:08;0015771448 0EC4> -RCMgri@250  bstrInParms: type[text]=normal-item;description[text]=[SummaryX]10&comma;00 € hineingesteckt
2941) 04/10 13:44:12;0517351572 SM-SMtb@4385, 4, TBGetTotalDetails--TotalDetail: lTaxDue:28; lTotal:317; lDiscount:0; szErrDescription:(null); lFoodStampDue:0
3109) 05/17 17:37:32;0126531462 0C24> SM-SMdmBase@1851 DM Coupon Sensor detected coupon slip
2115) 02/12 13:27:20;0025917577   -DMEncryptorgetPIN
2115) 02/12 13:27:20;0025917577   DM Encryptor Cancelled
2645) 09/26 15:17:35;0001175209 09C0> SM-SMdmBase@366  Parse DM evt 103, dev 15, code 0, length 0
2645) 09/26 15:17:35;0001175209 09C0> SM-SMdmBase@366  Parse DM evt 103, dev 15, code 4, length 0
2645) 09/26 15:17:35;0001175209 09C0> SM-SMdmBase@366  Parse DM evt 103, dev 15, code 5, length 0
2645) 09/26 15:17:35;0001175209 09C0> SM-SMdmBase@366  Parse DM evt 103, dev 15, code 6, length 0
8174) 10/01 18:04:25;0443146661 0C40> SM-SMdmBase@366  Parse DM evt 103, dev 16, code 0, length 0
8631) 10/01 18:07:56;0443357524 0C40> SM-SMdmBase@366  Parse DM evt 103, dev 16, code 4, length 0
8613) 10/01 18:07:07;0443309114 0C40> SM-SMdmBase@366  Parse DM evt 103, dev 16, code 5, length 0
7989) 10/01 18:02:56;0443057262 0C40> SM-SMdmBase@366  Parse DM evt 103, dev 16, code 6, length 0
11197) 10/02 10:25:32;0501988160 0C40> SM-SMdmBase@366  Parse DM evt 1, dev 11, code 111, length 0
2253) 10/03 11:09:03;0006622352 0C74> -SCOTDevFactory@462  ERROR: SignatureCapture\Emulator|111|0
2270) 10/03 11:09:35;0006653707 0C74> -SCOTDevFactory@462  ERROR: SignatureCapture\Emulator|107|0
2284) 10/03 11:10:01;0006680546 0C74> -SCOTDevFactory@462  ERROR: SignatureCapture\Emulator|108|0
7015) 10/04 17:04:09;0185763844 01A0> SM-SmReportsMenuBase@765  ParseString Input 328 [<<<
8353) 10/16 12:56:53;0087545954 0C54> SM-SmReportsMenuBase@765  ParseString Input 18 [[Session Closed]
8242) 10/16 12:56:40;0087532765 0C54> SM-SmReportsMenuBase@765  ParseString Input 149 [TT Enter Terminal Type
8249) 10/16 12:56:40;0087532895 0C54> SM-SmReportsMenuBase@947  ParsePrompt - REDRAW is set to TRUE,m_bProcessingMenus 1 m_bInitialMenu 0
39238) 10/15 17:22:11;0017063906 1138> DM-DMp@2287 +setTriColorLight, color = 3 state = 0 request = 0
39246) 10/15 17:22:11;0017063916 1138> DM-DMp@2322 -setTriColorLight, color = 3 state = 0, request = 0
6346) 10/05 19:52:34;0282268640 0104> DM-DMp@2287 +setTriColorLight, color = 3 state = 4 request = 0
6362) 10/05 19:52:34;0282268740 0104> DM-DMp@2322 -setTriColorLight, color = 3 state = 4, request = 03383) 06/13 19:15:00;0015763186 0EC4> -CReportingBase@1725 +CReportingBase::LogItemDetails
3384) 06/13 19:15:00;0015763847 0EC4> -CReportingBase@1787 -CReportingBase::LogItemDetails <ItemSold Time= '2013-06-13T11:15:00.216' ID='1' Code='1111' Description='White Bread' Department='0' ExtPrice='289' UnitPrice='289' PriceRqd='0' QtySold='1' DealQty='0' QtyRqd='0' QtyConfirmed='0' QtyLimitExceeded='0' WgtRqd='0' WgtSold='0' Coupon='0' TareRqd='0' NotFound='0' NotForSale='0' VisVerify='0' Restricted='0' RestrictedAge='0' Void='0' Linked='0' CrateAnswer='2' SecurityBaggingRqd='-1' SecuritySubChkRqd='-1' SecurityTag='0' ZeroWeight='0' PickList='0'/>
 111) 06/11 16:11:29;0416133538 0328> SM-SMdmBase@3889 +DMSayPhrase <31>
 112) 06/11 16:11:29;0416133538 0328> SM-SMdmBase@3909 -DMSayPhrase 0
3362) 06/13 19:14:59;0015762164 0EC4> SM-SMdmBase@3814 +DMSayAmount 289
3363) 06/13 19:14:59;0015762605 0EC4> DM-DMp@948  SCOTPriceSoundSayPrice 0x121
3364) 06/13 19:14:59;0015762605 0EC4> SM-SMdmBase@3848 -DMSayAmount 0
4989) 06/13 19:15:15;0015778338 0EC4> SM-SMdmBase@3916 +DMSaySecurity <0> <ThankYouUsingNCRSelfServCheckout> <hWaitEvent=0x70>
4990) 06/13 19:15:15;0015778338 0EC4> DM-DMp@998  +SaySecurity, ThankYouUsingNCRSelfServCheckout.
4991) 06/13 19:15:15;0015778428 0EC4> DM-DMp@1044 -SaySecurity, ThankYouUsingNCRSelfServCheckout.
4992) 06/13 19:15:15;0015778428 0EC4> SM-SMdmBase@3933 -DMSaySecurity 0
2917) 06/13 19:14:43;0015746332 0EC4> SM-ScanAndBag@469  DMSayPhrase(WELCOMEPSB)
2918) 06/13 19:14:43;0015746342 0EC4> SM-SMdmBase@3889 +DMSayPhrase <1>
2919) 06/13 19:14:43;0015746532 0EC4> SM-SMdmBase@3909 -DMSayPhrase 0
16124) 10/22 17:00:20;0096914365 0D08> SM-SMdmBase@5201 Count Percentage : 100.000000. denom : -1. count 994. capacity 485.low level: 75
16125) 10/22 17:00:20;0096914365 0D08> SM-SMdmBase@5201 Count Percentage : 100.000000. denom : -5. count 998. capacity 126.low level: 40
16126) 10/22 17:00:20;0096914365 0D08> SM-SMdmBase@5201 Count Percentage : 100.000000. denom : -10. count 1000. capacity 365.low level: 75
16127) 10/22 17:00:20;0096914365 0D08> SM-SMdmBase@5201 Count Percentage : 100.000000. denom : -25. count 994. capacity 277.low level: 75
16128) 10/22 17:00:20;0096914365 0D08> SM-SMdmBase@5201 Count Percentage : 99.900000. denom : 100. count 2997. capacity 3000.low level: 20
16129) 10/22 17:00:20;0096914365 0D08> SM-SMdmBase@5201 Count Percentage : 50.000000. denom : 500. count 1500. capacity 3000.low level: 20
16130) 10/22 17:00:20;0096914365 0D08> SM-SMdmBase@5201 Count Percentage : 24.966667. denom : 1000. count 749. capacity 3000.low level: 20
16131) 10/22 17:00:20;0096914365 0D08> DM-DMp@2707 +GetPrinterPaperLow on thread 0x00000d08
16130) 10/22 17:00:20;0096914365 0D08> SM-SMdmBase@5201 Count Percentage : 24.966667. denom : 1000. count 749. capacity 3000.low level: 20
16131) 10/22 17:00:20;0096914365 0D08> DM-DMp@2707 +GetPrinterPaperLow on thread 0x00000d08
5749) 10/22 16:49:42;0096276287 SM-SMtb@4607, 4, TBBalanceDetails--TenderDetail: szDescription:(null); lTender:500; lBalance:-183; lChange:183; szErrDescription:(null); nTenderType:41;
1423) 10/24 16:47:42;0254643808 1108> DM-DMp@5447 -GetResultCodeExtended rc =0
1524) 10/24 16:47:43;0254644509 1108> XM-CMInter@245  GetDispenserCapacity from CM: denom: 100; capacity: 3000
124785) 11/17 09:07:24;0010947500 0DF8> SM-SMdmBase@842  Parse DM evt 0, dev 15, code 0, length 19
124794) 11/17 09:07:24;0010947500 0DF8> -RCMgri@248  bstrInParms: type[text]=normal-item;description[text]=[SummaryX]kr 1.000&comma;00 indsat
262861) 01/17 13:05:06;0026886468 09DC> SM-SMdmBase@840  Parse DM evt 0, dev 16, code 0, length 15
262870) 01/17 13:05:06;0026886468 09DC> -RCMgri@248  bstrInParms: type[text]=normal-item;description[text]=[SummaryX]kr 0&comma;50 indsat
111232) 02/05 14:39:50;0077916328 0400> SM-SMdmBase@841  Parse DM evt 0, dev 15, code 0, length 15
111298) 02/05 14:39:52;0077918531 0400> -RCMgri@248  bstrInParms: type[text]=normal-item;description[text]=[SummaryX]500 Ft behelyezve
111232) 02/05 14:39:50;0077916328 0400> SM-SMdmBase@841  Parse DM evt 0, dev 15, code 0, length 15
111244) 02/05 14:39:50;0077916328 0400> -RCMgri@248  bstrInParms: type[text]=normal-item;description[text]=[SummaryX]1 000 Ft behelyezve
120120) 02/05 14:43:42;0078148265 0400> SM-SMdmBase@841  Parse DM evt 0, dev 16, code 0, length 13
120280) 02/05 14:43:43;0078149015 0400> -RCMgri@248  bstrInParms: type[text]=normal-item;description[text]=[SummaryX]5 Ft behelyezve
31293) 12/11 14:35:18;0082720171 0B0C> SM-SMdmBase@841  Parse DM evt 0, dev 16, code 0, length 13
31305) 12/11 14:35:18;0082720171 0B0C> -RCMgri@248  bstrInParms: type[text]=normal-item;description[text]=[SummaryX]2&comma;00 EUR behelyezve
28335) 12/11 14:31:23;0082521140 0B0C> SM-SMdmBase@841  Parse DM evt 0, dev 15, code 0, length 15
28347) 12/11 14:31:23;0082521140 0B0C> -RCMgri@248  bstrInParms: type[text]=normal-item;description[text]=[SummaryX]50&comma;00 EUR behelyezve
6297) 03/10 12:06:08;0025642906 0470> SM-SMdmBase@375  Parse DM evt 0, dev 15, code 0, length 13
6339) 03/10 12:06:08;0025642921 0470> -RCMgri@250  bstrInParms: type[text]=normal-item;description[text]=[SummaryX]5&comma;00 € Inséré
3673) 01/21 16:32:39;0011185393 0944> SM-SMdmBase@8097 +SMStateBase::DMGetDeviceErrorHTML() DeviceClass=0, Model=Any, SubModel=, Status/Error=11, ExtCode=-99, Context=0, LCID=0409");
			
			LaneConfiguration config = new LaneConfigurationRepositoryStub().Read("");
			parser = config.Parsers.GetParser("Traces").Instantiate();
			
			parser.Parse += new EventHandler<ProgressEventArgs>(ParserParse);
		}
		
		[TearDown]
		public void Teardown()
		{
			parser.Parse -= new EventHandler<ProgressEventArgs>(ParserParse);
		}

		[Test]
		public void TestParse()
		{
			List<IScriptEvent> events = parser.PerformParse(log);
			Assert.AreEqual(45, events.Count); // Added TriColorLight and ReportEvent
			FingerScriptEvent evnt = events[0] as FingerScriptEvent;
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(new FingerDeviceEvent().GetType(), evnt.Item);
			FingerDeviceEvent item = evnt.Item as FingerDeviceEvent;
			Assert.AreEqual("Scale: 0", item.ToString());
			Assert.AreEqual("Scale", item.Id);
			Assert.AreEqual("0", item.Value);
		}
		
		[Test]
		public void TestParseNullLinesOnCashOrCoinDeviceEventAdder()
		{
			log = new ExtendedStringReader(@"28335) 12/11 14:31:23;0082521140 0B0C> SM-SMdmBase@841  Parse DM evt 0, dev 15, code 0, length 15");
			List<IScriptEvent> events = parser.PerformParse(log);
			Assert.AreEqual(0, events.Count);
		}
		
		[Test]
		public void TestParseNullLinesOnScannerDeviceEventAdder()
		{
			log = new ExtendedStringReader(@"2115) 02/12 13:27:20;0025917577 15F4> SM-SMStateBase@3234 +isBarcodeValidOperatorPassword  <A048500008621~048500008621~101>");
			List<IScriptEvent> events = parser.PerformParse(log);
			Assert.AreEqual(0, events.Count);
		}
		
		[Test]
		public void TestParseNullLinesOnScanner3207DeviceEventAdder()
		{
			log = new ExtendedStringReader(@"5560) 04/18 14:25:25;0001287571 0934> SM-SMStateBase@3235 +isBarcodeValidOperatorPassword  <830324006460
~830324006460~101>");
			List<IScriptEvent> events = parser.PerformParse(log);
			Assert.AreEqual(0, events.Count);
		}
		
		[Test]
		public void TestParseNullLinesOnSayAmountEventAdder()
		{
			log = new ExtendedStringReader(@"3362) 06/13 19:14:59;0015762164 0EC4> SM-SMdmBase@3814 +DMSayAmount 289");
			List<IScriptEvent> events = parser.PerformParse(log);
			Assert.AreEqual(0, events.Count);
		}
		
		[Test]
		public void TestParseNullLinesOnSaySecurityEventAdder()
		{
			log = new ExtendedStringReader(@"4989) 06/13 19:15:15;0015778338 0EC4> SM-SMdmBase@3916 +DMSaySecurity <0> <ThankYouUsingNCRSelfServCheckout> <hWaitEvent=0x70>");
			List<IScriptEvent> events = parser.PerformParse(log);
			Assert.AreEqual(0, events.Count);
		}
		
		[Test]
		public void TestParseNullLinesOnCMCountPercentageAdder()
		{
			log = new ExtendedStringReader(@"16124) 10/22 17:00:20;0096914365 0D08> SM-SMdmBase@5201 Count Percentage : 100.000000. denom : -1. count 994. capacity 485.low level: 75");
			List<IScriptEvent> events = parser.PerformParse(log);
			Assert.AreEqual(0, events.Count);
		}
		
		void ParserParse(object sender, ProgressEventArgs e)
		{
		}
	}
}
