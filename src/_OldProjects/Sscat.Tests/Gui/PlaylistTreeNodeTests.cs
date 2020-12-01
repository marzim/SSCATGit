//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using NUnit.Framework;
using Sscat.Core.Gui;
using Sscat.Core.Models;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class PlaylistTreeNodeTests
	{
		PlaylistTreeNode view;
		Playlist playlist;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			playlist = Playlist.Deserialize(new StringReader(@"<Playlist Name='test'>
	<Script File='C:\Projects\finger\trunk\scripts\test\test_0.finger'/>
	<Script File='C:\Projects\finger\trunk\scripts\test\test_1.finger'/>
</Playlist>"));
			view = new PlaylistTreeNode(playlist, 0);
		}
		
		[Test]
		public void TestViewTextValue()
		{
			Assert.AreEqual(playlist.Name, view.Text);
		}

        [Test]
        public void TestViewPlaylistScriptsLengthValue()
        {
            Assert.AreEqual(2, view.Playlist.Scripts.Length);
        }
	}
}
