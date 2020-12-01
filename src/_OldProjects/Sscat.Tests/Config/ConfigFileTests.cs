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
	public class ConfigFileTests
	{
		ConfigFile hasHost;
		ConfigFile hasHostDifferentContent;
		ConfigFile file;
		ConfigFile nonExistent;
		ConfigFile nonExistentInScot;
		ConfigFile differentContent;
		ConfigFile same;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			DnsHelper.Attach(new DnsManagerStub());
			
			hasHost = ConfigFile.Deserialize(new StringReader(@"<File Name='Scotopts.dat' Host='test'/>"));
			hasHostDifferentContent = ConfigFile.Deserialize(new StringReader(@"<File Name='Scotopts.dat' Host='test' DifferentFromScotConfig='true'/>"));
			file = ConfigFile.Deserialize(new StringReader(@"<File Name='Scotopts.000' Exists='true'/>"));
			
			differentContent = ConfigFile.Deserialize(new StringReader(@"<File Name='Scotopts.000' Exists='true'>hello</File>"));
			same = ConfigFile.Deserialize(new StringReader(@"<File Name='Scotopts.000' Exists='true'>hello world</File>"));
			nonExistent = ConfigFile.Deserialize(new StringReader(@"<File Name='Scotopts.000'>hello</File>"));
			nonExistentInScot = ConfigFile.Deserialize(new StringReader(@"<File Name='notexists' Exists='true'/>"));
		}
		
		[Test]
		public void TestHostNameValue()
		{
			Assert.AreEqual("Scotopts.dat", hasHost.Name);
		}

        [Test]
        public void TestHostValue()
        {
            Assert.AreEqual("test", hasHost.Host);
        }

        [Test]
        public void TestHasHostValue()
        {
            Assert.IsTrue(hasHost.HasHost());
        }

        [Test]
        public void TestSourceValue()
        {
            Assert.IsNull(hasHost.Source);
        }
		
        [Test]
        public void TestDestinationValue()
        {
            Assert.IsNull(hasHost.Destination);
        }

        [Test]
        public void TestExistsValue()
        {
            Assert.IsFalse(hasHost.Exists);
        }

        [Test]
        public void TestContentValue()

        {
            Assert.IsEmpty(file.Content);
        }

		//[Test]
        //TODO: Either fix or remove empty test
		public void TestLoadHasHostWithDifferentContent()
		{
            //hasHostDifferentContent.LoadOnServer += delegate(object sender, ConfigFileEventArgs e) { 
            //	Assert.AreEqual(hasHostDifferentContent.Name, e.File.Name);
            //};
            //hasHostDifferentContent.Load(new ConfigFileRepositoryStub(), @"C:\scot\config", @"C:\Projects\finger\trunk\ScotConfig");
		}
		
		//[Test]
        //TODO: Either fix or remove empty test
		public void TestLoadHasHost()
		{
            //hasHost.Loading += delegate(object sender, SscatEventArgs e) { 
            //	Assert.AreEqual(string.Format("{0} is identical at {1}", hasHost.Name, hasHost.Host), e.Message);
            //};
            //hasHost.Load(new ConfigFileRepositoryStub(), @"C:\scot\config", @"C:\Projects\finger\trunk\ScotConfig");
		}
		
		//[Test]
        //TODO: Either fix or remove empty test
		public void TestLoadDifferentContent()
		{
            //differentContent.Loading += delegate(object sender, SscatEventArgs e) { 
            //	Assert.AreEqual(string.Format("{0} is overridden", differentContent.Name), e.Message);
            //};
            //differentContent.Load(new ConfigFileRepositoryStub(), @"C:\scot\config", @"C:\Projects\finger\trunk\ScotConfig");
		}
		
		//[Test]
        //TODO: Either fix or remove empty test
		public void TestLoadNonExistentConfig()
		{
            //nonExistent.Loading += delegate(object sender, SscatEventArgs e) { 
            //	Assert.AreEqual(string.Format("{0} exists in SCOT but not in configuration. File is renamed to {0}.sscat", nonExistent.Name), e.Message);
            //};
            //nonExistent.Load(new ConfigFileRepositoryStub(), @"C:\scot\config", @"C:\Projects\finger\trunk\ScotConfig");
		}
		
		//[Test]
        //TODO: Either fix or remove empty test
		public void TestLoadNonExistentInScot()
		{
            //nonExistentInScot.Loading += delegate(object sender, SscatEventArgs e) { 
            //	Assert.AreEqual(string.Format("{0} is added", nonExistentInScot.Name), e.Message);
            //};
            //nonExistentInScot.Load(new ConfigFileRepositoryStub(), @"C:\scot\config", @"C:\Projects\finger\trunk\ScotConfig");
		}
		
		//[Test]
        //TODO: Either fix or remove empty test
		public void TestLoadSameConfig()
		{
            //same.Loading += delegate(object sender, SscatEventArgs e) { 
            //	Assert.AreEqual(string.Format("{0} is identical", same.Name), e.Message);
            //};
            //same.Load(new ConfigFileRepositoryStub(), @"C:\scot\config", @"C:\Projects\finger\trunk\ScotConfig");
		}
		
		//[Test]
        //TODO: Either fix or remove empty test
		public void TestDiffersOnHost()
		{
            //hasHost.CheckOnServer += delegate(object sender, ConfigFileEventArgs e) { 
            //	e.File.DifferentFromScotConfig = true;
            //};
            //Assert.IsTrue(hasHost.DiffersFromScotConfig(new ConfigFileRepositoryStub(), @"C:\scot\config", @"C:\sscat\scotconfig"));
		}
		
		//[Test]
        //TODO: Either fix or remove empty test
		public void TestDiffersInContent()
		{
            //Assert.IsTrue(differentContent.DiffersFromScotConfig(new ConfigFileRepositoryStub(), @"C:\scot\config", @"C:\sscat\scotconfig"));
		}
		
		//[Test]
        //TODO: Either fix or remove empty test
		public void TestDiffersExistence()
		{
            //Assert.IsTrue(nonExistent.DiffersFromScotConfig(new ConfigFileRepositoryStub(), @"C:\scot\config", @"C:\sscat\scotconfig"));
		}
		
		//[Test]
        //TODO: Either fix or remove empty test
		public void TestDiffersExistenceInScot()
		{
            //Assert.IsTrue(nonExistentInScot.DiffersFromScotConfig(new ConfigFileRepositoryStub(), @"C:\scot\config", @"C:\sscat\scotconfig"));
		}

        //[Test]
        //TODO: Either fix or remove empty test
		public void TestSameConfiguration()
		{
            //Assert.IsFalse(same.DiffersFromScotConfig(new ConfigFileRepositoryStub(), @"C:\scot\config", @"C:\sscat\scotconfig"));
		}
	}
}
