//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Controllers;
using Sscat.Core.Models;
using Sscat.Core.Util;
using Sscat.Gui;
using Sscat.Tests.Util;

namespace Sscat.Tests.Controllers
{
	[TestFixture]
	public class WldbControllerTests
	{
		WldbController controller;
		ISscatSecurityManager securityManager;
		UpdateWldbPane view;
		
		[SetUp]
		public void Setup()
		{
			MessageService.Attach(new NoMessageProvider());
			securityManager = new SecurityManagerStub();
			view = new UpdateWldbPane();
			controller = new WldbController(securityManager, view);
		}
		
		[Test]
		public void TestManage()
		{
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(UpdateWldbPane), controller.Manage());
		}
		
		[Test]
		public void TestWldbManagerManage()
		{
			Assert.That(() => securityManager.UpdateWldb(new WldbEvent("Update", "g2lane-ian", "some.mdb", "some.mdb", "some.xml", "scot", "Q+1MwHiTNa4RB04/+wirFg==")),
                Throws.TypeOf<NullReferenceException>());
		}
		
//		[Test]
//		public void TestViewManageUpdate()
//		{
//			view = new UpdateWldbPane();
//			controller = new WldbController(securityManager, view);			
//			view.Manage();
//		}
//		
//		[Test]
//		public void TestViewManageCreateUpdateScript()
//		{
//			UpdateWldbScriptPane view2 = new UpdateWldbScriptPane();
//			controller = new WldbController(securityManager, view2);
//			view2.Manage();
//		}		
	}
}
