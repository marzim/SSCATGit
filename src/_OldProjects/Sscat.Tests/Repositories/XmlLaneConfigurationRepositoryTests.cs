//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Repositories.Xml;

namespace Sscat.Tests.Repositories
{
	[TestFixture]
	public class XmlLaneConfigurationRepositoryTests
	{
		XmlLaneConfigurationRepository repository;
		string file = @"C:\Projects\finger\trunk\tests\test.xml";
		LaneConfiguration config;
		
		[SetUp]
		public void Setup()
		{
			FileHelper.Attach(new FileManager());
			
			config = new LaneConfiguration();
			config.FileName = file;
			repository = new XmlLaneConfigurationRepository();
			
			FileHelper.Create(file, config.Serialize());
		}
		
		[TearDown]
		public void Teardown()
		{
			FileHelper.Delete(file);
		}
		
		[Test]
		public void TestSave()
		{
			repository.Save(config);
		}
		
		[Test]
		public void TestRead()
		{
			repository.Read(file);
		}
	}
}
