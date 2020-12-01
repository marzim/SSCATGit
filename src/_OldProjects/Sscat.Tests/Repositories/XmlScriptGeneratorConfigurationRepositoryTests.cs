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
	public class XmlScriptGeneratorConfigurationRepositoryTests
	{
		XmlGeneratorConfigurationRepository d;
		string f = @"C:\Projects\finger\trunk\tests\test.xml";
		
		[SetUp]
		public void Setup()
		{
			d = new XmlGeneratorConfigurationRepository();
			
			FileHelper.Create(f, new GeneratorConfiguration().Serialize());
		}
		
		[TearDown]
		public void Teardown()
		{
			FileHelper.Delete(f);
		}
		
		[Test]
		public void TestRead()
		{
			GeneratorConfiguration c = d.Read(f);
			Assert.IsNotNull(c);
		}
	}
}
