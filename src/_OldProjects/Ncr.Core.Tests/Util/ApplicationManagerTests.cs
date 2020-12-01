//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class ApplicationManagerTests
	{
		ApplicationManager m;
		Assembly exe;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			FileHelper.Attach(new FileManagerStub());
			
			exe = Assembly.GetCallingAssembly();
			m = new ApplicationManager();
		}
		
		[Test]
		public void TestProcessNameValue()
		{
			Assert.IsNotEmpty(m.ProcessName);
		}

        [Test]
        public void TestProductNameValue()
        {
            Assert.IsNotEmpty(m.ProductName);
        }
		
		[Test]
		public void TestLocationValue()
		{
			Assert.IsNotEmpty(m.Location);
		}

        [Test]
        public void TestCleanSAConfigDirectoryValue()
        {
            Assert.IsNotEmpty(m.CleanSAConfigDirectory);
        }

        [Test]
        public void TestCleanWldbDirectoryValue()
        {
            Assert.IsNotEmpty(m.CleanWldbDirectory);
        }

        [Test]
        public void TestConfigDirectoryValue()
        {
            Assert.IsNotEmpty(m.ConfigDirectory);
        }

        [Test]
        public void TestDocsDirectoryValue()
        {
            Assert.IsNotEmpty(m.DocsDirectory);
        }
		
		[Test]
        public void TestInstallationDirectoryValue()
        {
            Assert.IsNotEmpty(m.InstallationDirectory);
        }

        [Test]
        public void TestLogsDirectoryValue()
        {
            Assert.IsNotEmpty(m.LogsDirectory);
        }

        [Test]
        public void TestPluginsDirectoryValue()
        {
            Assert.IsNotEmpty(m.PluginsDirectory);
        }

        [Test]
        public void TestPSToolsDirectoryValue()
        {
            Assert.IsNotEmpty(m.PSToolsDirectory);
        }

        [Test]
        public void TestReportsDirectoryValue()
        {
            Assert.IsNotEmpty(m.ReportsDirectory);
        }

        [Test]
        public void TestRootDirectoryValue()
        {
            Assert.IsNotEmpty(m.RootDirectory);
        }

        [Test]
        public void TestScotMemUsageDirectoryValue()
        {
            Assert.IsNotEmpty(m.ScotMemUsageDirectory);
        }

        [Test]
        public void TestToolsDirectoryValue()
        {
            Assert.IsNotEmpty(m.ToolsDirectory);
        }

        [Test]
        public void TestSettingsFileNameValue()
        {
            Assert.IsNotEmpty(m.SettingsFileName);
        }

        [Test]
        public void TestDiagsDirectoryValue()
        {
            Assert.IsNotEmpty(m.DiagsDirectory);
        }

        [Test]
        public void TestClientConfigurationDefaultFileNameValue()
        {
            Assert.IsNotEmpty(m.ClientConfigurationDefaultFileName);
        }

        [Test]
        public void TestLaneConfigurationFileNameValue()
        {
            Assert.IsNotEmpty(m.LaneConfigurationFileName);
        }

        [Test]
        public void TestProductNameAndVersionValue()
        {
            Assert.IsNotEmpty(m.ProductNameAndVersion);
            //Assert.IsNotEmpty(m.SscoStartupPath);
        }
		
		[Test]
		public void TestClientConfigurationFileName()
		{
			Assert.IsNotEmpty(m.ClientConfigurationFileName("localhost"));
		}
		
		[Test]
		public void TestSscoStartupPathDefault()
		{
			FileHelper.Attach(new D());
			Assert.IsNotEmpty(m.SscoStartupPath);
		}
		
		[Test]
		public void TestSscoStartupPathOverride()
		{
			FileHelper.Attach(new O());
			Assert.IsNotEmpty(m.SscoStartupPath);
		}
		
		[Test]
		public void TestRun()
		{
			m.Run(new F());
		}
		
		[Test]
		public void TestProductVersion()
		{
			Assert.AreEqual("3.0.0.0", m.ProductVersion);
		}
		
        //TODO: Please fix this
        //[Test]
        //[Ignore("Product name is not NUnit with TeamCity.")]
        //public void TestProductNameAndVersion()
        //{
        //    Assert.AreEqual("NUnit 3.0.0.0", m.ProductNameAndVersion);
        //}
		
		class F : Form
		{
			protected override void OnShown(EventArgs e)
			{
				base.OnShown(e);
				Close();
			}
		}
		
		class D : FileManager
		{
			public override string GetIniValue(string section, string keyName, string filePath)
			{
//				return @"C:\scot\bin\launchpadnet.exe";
				return @"C:\scot";
			}
		}
		
		class O : FileManager
		{
			public override string GetIniValue(string section, string keyName, string filePath)
			{
				return @"C:\scot\bin\scotappu.exe";
			}
		}
	}
}
