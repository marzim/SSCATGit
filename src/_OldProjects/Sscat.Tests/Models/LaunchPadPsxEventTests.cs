//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Models;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class LaunchPadPsxEventTests
	{
		[Test]
		public void TestEmptyConstructor()
		{
			LaunchPadPsxEvent e = new LaunchPadPsxEvent();
		}
		
		[Test]
		public void TestConstructor()
		{
			LaunchPadPsxEvent e = new LaunchPadPsxEvent("1", "Attract", "", "ChangeContext", "", "", 0);
		}
	}
}
