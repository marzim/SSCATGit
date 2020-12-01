//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//		<owner name="Apple Leo Chiong" email="ac185120@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.IO;
using Ncr.Core.Emulators;
using Ncr.Core.Models;
using Ncr.Core.Tests.Models;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Config;
using Sscat.Core.Emulators;
using Sscat.Core.Finger;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Core.Repositories;
using Sscat.Core.Services;
using Sscat.Core.Util;
using Sscat.Tests.Commands.Gui;
using Sscat.Tests.Commands.Psx;
using Sscat.Tests.Config;
using Sscat.Tests.Models;
using Sscat.Tests.Repositories;
using Sscat.Tests.Services;
using Sscat.Tests.Util;

namespace Sscat.Tests.Emulators
{
	[TestFixture]
	public class SscatLaneTests
	{
		SscatLane lane;
		List<IScript> scripts;
		IConfigFileRepository configFileRepository;
		IConfigFilesRepository configFilesRepository;
		LaneService service;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			DnsHelper.Attach(new DnsManagerStub());
			ProcessUtility.Attach(new ProcessManagerStub(true, false, "SMAttract"));
			RegistryHelper.Attach(new RegistryManagerStub());
			ApiHelper.Attach(new ApiManagerStub());
			ThreadHelper.Attach(new ThreadManagerStub());
			FileHelper.Attach(new FileManagerStub());
			WindowAppHelper.Attach(new WindowAppManagerStub());
			LoggingService.Attach(new Log4NetLogger());
			
			lane = new SscatLane(100, false, true);
			lane.LaunchPad = new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer());
			lane.SecurityManager = new SscatSecurityManager();
			lane.ApplicationLauncher = new ApplicationLauncherStub();
			
			lane.AddEmulator(new BagScale(), new Scale());
			
			service = new LaneServiceStub(
				lane,
				new ScriptRepositoryStub(),
				new ConfigFileRepositoryStub(),
				new ConfigFilesRepositoryStub(),
				new PlayerConfigurationRepositoryStub(),
				new GeneratorConfigurationRepositoryStub(),
				new LaneConfigurationRepositoryStub(),
				new ReportRepositoryStub(),
				new PsxDisplayRepositoryStub(),
				null,
				null
			);

			lane.Configuration = service.ReadLaneConfiguration("");
			lane.Configuration.Display = service.ReadPsxDisplay("");

			scripts = new List<IScript>();
			scripts.Add(new ScriptRepositoryStub().Read(""));
			
			configFilesRepository = new ConfigFilesRepositoryStub();
			configFilesRepository.LoadConfigOnServer += new EventHandler<ConfigFileEventArgs>(ConfigFilesRepositoryLoadConfigOnServer);
			
			configFileRepository = new ConfigFileRepositoryStub();
			
			lane.ConfigurationGet += new EventHandler<ConfigFilesEventArgs>(LaneConfigurationGet);
			lane.ParserInitialize += new EventHandler(LaneParserInitialize);
			lane.Parse += new EventHandler<ProgressEventArgs>(LaneParse);
			lane.Generating += new EventHandler<ProgressEventArgs>(LaneGenerating);
			
			lane.LogHookInitialize += new EventHandler(LaneLogHookInitialize);
			lane.ConfigFilesRead += new EventHandler<ScriptEventArgs>(LaneConfigFilesRead);
			lane.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
			lane.ConfigurationLoad += new EventHandler<ConfigFilesEventArgs>(LaneConfigurationLoad);
			lane.Playing += new EventHandler<ProgressEventArgs>(LanePlaying);
			lane.ScriptEventChanged += new EventHandler<ScriptEventEventArgs>(LaneScriptEventChanged);
			lane.ScriptChanged += new EventHandler<ScriptEventArgs>(LaneScriptChanged);
			lane.Stopping += new EventHandler(LaneStopping);
//			lane.LoggerStart += new EventHandler(LaneLoggerStart);
//			lane.LoggerStop += new EventHandler(LaneLoggerStop);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			lane.ConfigurationGet -= new EventHandler<ConfigFilesEventArgs>(LaneConfigurationGet);
			lane.ParserInitialize -= new EventHandler(LaneParserInitialize);
			lane.Parse -= new EventHandler<ProgressEventArgs>(LaneParse);
			lane.Generating -= new EventHandler<ProgressEventArgs>(LaneGenerating);
			
