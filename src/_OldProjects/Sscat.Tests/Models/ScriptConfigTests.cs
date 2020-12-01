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
	public class ScriptConfigTests
	{
		ScriptConfig c;
		
		[SetUp]
		public void Setup()
		{
			c = ScriptConfig.Deserialize(new StringReader(@"<ScriptConfig>
	<Script/>
	<Config/>
</ScriptConfig>"));
		}
		
		[Test]
		public void TestClear()
		{
			c.Clear();
			Assert.IsNull(c.Script);
		}
		
		[Test]
		public void TestValues()
		{
			Assert.IsNotNull(c.Script);
			Assert.IsNotNull(c.Files);
		}
		
//		[Test]
//		public void TestMethod()
//		{
//			FingerScript s1 = FingerScript.Deserialize(@"C:\projects\finger\trunk\scripts\test\test_0.xml");
//			FingerScript s2 = FingerScript.Deserialize(@"C:\projects\finger\trunk\scripts\test\test_0.xml");
//			List<IScript> scripts = new List<IScript>();
//			scripts.Add(s1);
//			scripts.Add(s2);
			
//			ConfigFiles files = ConfigFiles.Deserialize(new StringReader(@"<Files Source='C:\scot\config' Destination='C:\SSCAT\ScotConfig'>
//		<File Name='test.xml'>hello world</File>
//		<File Name='notexists.txt'></File>
//		<File Name='test2.xml'>hello worldx</File>
//	</Files>"));
//			
//			IConfigFilesDao dao = new IOConfigFilesDao();
//
//			ScriptConfigs configs = new ScriptConfigs();
//			string dir = Path.Combine(files.DestinationDirectory, "test");
//			configs.AddConfig(new ScriptConfig(s1, dao.Read(dir, files.GetFileNames())));
//			configs.AddConfig(new ScriptConfig(s2, dao.Read(dir, files.GetFileNames())));
//			Console.WriteLine(configs.Serialize());
//		}
	}
}
