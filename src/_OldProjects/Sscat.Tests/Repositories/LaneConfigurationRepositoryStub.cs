//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Repositories;

namespace Sscat.Tests.Config
{
	public class LaunchPadConfigRepositoryStub : BaseRepository, ILaunchPadConfigRepository
	{
		public LaunchPadConfig Read(string file)
		{
			return LaunchPadConfig.Deserialize(new StringReader(@"<?xml version='1.0'?>
<!-- Add Schema -->
<root>
	<App MainExecutable='FastLane' LoadOnStartUp='true' MainContext='FastLaneContext' CompanionContext='RAPContext' KeyLock='SCOTSwitch' CompanionExecutable='RAP' KillAppOnSwitch='true' LaunchPadSecurityOn='true' SecurityContext='EnterID' SecurityContext_='EnterAlphaNumericID' UtilityButtonVisible='true' ForegroundWindowTitle=''>
	</App>
	<!--Executable ExecutableName='FastLane'  WindowTitle='NCR SCOT' Path='' Filename='scotapp.exe'  Maximize='true'>
	</Executable-->
	<Executable ExecutableName='FastLane' WindowTitle='NCR SCOT' Path='' Filename='ScotAppU.exe' Maximize='true' MinimizeStart='true' StopWindow='SCOTInputWindow' StopUserMessage='101' TopMost='false'>
		<ExecuteFunction OnEvent='Start' ExecuteOn='Pre' ExecutableName='PreScotStart'></ExecuteFunction>
		<ExecuteFunction OnEvent='Start' ExecuteOn='Post' ExecutableName='PostScotStart'></ExecuteFunction>
		<ExecuteFunction OnEvent='Stop' ExecuteOn='Pre' ExecutableName='PreScotStop'></ExecuteFunction>
		<ExecuteFunction OnEvent='Stop' ExecuteOn='Post' ExecutableName='PostScotStop'></ExecuteFunction>
		<ExecuteFunction OnEvent='Minimize' ExecuteOn='Post' ExecutableName='PostScotMinimize'></ExecuteFunction>
	</Executable>
	<Executable ExecutableName='CommandPrompt' WindowTitle='Command Prompt' Path='{system}' Filename='cmd.exe' Maximize='false'>
	</Executable>
	<Executable ExecutableName='Reboot' Filename='reboot.exe' Maximize='false' MinimizeStart='true'>
		<ExecuteFunction OnEvent='Start' ExecuteOn='Pre' ExecutableName='FastLane' Execute='Stop'></ExecuteFunction>
	</Executable>
	<Executable ExecutableName='Shutdown' Filename='reboot.exe' Arguments='-s' Maximize='false' MinimizeStart='true'>
		<ExecuteFunction OnEvent='Start' ExecuteOn='Pre' ExecutableName='FastLane' Execute='Stop'></ExecuteFunction>
	</Executable>
	<Executable ExecutableName='Volume' WindowTitle='Master Volume,Master Out,Volume Control' Path='{system}' Filename='sndvol32.exe' Maximize='false'>
	</Executable>
	<Executable ExecutableName='EventViewer' WindowTitle='Event Viewer' Path='{system}' Filename='eventvwr.msc' TopMost='false'>
	</Executable>
	<Executable ExecutableName='TouchWare' WindowTitle='TouchWare Properties' Path='%APP_DRIVE%\scot\bin' Filename='CalibrateDisplay.bat' Arguments='/c' TopMost='false'>
	</Executable>
	<Executable ExecutableName='StartUp' WindowTitle='StartUp' Path='%APP_DRIVE%\scot\bin\' Filename='StartUp.bat' TopMost='false'>
	</Executable>
	<Executable ExecutableName='TrainingProgram' Filename='C:\Program Files\Internet Explorer\iexplore.exe' Arguments='-k C:\FastLane\FastLaneTraining\MainMenu.htm'>
	</Executable>
	<Executable ExecutableName='RSMLE' Filename='C:\Program Files\Internet Explorer\iexplore.exe' Arguments='C:\Program Files\NCR\RSM\Website\ConsoleLE.htm'>
	</Executable>
	<Executable ExecutableName='GenerateLog' WindowTitle='Get Diagnostics Files Results,GetDiagFiles' Path='%APP_DRIVE%\scot\bin\' Filename='autopushdiagfiles.bat' Arguments='/p' MinimizeStart='true'>
	</Executable>
	<Executable ExecutableName='ExitFastLaneAndRunProfile' WindowTitle='Profile Manager Lite' Path='%APP_DRIVE%\scot\bin\' Filename='ProfileManagerLite.exe' Maximize='true' TopMost='false'>
		<ExecuteFunction OnEvent='Start' ExecuteOn='Pre' ExecutableName='FastLane' Execute='Stop'></ExecuteFunction>
	</Executable>
	<Executable ExecutableName='TerminalInfo' WindowTitle='TerminalInfo' Filename='TerminalInfoU.exe'>
	</Executable>
	<Executable ExecutableName='PreScotStop' Path='%APP_DRIVE%\scot\config\' Filename='PreScotStop.bat' Maximize='false' MinimizeStart='true'>
	</Executable>
	<Executable ExecutableName='PreScotStart' Path='%APP_DRIVE%\scot\config\' Filename='PreScotStart.bat' Maximize='false' MinimizeStart='true'>
		<ExecuteFunction OnEvent='Start' ExecuteOn='Pre' ExecutableName='StartUp'></ExecuteFunction>
		<ExecuteFunction OnEvent='Start' ExecuteOn='Post' ExecutableName='ADD'></ExecuteFunction>
	</Executable>
	<Executable ExecutableName='ReplaceScotStop' Filename='ReplaceScotStop.bat' Maximize='false'>
	</Executable>
	<Executable ExecutableName='PostScotStop' Path='%APP_DRIVE%\scot\config\' Filename='PostScotStop.bat' Maximize='false' MinimizeStart='true'>
	</Executable>
	<Executable ExecutableName='PreScotMinimize' Filename='PreScotMinimize.bat' Maximize='false'>
	</Executable>
	<Executable ExecutableName='PostScotMinimize' Filename='PostScotMinimize.bat' Maximize='false'>
	</Executable>
	<Executable ExecutableName='ReplaceScotStart' Filename='ReplaceScotStart.bat' Maximize='false'>
	</Executable>
	<Executable ExecutableName='PostScotStart' Path='%APP_DRIVE%\scot\config\' Filename='PostScotStart.bat' Maximize='false' MinimizeStart='true'>
	</Executable>
	<Executable ExecutableName='ADD' Path='%APP_DRIVE%\scot\bin\' Filename='ADD.bat' Maximize='false' WaitForExit='true' MinimizeStart='true' ExecuteOnlyOnce='true'>
	</Executable>
	<Executable ExecutableName='RunADD' Path='%APP_DRIVE%\scot\bin\' Filename='StartADD.bat' Maximize='false' TopMost='false'>
	</Executable>
	<Executable ExecutableName='Oru' WindowTitle='ORU' Path='%APP_DRIVE%\scot\bin\' Filename='Oru.exe' Maximize='false' TopMost='false'>
	</Executable>
</root>"));
		}
	}
	
	public class LaneConfigurationRepositoryStub : BaseRepository, ILaneConfigurationRepository
	{
		public void Save(LaneConfiguration config)
		{
			OnAccessing(new NcrEventArgs("Saving config file..."));
		}
		
		public LaneConfiguration Read(string file)
		{
			return Read(file, "");
		}
		
		public LaneConfiguration Read(string file, string fileNameToOVerwrite)
		{
			return LaneConfiguration.Deserialize(new StringReader(@"<Configuration>
	<Files
		Name='ConfigFiles'
		Destination='C:\SSCAT\ScotConfig'
		Source='C:\scot\config'>
		<File Name='AssistMenuConfig.xml'/>
		<File Name='RCMConfig.000'/>
		<File Name='RCMConfig.xml'/>
		<File Name='Scotopts.000'/>
		<File Name='Scotopts.001'/>
		<File Name='Scotopts.002'/>
		<File Name='Scotopts.dat'/>
		<File Name='ScotTare.dat'/>
		<File Name='Scottend.000'/>
		<File Name='Scottend.dat'/>
		<File Name='SecurityConfig.000'/>
		<File Name='SecurityConfig.xml'/>
		<File Name='ConfigEntity-AllLanesCommon.xml' Host='g2rap-ian'/>
		<File Name='ConfigEntity-AllStoresCommon.xml'/>
		<File Name='ConfigEntity-DistributionController.xml'/>
		<File Name='ConfigEntity-EntityAssociation.xml'/>
		<File Name='ConfigEntity-ItemSecurityController.xml'/>
		<File Name='ConfigEntity-PersonalizationController.xml'/>
		<File Name='ConfigEntity-SystemCommon.xml'/>
	</Files>
	<Parsers>
		<Parser Name='Psx' Text='PSX_ScotAppU:03/21 09:17:13       502,913 0908> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Attract, EventName:ChangeContext, Param:, Consumed:0, TimeFired:502913)
PSX_ScotAppU:03/21 09:17:13       502,913 0908> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:RAP.ssco-4xsm-15, ControlName:, ContextName:, EventName:ConnectRemote, Param:HandheldRAP=0;operation[text]=sign-on-auto;UserId[text]=1;, Consumed:0, TimeFired:502913)
PSX_ScotAppU:03/21 09:17:36       526,527 0908> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:OutOfService2, EventName:ChangeContext, Param:, Consumed:0, TimeFired:526527)'>
			<Pattern Adder='Sscat.Core.Parsers.PsxEventAdder, Sscat.Core'>
				<![CDATA[:\d{2}/\d{2} \d{2}:\d{2}:\d{2}[ ]{1,7}(?<ms>[0-9,]+).*Handle event\(PSXId:(?<id>\d+), RemoteConnectionName:(?<connection>.*), ControlName:(?<control>.*), ContextName:(?<context>.*), EventName:(?<event>.*), Param:(?<param>.*), Consumed:(?<consumed>.*), TimeFired:(?<fired>.*)\)]]>
			</Pattern>
		</Parser>
		<Parser Name='LaunchPadPsx' Text='PSX_LaunchPadNet:05/23 17:31:06       734,375 0B20> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:StartupContext, EventName:ChangeContext, Param:, Consumed:0, TimeFired:734375)
PSX_LaunchPadNet:05/23 17:33:12       860,437 0B20> EventThreadProc queued events:2 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Echo, ContextName:EnterID, EventName:ChangeFocus, Param:, Consumed:0, TimeFired:860437)
PSX_LaunchPadNet:05/23 17:33:12       860,437 0B20> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:EnterID, EventName:ChangeContext, Param:, Consumed:0, TimeFired:860437)
PSX_LaunchPadNet:05/23 17:34:22       929,781 0B20> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:EnterID, EventName:KeyDown, Param:91, Consumed:0, TimeFired:929781)
PSX_LaunchPadNet:05/23 17:35:51     1,018,687 0B20> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:EnterID, EventName:KeyDown, Param:91, Consumed:0, TimeFired:1018687)
PSX_LaunchPadNet:05/23 17:36:02     1,030,203 0B20> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:EnterID, EventName:Quit, Param:, Consumed:0, TimeFired:1030203)'>
			<Pattern Adder='Sscat.Core.Parsers.LaunchPadPsxEventAdder, Sscat.Core'>
				<![CDATA[:\d{2}/\d{2} \d{2}:\d{2}:\d{2}[ ]{1,7}(?<ms>[0-9,]+).*Handle event\(PSXId:(?<id>\d+), RemoteConnectionName:(?<connection>.*), ControlName:(?<control>.*), ContextName:(?<context>.*), EventName:(?<event>.*), Param:(?<param>.*), Consumed:(?<consumed>.*), TimeFired:(?<fired>.*)\)]]>
			</Pattern>
		</Parser>		
		<Parser Name='Traces' Text='1932) 07/04 15:29:12;0315091568 0B88&gt; SM-SMdmBase@5921 Scale weight = 0
