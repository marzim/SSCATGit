//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Net;
using NUnit.Framework;

namespace Ncr.Core.Tests.Net
{
	public class HelloRequestDispatcher : RequestDispatcher
	{
		public HelloRequestDispatcher() : base("HELLO")
		{
		}
		
		public override void Dispatch(Request request)
		{
			OnDispatching(string.Format("Hello, {0}...", request.Content));
//			OnDispatched(request.CreateResponse("HELLO", string.Format("Hello, {0}...", request.Content)));
			OnDispatched(request.CreateResponse("HELLO", new MessageContent(string.Format("Hello, {0}...", request.Content))));
		}
	}
}
