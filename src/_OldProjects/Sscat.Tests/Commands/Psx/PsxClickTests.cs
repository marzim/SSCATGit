//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//		<owner name="Apple Leo Chiong" email="apple_leo_derilo.chiong@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Emulators;
using Ncr.Core.Models;
using Ncr.Core.Tests.Models;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Rhino.Mocks;
using Sscat.Core.Commands;
using Sscat.Core.Config;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Tests.Config;
using Sscat.Tests.PsxNet;

namespace Sscat.Tests.Commands.Psx
{
	[TestFixture]
	public class PsxClickTests
	{
		PsxClick click;
		PsxClick hasRap;
		PsxClick isExempted;
		SscatLane lane;
		IScotLogHook hook;
		
		[SetUp]
		public void Setup()
		{
			ThreadHelper.Attach(new ThreadManagerStub());
			ApiHelper.Attach(new ApiManagerStub());
			
			lane = new SscatLane(10, false, false);
			lane.PsxConnections.Add(new PsxStub("localhost", "FastLaneRemoteServer", "AUTOMATION", 10));
			
			hook = MockRepository.GenerateMock<IScotLogHook>();
			click = new PsxClick(hook, new PsxEvent("1", "Attract", "CMButton1Lg", "Click", "", "", 0), lane, 10, true);
			
			hasRap = new PsxClick(hook, new PsxEvent("1", "RAPSingle8", "LaneButton", "Click", "", "RAP.g2lane-ian", 0), lane, 10, true);
			
			isExempted = new PsxClick(hook, new PsxEvent("1", "XMCashStatus", "XMKeyBoardP4", "Click", "", "", 0), lane, 10, true);
		}
		
		[Test]
		public void TestWithoutPsxConnection()
		{
			lane.PsxConnections.Clear();
			Assert.That(() => click.Run(),
                Throws.TypeOf<NoPsxAttachedException>());
		}
		
		[Test]
		public void TestWithRap()
		{
			lane.PsxConnections.Add(new PsxStub("g2lane-ian", "FastLaneRemoteServer", "RAP.g2lane-ian", 10));
			hasRap.Run();
		}
		
		[Test]
		public void TestIsExempted()
		{
			isExempted.Run();
		}		
		
		[Test]
		public void TestWithRapWithoutPsxConnection()
		{
			lane.PsxConnections.Clear();
			hasRap.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(HasRapConnectionAdding);
			hasRap.Run();
			hasRap.ConnectionAdding -= new EventHandler<PsxWrapperEventArgs>(HasRapConnectionAdding);
		}
		
		[Test]
		public void TestRun()
		{
			click.Run();
		}
		
		[Test]
		public void TestSmReportsMenu()
		{
			ImageHelper.Attach(new ImageManagerStub());
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			
			click = new PsxClick(hook, new PsxEvent("1", "SmReportsMenu", "SMReceiptScrollUp", "Click", "", "", 0), lane, 10, true);
			click.Run();
		}
		
		[Test]
		public void TestRunOnInvalidPsxContext()
		{
			lane.PsxConnections.Clear();
			lane.PsxConnections.Add(new P("localhost", "FastLaneRemoteServer", "AUTOMATION", 10));
			Assert.That(() => click.Run(),
                Throws.TypeOf<PsxOutOfContextException>());
		}
		
		[Test]
		public void TestRunOnControlNotVisibleWithException()
		{
			lane.PsxConnections.Clear();
			lane.PsxConnections.Add(new VF("localhost", "FastLaneRemoteServer", "AUTOMATION", 10));
			Assert.That(() => click.Run(),
                Throws.TypeOf<PsxControlNotFoundException>());
		}
		
//		[Test]
		//Deprecated in NUnit 3 
		//[ExpectedException(typeof(PsxOutOfContextException))]
//		public void TestRunOnInvalidPsxContextOnLaneStopped()
//		{
//			lane.PsxConnections.Clear();
//			lane.PsxConnections.Add(new P("localhost", "FastLaneRemoteServer", "AUTOMATION", 10));
//
//			ThreadHelper.Attach(new T(lane));
//			click.Run();
//		}
//
		[Test]
		public void TestRunOnButtonList()
		{
			lane.PsxConnections.Clear();
			lane.PsxConnections.Add(new Q("localhost", "FastLaneRemoteServer", "AUTOMATION", 10));
			
			click.Run();
		}
		
