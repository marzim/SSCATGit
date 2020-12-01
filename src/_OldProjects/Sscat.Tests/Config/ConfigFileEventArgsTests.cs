//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Config;

namespace Sscat.Tests.Config
{
	[TestFixture]
	public class ConfigFileEventArgsTests
	{
		ConfigFileEventArgs e;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			e = new ConfigFileEventArgs(null);
		}
		
		[Test]
		public void TestFileValue()
		{
			Assert.IsNull(e.File);
		}

        [Test]
        public void TestDestinationPathValue()
        {
            Assert.IsEmpty(e.DestinationPath);
        }

        [Test]
        public void TestSourcePathValue()
        {
            Assert.IsEmpty(e.SourcePath);
        }
	}
}
