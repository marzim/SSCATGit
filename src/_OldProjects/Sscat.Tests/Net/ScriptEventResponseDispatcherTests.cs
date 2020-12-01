//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Net;
using NUnit.Framework;
using Sscat.Core.Models;
using Sscat.Core.Net;

namespace Sscat.Tests.Net
{
	[TestFixture]
	public class ScriptEventResponseDispatcherTests
	{
		ScriptEventResponseDispatcher d;
		
		[SetUp]
		public void Setup()
		{
			d = new ScriptEventResponseDispatcher();
		}
		
		[Test]
//		[Ignore()]
		public void TestDispatch()
		{
//			Response r = Response.Deserialize(new StringReader(@"<Response>
//	<Content>
//<![CDATA[
//<Event/>
//]]>
//	</Content>
//</Response>"));
			Response r = new Response("", new ScriptEvent());
			d.Dispatch(r);
		}
	}
}
