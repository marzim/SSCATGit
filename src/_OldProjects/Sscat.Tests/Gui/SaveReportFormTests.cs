//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Models;
using Sscat.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class SaveReportFormTests
	{
		SaveReportForm form;
		SaveReport saveReportInfo;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ProcessUtility.Attach(new ProcessManagerStub());
			
			saveReportInfo = new SaveReport();
			
			form = new SaveReportForm(new SaveReport());	
			form.ReportSave += new EventHandler<SaveReportEventArgs>(ReportSaveForm);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			form.ReportSave -= new EventHandler<SaveReportEventArgs>(ReportSaveForm);
		}
		
		[Test]
		public void TestContructor()
		{
			form = new SaveReportForm(saveReportInfo);
		}
		
		[Test]
		public void TestButtonOkClick()
		{
			form.ClickButtonOK();
		}
		
		[Test]
		public void TestButtonCancelClick()
		{
			form.ClickButtonCancel();
		}
		
		[Test]
		public void TestButtonOpenContainingFolderClick()
		{
			form.ClickButtonOpenContainingFolder();
		}
		
		void ReportSaveForm(object sender, SaveReportEventArgs e)
		{
		}
	}
}
