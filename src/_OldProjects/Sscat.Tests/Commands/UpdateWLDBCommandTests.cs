//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Commands;

namespace Sscat.Tests.Commands
{
	[TestFixture]
	public class UpdateWLDBCommandTests
	{
		UpdateWldbCommand command;
		
		[SetUp]
		public void Setup()
		{
			command = new UpdateWldbCommand();
		}

		[Test]
		public void TestRun()
		{
            Assert.That(() => command.Run(),
                Throws.TypeOf<Exception>());
		}			
	}
}
