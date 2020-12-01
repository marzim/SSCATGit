//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Emulators;
using Sscat.Core.Finger;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Tests.Config;

namespace Sscat.Tests.Log
{
	[TestFixture]
	public class HookerTests
	{
		IScotLogHook hook;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ThreadHelper.Attach(new ThreadManagerStub());
			SscatLane lane = new SscatLane();
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			lane.Hooks = lane.Configuration.GetHooks();
			hook = lane.Hooks["Psx"];
			hook.PerformChanged();
		}
		
		[Test]
		[Ignore("Parser can't find it because log hook text from XML file is treated as one line only so only one event is parsed.")]
		public void TestCheck()
		{
			IScriptEvent evnt = FingerScriptEvent.Deserialize(new StringReader(@"<FingerEventData>
              <enable>true</enable>
              <eventTimeMS>942962708</eventTimeMS>
              <eventType>PsxEventData</eventType>
              <PsxEventData>
                <contextName>Attract</contextName>
                <controlName>Display</controlName>
                <eventName>ChangeContext</eventName>
                <param />
                <psxId>1</psxId>
                <remoteConnectionName />
                <seqId>1</seqId>
              </PsxEventData>
            </FingerEventData>"));
			IScriptEvent lastSimilarEvent = null;
			Assert.IsTrue(hook.Exists(evnt, out lastSimilarEvent, 200));
		}
	}
}
