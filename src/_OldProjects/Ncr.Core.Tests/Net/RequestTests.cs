//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Net;
using NUnit.Framework;

namespace Ncr.Core.Tests.Net
{
	[TestFixture]
	public class RequestTests
	{
//		Request xml;
		Request r;
		
		[SetUp]
		public void Setup()
		{
//			r = new Request("INVINCIBLE", "Chuck Norris");
			r = new Request("INVINCIBLE", new MessageContent("Chuck Norris"));
//			xml = Request.Deserialize(new StringReader(@"<Request Type='HELLO' Client='192.168.0.1'>
//	<Content>Hello, World</Content>
//</Request>"));
		}
		
		[Test]
		public void TestValues()
		{
			Assert.AreEqual("Chuck Norris", (r.Content as MessageContent).Message);
			
//			Assert.AreEqual("192.168.0.1", xml.Client);
//			Assert.AreEqual("Hello, World", xml.Content);
//			Assert.AreEqual("HELLO", xml.Type);
		}
		
		//[Test]
        //TODO: Either remove or fix empty test
		public void TestCreateResponse()
		{
//			Response e = xml.CreateResponse("HELLO", "Hello, Chuck Norris");
//			Response e = xml.CreateResponse("HELLO", new MessageContent("Hello, Chuck Norris"));
//			Assert.AreEqual("HELLO", xml.Type);
		}
	}
}
