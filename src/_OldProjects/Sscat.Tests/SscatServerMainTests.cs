//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Emulators;
using Sscat.Server;

namespace Sscat.Tests
{
	[TestFixture]
	public class SscatServerMainTests
	{
		[Test]
		[Ignore()]
		public void TestMain()
		{
			SscatServerMain.Main(new string[] { });
		}
	}
}
