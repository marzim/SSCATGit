//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Net;
using NUnit.Framework;
using Sscat.Core.Net;
using Sscat.Core.Net.Dispatchers.Response;

namespace Sscat.Tests.Net
{
	[TestFixture]
	public class StopResponseDispatcherTests
	{
		StopResponseDispatcher dispatcher;

		[SetUp]
		public void Setup()
		{
			dispatcher = new StopResponseDispatcher();
		}
		
		[Test]
		public void TestDispatch()
		{
			dispatcher.Dispatch(new Response());
		}
	}
}