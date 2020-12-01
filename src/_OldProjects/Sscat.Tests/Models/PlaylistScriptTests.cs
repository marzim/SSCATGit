//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using NUnit.Framework;
using Sscat.Core.Models;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class PlaylistScriptTests
	{
		[Test]
		public void TestEmptyConstructor()
		{
			PlaylistScript p = new PlaylistScript();
		}
		
		[Test]
		public void TestConstructor()
		{
			PlaylistScript p = new PlaylistScript(new Script());
			Assert.IsNotNull(p.Script);
		}
		
		[Test]
		public void TestConstructorWithFile()
		{
			PlaylistScript p = new PlaylistScript(@"C:\Projects\finger\trunk\tests\script.xml");
			Assert.IsNotNull(p.File);
		}
		
		[Test]
		public void TestNullScript()
		{
			PlaylistScript p = new PlaylistScript();
			p.Script = null;
			//Assert.IsNotNull(p.Script);
            Assert.That(() => p.Script,
                Throws.TypeOf<ArgumentNullException>());
		}
	}
}
