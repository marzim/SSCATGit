//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Net;
using NUnit.Framework;
using Sscat.Core.Net;

namespace Sscat.Tests.Net
{
	[TestFixture]
	public class ErrorResponseDispatcherTests
	{
		ErrorResponseDispatcher dispatcher;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			dispatcher = new ErrorResponseDispatcher();
		}
		
		[Test]
		public void TestDispatch()
		{
            //			Response r = Response.Deserialize(new StringReader(@"<Response>
            //	<Content>hello world</Content>
            //</Response>"));
            Response r = new Response("", new MessageContent("hello world"));
			dispatcher.Dispatch(r);
		}
	}
}
