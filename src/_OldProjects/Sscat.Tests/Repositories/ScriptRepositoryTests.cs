//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.IO;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Models;
using Sscat.Core.Repositories;
using Sscat.Core.Repositories.Xml;

namespace Sscat.Tests.Repositories
{
	[TestFixture]
	public class ScriptRepositoryTests
	{
		XmlScriptRepository xmlRepository;
		IScript script;
		string scriptFile1 = @"C:\Projects\finger\trunk\tests\test.xml";
		string scriptFile2 = @"C:\Projects\finger\trunk\tests\tests\test.xml";
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			FileHelper.Attach(new FileManager());
			
			script = new Script();
			script.FileName = scriptFile1;
			xmlRepository = new XmlScriptRepository();
			
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
			xmlRepository.Save(script);
		}
		
		[Test]
		public void TestReadScripts()
		{
			List<IScript> scripts = new List<IScript>();
			xmlRepository.ReadScripts(@"C:\Projects\finger\trunk\tests", "*.xml", scripts);
		}
		
		[Test]
		public void TestSaveMultipleScripts()
		{
			xmlRepository.Save(new IScript[] { script });
		}
		
		[Test]
		public void TestRead()
		{
			IScript s = xmlRepository.Read(scriptFile1);
			Assert.AreEqual(scriptFile1, s.FileName);
		}
		
		[Test]
		public void TestGetScripts()
		{
			DirectoryHelper.Attach(new DirectoryManagerStub());
			List<ScriptFile> scripts = xmlRepository.GetScripts(new string[] { "", "1", "0" });
		}
	}
	
	public class ScriptRepositoryStub : BaseRepository, IScriptRepository
	{
		public void Save(IScript script)
		{
			OnAccessing(script.FileName);
		}
		
		public void Save(IScript[] scripts)
		{
			foreach (IScript script in scripts) {
				Save(script);
			}
			OnAccessing(string.Format("{0} script(s) created.", scripts.Length));
		}
		
		public virtual IScript Read(string file)
		{
			return FingerScript.Deserialize(new StringReader(@"<FingerScript>
	  <fingerBuild>2.2.0</fingerBuild>
	  <scriptName>test</scriptName>
	  <scriptDescription>test</scriptDescription>
	  <flBuild>4.04.00.0.000.391</flBuild>
	  <dateTime>8/16/2011 2:21:34 PM</dateTime>
	  <FileName>C:\test\test.xml</FileName>
	  <FingerEventData>
	    <enable>true</enable>
	    <eventTimeMS>942962708</eventTimeMS>
	    <eventType>PsxEventData</eventType>
	    <PsxEventData>
	      <contextName>Attract</contextName>
	      <controlName>Display</controlName>
	      <eventName>ChangeContext</eventName>
	      <param />
	      <psxId>1</psxId>
	      <remoteConnectionName />
	      <seqId>1</seqId>
	    </PsxEventData>
	  </FingerEventData>
	  <FingerEventData>
	    <enable>true</enable>
	    <eventTimeMS>942962808</eventTimeMS>
	    <eventType>PsxEventData</eventType>
	    <PsxEventData>
	      <contextName />
	      <controlName />
	      <eventName>ConnectRemote</eventName>
	      <param>HandheldRAP=0;operation[text]=sign-on-auto;UserId[text]=1;</param>
	      <psxId>1</psxId>
	      <remoteConnectionName>RAP.ssco-4xsm-15</remoteConnectionName>
	      <seqId>2</seqId>
	    </PsxEventData>
	  </FingerEventData>
	  <FingerEventData>
	    <enable>true</enable>
	    <eventTimeMS>942962949</eventTimeMS>
	    <eventType>DeviceEventData</eventType>
	    <DeviceEventData>
	      <deviceId>Scale</deviceId>
	      <deviceValue>0</deviceValue>
	      <seqId>2</seqId>
	    </DeviceEventData>
	  </FingerEventData>
	</FingerScript>"));
		}
		
		public void ReadScripts(string dir, string searchPattern, IList<IScript> scripts)
		{
			throw new NotImplementedException();
		}
		
		public List<ScriptFile> GetScripts(string[] args)
		{
			return GetScripts(args, 2);
		}
		
		public List<ScriptFile> GetScripts(string[] args, int length)
		{
			return new List<ScriptFile>(new ScriptFile[] { new ScriptFile(@"C:\Projects\finger\trunk\test\test.xml") });
		}
	}
}
