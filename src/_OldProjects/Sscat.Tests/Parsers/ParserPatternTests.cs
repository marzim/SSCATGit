//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//		<owner name="Apple Leo Chiong" email="ac185120@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Core.Parsers.DeviceEvents;

namespace Sscat.Tests.Parsers
{
	[TestFixture]
	public class ParserPatternTests
	{
		//[Test]
        //TODO: Either remove or fix empty test
		public void TestPsx()
		{
            //ParserPattern p = new ParserPattern(ParserPattern.Psx, new PsxEventAdder());
            //Assert.IsTrue(p.Match(@"PSX_ScotAppU:03/21 09:17:13       502,913 0908> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Startup, EventName:ChangeContext, Param:, Consumed:0, TimeFired:502913)").Success);
		}

        //[Test]
        //TODO: Either remove or fix empty test
		public void TestPsxRap()
		{
            //ParserPattern p = new ParserPattern(ParserPattern.Psx, new PsxEventAdder());
            //Assert.IsTrue(p.Match(@"PSX_RapNet:10/12 09:39:42    62,267,596 03E0> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Startup, EventName:KeyDown, Param:91, Consumed:0, TimeFired:62267596)").Success);
		}

        //[Test]
        //TODO: Either remove or fix empty test
		public void TestScale()
		{
            //ParserPattern p = new ParserPattern(ParserPattern.Scale, new DeviceEventAdder("Scale"));
            //Assert.IsTrue(p.Match(@"1932) 07/04 15:29:12;0315091568 0B88> SM-SMdmBase@5921 Scale weight = 0").Success);
		}

        //[Test]
        //TODO: Either remove or fix empty test
		public void TestReceiptItem()
		{
            //ParserPattern p = new ParserPattern(ParserPattern.ReceiptItem, new ReceiptItemDeviceEventAdder());
            //Assert.IsTrue(p.Match(@"2637) 08/10 09:55:13;0049851332 0C14> -CReport@1739 -CReporting::LogItemDetails <ItemSold Time= ""2012-08-10T01:55:13.722"" ID=""1"" Code=""1111"" Description=""White Bread"" Department=""0"" ExtPrice=""289"" UnitPrice=""289"" PriceRqd=""0"" QtySold=""1"" DealQty=""0"" QtyRqd=""0"" QtyConfirmed=""0"" QtyLimitExceeded=""0"" WgtRqd=""0"" WgtSold=""0"" Coupon=""0"" TareRqd=""0"" NotFound=""0"" NotForSale=""0"" VisVerify=""0"" Restricted=""0"" RestrictedAge=""0"" Void=""0"" Linked=""0"" CrateAnswer=""2"" SecurityBaggingRqd=""-1"" SecuritySubChkRqd=""-1"" SecurityTag=""0"" ZeroWeight=""0"" PickList=""0""/>").Success);
		}

        //[Test]
        //TODO: Either remove or fix empty test
		public void TestReceiptItemBase()
		{
            //ParserPattern p = new ParserPattern(ParserPattern.ReceiptItemBase, new ReceiptItemDeviceEventAdder());
            //Assert.IsTrue(p.Match(@"2637) 08/10 09:55:13;0049851332 0C14> -CReport@1739 -CReportingBase::LogItemDetails <ItemSold Time= ""2012-08-10T01:55:13.722"" ID=""1"" Code=""1111"" Description=""White Bread"" Department=""0"" ExtPrice=""289"" UnitPrice=""289"" PriceRqd=""0"" QtySold=""1"" DealQty=""0"" QtyRqd=""0"" QtyConfirmed=""0"" QtyLimitExceeded=""0"" WgtRqd=""0"" WgtSold=""0"" Coupon=""0"" TareRqd=""0"" NotFound=""0"" NotForSale=""0"" VisVerify=""0"" Restricted=""0"" RestrictedAge=""0"" Void=""0"" Linked=""0"" CrateAnswer=""2"" SecurityBaggingRqd=""-1"" SecuritySubChkRqd=""-1"" SecurityTag=""0"" ZeroWeight=""0"" PickList=""0""/>").Success);
		}

        //[Test]
        //TODO: Either remove or fix empty test
		public void TestMsr()
		{
            //ParserPattern p = new ParserPattern(ParserPattern.Msr, new MsrDeviceEventAdder());
			// TODO: Provide match point
		}

