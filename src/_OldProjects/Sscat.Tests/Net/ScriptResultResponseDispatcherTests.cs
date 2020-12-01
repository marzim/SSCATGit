//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Net;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Models;
using Sscat.Core.Net;

namespace Sscat.Tests.Net
{
	[TestFixture]
	public class ScriptResultResponseDispatcherTests
	{
		ScriptResultResponseDispatcher dispatcher;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			dispatcher = new ScriptResultResponseDispatcher();
		}
		
		[Test]
//		[Ignore()]
		public void TestDispatch()
		{
            //Response r = Response.Deserialize(new StringReader(@"<Response>
            //	<Content>
            //<![CDATA[
            //<FingerScript Name=''>
            //	<Result>
            //	</Result>
            //</FingerScript>
            //]]>
            //	</Content>
            //</Response>"));
            FingerScript s = new FingerScript();
            s.Result = new Result();
			Response r = new Response("", s);
			dispatcher.Dispatch(r);
		}
	}
}
