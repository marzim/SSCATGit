//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Net;
using NUnit.Framework;

namespace Ncr.Core.Tests.Net
{
	public class TestResponseDispatcher : ResponseDispatcher
	{
		public TestResponseDispatcher(string name) : base(name)
		{
		}
		
		public override void Dispatch(Response response)
		{
			base.Dispatch(response);
			OnDispatching("test...");
			OnErrorDispatched(null);
		}
	}
}