			lane.LogHookInitialize -= new EventHandler(LaneLogHookInitialize);
			lane.ConfigFilesRead -= new EventHandler<ScriptEventArgs>(LaneConfigFilesRead);
			lane.ConnectionAdding -= new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
			lane.ConfigurationLoad -= new EventHandler<ConfigFilesEventArgs>(LaneConfigurationLoad);
			lane.Playing -= new EventHandler<ProgressEventArgs>(LanePlaying);
			lane.ScriptEventChanged -= new EventHandler<ScriptEventEventArgs>(LaneScriptEventChanged);
			lane.ScriptChanged -= new EventHandler<ScriptEventArgs>(LaneScriptChanged);
			lane.Stopping -= new EventHandler(LaneStopping);
//			lane.LoggerStart -= new EventHandler(LaneLoggerStart);
//			lane.LoggerStop -= new EventHandler(LaneLoggerStop);
		}
		
		[Test]
		public void TestEmptyConstructor()
		{
			lane = new SscatLane();
			Assert.AreEqual(60000 * 10, lane.Timeout);

            ResetLane();
		}
		
		[Test]
		public void TestGenerate()
		{
			lane.Generate("test", "", "4.5", "3.0", true, @"C:\Projects\finger\trunk\tests", false, 0, Constants.MSCard.NAME_OF_DEFAULT_MS_CARD);
		}
		
		[Test]
		public void TestGenerateWithErrors()
		{
			lane.ValidateForGenerate();
            Assert.That(() => lane.Generate("test", "", "4.5", "3.0", true, @"C:\Projects\finger\trunk\tests", false, 0, Constants.MSCard.NAME_OF_DEFAULT_MS_CARD),
               Throws.TypeOf<Exception>());
		}
		
		[Test]
		public void TestGenerateOnStopped()
		{
			lane.ParserInitialize += delegate { lane.HasStopped = true; };
			lane.Generate("test", "", "4.5", "3.0", true, @"C:\Projects\finger\trunk\tests", false, 0, Constants.MSCard.NAME_OF_DEFAULT_MS_CARD);
		}
		
		[Test]
		public void TestGenerateWithException()
		{
			lane = new SscatLane();
			lane.Configuration = service.ReadLaneConfiguration("");
			lane.Parsers = new List<IParser>(new IParser[] { new P() });
            Assert.That(() => lane.Generate("test", "", "4.5", "3.0", true, @"C:\Projects\finger\trunk\tests", false, 0, Constants.MSCard.NAME_OF_DEFAULT_MS_CARD),
               Throws.TypeOf<NotImplementedException>());

            ResetLane();
		}
		
		[Test]
		public void TestPlayListOfScriptConfigs()
		{
			ScriptConfigs configs = new ScriptConfigs();
			ConfigFiles files = lane.Configuration.Files;
			FingerScript script = new ScriptRepositoryStub().Read("") as FingerScript;
			configs.AddConfig(new ScriptConfig(script, files));
			lane.Play(configs, 100, 15, true, 1);
		}
		
		[Test]
		public void TestPlayListOfScriptsWithRepeat()
		{
			lane.Play(scripts, 100, 1, 15, true);
		}
		
		[Test]
		public void TestPlayListOfScripts()
		{
			lane.Play(scripts, 100, 15, true, 1);
		}
		
		[Test]
		public void TestPlayListOfScriptsOnConsole()
		{
			lane = new SscatLane(100, true, true);
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
//			lane.PsxConnections.Add(new C("localhost", "FastLaneRemoteServer", "AUTOMATION", 100));
			lane.PsxConnections.Add(new PsxStub("localhost", "FastLaneRemoteServer", "AUTOMATION", 100));
			lane.Hooks = lane.Configuration.GetHooks();
			
			lane.Play(scripts, 100, 15, true, 1);
		}
		
		[Test]
		public void TestPlayListOfScriptsOnNotStarted()
		{
			ProcessUtility.Attach(new ProcessManagerStub(false, false, "SMAttract"));
            Assert.That(() => lane.Play(scripts, 100, 15, true, 1),
               Throws.TypeOf<SscoNotFoundException>());

            ResetLane();
		}
		
		[Test]
		public void TestPlayScriptOnStopped()
		{
            lane.Stop();
			lane.Play(scripts[0], 100, 15, true, 1);
		}
		
		[Test]
		public void TestValidateForPlay()
		{
			DnsHelper.Attach(new DA());
			lane.ValidateForPlay();
			Assert.IsFalse(lane.HasErrors);
		}
		
		[Test]
		public void TestStop()
		{
            lane.PsxConnections.Clear();
			lane.PsxConnections.Add(service.CreatePsx("localhost", "FastLaneRemoteServer", "AUTOMATION", 100));
			lane.Hooks = service.CreateHooks();
			lane.Parsers = service.CreateParsers();
			
			lane.Stop();
			Assert.IsTrue(lane.HasStopped);
		}
		
		[Test]
		public void TestGoAllTheWayBack()
		{
			lane.PsxConnections.Clear();
			lane.PsxConnections.Add("AUTOMATION", new X());
			Assert.That(() => lane.GoAllTheWayBack(5000),
                Throws.TypeOf<ArgumentOutOfRangeException>());

            ResetLane();
		}
		
		[Test]
		public void TestGoAllTheWayBackAlphaNumeric()
		{
			lane.PsxConnections.Clear();
			lane.PsxConnections.Add("AUTOMATION", new Y());
			Assert.That(() => lane.GoAllTheWayBack(5000),
                Throws.TypeOf<ArgumentOutOfRangeException>());

            ResetLane();
		}

		[Test]
		public void TestEmulatorsCountValues()
		{
			Assert.AreEqual(2, lane.Emulators.Count);
		}

        [Test]
        public void TestLaunchPadValue()
        {
            Assert.IsNotNull(lane.LaunchPad);

        }

        [Test]
        public void TestConfigurationValue()
        {
            Assert.IsNotNull(lane.Configuration);

        }

        [Test]
        public void TestSecurityManagerValue()
        {
            Assert.IsNotNull(lane.SecurityManager);
        }

        [Test]
        public void TestApplicationLauncherValue()
        {
            Assert.IsNotNull(lane.ApplicationLauncher);
        }
		
		[Test]
		public void TestLoadConfiguration()
		{
			ConfigFiles files = ConfigFiles.Deserialize(new StringReader(@"<Files Source='C:\scot\config' Destination='C:\SSCAT\ScotConfig'>
	            <File Name='scotopts.dat' Host='g2lane-ian'/>
            </Files>"));
			ProcessUtility.Attach(new ProcessManagerStub(false, false, "SMAttract"));
			lane.LoadConfiguration();

            ResetLane();
		}
		
		[Test]
		public void TestSetCurrentCoinAndBillCount()
		{
			IScript s = new ScriptRepositoryStubSscatLane().Read("");
			Assert.IsTrue(lane.IsCashManagementScript(s));
			lane.SetCurrentCoinAndBillCount();
		}
		
		[Test]
		public void TestEventState()
		{
			FingerScript script = FingerScript.Deserialize(@"C:\projects\finger\trunk\scripts\test\test_3.xml");
			ScriptEvent e = script.Events.Events[21];
			
			Assert.AreEqual(Constants.EventState.CLICKING_CREDENTIALS, lane.EventState(e));
			
			e = script.Events.Events[22];
			Assert.AreEqual(Constants.EventState.CLICKING_ENTER, lane.EventState(e));
			
			e = script.Events.Events[35];
			Assert.AreEqual(Constants.EventState.NOT_LOGIN_EVENT, lane.EventState(e));
			
			e = script.Events.Events[20];
			Assert.AreEqual(Constants.EventState.DISPLAYING_LOGIN, lane.EventState(e));
			
			e = script.Events.Events[3];
			Assert.AreEqual(Constants.EventState.DEVICE_EVENT_FORGIVABLE, lane.EventState(e));

			e = script.Events.Events[10];
			Assert.AreEqual(Constants.EventState.SCANNER_OPERATOR, lane.EventState(e));

			e = script.Events.Events[33];
			Assert.AreEqual(Constants.EventState.LAUNCH_PAD_EVENT, lane.EventState(e));

			e = script.Events.Events[6];
			Assert.AreEqual(Constants.EventState.INVALID_LOGIN, lane.EventState(e));			
			
			e = script.Events.Events[5];
			Assert.AreEqual(Constants.EventState.NOT_PSX, lane.EventState(e));
			
			e = script.Events.Events[18];
			Assert.AreEqual(Constants.EventState.DISPLAYING_SCREEN_BEFORE_LOGIN, lane.EventState(e));
			
			e = script.Events.Events[22];
			(e.Item as IPsxEvent).Control = "ButtonGoBack";
			Assert.AreEqual(Constants.EventState.CLICKING_GO_BACK, lane.EventState(e));
			
			e = script.Events.Events[0];
			e.Type = "XmEventCommand";
			Assert.AreEqual(Constants.EventState.NOT_PSX, lane.EventState(e));			
		}
		
		[Test]
		public void TestIsValidOperator()
		{
			FingerScript script = FingerScript.Deserialize(@"C:\projects\finger\trunk\scripts\test\test_3.xml");			
			
			Assert.IsTrue(lane.IsValidOperator(script.Events.Events, 9));
			Assert.IsFalse(lane.IsValidOperator(script.Events.Events, 4));
		}

		[Test]
		public void TestLoginEventCount()
		{
			FingerScript script = FingerScript.Deserialize(@"C:\projects\finger\trunk\scripts\test\test_3.xml");			
			
			Assert.AreEqual(20, lane.LoginEventCount(script.Events.Events, 20));
			Assert.AreEqual(35, lane.LoginEventCount(script.Events.Events, 28));
		}
		
		[Test]
		public void TestIdentifyScriptResult()
		{
			Result evntResult = new Result(ResultType.Warning, "", 1, 1);
			Result scriptResult = new Result(ResultType.Passed, "Result for this script contains warning(s).", 1, 1);
			Result identifyScriptResult = lane.IdentifyScriptResult(evntResult, 1);
			
			Assert.AreEqual(scriptResult.Notes, identifyScriptResult.Notes);
			Assert.AreEqual(scriptResult.Type, identifyScriptResult.Type);
			
			evntResult = new Result(ResultType.Skipped, "", 1, 1);
			scriptResult = new Result(ResultType.Passed, "Some system responses were not found and was intentionally skipped.", 1, 1);
			identifyScriptResult = lane.IdentifyScriptResult(evntResult, 1);
			
			Assert.AreEqual(scriptResult.Notes, identifyScriptResult.Notes);
			Assert.AreEqual(scriptResult.Type, identifyScriptResult.Type);

			bool temp;
			temp = lane.HasStopped;
			lane.HasStopped = true;
			evntResult = new Result(ResultType.Passed, "", 1, 1);
			scriptResult = new Result(ResultType.Stopped, "Result for this script will not consider event-level results.", 1, 1);			
			identifyScriptResult = lane.IdentifyScriptResult(evntResult, 1);
			Assert.AreEqual(scriptResult.Notes, identifyScriptResult.Notes);
			Assert.AreEqual(scriptResult.Type, identifyScriptResult.Type);
			lane.HasStopped = temp;
		}
		
		[Test]
		public void TestValidateScriptName()
		{
			string script = "script.xml";
			lane.ValidateScriptname(ref script, @"C:\projects\finger\trunk\scripts\test\");
		}
		
		[Test]
		public void TestBackUpLogFiles()
		{
			lane.BackupLogFiles("test");
		}
		
		[Test]
		public void TestCaptureScreen()
		{
            ResetLane();
			lane.CaptureScreen("ChangeContext", "Attract");
		}
		
		[Test]	
		public void TestIsControlVisible()
		{
            try
            {
                lane.IsControlVisible("CMButton1Lg", 1000);
            }
            catch (Exception)
            {
                Assert.That(() => lane.IsControlVisible("CMButton1Lg", 1000),
                    Throws.TypeOf<NullReferenceException>());
            }
		}
		
		[Test]	
		public void TestCashChangerDiffers()
		{
			Assert.IsTrue(lane.CashChangerCountDiffers());
		}

		[Test]	
		public void TestClickNum1()
		{
			PsxControl c = lane.Configuration.Display.Controls.GetControl("NumericP1");
			Assert.That(() => lane.ClickNum("1".ToCharArray(), c, 1000),
                Throws.TypeOf<NullReferenceException>());
		}
		
		[Test]	
		public void TestClickNum0()
		{
			PsxControl c = lane.Configuration.Display.Controls.GetControl("NumericP1");
			Assert.That(() => lane.ClickNum("0".ToCharArray(), c, 1000),
                Throws.TypeOf<NullReferenceException>());
		}
		
		[Test]		
		public void TestClickButtonList()
		{
			PsxControl c = lane.Configuration.Display.Controls.GetControl("NumericP1");
			Assert.That(() => lane.ClickNum("0".ToCharArray(), c, 1000),
                Throws.TypeOf<NullReferenceException>());
		}		

		[Test]	
		public void TestClickEnter()
		{
			Assert.That(() => lane.ClickEnter(1000),
                Throws.TypeOf<NullReferenceException>());
		}
				
		[Test]		
		public void TestLogin()
		{
			Assert.That(() => lane.Login("1", "1", 1000),
                Throws.TypeOf<NullReferenceException>());
		}

		[Test]	
		public void TestClickAlphaNumericEnter()
		{
			Assert.That(() => lane.ClickAlphaNumericEnter(1000),
                Throws.TypeOf<NullReferenceException>());
		}

		[Test]
		public void TestClickAlphaNumeric()
		{
			Assert.That(() => lane.AlphaNumericPassword(1000),
                Throws.TypeOf<NullReferenceException>());
		}
		
		[Test]
		public void TestGoToLaneClosed()
		{
			Assert.That(() => lane.GoToLaneClosed(1000),
                Throws.TypeOf<Exception>());
		}
		
		[Test]
		public void TestSafeClick()
		{
            try
            {
                lane.SafeClick("CMButton1Lg", "Attract", 1000);
            }
            catch (Exception)
            {
                Assert.That(() => lane.SafeClick("CMButton1Lg", "Attract", 1000),
                    Throws.TypeOf<Exception>());
            }
		}
		
		[Test]
		public void TestSleep()
		{
			FingerScript script = FingerScript.Deserialize(@"C:\projects\finger\trunk\scripts\test\test_3.xml");			
			//evnt Time = 121573423
			lane.Sleep(script.Events.Events[1], 121573400, 100);
		}
		
        public void ResetLane()
        {
            if(lane != null)
            {

                lane.ConfigurationGet -= new EventHandler<ConfigFilesEventArgs>(LaneConfigurationGet);
                lane.ParserInitialize -= new EventHandler(LaneParserInitialize);
                lane.Parse -= new EventHandler<ProgressEventArgs>(LaneParse);
                lane.Generating -= new EventHandler<ProgressEventArgs>(LaneGenerating);

                lane.LogHookInitialize -= new EventHandler(LaneLogHookInitialize);
                lane.ConfigFilesRead -= new EventHandler<ScriptEventArgs>(LaneConfigFilesRead);
                lane.ConnectionAdding -= new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
                lane.ConfigurationLoad -= new EventHandler<ConfigFilesEventArgs>(LaneConfigurationLoad);
                lane.Playing -= new EventHandler<ProgressEventArgs>(LanePlaying);
                lane.ScriptEventChanged -= new EventHandler<ScriptEventEventArgs>(LaneScriptEventChanged);
                lane.ScriptChanged -= new EventHandler<ScriptEventArgs>(LaneScriptChanged);
                lane.Stopping -= new EventHandler(LaneStopping);
                //			lane.LoggerStart -= new EventHandler(LaneLoggerStart);
                //			lane.LoggerStop -= new EventHandler(LaneLoggerStop);
            }
            DnsHelper.Attach(new DnsManagerStub());
            ProcessUtility.Attach(new ProcessManagerStub(true, false, "SMAttract"));
            RegistryHelper.Attach(new RegistryManagerStub());
            ApiHelper.Attach(new ApiManagerStub());
            ThreadHelper.Attach(new ThreadManagerStub());
            FileHelper.Attach(new FileManagerStub());
            WindowAppHelper.Attach(new WindowAppManagerStub());
            LoggingService.Attach(new Log4NetLogger());

            lane = new SscatLane(100, false, true);
            lane.LaunchPad = new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer());
            lane.SecurityManager = new SscatSecurityManager();
            lane.ApplicationLauncher = new ApplicationLauncherStub();

            lane.AddEmulator(new BagScale(), new Scale());

            service = new LaneServiceStub(
                lane,
                new ScriptRepositoryStub(),
                new ConfigFileRepositoryStub(),
                new ConfigFilesRepositoryStub(),
                new PlayerConfigurationRepositoryStub(),
                new GeneratorConfigurationRepositoryStub(),
                new LaneConfigurationRepositoryStub(),
                new ReportRepositoryStub(),
                new PsxDisplayRepositoryStub(),
                null,
                null
            );

            lane.Configuration = service.ReadLaneConfiguration("");
            lane.Configuration.Display = service.ReadPsxDisplay("");

            scripts = new List<IScript>();
            scripts.Add(new ScriptRepositoryStub().Read(""));

            configFilesRepository = new ConfigFilesRepositoryStub();
            configFilesRepository.LoadConfigOnServer += new EventHandler<ConfigFileEventArgs>(ConfigFilesRepositoryLoadConfigOnServer);

            configFileRepository = new ConfigFileRepositoryStub();

            lane.ConfigurationGet += new EventHandler<ConfigFilesEventArgs>(LaneConfigurationGet);
            lane.ParserInitialize += new EventHandler(LaneParserInitialize);
            lane.Parse += new EventHandler<ProgressEventArgs>(LaneParse);
            lane.Generating += new EventHandler<ProgressEventArgs>(LaneGenerating);

            lane.LogHookInitialize += new EventHandler(LaneLogHookInitialize);
            lane.ConfigFilesRead += new EventHandler<ScriptEventArgs>(LaneConfigFilesRead);
            lane.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
            lane.ConfigurationLoad += new EventHandler<ConfigFilesEventArgs>(LaneConfigurationLoad);
            lane.Playing += new EventHandler<ProgressEventArgs>(LanePlaying);
            lane.ScriptEventChanged += new EventHandler<ScriptEventEventArgs>(LaneScriptEventChanged);
            lane.ScriptChanged += new EventHandler<ScriptEventArgs>(LaneScriptChanged);
            lane.Stopping += new EventHandler(LaneStopping);
            //			lane.LoggerStart += new EventHandler(LaneLoggerStart);
            //			lane.LoggerStop += new EventHandler(LaneLoggerStop);
        }

		void LaneLoggerStop(object sender, EventArgs e)
		{
		}

		void LaneLoggerStart(object sender, EventArgs e)
		{
		}

		void LaneStopping(object sender, EventArgs e)
		{
		}

		void LaneConfigurationGet(object sender, ConfigFilesEventArgs e)
		{
			configFilesRepository.Get(e.Files, e.ConfigName);
		}

		void LaneConfigFilesRead(object sender, ScriptEventArgs e)
		{
		}

		void LaneScriptChanged(object sender, ScriptEventArgs e)
		{
		}

		void LaneScriptEventChanged(object sender, ScriptEventEventArgs e)
		{
		}

		void LanePlaying(object sender, ProgressEventArgs e)
		{
		}

		void LaneGenerating(object sender, ProgressEventArgs e)
		{
		}

		void LaneLogHookInitialize(object sender, EventArgs e)
		{
			lane.Hooks = service.CreateHooks();
		}

		void LaneParse(object sender, ProgressEventArgs e)
		{
		}

		void ConfigFilesRepositoryLoadConfigOnServer(object sender, ConfigFileEventArgs e)
		{
		}

		void LaneConfigurationLoad(object sender, ConfigFilesEventArgs e)
		{
			configFilesRepository.Load(e.Files);
		}

		void LaneConnectionAdding(object sender, PsxWrapperEventArgs e)
		{
			lane.PsxConnections.Add(service.CreatePsx(e.HostName, e.ServiceName, e.ConnectionName, e.Timeout));
		}

		void LaneParserInitialize(object sender, EventArgs e)
		{
			lane.Parsers = service.CreateParsers();
		}
		
		class P : AbstractParser
		{
			public override List<IScriptEvent> PerformParse()
			{
				return PerformParse(null);
			}
			
			public override List<IScriptEvent> PerformParse(IExtendedTextReader reader)
			{
				throw new NotImplementedException();
			}
		}
		
		class X : PsxStub
		{
			int i = 0;
			IList<string> contexts;
			
			public X()
			{
				contexts = new List<string>();
				contexts.Add("ScanAndBag");
				contexts.Add("EnterID");
				contexts.Add("ThankYou");
				contexts.Add("Attract");
			}
			
			public override string GetContext(uint displayTarget)
			{
				string context = contexts[i++];
				return context;
			}
		}
		
		class Y : PsxStub
		{
			int i = 0;
			IList<string> contexts;
			
			public Y()
			{
				contexts = new List<string>();
				contexts.Add("ScanAndBag");
				contexts.Add("EnterAlphaNumericPassword");
				contexts.Add("ThankYou");
				contexts.Add("Attract");
			}
			
			public override string GetContext(uint displayTarget)
			{
				string context = contexts[i++];
				return context;
			}
		}
		
		class DA : DnsManagerStub
		{
			public override bool ValidHostName(string host)
			{
				return true;
			}
		}
		
		class ScriptRepositoryStubSscatLane : ScriptRepositoryStub
		{
			public override IScript Read(string file)
			{
				return FingerScript.Deserialize(new StringReader(@"<FingerScript>
	  <fingerBuild>2.2.0</fingerBuild>
	  <scriptName>test</scriptName>
	  <scriptDescription>test</scriptDescription>
	  <flBuild>4.04.00.0.000.391</flBuild>
	  <dateTime>8/16/2011 2:21:34 PM</dateTime>
	  <FileName>C:\test\test.xml</FileName>
	  <FingerEventData>
	    <enable>true</enable>
	    <eventTimeMS>942962708</eventTimeMS>
	    <eventType>PsxEventData</eventType>
	    <PsxEventData>
	      <contextName>Attract</contextName>
	      <controlName>Display</controlName>
	      <eventName>ChangeContext</eventName>
	      <param />
	      <psxId>1</psxId>
	      <remoteConnectionName />
	      <seqId>1</seqId>
	    </PsxEventData>
	  </FingerEventData>
	  <FingerEventData>
	    <enable>true</enable>
	    <eventTimeMS>942962808</eventTimeMS>
	    <eventType>PsxEventData</eventType>
	    <PsxEventData>
	      <contextName />
	      <controlName />
	      <eventName>ConnectRemote</eventName>
	      <param>HandheldRAP=0;operation[text]=sign-on-auto;UserId[text]=1;</param>
	      <psxId>1</psxId>
	      <remoteConnectionName>RAP.ssco-4xsm-15</remoteConnectionName>
	      <seqId>2</seqId>
	    </PsxEventData>
	  </FingerEventData>
	  <FingerEventData>
	    <enable>true</enable>
	    <eventTimeMS>942962949</eventTimeMS>
	    <eventType>DeviceEventData</eventType>
	    <DeviceEventData>
	      <deviceId>Scale</deviceId>
	      <deviceValue>0</deviceValue>
	      <seqId>2</seqId>
	    </DeviceEventData>
	  </FingerEventData>
	  <FingerEventData ScriptIndex='0' Index='0' ScreenshotLink=''>
    	<enable>true</enable>
    	<eventTimeMS>100161134</eventTimeMS>
    	<eventType>DeviceEventData</eventType>
    	<DeviceEventData>
      		<IsForgivable>false</IsForgivable>
      		<deviceId>CMCashCount</deviceId>
      		<deviceValue>-1:39,-5:10,-10:28,-25:24;100:8,500:0,1000:0</deviceValue>
      		<seqId>36</seqId>
   		</DeviceEventData>
    	<Result Type='None' NumberOfWarnings='0' RepetitionIndex='0' ExpectedResult='' ActualResult='' ScreenshotPath='' DiagnosticPath='' ScreenshotLink='' />
  	  </FingerEventData>
	  <FingerEventData ScriptIndex='0' Index='0' ScreenshotLink=''>
    	<enable>true</enable>
    	<eventTimeMS>100162255</eventTimeMS>
    	<eventType>PsxEventData</eventType>
    	<PsxEventData>
      		<IsForgivable>false</IsForgivable>
      		<psxId>1</psxId>
      		<contextName>XMCashStatus</contextName>
      		<controlName>Display</controlName>
      		<eventName>ChangeContext</eventName>
      		<param />
      		<remoteConnectionName />
      	<seqId>3</seqId>
    	</PsxEventData>
   		<Result Type='None' NumberOfWarnings='0' RepetitionIndex='0' ExpectedResult='' ActualResult='' ScreenshotPath='' DiagnosticPath='' ScreenshotLink='' />
  	</FingerEventData>
	</FingerScript>"));
			}
		}
	}
	
	public class SscatLaneStub : SscatLane
	{
		bool hasStarted;
		
		public SscatLaneStub() : this(true)
		{
		}
		
		public SscatLaneStub(bool hasStarted) : base()
		{
			this.hasStarted = hasStarted;
			PsxConnections = new PsxCollection();
		}
		
		public override bool HasStarted {
			get { return hasStarted; }
		}
//
//		public override bool ContextEquals(string context, int t)
//		{	return true;
//		}
	}
}
