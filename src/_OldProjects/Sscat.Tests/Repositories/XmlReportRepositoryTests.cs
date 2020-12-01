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
	public class XmlReportRepositoryTests
	{
		XmlReportRepository d;
		string f = @"C:\Projects\finger\trunk\tests\report.xml";
		Report r;
		DateTime n;
		
		[SetUp]
		public void Setup()
		{
			FileHelper.Attach(new FileManager());
			r = new Report();
			n = DateTime.Now;
			r.Date = n;
			r.FileName = f;
			
			FileHelper.Create(f, r.Serialize());
			
			d = new XmlReportRepository();
		}
		
		[TearDown]
		public void Teardown()
		{
			FileHelper.Delete(f);
		}
		
		[Test]
		public void TestRead()
		{
			d.Read(f);
			Assert.AreEqual(n.ToString(), r.Date.ToString());
		}
		
		[Test]
		public void TestSave()
		{
//			d.Save(Report.Deserialize(new StringReader(@"<Report FileName='C:\Projects\finger\trunk\tests\report.xml'/>")));
			d.Save(r);
		}
		
		[Test]
		public void TestSaveWithText()
		{
			d.Save(r, "test");
		}
	}
}
