//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Models;
using Sscat.Core.Repositories.Xml;

namespace Sscat.Tests.Repositories
{
	[TestFixture]
	public class XmlFingerScriptRepositoryTests
	{
		XmlFingerScriptRepository repository;
		IScript script;
		string scriptFile1 = @"C:\Projects\finger\trunk\tests\test.xml";
		string scriptFile2 = @"C:\Projects\finger\trunk\tests\tests\test.xml";
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			FileHelper.Attach(new FileManager());
			
			script = new FingerScript();
			script.FileName = scriptFile1;
			repository = new XmlFingerScriptRepository();
			
			FileHelper.Create(scriptFile1, script.Serialize());
			FileHelper.Create(scriptFile2, script.Serialize());
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			FileHelper.Delete(scriptFile1);
			FileHelper.Delete(scriptFile2);
		}
		
		[Test]
		public void TestSave()
		{
			repository.Save(script);
		}
		
		[Test]
		public void TestReadScripts()
		{
			List<IScript> scripts = new List<IScript>();
			repository.ReadScripts(@"C:\Projects\finger\trunk\tests", "*.xml", scripts);
		}
		
		[Test]
		public void TestSaveMultipleScripts()
		{
			repository.Save(new IScript[] { script });
		}
		
		[Test]
		public void TestRead()
		{
			IScript s = repository.Read(scriptFile1);
			Assert.AreEqual(scriptFile1, s.FileName);
		}
		
		[Test]
		public void TestReadFileNotExist()
		{
			FileHelper.Delete(scriptFile1);
			IScript s; 
            Assert.That(() => s = repository.Read(scriptFile1),
                Throws.TypeOf<Exception>());
		}		
		
		[Test]
		public void TestGetScripts()
		{
			DirectoryHelper.Attach(new DirectoryManagerStub());
			List<ScriptFile> scripts = repository.GetScripts(new string[] { "", "1", "0" });
		}
	}
}
