//	<file>
//		<license></license>
//		<owner name="Apple Leo Chiong" email="ac185120@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Models;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class ReportPlaybackUtilityTests
	{
		ReportPlaybackUtility reportUtility;
		ReportPlayback reportPlayback;
		DirectoryInfo reportDirectory;
		string newFile;
		
		[SetUp]
		public void Setup()
		{
			ApplicationUtility.Attach(new ApplicationManager());
			FileHelper.Attach(new FileManagerStub());
			
			reportUtility = new ReportPlaybackUtility();
			reportPlayback = new ReportPlayback();
			reportDirectory = new DirectoryInfo(@"C:\sscat\reports");
			newFile = @"C:\sscat\reports\newFile.csv";
			reportPlayback.CreateReportPlaybackFormat(newFile);
		}
		
		[TearDown]
		public void DeleteSetupFile()
		{
			FileHelper.Delete(newFile);
		}
		
		[Test]
		public void TestGetLatestReportPlaybackFile()
		{
			FileInfo latestFile = reportUtility.GetLatestReportPlaybackFile(reportDirectory);
			Assert.AreEqual("newFile.csv", latestFile.ToString());
		}
		
		[Test]
		public void TestGetLatestReportPlaybackFileNull()
		{
			FileInfo latestFile = reportUtility.GetLatestReportPlaybackFile(null);
			Assert.IsNull(latestFile);
		}
		
		[Test]
		public void TestWriteOnReportPlaybackFile()
		{
			string message = "1, TestSript1, Passed, Ok, TestScript1_Screen1, TestScript1_Diagnostic";
			reportUtility.WriteOnReportPlaybackFile(newFile, message);
		}
		
		[Test]
		public void TestUpdateReportPlaybackSummaryPassed()
		{
			ResultType passed = ResultType.Passed;
			reportUtility.UpdateReportPlaybackSummary(newFile, passed);
		}
		
		[Test]
		public void TestUpdateReportPlaybackSummaryFailed()
		{
			ResultType failed = ResultType.Failed;
			reportUtility.UpdateReportPlaybackSummary(newFile, failed);
		}
		
		[Test]
		public void TestUpdateReportPlaybackSummaryException()
		{
			ResultType exception = ResultType.Exception;
			reportUtility.UpdateReportPlaybackSummary(newFile, exception);
		}
		
		[Test]
		public void TestUpdateReportPlaybackSummaryCatchException()
		{
			ResultType exception = ResultType.Exception;
			reportUtility.UpdateReportPlaybackSummary(null, exception);
		}
		
		[Test]
		public void TestGetCacheFiles()
		{
			DirectoryInfo cacheDirectory = new DirectoryInfo(@"C:\sscat\cache");
			reportUtility.GetCacheFiles(cacheDirectory);
		}
		
		[Test]
		public void TestGetCacheFilesNullDirectory()
		{
			DirectoryInfo cacheDirectory = new DirectoryInfo(@"C:\NotCreatedFolder");
			Assert.IsNull(reportUtility.GetCacheFiles(cacheDirectory));
		}
		
		[Test]
		public void TestGetScriptEventReportFileName()
		{
			string cacheScriptFileName = @"C:\sscat\cache\playback-1-0-TestNormalTransactions_0";
			DirectoryInfo reportsTempDirectory = new DirectoryInfo(@"C:\sscat\reports\sscattemp");
			Assert.AreEqual(@"C:\sscat\reports\sscattemp\playback-1-0-TestNormalTransactions_0.csv", reportUtility.GetScriptEventReportFileName(cacheScriptFileName, reportsTempDirectory));
		}
	}
}
