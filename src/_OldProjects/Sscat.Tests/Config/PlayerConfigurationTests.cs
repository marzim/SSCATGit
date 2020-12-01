//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Models;
using Sscat.Core.Repositories;

namespace Sscat.Tests.Config
{
	[TestFixture]
	public class PlayerConfigurationTests
	{
		PlayerConfiguration config;
		IPlayerConfigurationRepository repository;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			repository = new PlayerConfigurationRepositoryStub();
			config = repository.Read("");
		}
		
		[Test]
        public void TestReadValue()
        {
            config = repository.Read("");
		}

        [Test]
        public void TestPlaybackRepetitionValue()
        {
            Assert.AreEqual(1, config.PlaybackRepetition);
        }

        [Test]
        public void TestLogHookTimeoutValue()
        {
            Assert.AreEqual(60000, config.LogHookTimeout);
        }

        [Test]
        public void TestSecurityServerValue()
        {
            Assert.AreEqual("g2lane-ian", config.SecurityServer);
        }

        [Test]
        public void TestSaveReportInServerValue()
        {
            Assert.IsFalse(config.SaveReportInServer);
        }

        [Test]
        public void TestSimulateUserTimeValue()
        {
            Assert.IsTrue(config.SimulateUserTime);
        }

        [Test]
        public void TestLoadConfigurationValue()
        {
            Assert.IsTrue(config.LoadConfiguration);
        }

        [Test]
        public void TestReportFilePathValue()
        {
            Assert.IsEmpty(config.ReportFilePath);
        }

        [Test]
        public void TestScreenshotPathValue()
        {
            Assert.IsEmpty(config.ScreenshotPath);
        }

        [Test]
        public void TestDiagnosticPathValue()
        {
            Assert.IsEmpty(config.DiagnosticPath);
        }

        [Test]
        public void TestLogFilesPathValue()
        {
            Assert.IsEmpty(config.LogFilesPath);
        }

        [Test]
        public void TestScotConfigPathValue()
        {
            Assert.IsEmpty(config.ScotConfigPath);
        }

        [Test]
        public void TestFilesLengthValue()
        {
            Assert.AreEqual(19, config.ConfigFiles.Files.Length);
        }

        [Test]
        public void TestUserInterventionOnErrorValue()
        {
            Assert.IsFalse(config.UserInterventionOnError);
        }

        [Test]
        public void TestGetDiagsOnErrorValue()
        {
            Assert.IsTrue(config.GetDiagsOnError);
        }

        [Test]
        public void TestAutoGetDiagsAfterPlaybackValue()
        {
            Assert.IsFalse(config.AutoGetDiagsAfterPlayback);
        }

        [Test]
        public void TestDisplayResultsAfterPlaybackValue()
        {
            Assert.IsTrue(config.DisplayResultsAfterPlayback);
        }

        [Test]
        public void TestCaptureScreenShotValue()
        {
            Assert.IsTrue(config.CaptureScreenShot);
        }

        [Test]
        public void TestStopOnErrorValue()
        {
            Assert.IsFalse(config.StopOnError);
        }

        [Test]
        public void TestLockedScreenshotValue()
        {
            Assert.IsFalse(config.LockedScreenshot);
        }

        [Test]
        public void TestUseSmartExitValue()
        {
            Assert.IsFalse(config.UseSmartExit);
        }

        [Test]
        public void TestOverrideLoginValue()
        {
            Assert.IsFalse(config.OverrideLogin);
        }

        [Test]
        public void TestEnableLogHookValue()
        {
            Assert.IsTrue(config.EnableLogHook);
        }

        [Test]
        public void TestOverrideSecurityServerValue()
        {
            Assert.IsFalse(config.OverrideSecurityServer);
        }

        [Test]
        public void TestWarningTimeoutValue()
        {
            config.WarningTimeout = 15000;
            Assert.AreEqual(15000, config.WarningTimeout);
        }

        [Test]
        public void TestRapNameValue()
        {
            Assert.AreEqual("g2rap-ian", config.RapName);
        }

        [Test]
        public void TestOverrideRapNameValue()
        {
            Assert.IsTrue(config.OverrideRapName);
        }

        [Test]
        public void TestCardNameValue()
        {
            Assert.AreEqual("WalmartMCXShoppingCard", config.WalmartCards.Cards[1].Name);
        }

        [Test]
        public void TestCardTrack1Value()
        {
            Assert.AreEqual("B6010566912936155^WALMARTSHOPCARD^25010004000060013419", config.WalmartCards.Cards[1].Track1);
        }

        [Test]
        public void TestCardLengthValue()
        {
            Assert.AreEqual(4, config.WalmartCards.Cards.Length);
        }

