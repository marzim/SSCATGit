//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Rhino.Mocks;
using Sscat.Core.Commands;
using Sscat.Core.Config;
using Sscat.Core.Emulators;
using Sscat.Core.Models;
using Sscat.Core.Util;
using Sscat.Tests.Config;

namespace Sscat.Tests.Commands.Wldb
{
	[TestFixture]
	public class BackupWldbTests
	{
//		BackupWldb command;
		SscatLane lane;
		IWldbEvent evnt;
		
		[SetUp]
		public void Setup()
		{
			MessageService.Attach(new ConsoleMessageProvider());
			ProcessUtility.Attach(new ProcessManagerStub());
			ApplicationUtility.Attach(new ApplicationManagerStub());
			
			lane = new SscatLane();
			lane.SecurityManager = new SscatSecurityManager();
			
			evnt = new WldbEvent("Backup", "g2lane-ian", @"C:\sscat\wldb\some.mdb", @"C:\sscat\wldb\some.wldb", @"C:\sscat\scripts\test.xml", "scot", "scot");
			command = new BackupWldb(evnt, lane);
		}
		
		[Test]
		public void TestManage()
		{
			lane.SecurityManager.BackupWldb(evnt);
		}
		
		[Test]
		public void TestPreRun()
		{
			lane.Configuration = LaneConfiguration.Deserialize(new StringReader(@"<Configuration>
	<Player OverrideSecurityServer='true'/>
</Configuration>"));
			command.PreRun();
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
		}
		
		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void TestRunWithException()
		{
			lane.SecurityManager = new A();
			command = new BackupWldb(evnt, lane);
			command.Run();
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
