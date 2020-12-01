//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Parsers;

namespace Sscat.Tests.Parsers
{
	[TestFixture]
	public class ProgressEventArgsTests
	{
		ProgressEventArgs e;
		ProgressEventArgs em;
		ProgressEventArgs ex;
		
		[SetUp]
		public void Setup()
		{
			em = new ProgressEventArgs("test");
			ex = new ProgressEventArgs("test", 42);
			e = new ProgressEventArgs("test", 0, 100);
		}
		
		[Test]
		public void TestValues()
		{
			Assert.AreEqual("test", e.Message);
			Assert.AreEqual(0, e.Minimum);
			Assert.AreEqual(100, e.Maximum);
		}
	}
}
