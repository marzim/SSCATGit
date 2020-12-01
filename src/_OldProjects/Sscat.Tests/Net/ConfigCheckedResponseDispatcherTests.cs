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
	public class ConfigCheckedResponseDispatcherTests
	{
		ConfigCheckedResponseDispatcher d;

        [OneTimeSetUp]
        public void OneTimeSetUp()
		{
			d = new ConfigCheckedResponseDispatcher();
			d.ConfigCheckedDispatched += new EventHandler<ConfigFileEventArgs>(DispatcherConfigCheckedDispatched);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			d.ConfigCheckedDispatched -= new EventHandler<ConfigFileEventArgs>(DispatcherConfigCheckedDispatched);
		}
		
		[Test]
        //[Ignore()]
		public void TestDispatch()
		{
            //Response r = Response.Deserialize(new StringReader(@"<Response>
            //	<Content>
            //<![CDATA[
            //<File Name='test.xml'/>
            //]]>
            //	</Content>
            //</Response>"));
            ConfigFile c = new ConfigFile("test.xml");
            Response r = new Response("", c);
			d.Dispatch(r);
		}

		void DispatcherConfigCheckedDispatched(object sender, ConfigFileEventArgs e)
		{
		}
	}
}
