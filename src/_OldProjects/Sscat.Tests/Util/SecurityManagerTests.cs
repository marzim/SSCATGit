//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Models;
using Sscat.Core.Util;

namespace Sscat.Tests.Util
{
	[TestFixture]
	public class SecurityManagerTests
	{
		[Test]
		public void TestMethod()
		{
			ISscatSecurityManager s = new SecurityManagerStub();
			s.WldbManage += delegate(object sender, WldbEventArgs e) {
//				Console.WriteLine(e.Message);
			};
			s.UpdateWldb("g2lane-ian", @"C:\Finger\tools\pstools\clean wldb\WLDB.mdb", @"C:\Finger\tools\pstools\clean SAconfig\SACONFIG.mdb", "scot", "Q+1MwHiTNa4RB04/+wirFg==");
		}
	}
}
