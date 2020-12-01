//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Models;
using Sscat.Core.Util;

namespace Sscat.Tests.Util
{
	[TestFixture]
	public class SscatSecurityManagerTests
	{
		SscatSecurityManager m;
		
		[SetUp]
		public void Setup()
		{
			ApplicationUtility.Attach(new ApplicationManagerStub());
			RegistryHelper.Attach(new RegistryManagerStub());
			DnsHelper.Attach(new DnsManagerStub());
			FileHelper.Attach(new FileManager());
			
			m = new SscatSecurityManager();
			m.WldbManage += new EventHandler<WldbEventArgs>(ManagerWldbManage);
		}
		
		[TearDown]
		public void Teardown()
		{
			FileHelper.Delete(@"C:\sscat\scripts\some.xml");
			m.WldbManage -= new EventHandler<WldbEventArgs>(ManagerWldbManage);
		}
		
		[Test]
		public void TestUpdateWldb()
		{
			Assert.That(() => m.UpdateWldb(new WldbEvent("Update", "localhost", "some.mdb", "some.mdb", "some.xml", "scot", "scot")),
                Throws.TypeOf<SecurityManagerException>());
		}
		
		[Test]
		public void TestUpdateWldbWithEventErrors()
		{
			m.UpdateWldb(new WldbEvent("Update", "", "some.mdb", "some.mdb", "some.xml", "scot", "scot"));
		}

		[Test]
		public void TestCreateUpdateScript()
		{
			m.CreateUpdateScript(new WldbEvent("Update", "localhost", "some.mdb", "some.mdb", "some", "scot", "scot"));
		}
		
		[Test]
		public void TestCreateUpdateScriptWithEventErrors()
		{
			m.CreateUpdateScript(new WldbEvent("Update", "", "some.mdb", "some.mdb", "some.xml", "scot", "scot"));
		}

		void ManagerWldbManage(object sender, WldbEventArgs e)
		{
		}
	}
}
