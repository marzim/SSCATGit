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
	public class ResponseDispatcherTests
	{
		TestResponseDispatcher d;
		
		[SetUp]
		public void Setup()
		{
			d = new TestResponseDispatcher("MESSAGE");
			d.Dispatching += new EventHandler<NcrEventArgs>(DispatcherDispatching);
			d.ErrorDispatched += new EventHandler(DispatcherErrorDispatched);
		}
		
		[TearDown]
		public void Teardown()
		{
			d.Dispatching -= new EventHandler<NcrEventArgs>(DispatcherDispatching);
			d.ErrorDispatched -= new EventHandler(DispatcherErrorDispatched);
		}
		
		[Test]
		public void TestValues()
		{
			Assert.AreEqual("MESSAGE", d.Name);
		}
		
		[Test]
		public void TestDispatch()
		{
			d.Dispatch(new Response());
		}

		void DispatcherErrorDispatched(object sender, EventArgs e)
		{
		}

		void DispatcherDispatching(object sender, NcrEventArgs e)
		{
		}
	}
}
