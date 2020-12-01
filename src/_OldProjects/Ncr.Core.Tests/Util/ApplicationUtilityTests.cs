//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Threading;
using System.Windows.Forms;
using Ncr.Core.Commands;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class ApplicationUtilityTests
	{
		[SetUp]
        public void SetUp()
		{
			ApplicationUtility.Attach(new ApplicationManagerStub());
		}
		
		[Test]
		public void TestProductVersionValue()
		{
			Assert.AreEqual("3.0", ApplicationUtility.ProductVersion);
			// Assert.AreEqual(@"C:\scot\bin\LaunchPadNet.exe", ApplicationUtility.SscoStartupPath); FIXME: Problem with SscoStartupPath cannot be added in ApplicationManagerStub()
		}

        [Test]
        public void TestProcessNameValue()
        {
            Assert.AreEqual("SSCAT", ApplicationUtility.ProcessName);
        }

        [Test]
        public void TestProductNameAndVersionValue()
        {
            Assert.AreEqual("SSCAT 3.0", ApplicationUtility.ProductNameAndVersion);
        }

        [Test]
        public void TestInstallationDirectoryValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\", ApplicationUtility.InstallationDirectory);
        }

        [Test]
        public void TestRootDirectoryValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\bin", ApplicationUtility.RootDirectory);
        }

        [Test]
        public void TestConfigDirectoryValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\config", ApplicationUtility.ConfigDirectory);
        }

        [Test]
        public void TestDocsDirectoryValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\docs", ApplicationUtility.DocsDirectory);
        }

        [Test]
        public void TestLogsDirectoryValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\logs", ApplicationUtility.LogsDirectory);
        }

        [Test]
        public void TestPluginsDirectoryValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\plugins", ApplicationUtility.PluginsDirectory);
        }

        [Test]
        public void TestReportsDirectoryValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\reports", ApplicationUtility.ReportsDirectory);
        }

        [Test]
        public void TestToolsDirectoryValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\tools", ApplicationUtility.ToolsDirectory);
        }

        [Test]
        public void TestScotMemeUsageDirectoryValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\tools\ScotAppMemUsage", ApplicationUtility.ScotMemUsageDirectory);
        }

        [Test]
        public void TestPSToolsDirectoryValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\tools\pstools", ApplicationUtility.PSToolsDirectory);
        }

        [Test]
        public void TestCleanSAConfigDirectoryValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\tools\pstools\clean SAconfig", ApplicationUtility.CleanSAConfigDirectory);
        }

        [Test]
        public void TestCleanWldbDirectoryValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\tools\pstools\clean wldb", ApplicationUtility.CleanWldbDirectory);
        }

        [Test]
        public void TestCacheDirectoryValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\cache", ApplicationUtility.CacheDirectory);
        }

        [Test]
        public void TestPlayListsDirectoryValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\playlists", ApplicationUtility.PlaylistsDirectory);
        }

        [Test]
        public void TestClientConfigurationDefaultFileNameValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\config\ClientConfiguration.default.xml", ApplicationUtility.ClientConfigurationDefaultFileName);
        }

        [Test]
        public void TestLaneConfigurationFileNameValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\config\LaneConfiguration.xml", ApplicationUtility.LaneConfigurationFileName);
        }

        [Test]
        public void TestClientConfigurationFileNameValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\config\ClientConfiguration.123.45.678.910.xml", ApplicationUtility.ClientConfigurationFileName("123.45.678.910"));
        }

        [Test]
        public void TestSettingsFileNameValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\config\Settings.ini", ApplicationUtility.SettingsFileName);
        }
		
		[Test]
		public void TestRunOnNullManager()
		{
			ApplicationUtility.Attach(null);
            Assert.That(() => ApplicationUtility.Run(new Form()),
                Throws.TypeOf<ArgumentException>());
		}
		
		[Test]
		public void TestProductNameOnNullManager()
		{
			ApplicationUtility.Attach(null);
            Assert.That(() => Assert.IsNotEmpty(ApplicationUtility.ProductName),
                Throws.TypeOf<ArgumentException>());
		}
		
		[Test]
		public void TestRun()
		{
			ApplicationUtility.Run(new Form());
		}
		
		[Test]
		public void TestProductVersionOnNullManager()
		{
			ApplicationUtility.Attach(null);
            Assert.That(() => Assert.AreEqual("3.0", ApplicationUtility.ProductVersion),
                Throws.TypeOf<ArgumentException>());
		}
		
		[Test]
		public void TestProcessNameOnNullManager()
		{
			ApplicationUtility.Attach(null);
            Assert.That(() => Assert.AreEqual("SSCAT", ApplicationUtility.ProcessName),
                Throws.TypeOf<ArgumentException>());
		}
		
		[Test]
		public void TestSettingsFileNameOnNullManager()
		{
			ApplicationUtility.Attach(null);
            Assert.That(() => Assert.AreEqual("", ApplicationUtility.SettingsFileName),
                Throws.TypeOf<ArgumentException>());
		}
		
		[Test]
		public void TestSscoStartupPathOnNullManager()
		{
			ApplicationUtility.Attach(null);
            Assert.That(() => Assert.AreEqual("", ApplicationUtility.SscoStartupPath),
                Throws.TypeOf<ArgumentException>());
		}
		
		[Test]
		public void TestLocationOnNullManager()
		{
			ApplicationUtility.Attach(null);
			Assert.AreEqual(Application.StartupPath, ApplicationUtility.Location);
		}
	}
}
