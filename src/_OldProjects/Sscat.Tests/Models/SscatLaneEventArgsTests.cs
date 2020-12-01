//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Sscat.Core.Emulators;
using Sscat.Core.Models;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class SscatLaneEventArgsTests
	{
		SscatLaneEventArgs e;
		
		[SetUp]
		public void Setup()
		{
			e = new SscatLaneEventArgs(new List<ScriptFile>(new ScriptFile[] { new ScriptFile(@"C:\Projects\finger\trunk\tests\script.xml") }));
		}
		
		[Test]
		public void TestValues()
		{
			Assert.IsNotNull(e.ScriptFiles);
		}
	}
}
