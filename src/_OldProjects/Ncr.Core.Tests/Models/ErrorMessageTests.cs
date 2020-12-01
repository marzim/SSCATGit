//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Models;
using NUnit.Framework;

namespace Ncr.Core.Tests.Models
{
	[TestFixture]
	public class ErrorMessageTests
	{
		ErrorMessage e;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			e = new ErrorMessage("test");
		}
		
		[Test]
		public void TestMessageValue()
		{
			Assert.AreEqual("test", e.Message);
		}
	}
}
