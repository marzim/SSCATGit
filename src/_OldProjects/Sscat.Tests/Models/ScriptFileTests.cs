//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Models;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class ScriptFileTests
	{
		ScriptFile f;
		
		[SetUp]
		public void Setup()
		{
			f = new ScriptFile(@"C:\Projects\finger\trunk\tests\test.xml");
		}
		
		[Test]
		public void TestMethod()
		{
		}
	}
}
