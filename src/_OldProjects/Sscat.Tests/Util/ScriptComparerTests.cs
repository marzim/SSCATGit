//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Util;

namespace Sscat.Tests.Util
{
	[TestFixture]
	public class ScriptComparerTests
	{
		ScriptComparer c;
		
		[SetUp]
		public void Setup()
		{
			c = new ScriptComparer();
		}
		
		[Test]
		public void TestCompare()
		{
			Assert.AreEqual(-1, c.Compare(new FingerScript(), new FingerScript()));
		}
	}
}
