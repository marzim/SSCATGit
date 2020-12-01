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
	public class RegexUtilityTests
	{
		[Test]
		public void TestMethod()
		{
			Assert.IsNotNull(RegexUtility.Match("", ""));
		}
	}
}
