//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using NUnit.Framework;
using Sscat.Core.Models;

namespace Sscat.Tests.Config
{
	[TestFixture]
	public class ScriptConfigsTests
	{
		ScriptConfigs s;
		ScriptConfigs xml;
		
		[SetUp]
		public void Setup()
		{
			s = new ScriptConfigs();
			xml = ScriptConfigs.Deserialize(new StringReader(@"<ScriptConfigs>
	<ScriptConfig>
		<Script>
		</Script>
		<Config>
			<File Name='test.xml'/>
		</Config>
	</ScriptConfig>
</ScriptConfigs>"));
		}
		
		[Test]
		public void TestValues()
		{
			ScriptConfig c = xml.ScriptConfigurations[0];
			Assert.AreEqual(1, c.Files.Files.Length);
		}
	}
}
