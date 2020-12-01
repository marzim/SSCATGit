//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
//using Ncr.Core.IoC;
using NUnit.Framework;
using Sscat.Core.Models;
using Sscat.Core.Util;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class PlaylistTests
	{
		Playlist p;
		IPlaylist ps;
		
		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			p = Playlist.Deserialize(new StringReader(@"<Playlist Name='test' Description='test'>
	            <Script File='C:\Projects\finger\trunk\scripts\test\test_0.xml'/>
            </Playlist>"));
			ps = Playlist.Deserialize(new StringReader(@"<Playlist Name='Test Playlist'>
	            <Script File='C:\Projects\finger\trunk\scripts\test\test_0.finger'/>
            </Playlist>"));
			
			p.ScriptAdded += new EventHandler<PlaylistScriptEventArgs>(PlaylistScriptAdded);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			p.ScriptAdded -= new EventHandler<PlaylistScriptEventArgs>(PlaylistScriptAdded);
		}
		
		[Test]
		public void TestValues()
        {
            p.Scripts = null;
            p.AddScript(new string[] { @"C:\Projects\finger\trunk\tests\script.xml" });
            Assert.AreEqual("test", p.Description);
			Assert.AreEqual("test", p.Name);
			Assert.AreEqual(1, p.Scripts.Length);
		}
		
		[Test]
		public void TestNullScripts()
		{
			p.Scripts = null;
			Assert.AreEqual(0, p.Scripts.Length);
		}
		
		[Test]
		public void TestAddScriptFile()
		{
			p.AddScript(new string[] { @"C:\Projects\finger\trunk\tests\script.xml" });
		}
		
		[Test]
		public void TestAddScript()
		{
			p.AddScript(new Script());
		}

		void PlaylistScriptAdded(object sender, PlaylistScriptEventArgs e)
		{
		}
	}
}
