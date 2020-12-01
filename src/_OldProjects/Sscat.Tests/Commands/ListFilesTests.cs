//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Commands;

namespace Sscat.Tests.Commands
{
	[TestFixture]
	public class ListFilesTests
	{
		ListFiles command;

		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			DirectoryHelper.Attach(new DirectoryManagerStub());
			MessageService.Attach(new NoMessageProvider());
			command = new ListFiles("*.txt");
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
		}
	}
}
