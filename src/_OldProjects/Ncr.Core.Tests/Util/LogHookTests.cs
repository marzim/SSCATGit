//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class LogHookTests
	{
		LogHook hook;
		string changes;
		string log;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			FileHelper.Attach(new FileManager());
			
			log = @"C:\Projects\finger\trunk\logs\test.log";
			FileHelper.Create(log);
			
			changes = "";
			hook = new LogHook(new TextWatcher(@""));
			hook.Changed += new EventHandler<LogHookEventArgs>(HookChanged);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			hook.Changed -= new EventHandler<LogHookEventArgs>(HookChanged);
			hook.Dispose();
			FileHelper.Delete(log);
		}
		
		[Test]
		public void TestConstructorWithFileLog()
		{
			hook = new LogHook(log);

            hook = new LogHook(new TextWatcher(@""));
            hook.Changed += new EventHandler<LogHookEventArgs>(HookChanged);
		}
		
		[Test]
        public void TestAppendLogValue()
		{
			hook.AppendLog("test...");
			Assert.AreEqual(changes, "test...");
		}

        [Test]
        public void TestClearChangesValue()
        {
            hook.ClearChanges();
            Assert.AreEqual(changes, "");
        }

        [Test]
        public void TestPerformChangedValue()
        {
            hook.AppendLog("test2...");
            hook.PerformChanged();
            Assert.AreEqual(changes, "test2...");
        }

		void HookChanged(object sender, LogHookEventArgs e)
		{
			changes = e.Changes;
		}
	}
}
