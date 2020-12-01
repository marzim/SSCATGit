//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Views;

namespace Sscat.Tests.Views
{
	[TestFixture]
	public class ConsoleAboutViewTests
	{
		ConsoleAboutView v;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			v = new ConsoleAboutView();
		}
		
		[Test]
		public void TestHandle()
		{
			//Assert.IsNotNull(v.Handle);
            Assert.That(() => v.Handle, Throws.TypeOf<NotImplementedException>());
		}
	}
}
