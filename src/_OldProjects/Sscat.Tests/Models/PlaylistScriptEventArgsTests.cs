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
	public class PlaylistScriptEventArgsTests
	{
		PlaylistScriptEventArgs e;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			e = new PlaylistScriptEventArgs(new PlaylistScript());
		}
		
		[Test]
		public void TestValues()
		{
			Assert.IsNotNull(e.Script);
		}
	}
}
