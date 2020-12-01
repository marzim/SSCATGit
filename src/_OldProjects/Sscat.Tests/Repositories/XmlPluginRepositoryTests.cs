//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Plugins;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Repositories.Xml;

namespace Sscat.Tests.Repositories
{
	[TestFixture]
	public class XmlPluginRepositoryTests
	{
		XmlPluginRepository repository;
		string f = @"C:\Projects\finger\trunk\tests\test.xml";
		
		[SetUp]
		public void Setup()
		{
			repository = new XmlPluginRepository();
			FileHelper.Create(f, new Plugin().Serialize());
		}
		
		[Test]
		public void TestLoad()
		{
			repository.Load(f);
		}
		
		[TearDown]
		public void Teardown()
		{
			FileHelper.Delete(f);
		}		
	}
}
