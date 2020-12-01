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
	public class PlayerStoppedResponseDispatcherTests
	{
		PlayerStoppedResponseDispatcher dispatcher;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			dispatcher = new PlayerStoppedResponseDispatcher();
		}
		
		[Test]
//		[Ignore()]
		public void TestDispatch()
		{
//			Response r = Response.Deserialize(new StringReader(@"<Response/>"));
			Response r = new Response();
			dispatcher.Dispatch(r);
		}
	}
}