2115) 02/12 13:27:20;0025917577 15F4&gt; SM-SMStateBase@3234 +isBarcodeValidOperatorPassword  &lt;A048500008621~048500008621~101&gt;
2116) 02/12 13:27:20;0025917577 15F4&gt; SM-SMStateBase@3495 -isBarcodeValidOperatorPassword  &lt;0&gt;
2487) 02/12 13:27:23;0025920832 15F4&gt; -CReport@1739 -CReporting::LogItemDetails &lt;ItemSold Time= ""2011-02-12T18:27:23.459"" ID=""1"" Code=""A048500008621"" Description=""Grapefruit Juice"" Department=""123"" ExtPrice=""129"" UnitPrice=""129"" PriceRqd=""0"" QtySold=""1"" DealQty=""0"" QtyRqd=""0"" QtyConfirmed=""0"" QtyLimitExceeded=""0"" WgtRqd=""0"" WgtSold=""0"" Coupon=""0"" TareRqd=""0"" NotFound=""0"" NotForSale=""0"" VisVerify=""0"" Restricted=""0"" RestrictedAge=""0"" Void=""0"" Linked=""0"" CrateAnswer=""2"" SecurityBaggingRqd=""-1"" SecuritySubChkRqd=""-1"" SecurityTag=""0"" ZeroWeight=""0"" PickList=""0""/&gt;
2256) 04/23 13:28:22;0004591301 0558&gt; DM-DMX@191  DMX:PostDmEventToApplication MSR-0 DM_DATA length(157)
5003) 04/23 13:31:16;0004764981 0E98&gt; -RCMgri@250  bstrInParms: type[text]=normal-item;description[text]=[SummaryX]$0.01 inserted
2202) 04/10 13:43:51;0517330582 0EAC&gt; SM-SMdmBase@366  Parse DM evt 103, dev 12, code 19, length 0
2941) 04/10 13:44:12;0517351572 SM-SMtb@4385, 4, TBGetTotalDetails--TotalDetail: lTaxDue:28; lTotal:317; lDiscount:0; szErrDescription:(null); lFoodStampDue:0
26732) 12/11 13:50:58;0067954032 0DB4> SM-SMdmBase@8057 +SMStateBase::DMGetDeviceErrorHTML() DeviceClass=0, Model=Any, SubModel=, Status/Error=114, ExtCode=201, Context=1, LCID=0409
26733) 12/11 13:50:59;0067954673 0DB4> SM-SMdmBase@8084 Device error html: C:\scot\data\deviceerror\0409\ReceiptPrinter_Any_114_201_-1.htm
26734) 12/11 13:50:59;0067954673 0DB4> SM-SMdmBase@8135 -SMStateBase::DMGetDeviceErrorHTML()'>
			<Pattern Adder='Sscat.Core.Parsers.ScaleEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* Scale weight = (?<value>\d+)]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.ScannerDeviceEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* \+isBarcodeValidOperatorPassword  <(?<value>.*)>]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.Scanner3207DeviceEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* \+isBarcodeValidOperatorPassword  <(?<value>.*)]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.ReceiptItemDeviceEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* -CReporting::LogItemDetails <ItemSold.*Description='(?<description>.*)' Department.*ExtPrice='(?<price>[0-9\-]+)'.*]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.ReceiptItemDeviceEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* -CReportingBase::LogItemDetails <ItemSold .* Description='(?<description>.*)' Department.*ExtPrice='(?<price>[0-9\-]+)'.*]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.MsrDeviceEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* DM_DATA length\((?<value>\d+)\)]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.CashEventAdder, Sscat.Core'>
				<![CDATA[Parse DM evt 0, dev 15]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.CoinEventAdder, Sscat.Core'>
				<![CDATA[Parse DM evt 0, dev 16]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.SignatureCaptureEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* Parse DM evt 103, dev 12]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.PinPadDeviceEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* -DMEncryptorgetPIN]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.PinPadCancelDeviceEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* DM Encryptor Cancelled]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.CouponSlipDeviceEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* DM Coupon Sensor detected coupon slip]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.AmountAndTaxDueDeviceEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* lTaxDue:(?<taxdue>\d+)+; lTotal:(?<amount>\d+)]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.ChangeDueAndTenderTypeEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* lTender:(?<tender>.*); lBalance:(?<balance>.*); lChange:(?<change>.*); .* nTenderType:(?<tenderType>.*);]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.ReportsMenuEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* ParseString Input (?<value>.*) \[TT Enter Terminal Type]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.RunReportsEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* ParseString Input (?<value>.*) \[<<<]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.TriColorLightEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* \+setTriColorLight, color = (?<value>\d{0,1}[1-3]) state = [1-4] request = .*]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.CashErrorEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* Parse DM evt 103, dev 15, code (?<value>\d{1,3}), length 0]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.CoinErrorEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* Parse DM evt 103, dev 16, code (?<value>\d{1,3}), length 0]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.ScannerDeviceErrorEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* Parse DM evt 1, dev 11, code (?<value>\d{1,3}), length 0]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.SignatureCaptureErrorEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* ERROR: SignatureCapture\\Emulator\|(?<value>\d{1,3})\|0]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.CMCountPercentageAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .*SM-SMdmBase.* Count Percentage : (?<countPercentage>.*)\. denom : (?<denom>.*)\. count (?<count>.*)\. capacity (?<capacity>.*)\.low level: (?<lowLevel>.*)]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.SayPhraseEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* SM-SMdmBase.* \+DMSayPhrase <(?<value>.*)>]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.SayAmountEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* SM-SMdmBase.* \+DMSayAmount (?<value>.*)]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.SaySecurityEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* SM-SMdmBase.* \+DMSaySecurity <.*> <(?<value>.*)> <.*>]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.TABTransportEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* SM-TransportItem.* \+DMTakeawayReadyForItem]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.TABSmartScaleEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}) .* SM-TransportItem.* Resetting SmartScale]]>
			</Pattern>	
			<Pattern Adder='Sscat.Core.Parsers.PrinterEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>\d{10}).* SM-SMdmBase.* \+SMStateBase::DMGetDeviceErrorHTML\(\)(?<value>.*), Status/Error=(?<value1>.*), ExtCode=(?<value2>.*), Context.*]]>
			</Pattern>			
		</Parser>
		<Parser Name='SM' Text='SM: 08/16 14:21:06   942,985,140 1290> lCurrentTotalWeight=0'>
			<Pattern Adder='Sscat.Core.Parsers.BagScaleEventAdder, Sscat.Core'>
				<![CDATA[SM: .* (?<ms>(\d+,)+\d+) .* (m_wLastWeight:[ ]+(?<value>\d+)|Sending message:  Zero Wt|lCurrentTotalWeight=(?<value>\d+))]]>
			</Pattern>
		</Parser>
		<Parser Name='Xmode' Text='XM: 11/06 22:24:46   180242655 8A0> * COUNTS AFTER CHANGES: ndisp: [1:15,5:3,25:2,100:1;100:6,200:0,500:2,1000:1,2000:0,5000:0,10000:0]; disp: [1:110,5:100,10:100,25:100;100:3000,500:1500,1000:750] *' Condition='Sscat.Core.Parsers.IsLogExists, Sscat.Core'>
			<Pattern Adder='Sscat.Core.Parsers.XmPrintDataEventAdder, Sscat.Core'>
				<![CDATA[XM: .* (?<ms>\d{4,10}).* \+XMCashManagementBase::PrintReceipt]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.XmAlertMessageEventAdder, Sscat.Core'>
				<![CDATA[XM: .* (?<ms>\d{4,10}).* \+XMCashReplenishBase::(?<value>AlertMessage)]]>
			</Pattern>
			<Pattern Adder='Sscat.Core.Parsers.XmCountChangesEventAdder, Sscat.Core'>
				<![CDATA[XM: .* (?<ms>\d{4,10}).* COUNTS AFTER CHANGES: ndisp: \[(?<coinValue>.*)\]; disp: \[(?<billValue>.*)\] *]]>
			</Pattern>
		</Parser>
		<Parser Name='TAB' File='C:\scot\logs\TakeawayBelt.log' Condition='Sscat.Core.Parsers.IsLogExists, Sscat.Core'>
			<Pattern Adder='Sscat.Core.Parsers.TABReverseEventAdder, Sscat.Core'>
				<![CDATA[(?<ms>(\d+,)+\d+)> .* ""UnPurchasedItemPause"" to ""UnPurchasedItemAsk""]]>
			</Pattern>
		</Parser>
	</Parsers>
	<Hooks>
		<Hook Name='Psx' Parser='Psx' Text='PSX_ScotAppU:03/21 09:17:13       502,913 0908> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Attract, EventName:ChangeContext, Param:, Consumed:0, TimeFired:502913)
PSX_ScotAppU:03/21 09:17:13       502,913 0908> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:RAP.ssco-4xsm-15, ControlName:, ContextName:, EventName:ConnectRemote, Param:HandheldRAP=0;operation[text]=sign-on-auto;UserId[text]=1;, Consumed:0, TimeFired:502913)
PSX_ScotAppU:03/21 09:17:36       526,527 0908> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:OutOfService2, EventName:ChangeContext, Param:, Consumed:0, TimeFired:526527)'/>
		<Hook Name='LaunchPadPsx' Parser='Psx' Text='PSX_ScotAppU:03/21 09:17:13       502,913 0908> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Attract, EventName:ChangeContext, Param:, Consumed:0, TimeFired:502913)
