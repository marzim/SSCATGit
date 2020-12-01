//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using NUnit.Framework;
using Sscat.Core.Finger;

namespace Sscat.Tests.Finger
{
	[TestFixture]
	public class FingerReportScriptsTests
	{
		FingerReportScripts xml;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			xml = FingerReportScripts.Deserialize(new StringReader(@"<FingerPlayListReportFingerScriptReports>
	            <stepNum>0</stepNum>
	            <totalSteps>0</totalSteps>
	            <FingerScriptReport/>
            </FingerPlayListReportFingerScriptReports>"));
		}
		
		[Test]
		public void TestConstructor()
		{
			FingerReportScripts s = new FingerReportScripts(0, 0, new FingerReportScript());
			Assert.IsNotNull(s.Script);
		}
		
		[Test]
		public void TestStepNumValue()
		{
			Assert.AreEqual(0, xml.StepNum);
		}

        [Test]
        public void TestTotalStepsValue()
        {
            Assert.AreEqual(0, xml.TotalSteps);
        }

        [Test]
        public void TestScriptValue()
        {
            Assert.IsNotNull(xml.Script);
        }
	}
}
