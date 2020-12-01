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
using Sscat.Tests.Repositories;

namespace Sscat.Tests.Config
{
	[TestFixture]
	public class ClientConfigurationTests
	{
		ClientConfiguration xml;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			xml = new ClientConfigurationRepositoryStub().Read("");
		}
		
		[Test]
		public void TestConstruction()
		{
			ClientConfiguration c = new ClientConfiguration(@"C:\Projects\finger\trunk\test\test.xml");
			Assert.AreEqual(@"C:\Projects\finger\trunk\test\test.xml", c.FileName);
		}
		
		[Test]
		public void TestFilesLengthValue()
        {
			Assert.AreEqual(19, xml.Files.Files.Length);
		}

        [Test]
        public void TestFileNameIsEmptyValue()
        {
            Assert.IsEmpty(xml.FileName);
        }

        [Test]
        public void TestFileNameValue()
        {
            xml.FileName = @"C:\Projects\Finger\trunk\config\ClientConfiguration.default.xml";
            Assert.AreEqual(@"C:\Projects\Finger\trunk\config\ClientConfiguration.default.xml", xml.FileName);
        }

        [Test]
        public void TestGeneratorConfigurationValue()
        {
            Assert.IsNotNull(xml.GeneratorConfiguration);
        }

        [Test]
        public void TestPlayerConfigurationValue()
        {
            Assert.IsNotNull(xml.PlayerConfiguration);
        }
	}
}
