//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections;
using System.IO;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Finger;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Core.Services;
using Sscat.Tests.Config;

namespace Sscat.Tests.Log
{
	[TestFixture]
	public class ScotLogHookTests
	{
		IScotLogHook psxHook;
		IScotLogHook traceHook;
		IScotLogHook smHook;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			LaneConfiguration config = new LaneConfigurationRepositoryStub().Read("");
			
			psxHook = new ScotLogHook(
				new TextWatcher(@"PSX_ScotAppU:08/16 14:20:43   942,962,708 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Attract, EventName:ChangeContext, Param:, Consumed:0, TimeFired:942962708)
PSX_ScotAppU:08/16 14:20:56   942,975,467 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:CMButton1Lg, ContextName:Attract, EventName:Click, Param:, Consumed:0, TimeFired:942975467)
PSX_ScotAppU:08/16 14:20:57   942,976,238 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:ScanAndBag, EventName:ChangeContext, Param:, Consumed:0, TimeFired:942976238)
PSX_ScotAppU:08/16 14:20:59   942,977,790 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:CMButton2KeyInCode, ContextName:ScanAndBag, EventName:Click, Param:, Consumed:0, TimeFired:942977790)
PSX_ScotAppU:08/16 14:20:59   942,977,830 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:KeyInCode, EventName:ChangeContext, Param:, Consumed:0, TimeFired:942977830)
PSX_ScotAppU:08/16 14:21:00   942,978,982 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:NumericP1, ContextName:KeyInCode, EventName:Click, Param:97, Consumed:0, TimeFired:942978982)
PSX_ScotAppU:08/16 14:21:00   942,979,312 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:NumericP1, ContextName:KeyInCode, EventName:Click, Param:97, Consumed:0, TimeFired:942979312)
PSX_ScotAppU:08/16 14:21:01   942,979,823 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:NumericP1, ContextName:KeyInCode, EventName:Click, Param:97, Consumed:0, TimeFired:942979823)
PSX_ScotAppU:08/16 14:21:01   942,980,324 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:NumericP1, ContextName:KeyInCode, EventName:Click, Param:97, Consumed:0, TimeFired:942980324)
PSX_ScotAppU:08/16 14:21:02   942,981,045 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:NumericP4, ContextName:KeyInCode, EventName:Click, Param:, Consumed:0, TimeFired:942981045)
PSX_ScotAppU:08/16 14:21:02   942,981,595 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:BagAndEAS, EventName:ChangeContext, Param:, Consumed:0, TimeFired:942981595)
PSX_ScotAppU:08/16 14:21:03   942,982,547 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:CMButton1Med, ContextName:BagAndEAS, EventName:Click, Param:, Consumed:0, TimeFired:942982547)
PSX_ScotAppU:08/16 14:21:04   942,982,847 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:ScanAndBag, EventName:ChangeContext, Param:, Consumed:0, TimeFired:942982847)
PSX_ScotAppU:08/16 14:21:06   942,985,481 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:CMButton4LgFinish, ContextName:ScanAndBag, EventName:Click, Param:, Consumed:0, TimeFired:942985481)
PSX_ScotAppU:08/16 14:21:07   942,985,801 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Finish, EventName:ChangeContext, Param:, Consumed:0, TimeFired:942985801)
PSX_ScotAppU:08/16 14:21:08   942,986,923 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:TenderImage, ContextName:Finish, EventName:Click, Param:3, Consumed:0, TimeFired:942986923)
PSX_ScotAppU:08/16 14:21:08   942,987,013 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:CardProcessing, EventName:ChangeContext, Param:, Consumed:0, TimeFired:942987013)
PSX_ScotAppU:08/16 14:21:09   942,988,575 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:TakeReceipt, EventName:ChangeContext, Param:, Consumed:0, TimeFired:942988575)
PSX_ScotAppU:08/16 14:21:11   942,990,478 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:ThankYou, EventName:ChangeContext, Param:, Consumed:0, TimeFired:942990478)
PSX_ScotAppU:08/16 14:21:12   942,991,059 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Attract, EventName:ChangeContext, Param:, Consumed:0, TimeFired:942991059)"),
				config.Parsers.GetParser("Psx").Instantiate()
			);
			psxHook.EventsChanged += delegate { };
			psxHook.PerformChanged();
			Assert.AreEqual(20, psxHook.Events.Count);
			
			traceHook = new ScotLogHook(
				new TextWatcher(@"1917) 08/16 14:20:44;0942962949 1568> SM-SMdmBase@5921 Scale weight = 0
2405) 08/16 14:21:02;0942981195 SM-SMtb@4277, 4, TBGetTotalDetails--TotalDetail: lTaxDue:28; lTotal:317; lDiscount:0; szErrDescription:(null); lFoodStampDue:0
2440) 08/16 14:21:02;0942981465 1568> -CReport@1739 -CReporting::LogItemDetails <ItemSold Time= ""2011-08-16T06:21:02.740"" ID=""1"" Code=""1111"" Description=""White Bread"" Department=""0"" ExtPrice=""289"" UnitPrice=""289"" PriceRqd=""0"" QtySold=""1"" DealQty=""0"" QtyRqd=""0"" QtyConfirmed=""0"" QtyLimitExceeded=""0"" WgtRqd=""0"" WgtSold=""0"" Coupon=""0"" TareRqd=""0"" NotFound=""0"" NotForSale=""0"" VisVerify=""0"" Restricted=""0"" RestrictedAge=""0"" Void=""0"" Linked=""0"" CrateAnswer=""2"" SecurityBaggingRqd=""-1"" SecuritySubChkRqd=""-1"" SecurityTag=""0"" ZeroWeight=""0"" PickList=""0""/>
3243) 08/16 14:21:07;0942985972 SM-SMtb@4277, 4, TBGetTotalDetails--TotalDetail: lTaxDue:28; lTotal:317; lDiscount:0; szErrDescription:(null); lFoodStampDue:289
3826) 08/16 14:21:11;0942990518 SM-SMtb@4277, 4, TBGetTotalDetails--TotalDetail: lTaxDue:28; lTotal:317; lDiscount:0; szErrDescription:(null); lFoodStampDue:289"),
				config.Parsers.GetParser("Traces").Instantiate()
			);
			traceHook.PerformChanged();
