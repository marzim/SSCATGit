//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections;
using System.IO;

using Ncr.Core;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Models;
using Sscat.Core.Repositories;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class ReportTests
	{
		[Test]
		public void TestConstruction()
		{
			FingerReport finger = new FingerReport(DateTime.Now, DateTime.Now);
			finger.AddScript(new FingerReportScripts(0, 0, new FingerReportScript("test", "test")));
			finger.AddScript(new FingerReportScripts(0, 0, new FingerReportScript("test", "test")));
			finger.AddScript(new FingerReportScripts(0, 0, new FingerReportScript("test", "test")));
			
			Report report = new Report();
			Script script = Script.Deserialize(new StringReader(@"<Script>
	<Events>
		<Event Type='Psx'>
			<Psx Id='' Context='' Control='' Event='' Param='' RemoteConnection=''/>
		</Event>
		<Event Type='Device'>
			<Device Id='BagScale' Value='500'/>
		</Event>
		<Event Type='Xm'>
      		<Xm Id='XmCountChanges' ValueCount='2' Values='1:5983,5:5971;10:2984,25:5970' />
    	</Event>
		<Event Type='Wldb'>
			<Wldb Host='test' WldbFile='' SAConfigFile='' Action='Update'/>
		</Event>
		<Event Type='ApplicationLauncher'>
      		<ApplicationLauncher Host='Dev453-007' Path='C:\Projects\Finger\trunk\scripts\Artifacts\TestProcessManager.bat' />
    	</Event>
    	<Event Type='Report'>
      		<Report Id='ReportsMenu' Value='149' />
    	</Event>
    	<Event Type='LaunchPadPsx'>
      		<LaunchPadPsx Context='EnterID' Control='NumericP4' Id='1' Event='Click' RemoteConnection='' />
    	</Event>
	</Events>
</Script>"));
			report.AddScript(
				new ReportScript[] {
					new ReportScript(script)
				}
			);
		}
		
		[Test]
		public void TestDeserializeFromString()
		{
			FingerReport finger = FingerReport.Deserialize(new StringReader(@"<FingerPlayListReport>
	<startTime>2011-11-22T11:30:19.4487648+08:00</startTime>
	<endTime>2011-11-22T11:30:19.4487648+08:00</endTime>
	<FingerScriptReports>
		<stepNum>0</stepNum>
		<totalSteps>0</totalSteps>
		<FingerScriptReport>
			<scriptName>test</scriptName>
		</FingerScriptReport>
	</FingerScriptReports>
</FingerPlayListReport>"));
			Assert.IsNotNull(finger.StartTime);
			Assert.IsNotNull(finger.EndTime);
			Assert.AreEqual(1, finger.Scripts.Length);
			
			Report report = Report.Deserialize(new StringReader(@"<Report
	FileName='C:\sscat\reports\test.xml'
	Date='2011-11-22T11:30:19.4487648+08:00'>
	<Script Passed='0' Failed='0' Skipped='0' FileName='C:\sscat\scripts\test.xml'>
		<Event Type='Psx' Result='Passed'>
			<Psx Id='1' Context='Attract' Control='' Event='ChangeContext' Param='' RemoteConnection=''>
				<Control></Control>
			</Psx>
		</Event>
		<Event Type='Device' Result='Passed'>
			<Device Id='BagScale' Value='500'/>
		</Event>
		<Event Type='Xm' Result='Passed'>
      		<Xm Id='XmCountChanges' ValueCount='2' Values='1:5983,5:5971;10:2984,25:5970' />
    	</Event>
		<Event Type='Wldb' Result='Passed'>
			<Wldb Host='test' WldbFile='' SAConfigFile='' Action='Update'/>
		</Event>
		<Event Type='ApplicationLauncher' Result='Passed'>
      		<ApplicationLauncher Host='Dev453-007' Path='C:\Projects\Finger\trunk\scripts\Artifacts\TestProcessManager.bat' />
    	</Event>
    	<Event Type='Report' Result='Failed'>
      		<Report Id='ReportsMenu' Value='149' />
    	</Event>
    	<Event Type='LaunchPadPsx' Result='Passed'>
      		<LaunchPadPsx Context='EnterID' Control='NumericP4' Id='1' Event='Click' RemoteConnection='' />
    	</Event>
	</Script>
</Report>"));
			Assert.AreEqual(@"C:\sscat\reports\test.xml", report.FileName);
			Assert.AreEqual(1, report.Scripts.Length);
			ReportScript script = report.Scripts[0];
			Assert.AreEqual(7, script.Events.Length);
			
			ReportScriptEvent evnt = script.Events[0];
			Assert.AreEqual("Psx", evnt.Type);
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(ReportPsxEvent), evnt.Item);
			ReportPsxEvent psx = evnt.Item as ReportPsxEvent;
			Assert.AreEqual("1", psx.Id);
			Assert.AreEqual("Attract", psx.Context);
			Assert.AreEqual("", psx.Control);
			Assert.AreEqual("ChangeContext", psx.Event);
			Assert.AreEqual("", psx.Param);
			Assert.AreEqual("", psx.RemoteConnection);
			
			evnt = script.Events[1];
			Assert.AreEqual("Device", evnt.Type);
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(ReportDeviceEvent), evnt.Item);
			ReportDeviceEvent device = evnt.Item as ReportDeviceEvent;
			Assert.AreEqual("BagScale", device.Id);
			Assert.AreEqual("500", device.Value);
			
			evnt = script.Events[2];
			Assert.AreEqual("Xm", evnt.Type);
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(ReportXmEvent), evnt.Item);
			ReportXmEvent xm = evnt.Item as ReportXmEvent;
			Assert.AreEqual("XmCountChanges", xm.Id);
			Assert.AreEqual(2, xm.ValueCount);
			Assert.AreEqual("1:5983,5:5971;10:2984,25:5970", xm.Values[0]);
			
			evnt = script.Events[3];
			Assert.AreEqual("Wldb", evnt.Type);
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(ReportWldbEvent), evnt.Item);
			ReportWldbEvent wldb = evnt.Item as ReportWldbEvent;
			Assert.AreEqual("test", wldb.Host);
			Assert.AreEqual("", wldb.WldbFile);
			Assert.AreEqual("", wldb.SAConfigFile);
			Assert.AreEqual("Update", wldb.Action);
			
			evnt = script.Events[4];
			Assert.AreEqual("ApplicationLauncher", evnt.Type);
			Assert.AreEqual("Passed", evnt.Result);
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(ReportApplicationLauncherEvent), evnt.Item);
			ReportApplicationLauncherEvent appLauncher = evnt.Item as ReportApplicationLauncherEvent;
			Assert.AreEqual("Dev453-007", appLauncher.Host);
			Assert.AreEqual(@"C:\Projects\Finger\trunk\scripts\Artifacts\TestProcessManager.bat", appLauncher.Path);
			
			evnt = script.Events[5];
			Assert.AreEqual("Report", evnt.Type);
			Assert.AreEqual("Failed", evnt.Result);
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(ReportReportEvent), evnt.Item);
			ReportReportEvent rpt = evnt.Item as ReportReportEvent;
			Assert.AreEqual("ReportsMenu", rpt.Id);
			Assert.AreEqual("149", rpt.Val);
			
			evnt = script.Events[6];
			Assert.AreEqual("LaunchPadPsx", evnt.Type);
			Assert.AreEqual("Passed", evnt.Result);
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(ReportLaunchPadPsxEvent), evnt.Item);
			ReportLaunchPadPsxEvent launchpadPsx = evnt.Item as ReportLaunchPadPsxEvent;
			Assert.AreEqual("EnterID", launchpadPsx.Context);
			Assert.AreEqual("NumericP4", launchpadPsx.Control);
			Assert.AreEqual("1", launchpadPsx.Id);
			Assert.AreEqual("Click", launchpadPsx.Event);
			Assert.AreEqual("", launchpadPsx.RemoteConnection);
		}
	}
}