		[Test]
		public void TestRunOnButtonListWithException()
		{
			lane.PsxConnections.Clear();
			lane.PsxConnections.Add(new QE("localhost", "FastLaneRemoteServer", "AUTOMATION", 10));
			Assert.That(()=> click.Run(),
                Throws.TypeOf<PsxControlNotFoundException>());
		}
		
		[Test]
		public void TestRunOnGrid()
		{
			lane.PsxConnections.Clear();
			lane.PsxConnections.Add(new R("localhost", "FastLaneRemoteServer", "AUTOMATION", 10));
			
			click = new PsxClick(hook, new PsxEvent("1", "MultiSelectProduceFavorites", "ProductImage", "Click", "4388@@Oranges+ Valencia Florida Lg@@False@@Favorites", "", 0), lane, 10, true);
			click.Run();
		}
		
		[Test]
		public void TestRunOnGridWithException()
		{
			lane.PsxConnections.Clear();
			lane.PsxConnections.Add(new RE("localhost", "FastLaneRemoteServer", "AUTOMATION", 10));
			Assert.That(() => click.Run(),
                Throws.TypeOf<PsxControlNotFoundException>());
		}
		
		[Test]
		public void TestRunOnReceipt()
		{
			lane.PsxConnections.Clear();
			lane.PsxConnections.Add(new S("localhost", "FastLaneRemoteServer", "AUTOMATION", 10));
			
			click.Run();
		}
		
		[Test]
		public void TestRunOnGetElseWithException()
		{
			lane.PsxConnections.Clear();
			lane.PsxConnections.Add(new CF("localhost", "FastLaneRemoteServer", "AUTOMATION", 10));
			Assert.That(() => click.Run(),
                Throws.TypeOf<PsxControlNotClickableException>());
		}

		void HasRapConnectionAdding(object sender, PsxWrapperEventArgs e)
		{
			lane.PsxConnections.Add(new PsxStub("g2lane-ian", "FastLaneRemoteServer", "RAP.g2lane-ian", 10));
		}
		
		class T : ThreadManagerStub
		{
			SscatLane lane;
			
			public T(SscatLane lane)
			{
				this.lane = lane;
			}
			
			public override void Sleep(int time)
			{
				lane.Stop();
			}
		}
		
		class S : PsxStub
		{
			public S(string host, string service, string connection, int timeout) : base(host, service, connection, timeout)
			{
			}
			
			public override object GetControlProperty(string controlName, string propertyName)
			{
				return "Receipt";
			}
		}
		
		class R : PsxStub
		{
			public R(string host, string service, string connection, int timeout) : base(host, service, connection, timeout)
			{
			}
			
			public override object GetControlProperty(string controlName, string propertyName)
			{
				if (propertyName == "ControlType") {
					return "Grid";
				} else if (propertyName == "Data") {
					return "4388@@Oranges+ Valencia Florida Lg@@False@@Favorites";
				} else {
					return string.Format("{0},{1},{2},{3}", 0, 0, 0, 0);
				}
			}
		}
		
		class RE : PsxStub
		{
			public RE(string host, string service, string connection, int timeout) : base(host, service, connection, timeout)
			{
			}
			
			public override object GetControlProperty(string controlName, string propertyName)
			{
				return "Grid";
			}
		}
		
		class Q : PsxStub
		{
			public Q(string host, string service, string connection, int timeout) : base(host, service, connection, timeout)
			{
			}
			
			public override object GetControlProperty(string controlName, string propertyName)
			{
				return "ButtonList";
			}
			
			public override object SendControlCommand(string controlName, string command)
			{
				return new object[] { "" };
			}
		}
		
		class QE : PsxStub
		{
			public QE(string host, string service, string connection, int timeout) : base(host, service, connection, timeout)
			{
			}
			
			public override object GetControlProperty(string controlName, string propertyName)
			{
				return "ButtonList";
			}
			
			public override object SendControlCommand(string controlName, string command)
			{
				return new object[] { "Shit" };
			}
		}
		
		class P : PsxStub
		{
			public P(string host, string service, string connection, int timeout) : base(host, service, connection, timeout)
			{
			}
			
			public override bool ContextEquals(string contextName)
			{
				return false;
			}
		}
		
		class VF : PsxStub
		{
			public VF(string host, string service, string connection, int timeout) : base(host, service, connection, timeout)
			{
			}
			
			public override bool IsControlVisible(string controlName)
			{
				return false;
			}
		}
		
		class CF : PsxStub
		{
			public CF(string host, string service, string connection, int timeout) : base(host, service, connection, timeout)
			{
			}
			
			public override bool IsClickable(string controlName)
			{
				return false;
			}
		}
	}
}