        //[Test]
        //TODO: Either remove or fix empty test
		public void TestBagScale()
		{
            //ParserPattern p = new ParserPattern(ParserPattern.BagScale, new DeviceEventAdder("BagScale"));
            //Assert.IsTrue(p.Match(@"SM: 07/12 10:17:11    85,258,645 0A80> m_wLastWeight:  0").Success);
            //Assert.IsTrue(p.Match(@"SM: 08/17 16:33:27    10,390,660 0A80> Sending message:  Zero Wt").Success);
            //Assert.IsTrue(p.Match(@"SM: 08/17 16:33:27    10,390,660 0F2C> lCurrentTotalWeight=0").Success);
		}

        //[Test]
        //TODO: Either remove or fix empty test
		public void TestPinPad()
		{
            //Assert.IsTrue(p.Match(@"2115) 02/12 13:27:20;0025917577   -DMEncryptorgetPIN").Success);
            //ParserPattern p = new ParserPattern(ParserPattern.PinPad, new PinPadDeviceEventAdder());
		}

        //[Test]
        //TODO: Either remove or fix empty test
		public void TestPinPadCancel()
		{
            //ParserPattern p = new ParserPattern(ParserPattern.PinPadCancel, new PinPadCancelDeviceEventAdder());
            //Assert.IsTrue(p.Match(@"2115) 02/12 13:27:20;0025917577   DM Encryptor Cancelled").Success);
		}

        //[Test]
        //TODO: Either remove or fix empty test
		public void TestCouponSlip()
		{
            //ParserPattern p = new ParserPattern(ParserPattern.CouponSlip, new CouponSlipDeviceEventAdder());
            //Assert.IsTrue(p.Match(@"2844) 05/28 16:14:33;0005143666 SM-SMdmBase@1653 DM Coupon Sensor detected coupon slip").Success);
		}

        //[Test]
        //TODO: Either remove or fix empty test
		public void TestScanner()
		{
            //ScannerDeviceEventAdder a = new ScannerDeviceEventAdder();
            //ParserPattern p = new ParserPattern(ParserPattern.Scanner, a);
            //Match m = p.Match(@"2115) 02/12 13:27:20;0025917577 15F4> SM-SMStateBase@3234 +isBarcodeValidOperatorPassword  <A048500008621~048500008621~101>");
            //Assert.IsTrue(m.Success);
            //
            //List<IScriptEvent> events = new List<IScriptEvent>();
            //ExtendedStringReader l = new ExtendedStringReader(@"2116) 02/12 13:27:20;0025917577 15F4> SM-SMStateBase@3495 -isBarcodeValidOperatorPassword  <0>");
            //p.Add("", m, l, events);
            //Assert.AreEqual(1, events.Count);
		}

        //[Test]
        //TODO: Either remove or fix empty test
		public void TestScanner2()
		{
            //ScannerDeviceEventAdder a = new ScannerDeviceEventAdder();
            //ParserPattern p = new ParserPattern(ParserPattern.Scanner, a);
            //Match m = p.Match(@"2266) 08/31 15:24:34;0269995953 1768> SM-SMStateBase@3305 +isBarcodeValidOperatorPassword  <81109482911323343423434231234567~81109482911323343423434231234567~132>");
            //Assert.IsTrue(m.Success);
            //
            //List<IScriptEvent> events = new List<IScriptEvent>();
            //ExtendedStringReader l = new ExtendedStringReader(@"2267) 08/31 15:24:34;0269995953 1768> SM-SMStateBase@3539 -isBarcodeValidOperatorPassword  <0>");
            //p.Add("", m, l, events);
            //Assert.AreEqual(1, events.Count);
		}

        //[Test]
        //TODO: Either remove or fix empty test
		public void TestScanner3207()
		{
            //Scanner3207DeviceEventAdder a = new Scanner3207DeviceEventAdder();
            //ParserPattern p = new ParserPattern(ParserPattern.Scanner3207, a);
            //Match m = p.Match(@"2115) 02/12 13:27:20;0025917577 15F4> SM-SMStateBase@3234 +isBarcodeValidOperatorPassword  <A048500008621");
            //Assert.IsTrue(m.Success);
            //
            //List<IScriptEvent> events = new List<IScriptEvent>();
            //ExtendedStringReader l = new ExtendedStringReader(@"~830324006460~101>
                //5561) 04/18 14:25:25;0001287571 0934> SM-SMStateBase@3248 co.nOperationsOperatorLoginBarcodeType = 1
                //5562) 04/18 14:25:25;0001287571 0934> SM-SMStateBase@3259 csBarcodeScanType = 'F'
                //5563) 04/18 14:25:25;0001287571 0934> SM-SMStateBase@3280 csTemp = 101
                //5564) 04/18 14:25:25;0001287571 0934> SM-SMStateBase@3401 csItemCodeNoType = 30324006460
                //~830324006460~101
                //5565) 04/18 14:25:25;0001287571 0934> SM-SMStateBase@3508 -isBarcodeValidOperatorPassword  <0>");
            //p.Add("", m, l, events);
            //Assert.AreEqual(1, events.Count);
		}
		
