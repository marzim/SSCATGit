//	<file>
//		<license></license>
//		<owner name="Apple Leo Chiong" email="ac185120@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Models;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class ReportPlaybackTests
	{
		ReportPlaybackUtility reportUtility;
		ReportPlayback reportPlayback;
		DirectoryInfo reportDirectory;
		string newFile;
		IScript s;
		Result r;
		FingerScript cacheScript;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
//			ApplicationUtility.Attach(new ApplicationManager());
			ApplicationUtility.Attach(new ApplicationManagerStub());
			FileHelper.Attach(new FileManagerStub());
			
			reportPlayback = new ReportPlayback();
			reportUtility = new ReportPlaybackUtility();
			reportDirectory = new DirectoryInfo(@"C:\sscat\reports");
			newFile = @"C:\sscat\reports\newFile.csv";
			FileHelper.Create(newFile);
			
			s = new FingerScript();
			r = new Result();
			s.Index = 1;
			s.Name = "TestScript1";
			r.Type = ResultType.Passed;
			r.Notes = "OK";
			r.ScreenshotPath = @"C:\sscat\screenshot\testscript1_screen";
			r.DiagnosticPath = @"C:\sscat\screenshot\testscript1_diag";
			s.Result = r;
			
			cacheScript = FingerScript.Deserialize(new StringReader(@"<FingerScript Index=""0"">
  <Result Type=""Passed"" NumberOfWarnings=""4"" RepetitionIndex=""1"" ExpectedResult=""TriColorLight: 1~1"" ActualResult=""TriColorLight: 1~4"" ScreenshotPath="""" DiagnosticPath="""" ScreenshotLink="""">Result for this script contains warning(s).</Result>
  <ScreenshotPath />
  <DiagnosticPath />
  <fingerBuild>3.4.0.38</fingerBuild>
  <scriptName>TestNormalTransactions</scriptName>
  <scriptDescription />
  <flBuild>4.04.00.0.000.018</flBuild>
  <dateTime>8/5/2013 8:27:37 PM</dateTime>
  <FileName>C:\Projects\Finger\trunk\tests\cache\playback-1-0-TestNormalTransactions_0</FileName>
  <FingerEventData ScriptIndex=""0"" Index=""0"" ScreenshotLink="""">
    <enable>true</enable>
    <eventTimeMS>332834656</eventTimeMS>
    <eventType>PsxEventData</eventType>
    <PsxEventData>
      <IsForgivable>false</IsForgivable>
      <psxId>1</psxId>
      <contextName>AttractMultiLanguage</contextName>
      <controlName>Display</controlName>
      <eventName>ChangeContext</eventName>
      <param />
      <remoteConnectionName />
      <seqId>1</seqId>
    </PsxEventData>
    <Result Type=""Passed"" NumberOfWarnings=""0"" RepetitionIndex=""0"" ExpectedResult="""" ActualResult="""" ScreenshotPath="""" DiagnosticPath="""" ScreenshotLink="""">OK</Result>
  </FingerEventData>
  </FingerScript>"));
			
			DirectoryHelper.Attach(new DirectoryManager());
			DirectoryHelper.CreateDirectory(@"C:\Projects\finger\trunk\tests\cache");
			cacheScript.Serialize(@"C:\Projects\finger\trunk\tests\cache\playback-1-0-TestNormalTransactions_0");
		}
		
		[TearDown]
		public void Teardown()
		{
			FileHelper.Delete(newFile);
			FileHelper.Delete(@"C:\Projects\finger\trunk\tests\cache\playback-1-0-TestNormalTransactions_0");
		}
		
		[Test]
		public void TestFileName()
		{
			FileInfo file = reportPlayback.FileName;
			Assert.AreEqual("newFile.csv", file.ToString());
		}
		
		[Test]
		public void TestReportPlaybackFile()
		{
			Assert.AreEqual(newFile, reportPlayback.ReportPlaybackFile);
		}
		
		[Test]
		public void TestCreateReportPlaybackFormat()
		{
			reportPlayback.CreateReportPlaybackFormat(newFile);
		}
		
		[Test]
		public void TestUpdateReportPlayback()
		{
			reportPlayback.UpdateReportPlayback(s);
		}
		
		[Test]
		public void TestCreateCompressReportFiles()
		{
			SaveReport sp = new SaveReport();
			sp.ReportFilename = "ReportFileName";
			sp.ReportOutputDirectory = @"C:\sscat\reports";
			
			reportPlayback.CreateCompressReportFiles(sp, new DirectoryInfo(@"C:\Projects\finger\trunk\tests\cache"));
		}
	}
}
