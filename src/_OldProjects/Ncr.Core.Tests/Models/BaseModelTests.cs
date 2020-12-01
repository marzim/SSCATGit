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
	public class BaseModelTests
	{
		BaseModel<Life> s;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			s = new BaseModel<Life>();
		}
		
		[Test]
		public void TestValidate()
		{
			Life l = new BaseModelTests.Life();
			s.ValidateIf(l, true);
		}
		
		[Test]
		public void TestAddError()
		{
			int life = 42;
			s.AddErrorIf("life", life == 42);
			Assert.IsTrue(s.HasErrors);
		}
		
		[Test]
		public void TestToRepresentation()
		{
			s.ToRepresentation();
		}
		
		public class Life : BaseModel<Life>
		{
		}
	}
}
