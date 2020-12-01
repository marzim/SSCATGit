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
	public class XmlPlayerConfigurationRepositoryTests
	{
		XmlPlayerConfigurationRepository d;
		string f = @"C:\Projects\finger\trunk\tests\test.xml";
		
		[SetUp]
		public void Setup()
		{
			d = new XmlPlayerConfigurationRepository();
			
			FileHelper.Create(f, new PlayerConfiguration().Serialize());
		}
		
		[TearDown]
		public void Teardown()
		{
			FileHelper.Delete(f);
		}
		
		[Test]
		public void TestRead()
		{
			PlayerConfiguration c = d.Read(f);
			Assert.IsNotNull(c);
		}
	}
}
