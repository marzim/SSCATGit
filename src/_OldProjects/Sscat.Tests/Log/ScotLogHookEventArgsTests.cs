//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Sscat.Core.Log;
using Sscat.Core.Models;

namespace Sscat.Tests.Log
{
	[TestFixture]
	public class ScotLogHookEventArgsTests
	{
		ScotLogHookEventArgs e;
		
		[SetUp]
		public void Setup()
		{
			e = new ScotLogHookEventArgs(new List<IScriptEvent>());
		}
		
		[Test]
		public void TestEventCount()
		{
			Assert.AreEqual(0, e.Events.Count);
		}
		
		[TestAttribute]
		public void TestEventArgsNotNull()
		{
			Assert.IsNotNull(e);
		}
	}
}
