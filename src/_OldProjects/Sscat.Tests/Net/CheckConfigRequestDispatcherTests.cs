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
	public class CheckConfigRequestDispatcherTests
	{
		CheckConfigRequestDispatcher dispatcher;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			dispatcher = new CheckConfigRequestDispatcher(new ConfigFileRepositoryStub());
		}
		
		[Test]
        //[Ignore()]
		public void TestDispatchConfigFileExistence()
		{
			dispatcher.Dispatched += delegate(object sender, ResponseEventArgs e) { 
                //ConfigFile f = ConfigFile.Deserialize(new StringReader(e.Response.Content));
				ConfigFile f = e.Response.Content as ConfigFile;
				Assert.IsTrue(f.DifferentFromScotConfig);
			};
            //Request r = Request.Deserialize(new StringReader(@"<Request>
            //	<Content>
            //<![CDATA[
            //<File Name='test.xml' Destination='C:\scot\config'/>
            //]]>
            //	</Content>
            //</Request>"));
            ConfigFile c = new ConfigFile("test.xml", "");
            c.Destination = @"C:\scot\config";
            Request r = new Request("", c);
			dispatcher.Dispatch(r);
		}
		
		[Test]
        //[Ignore()]
		public void TestDispatchConfigFileDiffersContent()
		{
			dispatcher.Dispatched += delegate(object sender, ResponseEventArgs e) { 
            //ConfigFile f = ConfigFile.Deserialize(new StringReader(e.Response.Content));
				ConfigFile f = e.Response.Content as ConfigFile;
				Assert.IsTrue(f.DifferentFromScotConfig);
			};
            //Request r = Request.Deserialize(new StringReader(@"<Request>
            //	<Content>
            //<![CDATA[
            //<File Name='test.xml' Exists='true' Destination='C:\scot\config'>hello worldx</File>
            //]]>
            //	</Content>
            //</Request>"));
            ConfigFile c = new ConfigFile("test.xml", "");
            c.Exists = true;
            c.Destination = @"C:\scot\config";
            c.Content = "hello world";
            Request r = new Request("", c);
			dispatcher.Dispatch(r);
		}
		
		[Test]
        //[Ignore()]
		public void TestDispatchConfigFileSameContent()
		{
			dispatcher.Dispatched += delegate(object sender, ResponseEventArgs e) { 
                //ConfigFile f = ConfigFile.Deserialize(new StringReader(e.Response.Content));
				ConfigFile f = e.Response.Content as ConfigFile;
				Assert.IsFalse(f.DifferentFromScotConfig);
			};
            //Request r = Request.Deserialize(new StringReader(@"<Request>
            //	<Content>
            //<![CDATA[
            //<File Name='test.xml' Exists='true' DifferentFromScotConfig='true' Destination='C:\scot\config'>hello world</File>
            //]]>
            //	</Content>
            //</Request>"));
            ConfigFile c = new ConfigFile("test.xml", "");
            c.Exists = true;
            c.DifferentFromScotConfig = true;
            c.Destination = @"C:\scot\config";
            c.Content = "hello world";
            Request r = new Request("", c);
			dispatcher.Dispatch(r);
		}
		
		[Test]
        //[Ignore()]
		public void TestDispatchConfigFileNotExistsInDestinationDirectory()
		{
			dispatcher.Dispatched += delegate(object sender, ResponseEventArgs e) { 
                //ConfigFile f = ConfigFile.Deserialize(new StringReader(e.Response.Content));
				ConfigFile f = e.Response.Content as ConfigFile;
				Assert.IsTrue(f.DifferentFromScotConfig);
			};
            //Request r = Request.Deserialize(new StringReader(@"<Request>
            //	<Content>
            //<![CDATA[
            //<File Name='notexists.xml' Exists='true' Destination='C:\scot\config'/>
            //]]>
            //	</Content>
            //</Request>"));
            ConfigFile c = new ConfigFile("notexists.xml", "");
            c.Exists = true;
            c.Destination = @"C:\scot\config";
            Request r = new Request("", c);
			dispatcher.Dispatch(r);
		}
		
		[Test]
        //[Ignore()]
		public void TestDispatchOnError()
		{
            //Request r = Request.Deserialize(new StringReader(@"<Request>
            //	<Content/>
            //</Request>"));
            Request r = new Request("", new MessageContent(""));
			dispatcher.Dispatch(r);
		}
		
		[Test]
        //[Ignore()]
		public void TestDispatchNonExistentConfigFile()
		{
			dispatcher.Dispatched += delegate(object sender, ResponseEventArgs e) { 
                //ConfigFile f = ConfigFile.Deserialize(new StringReader(e.Response.Content));
				ConfigFile f = e.Response.Content as ConfigFile;
				Assert.IsFalse(f.DifferentFromScotConfig);
			};
            //Request r = Request.Deserialize(new StringReader(@"<Request>
            //	<Content>
            //<![CDATA[
            //<File Name='notexists.xml' Exists='false' Destination='C:\scot\config'/>
            //]]>
            //	</Content>
            //</Request>"));
            ConfigFile c = new ConfigFile("notexists.xml", "");
            c.Exists = false;
            c.Destination = @"C:\scot\config";
            Request r = new Request("", c);
			dispatcher.Dispatch(r);
		}
	}
}
