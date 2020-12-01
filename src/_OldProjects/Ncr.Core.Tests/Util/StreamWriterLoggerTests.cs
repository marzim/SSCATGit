//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class StreamWriterLoggerTests
	{
		StreamWriterLogger l;
		string file = @"C:\Projects\finger\trunk\tests\test.log";
		
		[SetUp]
		public void Setup()
		{
			FileHelper.Attach(new FileManager());
			FileHelper.Create(file);
			
			l = new StreamWriterLogger(file, new DateLogFormatter());
		}
		
		[TearDown]
		public void Teardown()
		{
			FileHelper.Delete(file);
		}
		
		[Test]
		public void TestCreate()
		{
			l.Create("create...");
		}
		
		[Test]
		public void TestDebug()
		{
			l.Debug("debug...");
		}
		
		[Test]
		public void TestWarning()
		{
			l.Warning("warning...");
		}
		
		[Test]
		public void TestInfo()
		{
			l.Info("info...");
		}
		
		[Test]
		public void TestExists()
		{
			l.Exists("exists...");
		}
		
		[Test]
		public void TestError()
		{
			l.Error("error...");
		}
	}
}
