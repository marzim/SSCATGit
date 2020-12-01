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
	public class ResponseTests
	{
//		Response xml;
		Response r;
		
		[SetUp]
		public void Setup()
		{
//			r = new Response("INVINCIBLE", "Chuck Norris");
			r = new Response("INVINCIBLE", new MessageContent("Chuck Norris"));
			r.Client = "192.168.0.1";
			
//			xml = Response.Deserialize(new StringReader(@"<Response Type='MESSAGE'>
//	<Content>Hello, World</Content>
//	<Notes/>
//</Response>"));
		}
		
		[Test]
		public void TestValues()
		{
			Assert.AreEqual("Chuck Norris", (r.Content as MessageContent).Message);
			Assert.AreEqual("192.168.0.1", r.Client);
			
//			Assert.AreEqual("Hello, World", xml.Content);
//			Assert.AreEqual("", xml.Notes);
//			Assert.IsNull(xml.Client);
		}
		
		[Test]
		public void TestValidate()
		{
			Response r = new Response();
			r.Validate();
			Assert.IsTrue(r.HasErrors);
		}
	}
}
