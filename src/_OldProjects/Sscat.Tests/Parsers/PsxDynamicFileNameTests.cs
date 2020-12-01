using System;
using System.IO;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Parsers;

namespace Sscat.Tests.Parsers
{
	[TestFixture]
	public class PsxDynamicFileNameTests
	{
		PsxDynamicFileName f;
		
		[SetUp]
		public void Setup()
		{
			f = new PsxDynamicFileName();
			f.Directory = @"C:\Projects\finger\trunk\tests\";
		}
			
		[Test]
		public void TestPsxUnicode()
		{
			FileHelper.Create(Path.Combine(f.Directory, "psx_ScotAppU.log"));
			Assert.AreEqual(@"C:\Projects\finger\trunk\tests\psx_ScotAppU.log", f.FileName);
			FileHelper.Delete(Path.Combine(f.Directory, "psx_ScotAppU.log"));
		}
		
		[Test]
		public void TestPsxAnsi()
		{
			FileHelper.Create(Path.Combine(f.Directory, "psx_ScotApp.log"));
			FileHelper.Delete(Path.Combine(f.Directory, "psx_ScotAppU.log"));
			Assert.AreEqual(@"C:\Projects\finger\trunk\tests\psx_ScotApp.log", f.FileName);
			FileHelper.Delete(Path.Combine(f.Directory, "psx_ScotApp.log"));
		}
	
		[Test]
		public void TestNoDirectory()
		{
			f.Directory = @"";
			Console.WriteLine(f.FileName);
		}		
	}
}
