//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using NUnit.Framework;
using Sscat.Core.Finger;

namespace Sscat.Tests.Finger
{
	[TestFixture]
	public class FingerReportScriptTests
	{
		FingerReportScript s;
		FingerReportScript xml;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			s = new FingerReportScript("test", "");
			xml = FingerReportScript.Deserialize(new StringReader(@"<FingerPlayListReportFingerScriptReportsFingerScriptReport>
	            <scriptName></scriptName>
	            <scriptDescription></scriptDescription>
	            <scriptFile></scriptFile>
	            <scriptLogOutputFile></scriptLogOutputFile>
	            <stepsPassednum>0</stepsPassednum>
	            <stepsFailednum>0</stepsFailednum>
	            <stepsSkippednum>0</stepsSkippednum>
	            <Result/>
	            <PlaylistFileName>C:\Projects\finger\trunk\tests\test.xml</PlaylistFileName>
            </FingerPlayListReportFingerScriptReportsFingerScriptReport>"));
		}
		
		[Test]
		public void TestScriptNameValue()
		{
			Assert.AreEqual("test", s.ScriptName);
		}

        [Test]
        public void TestScriptDescriptionValue()
        {
            Assert.IsEmpty(s.ScriptDescription);

        }

        [Test]
        public void TestXMLResultValue()
        {
            Assert.IsNotNull(xml.Result);

        }

        [Test]
        public void TestXMLNameValue()
        {

            Assert.IsEmpty(xml.ScriptName);
        }

        [Test]
        public void TestXMLDescriptionValue()
        {


            Assert.IsEmpty(xml.ScriptDescription);
        }

        [Test]
        public void TestXMLFileValue()
        {

            Assert.IsEmpty(xml.ScriptFile);
        }

        [Test]
        public void TestXMLLogOutputFileValue()
        {

            Assert.IsEmpty(xml.ScriptLogOutputFile);
        }

        [Test]
        public void TestXMLPassedValue()
        {

            Assert.AreEqual(0, xml.Passed);
        }

        [Test]
        public void TestXMLFailedValue()
        {

            Assert.AreEqual(0, xml.Failed);
        }

        [Test]
        public void TestXMLSkippedValue()
        {

            Assert.AreEqual(0, xml.Skipped);
        }

        [Test]
        public void TestXMLPlaylistValue()
        {
            
            Assert.AreEqual(@"C:\Projects\finger\trunk\tests\test.xml", xml.PlaylistFileName);

        }

        [Test]
        public void TestXMLStartTimeValue()
        {
            DateTime now = DateTime.Now;
            xml.StartTime = now;
            Assert.AreEqual(now, xml.StartTime);
        }

        [Test]
        public void TestXMLEndTimeValue()
        {

            DateTime now = DateTime.Now;
            xml.EndTime = now;
            Assert.AreEqual(now, xml.EndTime);
        }
	}
}
