//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using Ncr.Core.Controllers;
using NUnit.Framework;

namespace Ncr.Core.Tests.Controllers
{
	[TestFixture]
	public class ControllerBuilderTests
	{
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ControllerBuilder.SetControllerFactory(new A());
		}
		
		[Test]
		public void TestGetControllerFactoryValue()
		{
			Assert.IsNotNull(ControllerBuilder.GetControllerFactory());
		}
		
		class A : IControllerFactory
		{
			public IController CreateController(string controllerName, int offset)
			{
				throw new NotImplementedException();
			}
		}
	}
}
