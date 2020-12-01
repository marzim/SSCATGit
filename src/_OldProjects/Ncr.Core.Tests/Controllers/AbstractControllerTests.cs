//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Controllers;
using NUnit.Framework;

namespace Ncr.Core.Tests.Controllers
{
	[TestFixture]
	public class AbstractControllerTests
	{
		A a;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			a = new A();
		}
		
		//[Test]
        //TODO: Either fix or remove empty test
		public void TestConstructor()
		{
		}
		
		class A : AbstractController
		{
		}
	}
}
