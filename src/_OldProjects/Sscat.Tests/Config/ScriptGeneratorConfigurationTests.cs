//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Config;
using Sscat.Core.Repositories;

namespace Sscat.Tests.Config
{
	[TestFixture]
	public class GeneratorConfigurationTests
	{
		GeneratorConfiguration config;
		IGeneratorConfigurationRepository repository;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			DnsHelper.Attach(new DnsManagerStub());
			
			repository = new GeneratorConfigurationRepositoryStub();
			config = repository.Read("");
			
            //config.NameAndDescriptionClear += new EventHandler(ConfigNameAndDescriptionClear);
            //config.FileCopy += new EventHandler<ConfigFileEventArgs>(ConfigFileCopy);
            //config.FileCopyOnServer += new EventHandler<ConfigFileEventArgs>(ConfigFileCopyOnServer);
            //config.Managing += new EventHandler<SscatEventArgs>(ConfigManaging);
		}

        //[OneTimeTearDown]
        //TODO: Either remove or fix empty TearDown
		public void OneTimeTearDown()
		{
            //config.NameAndDescriptionClear -= new EventHandler(ConfigNameAndDescriptionClear);
            //config.FileCopy -= new EventHandler<ConfigFileEventArgs>(ConfigFileCopy);
            //config.FileCopyOnServer -= new EventHandler<ConfigFileEventArgs>(ConfigFileCopyOnServer);
            //config.Managing -= new EventHandler<SscatEventArgs>(ConfigManaging);
		}
		
		//[Test]
        //TODO: Either remove or fix empty test
		public void TestClearNameAndDescription()
		{
            //config.ClearNameAndDescription();
		}

        //[Test]
        //TODO: Either remove or fix empty test
		public void TestManage()
		{
            //config.Manage("");
		}
		
		[Test]
        public void TestScriptOutputDirectoryValue()
		{
			Assert.AreEqual(@"C:\SSCAT\Scripts", config.ScriptOutputDirectory);
		}

        [Test]
        public void TestLogsOutputDirectoryValue()
        {
            Assert.AreEqual(@"C:\SSCAT\logs", config.LogsOutputDirectory);
        }

        [Test]
        public void TestRootDirectoryValue()
        {
            Assert.AreEqual(@"C:\SSCAT", config.RootDirectory);
        }

        [Test]
        public void TestFilesLengthValue()
        {
            Assert.AreEqual(19, config.Files.Files.Length);
        }

        [Test]
        public void TestScriptsLengthValue()
        {
            Assert.AreEqual(0, config.Scripts.Scripts.Length);
        }

        [Test]
        public void TestScriptNameValue()
        {
            Assert.IsEmpty(config.ScriptName);
        }

        [Test]
        public void TestScriptDescriptionValue()
        {
            Assert.IsEmpty(config.ScriptDescription);
        }

        [Test]
        public void TestSegmentedScriptsValue()
        {
            Assert.IsTrue(config.SegmentedScripts);
        }

        [Test]
        public void TestDontShowMSCardEditorValue()
        {
            Assert.IsFalse(config.DontShowMSCardEditor);
        }

        [Test]
        public void TestDefaultMSCardValue()
        {
            Assert.IsEmpty(config.DefaultMSCard);	
        }

		[Test]
		public void TestValidate()
		{
			config.Validate();
			Assert.IsTrue(config.HasErrors);
		}
		
		[Test]
		public void TestNullScripts()
		{
			config.Scripts = null;
			Assert.AreEqual(0, config.Scripts.Scripts.Length);
		}

		void ConfigManaging(object sender, SscatEventArgs e)
		{
		}

		void ConfigFileCopyOnServer(object sender, ConfigFileEventArgs e)
		{
		}

		void ConfigFileCopy(object sender, ConfigFileEventArgs e)
		{
		}

		void ConfigNameAndDescriptionClear(object sender, EventArgs e)
		{
		}
	}
}
