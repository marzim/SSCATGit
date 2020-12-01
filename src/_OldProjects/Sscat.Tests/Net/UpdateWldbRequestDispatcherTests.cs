//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Net;
using NUnit.Framework;
using Sscat.Core.Net;

namespace Sscat.Tests.Net
{
	[TestFixture]
	public class UpdateWldbRequestDispatcherTests
	{
		UpdateWldbRequestDispatcher d;
		
		[SetUp]
		public void Setup()
		{
			d = new UpdateWldbRequestDispatcher();
		}
		
		[Test]
		public void TestDispatch()
		{
			d.Dispatch(new Request());
		}
	}
}
