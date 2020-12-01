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
	public class LaunchPadPsxChangeFocusTests
	{
//		LaunchPadPsxChangeFocus e;
		LaunchPadPsxChangeFocus validKey;
		LaunchPadPsxChangeFocus invalidKey;
		LaunchPadPsxChangeFocus nullEvent;
		SscatLane lane;
		IScotLogHook hook;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
//			IScotLogHook hook = MockRepository.GenerateMock<IScotLogHook>();
//			e = new LaunchPadPsxChangeFocus(hook, new LaunchPadPsxEvent(), new SscatLaneStub(), 5000, true);
			lane = new SscatLane();
			lane.PsxConnections.Add(new PsxStub("localhost", "FastLaneRemoteServer", "AUTOMATION", 5000));
			
			hook = MockRepository.GenerateMock<IScotLogHook>();
			
			validKey = new LaunchPadPsxChangeFocus(hook, new LaunchPadPsxEvent("1", "EnterPassword", "Display", "ChangeFocus", "", "RAP.g2lane-ian", 0), lane, 5000, true);
			invalidKey = new LaunchPadPsxChangeFocus(hook, new LaunchPadPsxEvent("1", "EnterID", "Echo", "ChangeFocus", "", "RAP.g2lane-ian", 0), lane, 5000, true);
			nullEvent = new LaunchPadPsxChangeFocus(hook, new LaunchPadPsxEvent(), lane, 5000, true);
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
			Assert.That(() => nullEvent.Run(), 
                Throws.TypeOf<NullReferenceException>());
		}
	}
}
