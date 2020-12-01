//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Models;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class ResultTests
	{
		[SetUp]
		public void Setup()
		{
		}
		
		[Test]
		public void TestConstructorEmpty()
		{
			Result result = new Result();
		}
		
		[Test]
		public void TestConstructor1()
		{
			Result result = new Result(ResultType.Passed, "OK");
		}
		
		[Test]
		public void TestConstructor2()
		{
			Result result = new Result(ResultType.Passed, "test", "test2", "test");
		}
		
		[Test]
		public void TestConstructor3()
		{
			Result result = new Result(ResultType.Passed, "test", "test2", "test", "test");
		}
		
		[Test]
		public void TestConstructor4()
		{
			Result result = new Result(ResultType.Warning, "test", 5);
		}
		
		[Test]
		public void TestConstructor5()
		{
			Result result = new Result(ResultType.Passed);
		}
		
		[Test]
		public void TestIsFailure()
		{
			Result result = new Result(ResultType.Failed, "Not Found");
			Assert.IsTrue(result.IsFailure);
		}

		[Test]
		public void TestToString()
		{
			Result result = new Result(ResultType.Passed, "test", "test2", "test", "test");
			Assert.AreEqual("Passed", result.ToString());
		}
		
		[Test]
		public void TestToRepresentationPassed()
		{
			Result result = new Result(ResultType.Passed, "test", "test2", "test", "test");
			Assert.AreEqual("Passed, test", result.ToRepresentation());
		}		
		
		[Test]
		public void TestToRepresentationWarning()
		{
			Result result = new Result(ResultType.Warning, "test", 5);
			Assert.AreEqual("Warning, test - Expected: ; Actual: ", result.ToRepresentation());
		}
		
		[Test]
		public void TestProperties()
		{
			Result result = new Result(ResultType.Passed, "test", "test2", "test", "test");
			
			result.NumberOfWarnings = 5;
			Assert.AreEqual(5, result.NumberOfWarnings);
			
			result.RepetitionIndex = 5;
			Assert.AreEqual(5, result.RepetitionIndex);		
			
			result.ExpectedResult = "test";
			Assert.AreEqual("test", result.ExpectedResult);	

			result.ActualResult = "test";
			Assert.AreEqual("test", result.ActualResult);	
			
			result.ScreenshotPath = "test";
			Assert.AreEqual("test", result.ScreenshotPath);	

			result.ScreenshotLink = "test";
			Assert.AreEqual("test", result.ScreenshotLink);	

			result.DiagnosticPath = "test";
			Assert.AreEqual("test", result.DiagnosticPath);	
			
			result.ExpectedResult = null;
			Assert.AreEqual("", result.ExpectedResult);	

			result.ActualResult = null;
			Assert.AreEqual("", result.ActualResult);	
			
			result.ScreenshotPath = null;
			Assert.AreEqual("", result.ScreenshotPath);	

			result.ScreenshotLink = null;
			Assert.AreEqual("", result.ScreenshotLink);	

			result.DiagnosticPath = null;
			Assert.AreEqual("", result.DiagnosticPath);

			result.Type = ResultType.Passed;
			Assert.AreEqual(ResultType.Passed, result.Type);	

			result.Notes = "test";
			Assert.AreEqual("test", result.Notes);
		}
	}
}