		[Test]
		public void TestScannerError()
		{
			ScannerDeviceErrorEventAdder a = new ScannerDeviceErrorEventAdder();
			ParserPattern p = new ParserPattern(@"(?<ms>\d{10}) .* Parse DM evt 1, dev 11, code (?<value>\d{1,3}), length 0", a);
			Assert.IsTrue(p.Match(@"11197) 10/02 10:25:32;0501988160 0C40> SM-SMdmBase@366  Parse DM evt 1, dev 11, code 111, length 0").Success);
		}
		
		[Test]
		public void TestSignatureCaptureError()
		{
			// Failure
			ParserPattern p = new ParserPattern(@"(?<ms>\d{10}) .* ERROR: SignatureCapture\\Emulator\|(?<value>\d{1,3})\|0", new SignatureCaptureErrorEventAdder());
			Assert.IsTrue(p.Match(@"2253) 10/03 11:09:03;0006622352 0C74> -SCOTDevFactory@462  ERROR: SignatureCapture\Emulator|111|0").Success);
			
			// No Hardware
			p = new ParserPattern(@"(?<ms>\d{10}) .* ERROR: SignatureCapture\\Emulator\|(?<value>\d{1,3})\|0", new SignatureCaptureErrorEventAdder());
			Assert.IsTrue(p.Match(@"8465) 10/04 10:47:33;0091731673 0C74> -SCOTDevFactory@462  ERROR: SignatureCapture\Emulator|107|0").Success);
			
			// Offline
			p = new ParserPattern(@"(?<ms>\d{10}) .* ERROR: SignatureCapture\\Emulator\|(?<value>\d{1,3})\|0", new SignatureCaptureErrorEventAdder());
			Match m = p.Match(@"8521) 10/04 10:48:37;0091796476 0C74> -SCOTDevFactory@462  ERROR: SignatureCapture\Emulator|108|0");
			Assert.IsTrue(m.Success);
		}
		
		[Test]
		public void TestCashAcceptor()
		{
			CashEventAdder a = new CashEventAdder();
			ParserPattern p = new ParserPattern("Parse DM evt 0, dev 15", a);
			Match m = p.Match(@"8182) 05/25 14:52:14;0001047826 0244> SM-SMdmBase@840  Parse DM evt 0, dev 15, code 0, length 17");
			
			List<IScriptEvent> events = new List<IScriptEvent>();
			ExtendedStringReader l = new ExtendedStringReader(@"8183) 05/25 14:52:14;0001047826 0244> SM-SMdmBase@2110 Hex: DM Data,17
                8232) 05/25 14:52:14;0001047856 0244> SM-SMStateBase@6266 +ra.OnNormalItem, Message=$100.00 inserted
                8235) 05/25 14:52:14;0001047856 0244> -RCMgri@248  bstrInParms: type[text]=normal-item;description[text]=[SummaryX]$100.00 inserted");
			p.Add("", m, l, events, "");
			Assert.AreEqual(1, events.Count);
		}
		
