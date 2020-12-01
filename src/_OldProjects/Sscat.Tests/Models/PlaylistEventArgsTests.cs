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
	public class PlaylistEventArgsTests
	{
		PlaylistEventArgs e;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			e = new PlaylistEventArgs(new Playlist());
		}
		
		[Test]
		public void TestValues()
		{
			Assert.IsNotNull(e.Playlist);
		}
	}
}
