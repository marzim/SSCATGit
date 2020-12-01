//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Net;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Net;
using Sscat.Tests.Config;
using Sscat.Tests.Repositories;

namespace Sscat.Tests.Net
{
	[TestFixture]
	public class GetConfigRequestDispatcherTests
	{
		GetConfigRequestDispatcher dispatcher;
		
		[SetUp]
		public void Setup()
		{
		}
		
		[Test]
//		[Ignore()]
		public void TestDispatch()
		{
			dispatcher = new GetConfigRequestDispatcher(new ConfigFileRepositoryStub());
//			Request r = Request.Deserialize(new StringReader(@"<Request>
//	<Content>
//<![CDATA[
//<Files>
//	<File Name='test.xml'/>
//</Files>
//]]>
//	</Content>
//</Request>"));
ConfigFiles c = new ConfigFiles();
c.AddFile(new ConfigFile("test.xml"));
Request r = new Request("", c);
			dispatcher.Dispatch(r);
		}
		
		[Test]
		public void TestDispatchWithError()
		{
			dispatcher = new GetConfigRequestDispatcher(null);
            //			Request r = Request.Deserialize(new StringReader(@"<Request>
            //	<Content>
            //<![CDATA[
            //<Files>
            //	<File Name='test.xml'/>
            //</Files>
            //]]>
            //	</Content>
            //</Request>"));
            ConfigFiles c = new ConfigFiles();
            c.AddFile(new ConfigFile("test.xml"));
            Request r = new Request("", c);
			Assert.That(()=> dispatcher.Dispatch(r), Throws.TypeOf<NullReferenceException>());
		}
	}
}
