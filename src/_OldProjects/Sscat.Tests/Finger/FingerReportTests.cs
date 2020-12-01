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
	public class FingerReportTests
	{
		FingerReport xml;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			xml = FingerReport.Deserialize(new StringReader(@"<FingerPlayListReport>
	            <startTime>2011-11-22T11:30:19.4487648+08:00</startTime>
	            <endTime>2011-11-22T11:30:19.4487648+08:00</endTime>
	            <PlaylistFileName>C:\Projects\finger\trunk\test\test.xml</PlaylistFileName>
	            <FingerScriptReports>
		            <stepNum>0</stepNum>
		            <totalSteps>0</totalSteps>
		            <FingerScriptReport>
			            <scriptName>test</scriptName>
		            </FingerScriptReport>
	            </FingerScriptReports>
	            <Result/>
            </FingerPlayListReport>"));
		}
		
		[Test]
		public void TestNullScripts()
		{
			xml.Scripts = null;
			Assert.AreEqual(0, xml.Scripts.Length);
            
            xml = FingerReport.Deserialize(new StringReader(@"<FingerPlayListReport>
	            <startTime>2011-11-22T11:30:19.4487648+08:00</startTime>
	            <endTime>2011-11-22T11:30:19.4487648+08:00</endTime>
	            <PlaylistFileName>C:\Projects\finger\trunk\test\test.xml</PlaylistFileName>
	            <FingerScriptReports>
		            <stepNum>0</stepNum>
		            <totalSteps>0</totalSteps>
		            <FingerScriptReport>
			            <scriptName>test</scriptName>
		            </FingerScriptReport>
	            </FingerScriptReports>
	            <Result/>
            </FingerPlayListReport>"));
		}
		
		[Test]
		public void TestAddScript()
		{
			xml.AddScript(new FingerReportScripts(0, 0, new FingerReportScript("test", "test")));
			Assert.AreEqual(2, xml.Scripts.Length);

            xml.Scripts = null;
            xml = FingerReport.Deserialize(new StringReader(@"<FingerPlayListReport>
	            <startTime>2011-11-22T11:30:19.4487648+08:00</startTime>
	            <endTime>2011-11-22T11:30:19.4487648+08:00</endTime>
	            <PlaylistFileName>C:\Projects\finger\trunk\test\test.xml</PlaylistFileName>
	            <FingerScriptReports>
		            <stepNum>0</stepNum>
		            <totalSteps>0</totalSteps>
		            <FingerScriptReport>
			            <scriptName>test</scriptName>
		            </FingerScriptReport>
	            </FingerScriptReports>
	            <Result/>
            </FingerPlayListReport>"));
		}
		
		[Test]
		public void TestConstructor()
		{
			DateTime now = DateTime.Now;
			FingerReport r = new FingerReport(now, now);
			Assert.AreEqual(now, r.StartTime);
			Assert.AreEqual(now, r.EndTime);
		}
		
		[Test]
		public void TestResultValue()
		{
			Assert.IsNotNull(xml.Result);
		}

        [Test]
        public void TestStartTimeValue()
        {
            Assert.IsNotNull(xml.StartTime);
        }

        [Test]
        public void TestEndTimeValue()
        {
            Assert.IsNotNull(xml.EndTime);
        }

        [Test]
        public void TestLengthValue()
        {
            Assert.AreEqual(1, xml.Scripts.Length);
        }

        [Test]
        public void TestPlaylistFileNameValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\test\test.xml", xml.PlaylistFileName);
        }
	}
}
