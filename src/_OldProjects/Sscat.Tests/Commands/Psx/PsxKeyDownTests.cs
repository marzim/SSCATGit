//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Models;
using NUnit.Framework;
using Rhino.Mocks;
using Sscat.Core.Commands;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Tests.PsxNet;

namespace Sscat.Tests.Commands.Psx
{
	[TestFixture]
	public class PsxKeyDownTests
	{
		PsxKeyDown invalidKey;
		PsxKeyDown nullEvent;
		PsxKeyDown validKey;
		SscatLane lane;
		IScotLogHook hook;
		
		[SetUp]
		public void Setup()
		{
			lane = new SscatLane();
			lane.PsxConnections.Add(new PsxStub("localhost", "FastLaneRemoteServer", "AUTOMATION", 5000));
			
			hook = MockRepository.GenerateMock<IScotLogHook>();
			
			invalidKey = new PsxKeyDown(hook, lane, new PsxEvent("1", "EnterWeight", "Display", "KeyDown", "91", "RAP.g2lane-ian", 0), 5000, true);
			nullEvent = new PsxKeyDown(hook, lane, new PsxEvent(), 5000, true);
			validKey = new PsxKeyDown(hook, lane, new PsxEvent("1", "EnterWeight", "Display", "KeyDown", "100", "RAP.g2lane-ian", 0), 5000, true);
		}
		
		[Test]
		public void TestRunValidKey()
		{
			validKey.Run();
		}
		
		[Test]
		public void TestNullEvent()
		{
			Assert.That(() => nullEvent.Run(), 
                Throws.TypeOf<NullReferenceException>());
		}
		
		[Test]
		public void TestRunInvalidKey()
		{
			invalidKey.Run();
		}
	}
}
