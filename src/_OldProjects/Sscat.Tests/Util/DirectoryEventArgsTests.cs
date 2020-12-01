//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Util;

namespace Sscat.Tests.Util
{
	[TestFixture]
	public class DirectoryEventArgsTests
	{
		DirectoryEventArgs e;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			e = new DirectoryEventArgs(@"C:\Projects\finger\trunk\tests");
		}
		
		[Test]
		public void TestDirectory()
		{
			Assert.IsNotEmpty(e.Directory);
		}
	}
}
