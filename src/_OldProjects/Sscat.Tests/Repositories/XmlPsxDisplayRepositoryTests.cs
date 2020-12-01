//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Models;
using Sscat.Core.Repositories.Xml;

namespace Sscat.Tests.Repositories
{
	[TestFixture]
	public class XmlPsxDisplayRepositoryTests
	{
		XmlPsxDisplayRepository repository;
		string f = @"C:\Projects\finger\trunk\tests\test.xml";
		
		[SetUp]
		public void Setup()
		{
			repository = new XmlPsxDisplayRepository();
			FileHelper.Create(f, new PsxDisplay().Serialize());
		}
		
		[Test]
		public void TestLoadContextEnterAlphaNUmericID()
		{
			repository.Load("EnterAlphaNumericID");
		}
		
		[Test]
		public void TestLoadContextEnterID()
		{
			repository.Load("EnterID");
		}

		[Test]
		public void TestLoadContextEnterPassword()
		{
			repository.Load("EnterPassword");
		}
		
		[Test]
		public void TestLoadContextDefault()
		{
			repository.Load("Default");
		}
		
		[Test]
		public void TestRead()
		{
			repository.Read(f);
		}
		
		[TearDown]
		public void Teardown()
		{
			FileHelper.Delete(f);
		}		
	}
}
