//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Net;
using NUnit.Framework;

namespace Ncr.Core.Tests.Net
{
	[TestFixture]
	public class RequestDispatcherTests
	{
		RequestDispatcher d;
		
		[SetUp]
		public void Setup()
		{
			d = new RequestDispatcher("HELLO");
			d.Dispatching += new EventHandler<NcrEventArgs>(DispatcherDispatching);
			d.Dispatched += new EventHandler<ResponseEventArgs>(DispatcherDispatched);
		}
		
		[TearDown]
		public void Teardown()
		{
			d.Dispatching -= new EventHandler<NcrEventArgs>(DispatcherDispatching);
			d.Dispatched -= new EventHandler<ResponseEventArgs>(DispatcherDispatched);
		}
		
		[Test]
		public void TestValues()
		{
			Request r = new Request();
			d.Dispatch(r);
			Assert.AreEqual(r, d.Request);
		}

		void DispatcherDispatched(object sender, ResponseEventArgs e)
		{
		}

		void DispatcherDispatching(object sender, NcrEventArgs e)
		{
		}
	}
}