PSX_ScotAppU:03/21 09:17:13       502,913 0908> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:RAP.ssco-4xsm-15, ControlName:, ContextName:, EventName:ConnectRemote, Param:HandheldRAP=0;operation[text]=sign-on-auto;UserId[text]=1;, Consumed:0, TimeFired:502913)
PSX_ScotAppU:03/21 09:17:36       526,527 0908> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:OutOfService2, EventName:ChangeContext, Param:, Consumed:0, TimeFired:526527)'/>
		<Hook Name='Traces' Parser='Traces' Text='1932) 07/04 15:29:12;0315091568 0B88&gt; SM-SMdmBase@5921 Scale weight = 0
2115) 02/12 13:27:20;0025917577 15F4&gt; SM-SMStateBase@3234 +isBarcodeValidOperatorPassword  &lt;A048500008621~048500008621~101&gt;
2116) 02/12 13:27:20;0025917577 15F4&gt; SM-SMStateBase@3495 -isBarcodeValidOperatorPassword  &lt;0&gt;
2487) 02/12 13:27:23;0025920832 15F4&gt; -CReport@1739 -CReporting::LogItemDetails &lt;ItemSold Time= ""2011-02-12T18:27:23.459"" ID=""1"" Code=""A048500008621"" Description=""Grapefruit Juice"" Department=""123"" ExtPrice=""129"" UnitPrice=""129"" PriceRqd=""0"" QtySold=""1"" DealQty=""0"" QtyRqd=""0"" QtyConfirmed=""0"" QtyLimitExceeded=""0"" WgtRqd=""0"" WgtSold=""0"" Coupon=""0"" TareRqd=""0"" NotFound=""0"" NotForSale=""0"" VisVerify=""0"" Restricted=""0"" RestrictedAge=""0"" Void=""0"" Linked=""0"" CrateAnswer=""2"" SecurityBaggingRqd=""-1"" SecuritySubChkRqd=""-1"" SecurityTag=""0"" ZeroWeight=""0"" PickList=""0""/&gt;
2256) 04/23 13:28:22;0004591301 0558&gt; DM-DMX@191  DMX:PostDmEventToApplication MSR-0 DM_DATA length(157)
5003) 04/23 13:31:16;0004764981 0E98&gt; -RCMgri@250  bstrInParms: type[text]=normal-item;description[text]=[SummaryX]$0.01 inserted
2202) 04/10 13:43:51;0517330582 0EAC&gt; SM-SMdmBase@366  Parse DM evt 103, dev 12, code 19, length 0
2941) 04/10 13:44:12;0517351572 SM-SMtb@4385, 4, TBGetTotalDetails--TotalDetail: lTaxDue:28; lTotal:317; lDiscount:0; szErrDescription:(null); lFoodStampDue:0'/>
		<Hook Name='SM' Parser='SM' Text='SM: 08/16 14:21:06   942,985,140 1290> lCurrentTotalWeight=0'/>
	    <Hook Name='Xmode' Parser='Xmode' Text='XM: 11/06 22:24:46   180242655 8A0> * COUNTS AFTER CHANGES: ndisp: [1:15,5:3,25:2,100:1;100:6,200:0,500:2,1000:1,2000:0,5000:0,10000:0]; disp: [1:110,5:100,10:100,25:100;100:3000,500:1500,1000:750] *'/>
	    <Hook Name='TAB' Parser='TAB' Text='TAB: 11/04 22:04:04     2,359,122> StateMachine Belt1: Transition from UnPurchasedItemPause to UnPurchasedItemAsk'/>
	</Hooks>
	<Generator
		ScriptOutputDirectory='C:\SSCAT\Scripts'
		SegmentedScripts='true'
		LogsOutputDirectory='C:\SSCAT\Logs'
		RootDirectory='C:\SSCAT'
		ScotConfigOutputDirectory='C:\SSCAT\ScotConfig'
		RapName='g2rap-ian'
		DiagPath=''>
	</Generator>
	<Player
		LogHookTimeout='100'
		OverrideRapname='false'
		RapName='g2rap-ian'
		CaptureScreenShot='true'
		DisplayResultsAfterPlayback='false'
		GetDiagsOnError='false'
		AutoGetDiagsAfterPlayback='false'
		UserInterventionOnErro='false'
		PlayerConfigFile='C:\SSCAT\Config'
		ScotConfigPath='C:\SSCAT\ScotConfig'
		LogFilesPath='C:\SSCAT\Logs'
		ReportFilePath='C:\SSCAT\Reports'
		LoadConfiguration='true'
		PlaybackRepetition='1'
		DiagTempPath='C:\temp'
		SimulateUserTime='true'
		StartContext='Attract'
		LoginId='1'
		Password='QAZ1'>
	</Player>
	<BackCommands>
		<Command Context='ScanAndBag' Control='CMButton3Global' />
		<Command Context='VoidItem' Control='CMButton2' />
		<Command Context='ConfirmAbort' Control='CMButton1Med' />
		<Command Context='VoidTransApproval' Control='ButtonStoreLogIn' />
		<Command Context='EnterID' Action='Sscat.Core.Emulators.Login, Sscat.Core' />
		<Command Context='EnterAlphaNumericPassword' Action='Sscat.Core.Emulators.AlphaNumericPassword, Sscat.Core' />
		<Command Context='SmAbort' Control='SMButton1' />
		<Command Context='SmAborted' Control='SMButton1' />
		<Command Context='KeyInCode' Control='ButtonGoBack' />
		<Command Context='ProductFavorites' Control='ButtonGoBack' />
		<Command Context='SmAuthorization' Control='SMButton8' />
		<Command Context='SmReportsMenu' Control='SMButton8' />
		<Command Context='SmSystemFunctions' Control='SMButton8' />
		<Command Context='SmmEditAdd' Control='SMButton8' />
		<Command Context='ContextHelp' Control='ButtonGoBack' />
		<Command Context='BagAndEAS' Control='CMButton1Med' />
		<Command Context='ContinueTrans' Control='CMButton1Med' />
		<Command Context='WaitForApproval' Control='CMButton1StoreLogIn' />
		<Command Context='ThankYou' Action='Sscat.Core.Emulators.Tear, Sscat.Core' />
	</BackCommands>
</Configuration>"));
		}
	}
}