		public void TestSetValues()
		{
			config.LogHookTimeout = 70000;
			config.WarningTimeout = 10000;
			config.OverrideSecurityServer = false;
			config.SecurityServer = "";
			config.OverrideRapName = false;
			config.RapName = "";
			config.CaptureScreenShot = true;
			config.GetDiagsOnError = false;
			config.LoadConfiguration = false;
			config.SimulateUserTime = true;
			config.LockedScreenshot = true;
			config.StopOnError = true;
			config.UseSmartExit = false;
			config.OverrideLogin = false;
			config.EnableLogHook = true;
			config.SaveReportInServer = true;
			config.UserInterventionOnError = true;
			config.StartContext = "Attract";
			config.LoginId = "1";
			config.Password = "1";
			config.OperatorBarcode = "F4120001345736~4120001345736~104~1";
			config.DiagTempPath = @"C:\Temp\";
			config.PlaybackRepetition = 1;
			config.ScotConfigPath = @"C:\SSCAT\ScotConfig";
			config.LogFilesPath = @"C:\SSCAT\Logs";
			config.ReportFilePath = @"C:\SSCAT\Reports";
			config.ScreenshotPath = @"C:\SSCAT\Screenshots";
			config.DiagnosticPath = @"C:\SSCAT\Diags";
			config.DisplayResultsAfterPlayback = false;
            config.AutoGetDiagsAfterPlayback = false;
		}
		
		[Test]
		public void TestGetValue()
		{
			TestSetValues();
			config.LogHookTimeout = 70000;	
			config.WarningTimeout = 10000;
			
			Assert.AreEqual(70000, config.LogHookTimeout);
			Assert.AreEqual(10000, config.WarningTimeout);
			Assert.AreEqual(1, config.PlaybackRepetition);
			Assert.IsFalse(config.OverrideSecurityServer);
			Assert.IsFalse(config.OverrideRapName);
			Assert.IsTrue(config.CaptureScreenShot);
			Assert.IsFalse(config.GetDiagsOnError);
			Assert.IsFalse(config.LoadConfiguration);
			Assert.IsTrue(config.SimulateUserTime);
			Assert.IsTrue(config.StopOnError);
			Assert.IsTrue(config.LockedScreenshot);
			Assert.IsFalse(config.UseSmartExit);
			Assert.IsFalse(config.OverrideLogin);
			Assert.IsFalse(config.DisplayResultsAfterPlayback);
			Assert.IsFalse(config.AutoGetDiagsAfterPlayback);
			Assert.AreEqual("", config.SecurityServer);
			Assert.AreEqual("", config.RapName);
			Assert.AreEqual("Attract", config.StartContext);
			Assert.AreEqual("1", config.LoginId);
			Assert.AreEqual("1", config.Password);
			Assert.AreEqual("F4120001345736~4120001345736~104~1", config.OperatorBarcode);
			Assert.AreEqual(@"C:\Temp\", config.DiagTempPath);
			Assert.AreEqual(@"C:\SSCAT\ScotConfig", config.ScotConfigPath);
			Assert.AreEqual(@"C:\SSCAT\Logs", config.LogFilesPath);
			Assert.AreEqual(@"C:\SSCAT\Reports", config.ReportFilePath);
			Assert.AreEqual(@"C:\SSCAT\Screenshots", config.ScreenshotPath);
			Assert.AreEqual(@"C:\SSCAT\Diags", config.DiagnosticPath);
            
            reset();
		}
		
		[Test]
		public void TestValidate()
		{
			TestSetValues();
            config.Validate();

            reset();
		}
		
		[Test]
		public void TestValidateWithOverrideRapNameAndServerName()
		{
			TestSetValues();
			config.OverrideSecurityServer = true;
			config.OverrideRapName = true;
            config.Validate();

            reset();
		}
		
		[Test]
		public void TestValidateWithOverrideRapName()
		{
			TestSetValues();
			config.OverrideSecurityServer = false;
			config.OverrideRapName = true;
            config.Validate();

            reset();
		}

		[Test]
		public void TestValidateWithOverrideServerName()
		{
			TestSetValues();
			config.OverrideSecurityServer = true;
			config.OverrideRapName = false;
            config.Validate();

            reset();
		}

		[Test]
		public void TestSetProperScripts()
		{
			TestSetValues();
			config.SetProperScripts();

            reset();
		}
		
		[Test]
		public void TestPlayerConfigurationEventArgs()
		{
			PlayerConfigurationEventArgs e = new PlayerConfigurationEventArgs(config, new ScriptFile(""));
			
			Assert.AreEqual(config, e.Config);
		}

        private void reset()
        {
            repository = new PlayerConfigurationRepositoryStub();
            config = repository.Read("");
        }
	}
}
