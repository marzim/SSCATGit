//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Finger;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Core.Services;
using Sscat.Tests.Config;

namespace Sscat.Tests.Parsers
{
	[TestFixture]
	public class SMParserTests
	{
		IExtendedTextReader log;
		IParser parserEmpty;
		IParser parser;
		
		[SetUp]
		public void SetUp()
		{
            //			log = new ExtendedStringReader(@"SM: 07/12 10:17:11    85,258,645 0A80> m_wLastWeight:  0
            //SM: 08/17 16:33:27    10,390,660 0A80> Sending message:  Zero Wt
            //SM: 08/17 16:33:27    10,390,660 0F2C> lCurrentTotalWeight=0");
            //
			            log = new ExtendedStringReader(@"SM: 07/12 10:17:11    85,258,645 0A80> m_wLastWeight:  0
            SM: 08/17 16:33:27    10,390,660 0F2C> lCurrentTotalWeight=0
            SM: 08/16 14:21:11   942,990,458 1310> Sending message:  Zero Wt
	            Message    = Zero Wt
                Action    = ResetTransaction
            SM: 05/14 16:24:50    13,273,046 05F8> Sending message:  Zero Wt
            SM: 05/14 16:24:50    13,273,046 05F8> Message complete:  Transaction Expired
                Action    = ResetTransaction");
			
			LaneConfiguration config = new LaneConfigurationRepositoryStub().Read("");
			parserEmpty = config.Parsers.GetParser("SM").Instantiate();
			parser = config.Parsers.GetParser("SM").Instantiate(log);
		}
		
		[Test]
		public void TestParseWithoutReaderParameter()
		{
			Assert.AreEqual(3, parser.PerformParse().Count);
		}
		
		[Test]
		public void TestParse()
		{
			List<IScriptEvent> events = parserEmpty.PerformParse(log);
			Assert.AreEqual(3, events.Count);
			FingerScriptEvent evnt = events[0] as FingerScriptEvent;
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(new FingerDeviceEvent().GetType(), evnt.Item);
			FingerDeviceEvent item = evnt.Item as FingerDeviceEvent;
			Assert.AreEqual("BagScale", item.Id);
			Assert.AreEqual("0", item.Value);
		}
		
		[Test]
		public void TestParseNullLinesOnBagScaleEventAdder()
		{
			log = new ExtendedStringReader(@"SM: 08/16 14:21:11   942,990,458 1310> Sending message:  Zero Wt");
			List<IScriptEvent> events = parserEmpty.PerformParse(log);
			Assert.AreEqual(0, events.Count);
		}
	}
}
