//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using System.Drawing;
using System.Threading;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Emulators;
using Sscat.Core.Models;
using Sscat.Core.Util;
using Sscat.Tests.Util;

namespace Sscat.Tests.Emulators
{
	[TestFixture]
	public class SscatLaunchPadTest
	{
		SscatLaunchPad l;

		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ThreadHelper.Attach(new ThreadManagerStub());
			
			l = new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer());
		}
		
		[Test]
		public void TestGenerateLogButton()
		{
			l.PerformLaunchPadEvent(new PsxEvent("", "", "GenerateLogButton", "", "", "", 1));
		}
		
		[Test]
		public void TestEventViewerButton()
		{
			l.PerformLaunchPadEvent(new PsxEvent("", "", "EventViewerButton", "", "", "", 1));
		}
		
		[Test]
		public void TestTerminalInfoButton()
		{
			l.PerformLaunchPadEvent(new PsxEvent("", "", "TerminalInfoButton", "", "", "", 1));
		}
		
		[Test]
		public void TestStopStartFastLaneButton()
		{
			l.PerformLaunchPadEvent(new PsxEvent("", "", "StopStartFastLaneButton", "", "", "", 1));
		}
		
		[Test]
		public void TestVolumeButton()
		{
			l.PerformLaunchPadEvent(new PsxEvent("", "", "VolumeButton", "", "", "", 1));
		}
		
		[Test]
		public void TestConfirmYes_GenerateLogButton()
		{
			WindowAppHelper.Attach(new WindowAppManagerStub("GenerateLogButton"));
			l.PerformLaunchPadEvent(new PsxEvent("", "", "ConfirmYes", "", "", "", 1));
		}
		
		[Test]
		public void TestConfirmYes_EventViewerButton()
		{
			WindowAppHelper.Attach(new WindowAppManagerStub("EventViewerButton"));
			l.PerformLaunchPadEvent(new PsxEvent("", "", "ConfirmYes", "", "", "", 1));
		}		
		
		[Test]
		public void TestConfirmYes_TerminalInfoButton()
		{
			WindowAppHelper.Attach(new WindowAppManagerStub("TerminalInfoButton"));
			l.PerformLaunchPadEvent(new PsxEvent("", "", "ConfirmYes", "", "", "", 1));
		}

		[Test]
		public void TestConfirmYes_StopStartFastLaneButton()
		{
			WindowAppHelper.Attach(new WindowAppManagerStub("StopStartFastLaneButton"));
			l.PerformLaunchPadEvent(new PsxEvent("", "", "ConfirmYes", "", "", "", 1));
		}		

		[Test]
		public void TestConfirmNo()
		{
			l.PerformLaunchPadEvent(new PsxEvent("", "", "ConfirmNo", "", "", "", 1));
		}
	}
}
