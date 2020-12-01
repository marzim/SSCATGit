//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Rhino.Mocks;
using Sscat.Core.Commands;
using Sscat.Core.Emulators;
using Sscat.Core.Models;
using Sscat.Core.Util;

namespace Sscat.Tests.Commands.Wldb
{
	[TestFixture]
	public class UpdateWldbTests
	{
		UpdateWldb command;
		UpdateWldb command2;
		IWldbEvent evnt;
		SscatLane lane;
		
		[SetUp]
		public void Setup()
		{
			MessageService.Attach(new ConsoleMessageProvider());
			ApplicationUtility.Attach(new ApplicationManagerStub());
			ProcessUtility.Attach(new ProcessManagerStub());
			
			lane = new SscatLane();
			lane.SecurityManager = new SscatSecurityManager();
			evnt = new WldbEvent("Update", "dev453-001", @"C:\sscat\wldb\some.mdb", @"C:\sscat\wldb\some.mdb", @"C:\sscat\scripts\test.xml", "scot", "Q+1MwHiTNa4RB04/+wirFg==");
			command = new UpdateWldb(evnt, lane);
		}
		
		[Test]
		public void TestManage()
		{
			Assert.That(() => lane.SecurityManager.UpdateWldb(evnt),
                Throws.TypeOf<SecurityManagerException>());
		}
		
		[Test]
		public void TestRun()
		{
			lane.SecurityManager = new SscatSecurityManager();
			command.Run();
			Assert.AreEqual(ResultType.Failed, command.Result.Type);
		}
		
		[Test]
		public void TestRunWith1Exception()
		{
			lane.SecurityManager = new A();
			command = new UpdateWldb(evnt, lane);
			Assert.That(() => command.Run(),
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestRunWith2CryptographicException()
		{
			lane.SecurityManager = new A();
			evnt = new WldbEvent("Update", "dev453-001", @"C:\sscat\wldb\some.mdb", @"C:\sscat\wldb\some.mdb", @"C:\sscat\scripts\test.xml", "scot", "scot");
			command2 = new UpdateWldb(evnt, lane);
			command2.Run();
			Assert.AreEqual(ResultType.Failed, command2.Result.Type);
		}		
	}
		
	public class A : SecurityManager, ISscatSecurityManager
	{
		public event EventHandler<WldbEventArgs> WldbManage;
		
		public void UpdateWldb(IWldbEvent item)
		{
			throw new NotImplementedException();
		}
		
		public void BackupWldb(IWldbEvent item)
		{
			throw new NotImplementedException();
		}
		
		public void CreateUpdateScript(IWldbEvent item)
		{
			throw new NotImplementedException();
		}
		
		public void CreateBackupScript(IWldbEvent item)
		{
			throw new NotImplementedException();
		}
		
		protected virtual void OnWldbManage(WldbEventArgs e)
		{
			if (WldbManage != null) {
				WldbManage(this, e);
			}
		}
	}	
}
