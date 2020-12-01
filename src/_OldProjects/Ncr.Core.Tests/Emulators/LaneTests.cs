//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Models;
using Ncr.Core.Tests.Models;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Emulators
{
	[TestFixture]
	public class LaneTests
	{
		Lane lane;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
            ApiHelper.Attach(new ApiManagerStub());
            RegistryHelper.Attach(new RegistryManagerStub());
			ProcessUtility.Attach(new ProcessManagerStub(true, false, "SMAttract"));
			FileHelper.Attach(new FileManagerStub());
			ThreadHelper.Attach(new ThreadManagerStub());
			ApplicationUtility.Attach(new ApplicationManagerStub());
			
			lane = new Lane(1000, true);
			lane.SecurityManager = new SecurityManager();
			lane.AddEmulator(new BagScale());
			
			lane.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			lane.ConnectionAdding -= new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
		}
		
		[Test]
		public void TestEmptyConstructor()
		{
			lane = new Lane();
			Assert.AreEqual(60000 * 10, lane.Timeout);

            lane = new Lane(1000, true);
            lane.SecurityManager = new SecurityManager();
            lane.AddEmulator(new BagScale());

            lane.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
		}
		
		[Test]
		public void TestProcessNameWithNotFoundRegistry()
		{
			RegistryHelper.Attach(new R());
            Assert.That(() => Assert.AreEqual("", lane.ProcessName),
               Throws.TypeOf<LaneException>());

            RegistryHelper.Attach(new RegistryManagerStub());
		}
		
		[Test]
		public void TestExistsValue()
		{
			Assert.AreEqual(lane.Exists, FileHelper.Exists(lane.FileName));
		}

        [Test]
        public void TestIsReadyValue()
        {
            lane = new Lane(1000, true);
            lane.SecurityManager = new SecurityManager();
            lane.AddEmulator(new BagScale());

            lane.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
            Assert.IsTrue(lane.IsReady);
        }

        [Test]
        public void TestLogsDirectoryValue()
        {
            Assert.AreEqual(@"C:\scot\logs", lane.LogsDirectory);
        }

        [Test]
        public void TestPsxConnectionsCountValue()
        {
            if (lane.IsReady)
            {
                Assert.AreEqual(1, lane.PsxConnections.Count);
            }
        }

        [Test]
        public void TestProductVersionValue()
        {
            Assert.AreEqual("4.5", lane.ProductVersion);
        }

        [Test]
        public void TestCurrentContextValue()
        {
            if (lane.IsReady)
            {
                Assert.AreEqual("Attract", lane.CurrentContext);
            }
        }

        [Test]
        public void TestEmulatorValue()
        {
            Assert.AreEqual(1, lane.Emulators.Count);
        }

        [Test]
        public void TestLogFilesCountValue()
        {
            Assert.AreEqual(18, lane.LogFiles.Count);
        }

        [Test]
        public void TestSecurityManagerValue()
        {
            Assert.IsNotNull(lane.SecurityManager);
        }
		
		[Test]
		public void TestGetStateNotReady()
		{
			lane.PsxConnections.Add(new GF("localhost", "FastLaneRemoteServer", "AUTOMATION", 5000));
			Assert.IsFalse(lane.IsReady);
			
			lane.CheckForStoreLogin = false;
			Assert.IsTrue(lane.IsReady);
		}
		
		[Test]
		public void TestGetStateOnStopped()
		{
            lane = new Lane(1000, true);

            lane.PsxConnections.Clear();
			lane.PsxConnections.Add(new GF("localhost", "FastLaneRemoteServer", "AUTOMATION", 5000));
			lane.Stop();
			Assert.IsFalse(lane.IsReady);
		}
		
		[Test]
		public void TestCaptureImageWindow()
		{
			Assert.IsNull(lane.CaptureImageWindow());
		}
		
		[Test]
		public void TestCaptureScreen()
		{
			Assert.IsNull(lane.CaptureScreen());
		}
		
		[Test]
		public void TestCaptureImageWindowOnException()
		{
			ApiHelper.Attach(new ApiManagerStub(666, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.That(() => lane.CaptureImageWindow(),
               Throws.TypeOf<LaneException>());

            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestCaptureScreenOnException()
		{
			ApiHelper.Attach(new ApiManagerStub(666, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.That(() => lane.CaptureScreen(),
               Throws.TypeOf<LaneException>());

            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestFire()
		{
			lane.Fire(100);
		}
		
		[Test]
		public void TestClickButton()
		{
			lane.ClickAt(100, 100);
		}
		
		[Test]
		public void TestDeleteLogs()
		{
			lane.DeleteLogs();
		}
		
		[Test]
		public void TestNullCurrentPsx()
		{
			lane.PsxConnections.Clear();
			Assert.IsNull(lane.CurrentPsx);
			Assert.IsEmpty(lane.CurrentContext);

            lane = new Lane(1000, true);
            lane.SecurityManager = new SecurityManager();
            lane.AddEmulator(new BagScale());

            lane.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
		}
		
		[Test]
		public void TestKill()
		{
			lane.Kill();
		}
		
		[Test]
		public void TestStop()
		{
			lane.Stop();
		}
		
		[Test]
		public void TestForceKill()
		{
			lane.ForceKill();
		}
		
		[Test]
		public void TestStart()
		{
			lane.Start();
		}
		
		[Test]
		public void TestStartOnNotStarted()
		{
			ProcessUtility.Attach(new ProcessManagerStub(false, false, "SMAttract"));
			lane.Start();
		}
		
		[Test]
		public void TestStartOnFailedStateWithException()
		{
            lane.PsxConnections.Clear();
			lane.PsxConnections.Add(new GF("localhost", "FastLaneRemoteServer", "AUTOMATION", 5000));
//			ProcessUtility.Attach(new ProcessManagerStub(true, false, "Holy Crap!"));
            Assert.That(() => lane.Start(true),
               Throws.TypeOf<LaneException>());


            lane = new Lane(1000, true);
            lane.SecurityManager = new SecurityManager();
            lane.AddEmulator(new BagScale());

            lane.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
		}
		
		[Test]
		public void TestProductVersionOnNotExistingRegistry()
		{
			RegistryHelper.Attach(new RegistryManagerStub(false, null));
			Assert.AreEqual("NoProductVersionFound", lane.ProductVersion);


            RegistryHelper.Attach(new RegistryManagerStub());
		}
		
		[Test]
		public void TestRevertLane()
		{
			lane.RevertLane();
		}
		
		[Test]
		public void TestRevertLaneSettings()
		{
			lane.RevertLaneSettings();
		}
		
		[Test]
		public void TestGetPsxLogFile()
		{
			Assert.IsNotEmpty(lane.GetPsxLogFile());
		}
		
		[Test]
		public void TestProcessNameUnicodeAtSecondaryRegLocation()
		{
			RegistryHelper.Attach(new RS());
			Assert.AreEqual("SCOTAppU", lane.ProcessName);


            RegistryHelper.Attach(new RegistryManagerStub());
		}
		
		[Test]
		public void TestProcessNameUnicodeAtPrimaryRegLocation()
		{
			RegistryHelper.Attach(new RT());
			Assert.AreEqual("SCOTAppU", lane.ProcessName);

            RegistryHelper.Attach(new RegistryManagerStub());
		}
		
		[Test]
		public void TestProcessNameStringEmpty()
		{
			RegistryHelper.Attach(new RU());
            Assert.That(() => Assert.AreEqual("SSCAT is unable to determined the application type of your system.", lane.ProcessName),
               Throws.TypeOf<LaneException>());

            RegistryHelper.Attach(new RegistryManagerStub());
		}
		
		[Test]
		public void TestProcessNameAnsiAtSecondaryRegLocation()
		{
			RegistryHelper.Attach(new RV());
			Assert.AreEqual("SCOTApp", lane.ProcessName);

            RegistryHelper.Attach(new RegistryManagerStub());
		}
		
		[Test]
		public void TestProcessNameAnsiAtPrimaryRegLocation()
		{
			RegistryHelper.Attach(new RW());
			Assert.AreEqual("SCOTApp", lane.ProcessName);

            RegistryHelper.Attach(new RegistryManagerStub());
		}
		
		[Test]
		public void TestProcessNameNull()
		{
			RegistryHelper.Attach(new RX());
            Assert.That(() => Assert.AreEqual("SSCAT is unable to determined the application type of your system.", lane.ProcessName),
               Throws.TypeOf<LaneException>());

            RegistryHelper.Attach(new RegistryManagerStub());
		}
		
		[Test]
		public void TestTerminalNumber()
		{
			Assert.AreEqual("001", lane.TerminalNumber);
		}
		
		[Test]
		public void TestCashValueList()
		{
			Assert.AreEqual("-1,-5,-10,-25,100,500,1000,2000", lane.CashValueList);
		}
		
		[Test]
		public void TestCurrencyCode()
		{
			Assert.AreEqual("USD", lane.CurrencyCode);
			
			RegistryHelper.Attach(new R());
			Assert.AreEqual("NoCurrencyCode", lane.CurrencyCode);

            RegistryHelper.Attach(new RegistryManagerStub());
		}
		
		[Test]
		public void TestSetEmulatorCount()
		{
			string coinCount = "1:500,5:500,10:500,25:500";
			string billCount = "100:8,500:10,1000:20";
			
			lane.SetEmulatorCount("Coin", coinCount);
			lane.SetEmulatorCount("Bill", billCount);
			
			RegistryHelper.Attach(new RCBC());
			lane.SetEmulatorCount("Coin", coinCount);
            lane.SetEmulatorCount("Bill", billCount);

            RegistryHelper.Attach(new RegistryManagerStub());
		}
		
		[Test]
		public void TestCurrentCointCountLaneStarted()
		{
			Assert.IsNotNull(lane.CurrentCoinCount);
			
			RegistryHelper.Attach(new RCBC());
			Assert.IsNotNull(lane.CurrentCoinCount);


            RegistryHelper.Attach(new RegistryManagerStub());
		}
		
		[Test]
		public void TestCurrentCointCountLaneHasNotStarted()
		{
			ProcessUtility.Attach(new ProcessManagerStub(false, false, "SMAttract"));
			Assert.IsNotNull(lane.CurrentCoinCount);
			
			RegistryHelper.Attach(new RCBC());
			Assert.IsNotNull(lane.CurrentCoinCount);


            ProcessUtility.Attach(new ProcessManagerStub(true, false, "SMAttract"));
            RegistryHelper.Attach(new RegistryManagerStub());
		}
		
		[Test]
		public void TestCurrentBillCount()
		{
			Assert.IsNotNull(lane.CurrentBillCount);
			
			RegistryHelper.Attach(new R());
			Assert.AreEqual("NoCashCount", lane.CurrentBillCount);

            RegistryHelper.Attach(new RegistryManagerStub());

		}
		
		[Test]
		public void TestCurrentCoinAndBillCount()
		{
			Assert.IsNotNull(lane.CurrentCoinAndBillCount);
		}
		
		[Test]
		public void TestIsCADD()
		{
			Assert.IsFalse(lane.IsCADD);
			
			RegistryHelper.Attach(new RCBC());
			Assert.IsTrue(lane.IsCADD);
		}
		
		[Test]
		public void TestADDVersion()
		{
			Assert.IsNotNull(lane.ADDVersion);
			
			RegistryHelper.Attach(new R());
            Assert.AreEqual("NoADDVersionFound", lane.ADDVersion);

            RegistryHelper.Attach(new RegistryManagerStub());
		}
		
		void LaneConnectionAdding(object sender, PsxWrapperEventArgs e)
		{
			lane.PsxConnections.Add(new PsxStub("localhost", "FastLaneRemoteServer", "AUTOMATION", 5000));
		}
			
		class R : RegistryManagerStub
		{
			public override bool Exists(string key, Microsoft.Win32.RegistryKey subKey)
			{
				return false;
			}
		}
		
		class RCBC : RegistryManagerStub
		{
			public override bool Exists(string key, Microsoft.Win32.RegistryKey subKey)
			{
				return true;
			}
			
			public override string GetValue(string key, Microsoft.Win32.RegistryKey subKey)
			{
				switch (key) {
					case "PackageVersion":
						return "30.3.0.194";
					case "CountryCode":
						return "USD";
					case "ApplicationType":
						return "Ansi";
					default:
						throw new NotSupportedException();
				}
			}
		}
		
		class RS : RegistryManagerStub
		{
			public override string GetValue(string key, Microsoft.Win32.RegistryKey subKey)
			{
				switch (key) {
					case "Configure":
						return "Unicode";
					case "ApplicationType":
						return "";
					default:
						throw new NotSupportedException();
				}
			}
		}
		
		class RT : RegistryManagerStub
		{
			public override string GetValue(string key, Microsoft.Win32.RegistryKey subKey)
			{
				switch (key) {
					case "Configure":
						return "";
					case "ApplicationType":
						return "unicode";
					default:
						throw new NotSupportedException();
				}
			}
		}
		
		class RU : RegistryManagerStub
		{
			public override string GetValue(string key, Microsoft.Win32.RegistryKey subKey)
			{
				switch (key) {
					case "Configure":
						return "";
					case "ApplicationType":
						return "";
					default:
						throw new NotSupportedException();
				}
			}
		}
		
		class RV : RegistryManagerStub
		{
			public override string GetValue(string key, Microsoft.Win32.RegistryKey subKey)
			{
				switch (key) {
					case "Configure":
						return "ansi";
					case "ApplicationType":
						return "";
					default:
						throw new NotSupportedException();
				}
			}
		}
		
		class RW : RegistryManagerStub
		{
			public override string GetValue(string key, Microsoft.Win32.RegistryKey subKey)
			{
				switch (key) {
					case "Configure":
						return "";
					case "ApplicationType":
						return "ANSI";
					default:
						throw new NotSupportedException();
				}
			}
		}
		
		class RX : RegistryManagerStub
		{
			public override string GetValue(string key, Microsoft.Win32.RegistryKey subKey)
			{
				return null;
			}
		}
						
		class GF : PsxStub
		{
			public GF(string host, string service, string connection, int timeout) : base(host, service, connection, timeout)
			{
			}
			
			public override bool IsClickable(string controlName)
			{
				return false;
			}
			
			public override string GetContext(uint displayTarget)
			{
				return "LoyaltyCard";
			}
		}
	}
}
