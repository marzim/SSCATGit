//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Config;

namespace Sscat.Tests.Config
{
	[TestFixture]
	public class LaneConfigurationTests
	{
		LaneConfiguration config;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			FileHelper.Attach(new FileManagerStub());
			config = new LaneConfigurationRepositoryStub().Read("");
		}
		
		[Test]
		public void TestFilesLengthValue()
		{
			Assert.AreEqual(19, config.Files.Files.Length);
			
		}

        [Test]
        public void TestParsersValue()
        {
            Assert.IsNotNull(config.Parsers);
        }

        [Test]
        public void TestGeneratorConfigurationValue()
        {
            Assert.IsNotNull(config.GeneratorConfiguration);
        }

        [Test]
        public void TestPlayerConfigurationValue()
        {
            Assert.IsNotNull(config.PlayerConfiguration);
        }

        [Test]
        public void TestFileNameValue()
        {
            Assert.IsEmpty(config.FileName);
        }

        [Test]
        public void TestHooksValue()
        {
            Assert.IsNotNull(config.Hooks);
        }

        [Test]
        public void TestGetParsersValue()
        {
            Assert.AreEqual(6, config.GetParsers().Count);
        }

        [Test]
        public void TestGetHooksValue()
        {
            Assert.AreEqual(6, config.GetHooks().Count);
        }
	}
}