//			Assert.AreEqual(5, traceHook.Events.Count);
			Assert.AreEqual(4, traceHook.Events.Count);
			
//			smHook = new ScotLogHook(
//				new TextWatcher(@"SM: 08/16 14:21:06   942,985,140 1290> lCurrentTotalWeight=0
//SM: 08/16 14:21:11   942,990,458 1310> Sending message:  Zero Wt"),
//				config.Parsers.GetParser("SM").Instantiate()
//			);
			smHook = new ScotLogHook(
				new TextWatcher(@"SM: 08/16 14:21:06   942,985,140 1290> lCurrentTotalWeight=0
SM: 08/16 14:21:11   942,990,458 1310> Sending message:  Zero Wt
	Message    = Zero Wt
    Action    = ResetTransaction
SM: 05/14 16:24:50    13,273,046 05F8> Sending message:  Zero Wt
SM: 05/14 16:24:50    13,273,046 05F8> Message complete:  Transaction Expired
    Action    = ResetTransaction"),
				config.Parsers.GetParser("SM").Instantiate()
			);
			smHook.PerformChanged();
			Assert.AreEqual(2, smHook.Events.Count);
		}
		
		[Test]
		public void TestCheckPass()
		{
			FingerScriptEvent e = FingerScriptEvent.Deserialize(new StringReader(@"<FingerEventData>
                  <enable>true</enable>
                  <eventTimeMS>942975467</eventTimeMS>
                  <eventType>PsxEventData</eventType>
                  <PsxEventData>
                    <psxId>1</psxId>
                    <contextName>Attract</contextName>
                    <controlName>CMButton1Lg</controlName>
                    <eventName>Click</eventName>
                    <param />
                    <remoteConnectionName />
                    <seqId>0</seqId>
                  </PsxEventData>
                </FingerEventData>"));
			Assert.AreEqual(ResultType.Passed, psxHook.Check(e, 5000).Type);
		}

        [Test]
        public void TestCheckFail()
        {
            FingerScriptEvent e = FingerScriptEvent.Deserialize(new StringReader(@"<FingerEventData>
                <enable>true</enable>
                <eventTimeMS>0</eventTimeMS>
                <eventType>WLDBEventData</eventType>
                <WLDBEventData>
                  <servername>g2lane-ian</servername>
                  <action>Update</action>
                  <WLDBFilePath>C:\SSCAT\WLDB\G2_RAPISSM\WLDB.mdb</WLDBFilePath>
	              <SAConfigFilePath></SAConfigFilePath>
                  <seqId>0</seqId>
                </WLDBEventData>
              </FingerEventData>"));
            Assert.AreEqual(ResultType.Failed, psxHook.Check(e, 5000).Type);
        }

		[Test]
		public void TestCheckMethodToGiveWarningForSpecialEvents()
		{
			FingerScriptEvent sampleDeviceEvent = FingerScriptEvent.Deserialize(new StringReader(@"<FingerEventData>
                <enable>true</enable>
                <eventTimeMS>74069031</eventTimeMS>
                <eventType>DeviceEventData</eventType>
                <DeviceEventData>
                  <deviceId>AmountDue;TaxDue</deviceId>
                  <deviceValue>316;28</deviceValue>
                  <seqId>16</seqId>
                </DeviceEventData>
              </FingerEventData>"));
			(sampleDeviceEvent.Item as IScriptEventItem).IsForgivable = true;
  			Result logHookCheckingResult = traceHook.Check(sampleDeviceEvent, 5000);
			Assert.AreEqual(ResultType.Warning, logHookCheckingResult.Type);
			Assert.AreEqual(true, logHookCheckingResult.ActualResult.Equals("AmountDue;TaxDue: 317;28"));
		}
		
		[Test]
		public void TestCompareReceipt()
		{
			Assert.AreEqual(true, traceHook.CompareReceiptItem("Plax	1.00", "Plax	1.00"));
			Assert.AreEqual(true, traceHook.CompareReceiptItem("Plax	1,00", "Plax	1,00"));
		}
	}
}
