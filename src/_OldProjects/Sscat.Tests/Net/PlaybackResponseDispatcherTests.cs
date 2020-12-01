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
using Sscat.Tests.Models;

namespace Sscat.Tests.Net
{
	[TestFixture]
	public class PlaybackResponseDispatcherTests
	{
		ReportResponseDispatcher dispatcher;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			dispatcher = new ReportResponseDispatcher(new ReportRepositoryStub());
		}
		
		[Test]
		public void TestDispatch()
		{
            //Response r = Response.Deserialize(new StringReader(@"<Response>
            //  	<Content>
            //  <![CDATA[
            //  <Report/>
            //  ]]>
            //  	</Content>
            //  </Response>"));
            Response r = new Response("", new Report());
			dispatcher.Dispatch(r);
		}
	}
}