		[Test]
		public void TestCoinAcceptor()
		{
			CoinEventAdder a = new CoinEventAdder();
			ParserPattern p = new ParserPattern("", a);
			Match m = p.Match(@"");
			
			List<IScriptEvent> events = new List<IScriptEvent>();
			ExtendedStringReader l = new ExtendedStringReader(@"8183) 05/25 14:52:14;0001047826 0244> SM-SMdmBase@2110 Hex: DM Data,17
                8232) 05/25 14:52:14;0001047856 0244> SM-SMStateBase@6266 +ra.OnNormalItem, Message=$100.00 inserted
                8235) 05/25 14:52:14;0001047856 0244> -RCMgri@248  bstrInParms: type[text]=normal-item;description[text]=[SummaryX]$100.00 inserted");
			p.Add("", m, l, events, "");
		}
		
		[Test]
		public void TestTabTransport()
		{
			TABTransportEventAdder a = new TABTransportEventAdder();
			ParserPattern p = new ParserPattern("", a);
			Match m = p.Match(@"");
			
			List<IScriptEvent> events = new List<IScriptEvent>();
			ExtendedStringReader l = new ExtendedStringReader(@"8028) 10/30 21:01:30;0000464078 14D8> SM-TransportItem@104  +DMTakeawayReadyForItem");
			p.Add("", m, l, events, "");			
		}
		
		[Test]
		public void TestCashAcceptorErrors()
		{
			// OK
			ParserPattern p = new ParserPattern("Parse DM evt 103, dev 15, code 0, length 0", new CashErrorEventAdder());
			Assert.IsTrue(p.Match(@"2645) 09/26 15:17:35;0001175209 09C0> SM-SMdmBase@366  Parse DM evt 103, dev 15, code 0, length 0").Success);
			
			// Reset
			p = new ParserPattern("Parse DM evt 103, dev 15, code 4, length 0", new CashErrorEventAdder());
			Assert.IsTrue(p.Match(@"2501) 09/26 15:38:47;0002446958 0D08> SM-SMdmBase@366  Parse DM evt 103, dev 15, code 4, length 0").Success);

			// Jam
			p = new ParserPattern("Parse DM evt 103, dev 15, code 5, length 0", new CashErrorEventAdder());
			Assert.IsTrue(p.Match(@"2479) 09/26 15:36:28;0002308068 0D08> SM-SMdmBase@366  Parse DM evt 103, dev 15, code 5, length 0").Success);

			// Fail
			p = new ParserPattern("Parse DM evt 103, dev 15, code 6, length 0", new CashErrorEventAdder());
			Assert.IsTrue(p.Match(@"2623) 09/26 15:17:35;0001174689 09C0> SM-SMdmBase@366  Parse DM evt 103, dev 15, code 6, length 0").Success);
		}
		
		[Test]
		public void TestCoinAcceptorErrors()
		{
			// OK
			ParserPattern p = new ParserPattern("Parse DM evt 103, dev 16, code 0, length 0", new CoinErrorEventAdder());
			Assert.IsTrue(p.Match(@"8174) 10/01 18:04:25;0443146661 0C40> SM-SMdmBase@366  Parse DM evt 103, dev 16, code 0, length 0").Success);
			
			// Reset
			p = new ParserPattern("Parse DM evt 103, dev 16, code 4, length 0", new CoinErrorEventAdder());
			Assert.IsTrue(p.Match(@"7989) 10/01 18:02:56;0443057262 0C40> SM-SMdmBase@366  Parse DM evt 103, dev 16, code 4, length 0").Success);

			// Jam
			p = new ParserPattern("Parse DM evt 103, dev 16, code 5, length 0", new CoinErrorEventAdder());
			Assert.IsTrue(p.Match(@"8613) 10/01 18:07:07;0443309114 0C40> SM-SMdmBase@366  Parse DM evt 103, dev 16, code 5, length 0").Success);
			
			// Fail
			p = new ParserPattern("Parse DM evt 103, dev 16, code 6, length 0", new CoinErrorEventAdder());
			Assert.IsTrue(p.Match(@"8631) 10/01 18:07:56;0443357524 0C40> SM-SMdmBase@366  Parse DM evt 103, dev 16, code 6, length 0").Success);
		}

        //[Test]
        //TODO: Either remove or fix empty test
		public void TestScannerWithoutMatchingPattern()
		{
            //ScannerDeviceEventAdder a = new ScannerDeviceEventAdder();
            //ParserPattern p = new ParserPattern(ParserPattern.Scanner, a);
            //Match m = p.Match(@"2115) 02/12 13:27:20;0025917577 15F4> SM-SMStateBase@3234 +isBarcodeValidOperatorPassword  <A048500008621~048500008621~101>");
            //Assert.IsTrue(m.Success);
            //
            //List<IScriptEvent> events = new List<IScriptEvent>();
            //ExtendedStringReader l = new ExtendedStringReader(@"Not valid paring for last scanner event...");
            //p.Add("", m, l, events);
            //Assert.AreEqual(0, events.Count);
		}
	}
}
