//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Emulators;

namespace Sscat.Tests
{
	[TestFixture]
	public class SscatContextTests
	{
		[SetUp]
		public void Setup()
		{
			SscatContext.SetLane(new SscatLane());
		}
		
		[Test]
		public void TestValues()
		{
			Assert.IsNotNull(SscatContext.GetLane());
		}
	}
}
