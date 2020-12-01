//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Windows.Forms;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class MessageServiceTests
	{
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			MessageService.Attach(new ConsoleMessageProvider());
		}
		
		[Test]
		public void TestShowInfoOnNullProvider()
		{
			MessageService.Attach(null);
            Assert.That(() => MessageService.ShowInfo("Info..."),
                Throws.TypeOf<ArgumentNullException>());

            MessageService.Attach(new ConsoleMessageProvider());
		}
		
		[Test]
		public void TestShowInfo()
		{
			MessageService.ShowInfo("Info...");
		}
		
		[Test]
		public void TestShowWarningOnNullProvider()
		{
			MessageService.Attach(null);
            Assert.That(() => MessageService.ShowWarning("Warning..."),
                Throws.TypeOf<ArgumentNullException>());

            MessageService.Attach(new ConsoleMessageProvider());
		}
		
		[Test]
		public void TestShowWarning()
		{
			MessageService.ShowWarning("Warning...");
		}
		
		[Test]
		public void ShowWarningOnTop()
		{
			MessageService.ShowWarningOnTop("Warning... OnTop");
		}
		
		[Test]
		public void ShowWarningOnTopOnNullProvider()
		{
			MessageService.Attach(null);
            Assert.That(() => MessageService.ShowWarningOnTop("Warning... OnTop"),
                Throws.TypeOf<ArgumentNullException>());

            MessageService.Attach(new ConsoleMessageProvider());
		}
		
		[Test]
		public void TestShowErrorOnNullProvider()
		{
			MessageService.Attach(null);
            Assert.That(() => MessageService.ShowError("Error..."),
                Throws.TypeOf<ArgumentNullException>());

            MessageService.Attach(new ConsoleMessageProvider());
		}
		
		[Test]
		public void TestShowError()
		{
			MessageService.ShowError("Error...");
		}
		
		[Test]
		public void TestShowErrorOnTop()
		{
			MessageService.ShowErrorOnTop("Error... OnTop");
		}
		
		[Test]
		public void TestShowErrorOnTopOnNullProvider()
		{
			MessageService.Attach(null);
            Assert.That(() => MessageService.ShowErrorOnTop("Error... OnTop"),
                Throws.TypeOf<ArgumentNullException>());

            MessageService.Attach(new ConsoleMessageProvider());
		}
		
		[Test]
		public void TestShowYesNoOnNullProvider()
		{
			MessageService.Attach(null);
            Assert.That(() => MessageService.ShowYesNo("Yes? "),
               Throws.TypeOf<ArgumentNullException>());

            MessageService.Attach(new ConsoleMessageProvider());
		}
		
		[Test]
		public void TestShowYesNo()
		{
			MessageService.ShowYesNo("Yes? ");
		}
		
		[Test]
		public void TestDiagResultShowYesNoCancel()
		{
			MessageService.Attach(new NoMessageProvider());
			MessageService.ShowYesNoCancel("DiaglogResultShowYesNoCancel");
		}
		
		[Test]
		public void TestDiagResultShowYesNoCancelInConsoleMessageProvider()
		{
			Assert.AreEqual(DialogResult.Yes, MessageService.ShowYesNoCancel("DiaglogResultShowYesNoCancel"));
		}
		
		[Test]
		public void TestDiagResultShowYesNoCancelOnNullProvider()
		{
			MessageService.Attach(null);
            Assert.That(() => MessageService.ShowYesNoCancel("DiaglogResultShowYesNoCancel"),
               Throws.TypeOf<ArgumentNullException>());

            MessageService.Attach(new ConsoleMessageProvider());
		}
	}
	
	public class NoMessageProvider : IMessageProvider
	{
		public virtual void ShowInfo(string message, string caption)
		{
		}
		
		public virtual void ShowError(string message, string caption)
		{
		}
		
		public virtual void ShowErrorOnTop(string message, string caption)
		{
		}
		
		public virtual void ShowWarning(string message, string caption)
		{
		}
		
		public virtual void ShowWarningOnTop(string message, string caption)
		{
		}
		
		public virtual bool ShowYesNo(string message, string caption)
		{
			return true;
		}
		
		public virtual DialogResult ShowYesNoCancel(string message, string caption)
		{
			return DialogResult.Yes;
		}
	}
}
