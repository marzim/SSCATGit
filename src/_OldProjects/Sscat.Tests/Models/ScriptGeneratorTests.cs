//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Config;
using Sscat.Core.Finger;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Core.Services;
using Sscat.Tests.Config;
using Sscat.Tests.Util;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class GeneratorTests
	{
		Generator generator;
		ParserFactory factory;
		
		[SetUp]
		public void Setup()
		{
			DnsHelper.Attach(new DnsManagerStub());
			
			generator = new Generator();
			generator.Configuration = new GeneratorConfigurationRepositoryStub().Read("");
//			generator.Configuration = GeneratorConfiguration.Deserialize(new StringReader(@"<Configuration
//	ScriptOutputDirectory='C:\SSCAT\Scripts'
//	SegmentedScripts='true'
//	LogsOutputDirectory='C:\SSCAT\logs'
//	RootDirectory='C:\SSCAT'>
//	<Files
//		Name='ConfigFiles'
//		Destination='C:\SSCAT\ScotConfig'
//		Source='C:\scot\config'>
//		<File Name='AssistMenuConfig.xml' Host='somehost'/>
//		<File Name='RCMConfig.000'/>
//		<File Name='RCMConfig.xml'/>
//		<File Name='Scotopts.000'/>
//		<File Name='Scotopts.001'/>
//		<File Name='Scotopts.002'/>
//		<File Name='Scotopts.dat'/>
//		<File Name='ScotTare.dat'/>
//		<File Name='Scottend.000'/>
//		<File Name='Scottend.dat'/>
//		<File Name='SecurityConfig.000'/>
//		<File Name='SecurityConfig.xml'/>
//		<File Name='ConfigEntity-AllLanesCommon.xml'/>
//		<File Name='ConfigEntity-AllStoresCommon.xml'/>
//		<File Name='ConfigEntity-DistributionController.xml'/>
//		<File Name='ConfigEntity-EntityAssociation.xml'/>
//		<File Name='ConfigEntity-ItemSecurityController.xml'/>
//		<File Name='ConfigEntity-PersonalizationController.xml'/>
//		<File Name='ConfigEntity-SystemCommon.xml'/>
//	</Files>
//</Configuration>"));
			
			factory = new ParserFactory();
			
			List<IParser> parsers = new List<IParser>();
			parsers.Add(factory.CreatePsxParser(new ExtendedStringReader(@"PSX_ScotAppU:08/16 14:20:43   942,962,708 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Attract, EventName:ChangeContext, Param:, Consumed:0, TimeFired:942962708)
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
PSX_ScotAppU:08/16 14:21:12   942,991,059 17C8> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Attract, EventName:ChangeContext, Param:, Consumed:0, TimeFired:942991059)")));
			parsers.Add(factory.CreateTraceParser(new ExtendedStringReader(@"1917) 08/16 14:20:44;0942962949 1568> SM-SMdmBase@5921 Scale weight = 0
2405) 08/16 14:21:02;0942981195 SM-SMtb@4277, 4, TBGetTotalDetails--TotalDetail: lTaxDue:28; lTotal:317; lDiscount:0; szErrDescription:(null); lFoodStampDue:0
2440) 08/16 14:21:02;0942981465 1568> -CReport@1739 -CReporting::LogItemDetails <ItemSold Time= ""2011-08-16T06:21:02.740"" ID=""1"" Code=""1111"" Description=""White Bread"" Department=""0"" ExtPrice=""289"" UnitPrice=""289"" PriceRqd=""0"" QtySold=""1"" DealQty=""0"" QtyRqd=""0"" QtyConfirmed=""0"" QtyLimitExceeded=""0"" WgtRqd=""0"" WgtSold=""0"" Coupon=""0"" TareRqd=""0"" NotFound=""0"" NotForSale=""0"" VisVerify=""0"" Restricted=""0"" RestrictedAge=""0"" Void=""0"" Linked=""0"" CrateAnswer=""2"" SecurityBaggingRqd=""-1"" SecuritySubChkRqd=""-1"" SecurityTag=""0"" ZeroWeight=""0"" PickList=""0""/>
3243) 08/16 14:21:07;0942985972 SM-SMtb@4277, 4, TBGetTotalDetails--TotalDetail: lTaxDue:28; lTotal:317; lDiscount:0; szErrDescription:(null); lFoodStampDue:289
3826) 08/16 14:21:11;0942990518 SM-SMtb@4277, 4, TBGetTotalDetails--TotalDetail: lTaxDue:28; lTotal:317; lDiscount:0; szErrDescription:(null); lFoodStampDue:289")));
			parsers.Add(factory.CreateSMParser(new ExtendedStringReader(@"SM: 08/16 14:21:06   942,985,140 1290> lCurrentTotalWeight=0
SM: 08/16 14:21:11   942,990,458 1310> Sending message:  Zero Wt")));
			
			generator.Parsers = parsers;
			
			generator.ConfigManage += delegate { };
			generator.ConfigFileCopy += delegate { };
			generator.ConfigFileCopyOnServer += delegate { };
			generator.Generating += delegate(object sender, ProgressEventArgs e) { 
				Console.WriteLine(e.Message);
			};
			generator.Parse += delegate(object sender, ProgressEventArgs e) { 
				Console.Write(e.Message);
			};
			generator.Parsing += delegate(object sender, ProgressEventArgs e) { 
				Console.Write(".");
			};
			generator.Parsed += delegate(object sender, ProgressEventArgs e) { 
				Console.WriteLine("Done");
			};
		}
		
		[Test]
		[ExpectedException(typeof(Exception))]
		public void TestWithErrors()
		{
			generator.Configuration = null;
			generator.Validate();
			generator.Generate("test", "test description", "4.5", "3.0", true, @"C:\SSCAT\Scripts");
		}
		
		[Test]
		public void TestGenerate()
		{
			IScript[] scripts = generator.Generate("test", "test description", "4.5", "2.2", true, @"C:\SSCAT\scripts");
			Assert.AreEqual(2, scripts.Length);
			FingerScript script = scripts[0] as FingerScript;
			Assert.AreEqual("test", script.Name);
			Assert.AreEqual("test description", script.Description);
			Assert.AreEqual(@"C:\SSCAT\scripts\test_0.xml", script.FileName);
			Assert.AreEqual(26, script.ScriptEvents.Length);
		}
	}
}
