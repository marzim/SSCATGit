//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using System.Text;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class FileWatcherTests
	{
		FileWatcher w;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			FileHelper.Attach(new FileManager());
			FileHelper.Create(@"C:\Projects\finger\trunk\test\test.txt");
			DirectoryHelper.Attach(new DirectoryManager());
			w = new FileWatcher(@"C:\Projects\finger\trunk\test\test.txt", Encoding.Default, @"C:\Projects\finger\trunk\test\test.txt.bak", true);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			w.Dispose();
			DirectoryHelper.DeleteDirectory(@"C:\Projects\finger\trunk\test");
		}
		
		[Test]
		public void TestAppendLog()
		{
			w.AppendLog("");
		}
		
		[Test]
		public void TestPerformChanged()
		{
			w.PerformChanged();
		}
		
		[Test]
		public void TestChanges()
		{
			w.Changed += delegate(object sender, LogHookEventArgs e) { 
				Assert.AreEqual("hello world", e.Changes);
			};
			using (StreamWriter s = new StreamWriter(@"C:\Projects\finger\trunk\test\test.txt", true, Encoding.Default)) {
				s.WriteLine("hello world");
			}
		}
	}
}
