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

namespace Sscat.Tests.Net
{
	[TestFixture]
	public class ConfigResponseDispatcherTests
	{
		ConfigResponseDispatcher dispatcher;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			dispatcher = new ConfigResponseDispatcher();
		}
		
		[Test]
		public void TestDispatch()
		{
            //			Response r = Response.Deserialize(new StringReader(@"<Response>
            //	<Content>
            //<![CDATA[
            //<Files>
            //	<File Name='test.xml'/>
            //</Files>
            //]]>
            //	</Content>
            //</Response>"));
            ConfigFiles c = new ConfigFiles();
            c.AddFile(new ConfigFile("test.xml"));
            Response r = new Response("", c);
			dispatcher.Dispatch(r);
		}
	}
}
