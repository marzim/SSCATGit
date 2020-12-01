//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Commands;
using Sscat.Core.Commands.LaunchPadPsx;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Core.Repositories;
using Sscat.Tests.Config;

namespace Sscat.Tests.Commands.Psx
{
	[TestFixture]
	public class LaunchPadPsxClickTests
	{
		LaunchPadPsxClick command;
		IScotLogHook hook;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			SscatLane lane = new SscatLane();
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			lane.Hooks = lane.Configuration.GetHooks();
			hook = lane.Hooks["LaunchPadPsx"];
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "Display", "", "", "", 0), lane, new PsxDisplayRepositoryStub(), 100, true);
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
		}
		
		[Test]
		public void TestKeyBoardEvent1()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "KeyBoardP1", "", "1", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestKeyBoardEvent2()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "KeyBoardP1", "", "2", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestKeyBoardEvent3()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "KeyBoardP1", "", "3", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestKeyBoardEvent4()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "KeyBoardP1", "", "4", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestKeyBoardEvent5()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "KeyBoardP1", "", "5", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestKeyBoardEvent6()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "KeyBoardP1", "", "6", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestKeyBoardEvent7()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "KeyBoardP1", "", "7", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestKeyBoardEvent8()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "KeyBoardP1", "", "8", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestKeyBoardEvent9()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "KeyBoardP1", "", "9", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestAlphaNumKey3LaunchPad()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumKey3LaunchPad", "", "", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP1_1()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP1", "", "1", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestAlphaNumP1_2()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP1", "", "2", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP1_3()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP1", "", "3", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestAlphaNumP1_4()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP1", "", "4", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP1_5()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP1", "", "5", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP1_6()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP1", "", "6", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP1_7()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP1", "", "7", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}		
		[Test]
		public void TestAlphaNumP1_8()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP1", "", "8", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP1_9()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP1", "", "9", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestAlphaNumP1_0()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP1", "", "0", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestAlphaNumP1_break()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP1", "", "~", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}		

		[Test]
		public void TestAlphaNumP2_Q()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP2", "", "q", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestAlphaNumP2_W()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP2", "", "w", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP2_E()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP2", "", "e", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestAlphaNumP2_R()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP2", "", "r", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP2_T()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP2", "", "t", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP2_Y()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP2", "", "y", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP2_U()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP2", "", "u", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}		
		[Test]
		public void TestAlphaNumP2_I()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP2", "", "i", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP2_O()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP2", "", "o", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestAlphaNumP2_P()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP2", "", "p", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestAlphaNumP2_break()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP2", "", "~", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}		

		[Test]
		public void TestAlphaNumP3_A()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP3", "", "a", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestAlphaNumP3_S()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP3", "", "s", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP3_D()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP3", "", "d", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestAlphaNumP3_F()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP3", "", "f", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP3_G()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP3", "", "g", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP3_H()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP3", "", "h", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP3_J()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP3", "", "j", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}		
		[Test]
		public void TestAlphaNumP3_K()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP3", "", "k", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP3_L()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP3", "", "l", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP3_break()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP3", "", "~", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestAlphaNumP4_Z()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP4", "", "z", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP4_X()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP4", "", "x", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestAlphaNumP4_C()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP4", "", "c", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP4_V()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP4", "", "v", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP3_B()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP4", "", "b", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP3_N()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP4", "", "n", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}		
		[Test]
		public void TestAlphaNumP4_M()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP4", "", "m", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP4_DOT()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP4", "", ".", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestAlphaNumP4_break()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "AlphaNumP4", "", "~", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}

		[Test]
		public void TestKeyBoardDefaultEvent()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent("1", "", "KeyBoardP1", "", "10", "", 0), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestRunWithException()
		{
			command = new LaunchPadPsxClick(hook, new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer()), new LaunchPadPsxEvent(), new SscatLane(), new PsxDisplayRepositoryStub(), 100, true);
			command.Run();
		}	
	}
}
