//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class LoadingFormTests
	{
		LoadingForm f;
		
		[Test]
		public void TestForm()
		{
			f = new LoadingForm("Test Title", "Test Message");
		}
		
		[Test]
		public void TestDispose()
		{
			Assert.That(() => f.Dispose(),
                Throws.TypeOf<NullReferenceException>());
		}
	}
}