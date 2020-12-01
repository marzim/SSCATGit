//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Models;

namespace Sscat.Tests.Finger
{
	[TestFixture]
	public class FingerScriptTests
	{
		FingerScript xml;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			xml = FingerScript.Deserialize(new StringReader(@"<FingerScript>
              <fingerBuild>2.2.0</fingerBuild>
              <scriptName>test</scriptName>
              <scriptDescription>test</scriptDescription>
              <flBuild>4.04.00.0.000.391</flBuild>
              <dateTime>8/16/2011 2:21:34 PM</dateTime>
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
              <FileName>C:\Projects\finger\trunk\scripts\test.xml</FileName>
              <Result/>
              <ScreenshotPath></ScreenshotPath>
              <DiagnosticPath></DiagnosticPath>
            </FingerScript>"));
			
			FileHelper.Attach(new FileManager());
			DirectoryHelper.Attach(new DirectoryManager());
			DirectoryHelper.CreateDirectory(@"C:\Projects\finger\trunk\tests");
			FingerScript.Deserialize(new StringReader(@"<FingerScript/>")).Serialize(@"C:\Projects\finger\trunk\tests\qwerty.xml");
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
//			FileHelper.Delete(@"C:\Projects\finger\trunk\tests\qwerty.xml");
			DirectoryHelper.DeleteDirectory(@"C:\Projects\finger\trunk\tests");
		}
		
		[Test]
		public void TestToScript()
		{
			//Assert.IsNotNull(xml.ToScript());
            Assert.That(() => xml.ToScript(), Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestFromConstructorValues()
		{
			FingerScript s1 = new FingerScript("test", "");
			Assert.AreEqual("test", s1.Name);
			Assert.IsEmpty(s1.Description);
			
			FingerScript s2 = new FingerScript("test", "", "3.0", "4.5", new FingerScriptEvent(new FingerDeviceEvent("BagScale", "300")));
			Assert.AreEqual("test", s2.Name);
			Assert.IsEmpty(s2.Description);
			Assert.AreEqual("3.0", s2.SscatVersion);
			Assert.AreEqual("4.5", s2.SscoVersion);
			Assert.AreEqual(1, s2.ScriptEvents.Length);
		}
		
		[Test]
		public void TestDeserializeFromUnknownFile()
		{
			FingerScript s;
            Assert.That(()=> s = FingerScript.Deserialize(@"C:\Projects\finger\trunk\tests\unknown.qwerty"), 
                Throws.TypeOf<Exception>());
		}
		
		[Test]
		public void TestWithEvents() // This is for new version of script that has ScriptEvents element instead of some Finger class.
		{
			FingerScript s = new FingerScript();
			s.Events = null;
			Assert.AreEqual(0, s.Events.Events.Length);
		}
		
		[Test]
		public void TestDeserializeFromFile()
		{
			FingerScript s = FingerScript.Deserialize(@"C:\Projects\finger\trunk\tests\qwerty.xml");
			Assert.IsNull(s.Name);
			Assert.IsNotNull(s.Events);
		}
		
		[Test]
		public void TestNullScriptEvents()
		{
			FingerScript s = FingerScript.Deserialize(new StringReader(@"<FingerScript/>"));
			Assert.AreEqual(0, s.ScriptEvents.Length);
		}
		
		[Test]
        public void TestNameValue()
		{
			Assert.AreEqual("test", xml.Name);
		}

        [Test]
        public void TestSscatVersionValue()
        {
            Assert.AreEqual("2.2.0", xml.SscatVersion);
        }

        [Test]
        public void TestDescriptionValue()
        {
            Assert.AreEqual("test", xml.Description);
        }

        [Test]
        public void TestLengthValue()
        {
            Assert.AreEqual(1, xml.ScriptEvents.Length);
        }

        [Test]
        public void TestFileNameValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\scripts\test.xml", xml.FileName);
        }

        [Test]
        public void TestDateTimeValue()
        {
            Assert.AreEqual("8/16/2011 2:21:34 PM", xml.DateTime.ToString());
        }

        [Test]
        public void TestResultValue()
        {
            Assert.IsNotNull(xml.Result);
        }

        [Test]
        public void TestDiagnosticPathValue()
        {
            Assert.IsEmpty(xml.DiagnosticPath);

        }

        [Test]
        public void TestScreenshotPathValue()
        {
            Assert.IsEmpty(xml.ScreenshotPath);

        }

        [Test]
        public void TestVersionValue()
        {
            xml.Version = "1.0";
            Assert.AreEqual("1.0", xml.Version);

        }
	}
}
