//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using NUnit.Framework;
using Rhino.Mocks;
using Sscat.Core.Commands;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;

namespace Sscat.Tests.Commands.Psx
{
	[TestFixture]
	public class PsxKeyPressTests
	{
		PsxKeyPress e;
		
		[SetUp]
		public void Setup()
		{
			SscatLane lane = new SscatLane();
			IScotLogHook hook = MockRepository.GenerateMock<IScotLogHook>();
			e = new PsxKeyPress(hook, lane, new PsxEvent("1", "ScanAndBagWithReward", "Display", "KeyPress", "*", "", 0), 5000, true);
		}
		
		[Test]
		public void TestRun()
		{
			e.Run();
		}
	}
}
