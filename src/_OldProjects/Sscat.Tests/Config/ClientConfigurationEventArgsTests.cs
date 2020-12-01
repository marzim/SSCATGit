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
	public class ClientConfigurationEventArgsTests
	{
		ClientConfigurationEventArgs e;

        [OneTimeSetUp]
        public void OneTimeSetUp()
		{
			e = new ClientConfigurationEventArgs(null);
		}
		
		[Test]
		public void TestValues()
		{
			Assert.IsNull(e.Configuration);
		}
	}
}
