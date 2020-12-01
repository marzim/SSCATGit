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
	public class ConfigLoadedResponseDispatcherTests
	{
		ConfigLoadedResponseDispatcher dispatcher;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			dispatcher = new ConfigLoadedResponseDispatcher();
		}
		
		[Test]
//		[Ignore()]
		public void TestDispatch()
		{
//			Response r = Response.Deserialize(new StringReader(@"<Response/>"));
			Response r = new Response("", new MessageContent(""));
			dispatcher.Dispatch(r);
		}
	}
}
