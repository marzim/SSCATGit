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
	public class OptionsFormTests
	{
		OptionsForm f;
		
		[Test]
		public void TestDispose()
		{
			f.Dispose();
		}
			
		[Test]
		public void TestConstructor()
		{
			f = new OptionsForm();
		}
	}
}
