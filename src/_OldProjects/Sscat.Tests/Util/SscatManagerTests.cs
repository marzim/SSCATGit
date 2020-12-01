//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Util;

namespace Sscat.Tests.Util
{
	[TestFixture]
	public class SscatManagerTests
	{
		SscatManager m;
		
		[SetUp]
		public void Setup()
		{
			MessageService.Attach(new ConsoleMessageProvider());
			RegistryHelper.Attach(new RegistryManagerStub());
			ProcessUtility.Attach(new ProcessManagerStub(true));
			FileHelper.Attach(new FileManagerStub());
			DirectoryHelper.Attach(new DirectoryManagerStub());
			
			m = new SscatManager(new Lane());
			m.FileDelete += new EventHandler<FileEventArgs>(ManagerFileDelete);
			m.DirectoryDelete += new EventHandler<DirectoryEventArgs>(ManagerDirectoryDelete);
			m.Managing += new EventHandler<SscatEventArgs>(ManagerManaging);
		}
		
		[TearDown]
		public void Teardown()
		{
			m.FileDelete -= new EventHandler<FileEventArgs>(ManagerFileDelete);
			m.DirectoryDelete -= new EventHandler<DirectoryEventArgs>(ManagerDirectoryDelete);
			m.Managing -= new EventHandler<SscatEventArgs>(ManagerManaging);
		}
		
		[Test]
		public void TestClean()
		{
			m.Clean(true, true, true, true, true, true);
		}

		void ManagerManaging(object sender, SscatEventArgs e)
		{
		}
		
		void ManagerDirectoryDelete(object sender, DirectoryEventArgs e)
		{
		}

		void ManagerFileDelete(object sender, FileEventArgs e)
		{
		}
	}
}
