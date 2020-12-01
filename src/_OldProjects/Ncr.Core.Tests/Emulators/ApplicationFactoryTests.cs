//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Emulators
{
	[TestFixture]
	public class ApplicationFactoryTests
	{
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ProcessUtility.Attach(new ProcessManagerStub());
			FileHelper.Attach(new FileManagerStub());
			RegistryHelper.Attach(new RegistryManagerStub());
		}
		
		[Test]
		public void TestGetApplication()
		{
			Assert.IsNotNull(ApplicationFactory.GetApplication(new Lane()));
		}
		
		[Test]
		public void TestGetNotFoundApplication()
		{
			Assert.IsNull(ApplicationFactory.GetApplication(new A()));
		}
		
		class A : Emulator
		{
			public A() : base("A")
			{
			}
			
			public override bool Exists {
				get { return false; }
			}
		}
	}
}
