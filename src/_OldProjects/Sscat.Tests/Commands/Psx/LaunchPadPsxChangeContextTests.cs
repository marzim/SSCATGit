//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//		<owner name="Apple Leo Chiong" email="Apple_Leo_Derilo.Chiong@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Models;
using NUnit.Framework;
using Rhino.Mocks;
using Sscat.Core.Commands.LaunchPadPsx;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Tests.Emulators;

namespace Sscat.Tests.Commands.Psx
{
	[TestFixture]
	public class LaunchPadPsxChangeContextTests
	{
//		LaunchPadPsxChangeContext e;
		LaunchPadPsxChangeContext validKey;
		LaunchPadPsxChangeContext invalidKey;
		LaunchPadPsxChangeContext nullEvent;
		LaunchPadPsxUnsupportedEvent unsupportedEvent;
		SscatLane lane;
		IScotLogHook hook;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
//			IScotLogHook hook = MockRepository.GenerateMock<IScotLogHook>();
//			e = new LaunchPadPsxChangeContext(hook, new LaunchPadPsxEvent(), new SscatLaneStub(), 5000, true);
			lane = new SscatLane();
			lane.PsxConnections.Add(new PsxStub("localhost", "FastLaneRemoteServer", "AUTOMATION", 5000));
			
			hook = MockRepository.GenerateMock<IScotLogHook>();
			
			validKey = new LaunchPadPsxChangeContext(hook, new LaunchPadPsxEvent("1", "EnterAlphaNumericID", "Display", "ChangeContext", "", "RAP.g2lane-ian", 0), lane, 5000, true);
			invalidKey = new LaunchPadPsxChangeContext(hook, new LaunchPadPsxEvent("1", "EnterID", "Display", "ChangeContext", "", "RAP.g2lane-ian", 0), lane, 5000, true);
			nullEvent = new LaunchPadPsxChangeContext(hook, new LaunchPadPsxEvent(), lane, 5000, true);
			unsupportedEvent = new LaunchPadPsxUnsupportedEvent(hook, new LaunchPadPsxEvent("1", "FastlaneContext", "Display", "Quit", "", "RAP.g2lane-ian", 0), lane, 5000, true);
		}
		
		[Test]
		public void TestRunValidKey()
		{
//			e.Run();
			validKey.Run();
		}
		
		[Test]
		public void TestRunInvalidKey()
		{
			invalidKey.Run();
		}
		
		[Test]
		public void TestRunNullEvent()
		{
			Assert.That(() => nullEvent.Run(), Throws.TypeOf<NullReferenceException>());
		}
		
		[Test]
		public void TestRunUnsupportedEvent()
		{
			unsupportedEvent.Run();
		}		
	}
}
